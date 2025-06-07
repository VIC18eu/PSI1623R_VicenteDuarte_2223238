using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace ProjetoFinal
{
    public partial class AdicionarVenda : MaterialForm
    {
        private List<Stock> listaDeMedicamentos = new List<Stock>();

        public AdicionarVenda()
        {
            InitializeComponent();
            Theme.AplicarTema(this, Theme.TemaAtual);
            CarregarMedicamentos();
        }

        private void CarregarMedicamentos()
        {
            using (var context = new Entities())
            {
                listaDeMedicamentos = context.Stock
                    .Include(s => s.Medicamento)
                    .Where(m => m.FarmaciaId == Contas.Farmacia && m.Quantidade > 0)
                    .ToList();
            }

            CarregarMedicamentosNoComboBox();
        }


        private void CarregarMedicamentosNoComboBox()
        {
            try
            {

                cmbMedicamento.Items.Clear();

                foreach (var medicamento in listaDeMedicamentos)
                {
                    cmbMedicamento.Items.Add(medicamento.Medicamento.Nome);
                }

                if (cmbMedicamento.Items.Count > 0)
                {
                    cmbMedicamento.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os medicamentos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Lista para armazenar os produtos da venda (globais)
        private List<VendaProduto> produtosSelecionados = new List<VendaProduto>();

        private void BtnAdicionarProduto_Click(object sender, EventArgs e)
        {
            if (cmbMedicamento.SelectedItem == null)
            {
                MessageBox.Show("Selecione um medicamento.");
                return;
            }

            if (!int.TryParse(txtQuantidade.Text.Trim(), out int quantidade) || quantidade <= 0)
            {
                MessageBox.Show("Quantidade inválida.");
                return;
            }

            Stock stockSelecionado = listaDeMedicamentos[cmbMedicamento.SelectedIndex];

            if (quantidade > stockSelecionado.Quantidade)
            {
                MessageBox.Show("Quantidade solicitada excede o stock disponível.");
                return;
            }

            // Verifica se já existe na lista
            var produtoExistente = produtosSelecionados.FirstOrDefault(p => p.MedicamentoId == stockSelecionado.MedicamentoId);

            if (produtoExistente != null)
            {
                // Atualiza a quantidade no produto já existente
                int novaQuantidade = produtoExistente.Quantidade + quantidade;

                if (novaQuantidade > stockSelecionado.Quantidade)
                {
                    MessageBox.Show("Quantidade total excede o stock disponível.");
                    return;
                }

                produtoExistente.Quantidade = novaQuantidade;
            }
            else
            {
                // Cria um novo objeto VendaProduto e adiciona à lista
                produtosSelecionados.Add(new VendaProduto
                {
                    MedicamentoId = stockSelecionado.MedicamentoId,
                    PrecoUnitario = stockSelecionado.Preco,  // Presumo que tens essa propriedade
                    Quantidade = quantidade
                });
            }

            // Atualiza a listProdutos para mostrar os produtos atuais com quantidades
            AtualizarListProdutos();

            // Limpa os campos
            txtQuantidade.Text = "";
            cmbMedicamento.SelectedIndex = -1;
        }

        private void AtualizarListProdutos()
        {
            listProdutos.Items.Clear();

            foreach (var produto in produtosSelecionados)
            {
                var stock = listaDeMedicamentos.FirstOrDefault(s => s.MedicamentoId == produto.MedicamentoId);
                if (stock != null)
                {
                    listProdutos.Items.Add($"{stock.Medicamento.Nome} | Quantidade: {produto.Quantidade}");
                }
            }
        }


        private void BtnRemoverProduto_Click(object sender, EventArgs e)
        {
            if (listProdutos.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um produto para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obter o nome do medicamento a partir do item selecionado
            string itemSelecionado = listProdutos.SelectedItem.ToString();
            string nomeMedicamento = itemSelecionado.Split('|')[0].Trim(); // antes do "|"

            // Encontrar o stock correspondente
            var stock = listaDeMedicamentos.FirstOrDefault(s => s.Medicamento.Nome == nomeMedicamento);

            if (stock != null)
            {
                // Remover da lista de produtos selecionados
                produtosSelecionados.RemoveAll(p => p.MedicamentoId == stock.MedicamentoId);

                // Atualizar lista visual
                AtualizarListProdutos();
            }
        }


        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbTipoVenda.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, selecione o tipo de venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nomeCliente = txtCliente.Text.Trim();
            if (string.IsNullOrEmpty(nomeCliente))
            {
                MessageBox.Show("Por favor, introduza o nome do cliente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(nomeCliente, @"^[A-Za-zÀ-ÿ\s]+$"))
            {
                MessageBox.Show("O nome do cliente só pode conter letras e espaços.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (produtosSelecionados == null || produtosSelecionados.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos um produto à venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new Entities())
                {
                    var novaVenda = new Venda
                    {
                        DataVenda = DateTime.Now,
                        Tipo = cmbTipoVenda.SelectedItem.ToString(),
                        Cliente = nomeCliente,
                        VendaProduto = new List<VendaProduto>(),
                        FarmaciaId = Contas.Farmacia,
                        ValorTotal = produtosSelecionados.Sum(p => p.PrecoUnitario * p.Quantidade)
                    };

                    // Adiciona os produtos à venda
                    foreach (var produto in produtosSelecionados)
                    {
                        var produtoVenda = new VendaProduto
                        {
                            MedicamentoId = produto.MedicamentoId,
                            PrecoUnitario = produto.PrecoUnitario,
                            Quantidade = produto.Quantidade,
                            Subtotal = produto.PrecoUnitario * produto.Quantidade
                        };

                        novaVenda.VendaProduto.Add(produtoVenda);
                    }

                    context.Venda.Add(novaVenda);
                    context.SaveChanges();
                }


                MessageBox.Show("Venda guardada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmbTipoVenda.SelectedIndex = -1;
                txtCliente.Text = "";
                produtosSelecionados.Clear();
                listProdutos.Items.Clear();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao guardar na base de dados:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }



}
