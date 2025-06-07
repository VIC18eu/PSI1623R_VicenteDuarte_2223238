using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace ProjetoFinal
{
    public partial class DetalhesVenda : MaterialForm
    {
        private int vendaId;

        public DetalhesVenda(int id)
        {
            vendaId = id;
            InitializeComponent();
            CarregarDetalhesVenda();

            Theme.AplicarTema(this, ConfigManager.Configuracoes.ModoEscuro);
        }

        private void CarregarDetalhesVenda()
        {
            using (var context = new Entities())
            {
                var venda = context.Venda.FirstOrDefault(v => v.Id == vendaId);

                if (venda != null)
                {
                    lblId.Text = $"ID: {venda.Id}";
                    lblCliente.Text = $"Cliente: {venda.Cliente}";
                    lblTipo.Text = $"Tipo: {venda.Tipo}";
                    lblData.Text = $"Data: {venda.DataVenda}";
                    lblTotal.Text = $"Total: {venda.ValorTotal:C}";

                    foreach (var vp in venda.VendaProduto)
                    {
                        listBoxProdutos.Items.Add($"{vp.Medicamento.Nome} - {vp.Quantidade} x {vp.PrecoUnitario:C} = {vp.Subtotal:C}");
                    }
                }
            }
        }
    }

}
