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

            Theme.AplicarTema(this, ConfigManager.Configuracoes.ModoEscuro);
            CarregarDetalhesreserva();
        }

        private void CarregarDetalhesreserva()
        {
            using (var context = new Entities())
            {
                var reserva = context.Reserva
                    .Include("ReservaProduto.Stock.Medicamento")
                    .FirstOrDefault(v => v.Id == reservaId);

                if (reserva != null)
                {
                    lblId.Text = $"ID: {reserva.Id}";
                    lblId.Font = new System.Drawing.Font("Roboto", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
                    lblCliente.Text = $"Cliente: {reserva.NomeCliente}";
                    lblEstado.Text = $"Estado: {reserva.Estado}";
                    lblEstado.ForeColor = reserva.Estado == "Cancelado" ? Color.Red : reserva.Estado == "Confirmado" ? Color.DarkSeaGreen : Color.DarkOrange;
                    lblData.Text = $"{reserva.DataReserva}";
                    lblTotal.Text = $"Total: {reserva.ReservaProduto.Sum(r => r.Quantidade * r.Stock.Preco):C}";

                    listBoxProdutos.Items.Clear();
                    foreach (var rp in reserva.ReservaProduto)
                    {
                        listBoxProdutos.Items.Add($"{rp.Stock.Medicamento.Nome} - {rp.Quantidade} x {rp.Stock.Preco:C} = {rp.Quantidade * rp.Stock.Preco:C}");
                    }

                    // Lógica para mostrar ou esconder botões com base no estado
                    bool mostrarBotoes = reserva.Estado.ToLower() == "pendente";

                    btnCancelar.Visible = mostrarBotoes;
                    btnConfirmar.Visible = mostrarBotoes;
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Tem a certeza que deseja confirmar esta reserva como venda?",
                                             "Confirmar Venda",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                using (var context = new Entities())
                {
                    var reserva = context.Reserva.FirstOrDefault(r => r.Id == reservaId);

                    if (reserva != null)
                    {
                        // Calcular o total
                        decimal total = reserva.ReservaProduto
                            .Sum(rp => rp.Quantidade * rp.Stock.Preco);

                        // Criar venda
                        var novaVenda = new Venda
                        {
                            DataVenda = DateTime.Now,
                            Tipo = "Encomenda",
                            ValorTotal = total,
                            Cliente = reserva.NomeCliente,
                            FarmaciaId = reserva.FarmaciaId // Certifica-te que esse campo existe
                        };

                        context.Venda.Add(novaVenda);
                        context.SaveChanges(); // Necessário para obter o ID da venda

                        // Adicionar os produtos vendidos
                        foreach (var rp in reserva.ReservaProduto)
                        {
                            var vendaProduto = new VendaProduto
                            {
                                VendaId = novaVenda.Id,
                                MedicamentoId = rp.Stock.MedicamentoId,
                                Quantidade = rp.Quantidade,
                                PrecoUnitario = rp.Stock.Preco,
                                Subtotal = rp.Quantidade * rp.Stock.Preco
                            };
                            context.VendaProduto.Add(vendaProduto);
                        }

                        // Atualiza o estado da reserva
                        reserva.Estado = "Confirmado";

                        context.SaveChanges();

                        MessageBox.Show("Venda criada e reserva confirmada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CarregarDetalhesreserva();
                    }
                }
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Tem a certeza que deseja cancelar esta reserva?",
                                             "Cancelar Reserva",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                using (var context = new Entities())
                {
                    var reserva = context.Reserva.FirstOrDefault(r => r.Id == reservaId);

                    if (reserva != null)
                    {
                        // Devolver ao stock
                        foreach (var rp in reserva.ReservaProduto)
                        {
                            var stock = context.Stock.FirstOrDefault(s => s.Id == rp.StockId);
                            if (stock != null)
                            {
                                stock.Quantidade += rp.Quantidade;
                            }
                        }

                        // Atualizar estado
                        reserva.Estado = "Cancelado";

                        context.SaveChanges();

                        MessageBox.Show("Reserva cancelada e stock reposto com sucesso.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregarDetalhesreserva(); // Atualiza o formulário
                    }
                }
            }
        }


    }

}
