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
    public partial class DetalhesReserva : MaterialForm
    {
        private int reservaId;

        public DetalhesReserva(int id)
        {
            reservaId = id;
            InitializeComponent();
            CarregarDetalhesreserva();

            Theme.AplicarTema(this, ConfigManager.Configuracoes.ModoEscuro);
        }

        private void CarregarDetalhesreserva()
        {
            using (var context = new Entities())
            {
                var reserva = context.Reserva.FirstOrDefault(v => v.Id == reservaId);

                if (reserva != null)
                {
                    lblId.Text = $"ID: {reserva.Id}";
                    lblCliente.Text = $"Cliente: {reserva.NomeCliente}";
                    lblEstado.Text = $"Cliente: {reserva.Estado}";
                    lblData.Text = $"Data: {reserva.DataReserva}";
                    lblTotal.Text = $"Total: {reserva.ReservaProduto.Sum(r => r.Quantidade * r.Stock.Preco):C}";

                    foreach (var rp in reserva.ReservaProduto)
                    {
                        listBoxProdutos.Items.Add($"{rp.Stock.Medicamento.Nome} - {rp.Quantidade} x {rp.Stock.Preco:C} = {rp.Quantidade * rp.Stock.Preco:C}");
                    }
                }
            }
        }
    }

}
