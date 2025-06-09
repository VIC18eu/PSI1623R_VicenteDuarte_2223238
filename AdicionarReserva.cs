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
    public partial class AdicionarReserva : MaterialForm
    {
        private List<Stock> listaDeMedicamentos = new List<Stock>();
        private List<ReservaProduto> produtosSelecionados = new List<ReservaProduto>();

        public AdicionarReserva()
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

            var produtoExistente = produtosSelecionados.FirstOrDefault(p => p.StockId == stockSelecionado.Id);

            if (produtoExistente != null)
            {
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
                produtosSelecionados.Add(new ReservaProduto
                {
                    StockId = stockSelecionado.Id,
                    Quantidade = quantidade
                });
            }

            AtualizarListProdutos();
            txtQuantidade.Text = "";
            cmbMedicamento.SelectedIndex = -1;
        }

        private void AtualizarListProdutos()
        {
            listProdutos.Items.Clear();

            foreach (var produto in produtosSelecionados)
            {
                var stock = listaDeMedicamentos.FirstOrDefault(s => s.Id == produto.StockId);
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

            string itemSelecionado = listProdutos.SelectedItem.ToString();
            string nomeMedicamento = itemSelecionado.Split('|')[0].Trim();

            var stock = listaDeMedicamentos.FirstOrDefault(s => s.Medicamento.Nome == nomeMedicamento);

            if (stock != null)
            {
                produtosSelecionados.RemoveAll(p => p.StockId == stock.Id);
                AtualizarListProdutos();
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("Adicione pelo menos um produto à reserva.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DateTime.TryParse(txtDataReserva.Text.Trim(), out DateTime dataReserva))
            {
                MessageBox.Show("Data da reserva inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataReserva.Date < DateTime.Today)
            {
                MessageBox.Show("A data da reserva não pode ser anterior ao dia atual.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new Entities())
                {
                    var novaReserva = new Reserva
                    {
                        NomeCliente = nomeCliente,
                        DataReserva = dataReserva.Date,
                        Estado = "Pendente",
                        FarmaciaId = Contas.Farmacia
                    };

                    context.Reserva.Add(novaReserva);
                    context.SaveChanges(); // Salva a reserva para obter o Id

                    foreach (var produto in produtosSelecionados)
                    {
                        // Cria o objeto ReservaProduto
                        var reservaProduto = new ReservaProduto
                        {
                            ReservaId = novaReserva.Id,
                            StockId = produto.StockId,
                            Quantidade = produto.Quantidade
                        };

                        context.ReservaProduto.Add(reservaProduto);

                        // Reduz a quantidade no stock
                        var stock = context.Stock.FirstOrDefault(s => s.Id == produto.StockId);
                        if (stock != null)
                        {
                            stock.Quantidade -= produto.Quantidade;

                            // Validação extra opcional: evitar stock negativo (defesa contra race condition)
                            if (stock.Quantidade < 0)
                            {
                                throw new InvalidOperationException("O stock ficou negativo. Operação cancelada.");
                            }
                        }
                    }

                    context.SaveChanges(); // Grava alterações nos produtos e stock
                }

                MessageBox.Show("Reserva guardada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtCliente.Text = "";
                txtDataReserva.Text = "";
                produtosSelecionados.Clear();
                listProdutos.Items.Clear();
                cmbMedicamento.SelectedIndex = -1;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao guardar na base de dados:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
