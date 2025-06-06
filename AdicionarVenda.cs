using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public AdicionarVenda()
        {
            InitializeComponent();
            Theme.AplicarTema(this, Theme.TemaAtual);
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

            // Exemplo: objeto selecionado no ComboBox com os medicamentos
            var medicamento = (Stock)cmbMedicamento.SelectedItem;

            // Cria o produto selecionado
            var produto = new ProdutoSelecionado
            {
                MedicamentoId = medicamento.MedicamentoId,
                Nome = medicamento.Medicamento.Nome,
                Preco = medicamento.Preco, // Supondo que tens esta propriedade
                Quantidade = quantidade
            };

            // Adiciona à lista
            listProdutos.Items.Add(produto);

            // Limpa os campos
            txtQuantidade.Text = "";
            cmbMedicamento.SelectedIndex = -1;
        }

        private void BtnRemoverProduto_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validação: Data preenchida
            string dataTexto = txtDataVenda.Text.Trim();
            if (string.IsNullOrEmpty(dataTexto))
            {
                MessageBox.Show("Por favor, introduza a data da venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validação: Formato da data e data não futura
            if (!DateTime.TryParseExact(dataTexto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataVenda))
            {
                MessageBox.Show("A data deve estar no formato DD/MM/AAAA.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataVenda.Date > DateTime.Today)
            {
                MessageBox.Show("A data da venda não pode ser no futuro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validação: Tipo de venda
            if (cmbTipoVenda.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, selecione o tipo de venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validação: Nome do cliente
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

            // Validação: Pelo menos um produto
            if (listProdutos.Items.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos um produto à venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new Entities())
                {
                    // Criar nova venda
                    var novaVenda = new Venda
                    {
                        DataVenda = dataVenda,
                        Tipo = cmbTipoVenda.SelectedItem.ToString(),
                        Cliente = nomeCliente,
                        VendaProduto = new List<VendaProduto>()
                    };

                    // Adicionar produtos à venda
                    foreach (ProdutoSelecionado item in listProdutos.Items)
                    {
                        var produto = new VendaProduto
                        {
                            MedicamentoId = item.MedicamentoId,
                            PrecoUnitario = item.Preco,
                            Quantidade = item.Quantidade,
                            Subtotal = item.Preco * item.Quantidade,
                            // VendaId será preenchido automaticamente pela EF
                        };

                        novaVenda.VendaProduto.Add(produto);
                    }

                    // Guardar na BD
                    context.Venda.Add(novaVenda);
                    context.SaveChanges();
                }

                MessageBox.Show("Venda guardada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpar os campos após guardar
                txtDataVenda.Text = "";
                cmbTipoVenda.SelectedIndex = -1;
                txtCliente.Text = "";
                listProdutos.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao guardar na base de dados:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
    public class ProdutoSelecionado
    {
        public int MedicamentoId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }

        public decimal Subtotal => Preco * Quantidade;

        public override string ToString()
        {
            return $"{Nome} - {Quantidade} x {Preco:C} = {Subtotal:C}";
        }
    }


}
