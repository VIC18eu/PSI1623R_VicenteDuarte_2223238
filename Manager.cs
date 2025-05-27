using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System.Globalization;


namespace ProjetoFinal
{
    public partial class Manager : MaterialForm
    {
        public Manager()
        {
            bool modoEscuro = ConfigManager.Configuracoes?.ModoEscuro ?? false;
            Theme.AplicarTema(this, modoEscuro);

            InitializeComponent();

            CarregarSettings();

            header.BackColor = Color.FromArgb(25, 118, 210);
            this.FormBorderStyle = FormBorderStyle.None;

            txtUser.Font = new Font("Arial", 12, FontStyle.Bold);
            txtUser.ForeColor = Color.White;
            txtUser.BackColor = Color.FromArgb(25, 118, 210);
            txtFarmacia.Font = new Font("Arial", 9, FontStyle.Bold);
            txtFarmacia.ForeColor = Color.White;
            txtFarmacia.BackColor = Color.FromArgb(25, 118, 210);

            CarregarPerfil();
            AjustarTxtUser();


            this.header.Resize += (s, e) => AjustarTxtUser();

            ConstruirGraficos();
        }

        private void CarregarPerfil()
        {
            using (var context = new Entities())
            {
                var user = context.Utilizador.FirstOrDefault(u => u.Email == Contas.Email);

                if (user != null)
                {
                    txtUser.Text = user.Nome;
                    txtFarmacia.Text = context.Farmacia.FirstOrDefault(f => f.Id == Contas.Farmacia).Nome;

                    // Verifica se a imagem existe
                    if (!string.IsNullOrEmpty(user.Imagem))
                    {
                        try
                        {
                            byte[] imagemBytes = Convert.FromBase64String(user.Imagem);
                            using (MemoryStream ms = new MemoryStream(imagemBytes))
                            {
                                ftPerfil.Image = Image.FromStream(ms);
                                ftPerfil.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                        }
                        catch
                        {
                            // Em caso de erro ao converter imagem, usar imagem padrão
                            ftPerfil.Image = Properties.Resources.pfpDefault;
                            ftPerfil.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    else
                    {
                        // Se imagem for nula ou vazia, usar imagem padrão
                        ftPerfil.Image = Properties.Resources.pfpDefault;
                        ftPerfil.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
            }
        }

        private void AbrirPerfil(object sender, EventArgs e)
        {
            Perfil perfil = new Perfil();
            perfil.ShowDialog();
            ftPerfil.Image = Perfil.PUBLICFOTO;
            txtUser.Text = Perfil.Nome;

            if (Contas.Email == string.Empty)
            {
                this.Hide();
            }

            header.BackColor = Color.FromArgb(25, 118, 210);

            txtUser.Font = new Font("Arial", 12, FontStyle.Bold);
            txtUser.ForeColor = Color.White;
            txtUser.BackColor = Color.FromArgb(25, 118, 210);
            txtFarmacia.Font = new Font("Arial", 9, FontStyle.Bold);
            txtFarmacia.ForeColor = Color.White;
            txtFarmacia.BackColor = Color.FromArgb(25, 118, 210);
            CarregarPerfil();
            AjustarTxtUser();
        }

        private void ConstruirGraficos()
        {
            int farmaciaId = Contas.Farmacia; // ID da farmácia atual

            using (var context = new Entities())
            {
                var hoje = DateTime.Today;
                var seisMesesAtras = hoje.AddMonths(-5);
                var inicioPeriodo = new DateTime(seisMesesAtras.Year, seisMesesAtras.Month, 1);

                // Trazer vendas filtrando pela farmácia e período
                var vendas = context.Venda
                    .Where(v => v.DataVenda >= inicioPeriodo && v.FarmaciaId == farmaciaId)
                    .ToList();

                // ===== Gráfico Encomendas vs Balcão (quantidade) - linhas =====

                var vendasPorTipoMes = vendas
                    .GroupBy(v => new { v.DataVenda.Year, v.DataVenda.Month, Tipo = v.Tipo.ToLower() })
                    .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month)
                    .Select(g => new
                    {
                        Ano = g.Key.Year,
                        Mes = g.Key.Month,
                        Tipo = g.Key.Tipo,
                        Quantidade = g.Count()
                    })
                    .ToList();

                var mesesLabels = vendasPorTipoMes
                    .GroupBy(x => new { x.Ano, x.Mes })
                    .OrderBy(g => g.Key.Ano).ThenBy(g => g.Key.Mes)
                    .Select(g => CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(g.Key.Mes))
                    .ToArray();

                var mesIndex = mesesLabels
                    .Select((m, i) => new { m, i })
                    .ToDictionary(x => x.m, x => x.i);

                var encomendas = new double[mesesLabels.Length];
                var balcao = new double[mesesLabels.Length];

                foreach (var item in vendasPorTipoMes)
                {
                    var mesNome = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(item.Mes);
                    int idx = mesIndex[mesNome];
                    if (item.Tipo == "encomenda")
                        encomendas[idx] = item.Quantidade;
                    else if (item.Tipo == "normal" || item.Tipo == "balcão" || item.Tipo == "balcao")
                        balcao[idx] = item.Quantidade;
                }

                chartEncomendasBalcao.Series = new SeriesCollection
        {
            new LineSeries
            {
                Title = "Encomendas",
                Values = new ChartValues<double>(encomendas),
                PointGeometry = DefaultGeometries.Circle,
                PointGeometrySize = 6
            },
            new LineSeries
            {
                Title = "Balcão",
                Values = new ChartValues<double>(balcao),
                PointGeometry = DefaultGeometries.Square,
                PointGeometrySize = 6
            }
        };

                chartEncomendasBalcao.AxisX.Clear();
                chartEncomendasBalcao.AxisX.Add(new Axis
                {
                    Title = "Mês",
                    Labels = mesesLabels
                });

                chartEncomendasBalcao.AxisY.Clear();
                chartEncomendasBalcao.AxisY.Add(new Axis
                {
                    Title = "Quantidade de Vendas",
                    LabelFormatter = value => value.ToString("N0")
                });

                if (!home.Controls.Contains(chartEncomendasBalcao))
                    home.Controls.Add(chartEncomendasBalcao);


                // ===== Gráfico Valor total de vendas por mês - linhas =====

                var vendasPorMes = vendas
                    .GroupBy(v => new { v.DataVenda.Year, v.DataVenda.Month })
                    .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month)
                    .Select(g => new
                    {
                        Mes = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(g.Key.Month),
                        Total = g.Sum(v => v.ValorTotal)
                    })
                    .ToList();

                var valores = new ChartValues<double>(vendasPorMes.Select(v => (double)v.Total));
                var labels = vendasPorMes.Select(v => v.Mes).ToArray();

                chartVendas.Series = new SeriesCollection
        {
            new LineSeries
            {
                Title = "Vendas (€)",
                Values = valores,
                PointGeometry = DefaultGeometries.Circle,
                PointGeometrySize = 8
            }
        };

                chartVendas.AxisX.Clear();
                chartVendas.AxisY.Clear();

                chartVendas.AxisX.Add(new Axis
                {
                    Title = "Mês",
                    Labels = labels,
                    LabelsRotation = 15
                });

                chartVendas.AxisY.Add(new Axis
                {
                    Title = "Valor (€)",
                    LabelFormatter = valor => valor.ToString("C", CultureInfo.CurrentCulture)
                });

                chartVendas.LegendLocation = LegendLocation.Top;

                if (!home.Controls.Contains(chartVendas))
                    home.Controls.Add(chartVendas);
            }
        }

        private void AjustarTxtUser()
        {
            int maxRight = ftPerfil.Left - 10;

            // Desativar AutoSize para poder controlar manualmente
            txtUser.AutoSize = false;
            txtFarmacia.AutoSize = false;

            // Definir altura fixa (opcionalmente adapta à fonte + margem)
            txtUser.Height = txtUser.Font.Height + 6;
            txtFarmacia.Height = txtFarmacia.Font.Height + 6;

            // Medir o texto de forma mais fiel a Labels
            Size userSize = TextRenderer.MeasureText(txtUser.Text.Trim(), txtUser.Font);
            Size farmSize = TextRenderer.MeasureText(txtFarmacia.Text.Trim(), txtFarmacia.Font);

            int margem = 10; // margem para evitar corte da última palavra

            int widthUser = userSize.Width + margem;
            int widthFarm = farmSize.Width + margem;

            txtUser.Width = widthUser;
            txtFarmacia.Width = widthFarm;

            // Alinha à direita respeitando o espaço antes da imagem
            txtUser.Left = maxRight - widthUser;
            txtFarmacia.Left = maxRight - widthFarm;

            // Garantir que o texto fica corretamente alinhado e visível
            txtUser.TextAlign = ContentAlignment.MiddleLeft;
            txtFarmacia.TextAlign = ContentAlignment.MiddleLeft;

            txtUser.Padding = Padding.Empty;
            txtFarmacia.Padding = Padding.Empty;
        }

        private void MostrarMenuFarmacias()
        {
            // Cria um novo ContextMenuStrip
            ContextMenuStrip menu = new ContextMenuStrip();

            using (var db = new Entities())
            {
                string email = Contas.Email;

                // Busca as farmácias do usuário
                var farmacias = db.Farmacia
                                  .Where(f => f.DonoEmail == email)
                                  .ToList();

                if (farmacias.Any())
                {
                    foreach (var farmacia in farmacias)
                    {
                        var item = new ToolStripMenuItem(farmacia.Nome);
                        item.Tag = farmacia; // Guarda o objeto para uso posterior
                        item.Click += (s, ev) =>
                        {
                            txtFarmacia.Text = farmacia.Nome;
                            Contas.Farmacia = farmacia.Id;
                            AjustarTxtUser();
                        };
                        menu.Items.Add(item);
                    }
                }
                else
                {
                    menu.Items.Add(new ToolStripMenuItem("Nenhuma farmácia encontrada") { Enabled = false });
                }
            }

            // Exibe o menu abaixo do TextBox
            var ponto = txtFarmacia.PointToScreen(new Point(0, txtFarmacia.Height));
            menu.Show(ponto);
        }


        private void txtFarmacia_Click(object sender, EventArgs e)
        {
            MostrarMenuFarmacias();
        }

        private void switchDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            bool ativado = switchDarkMode.Checked;
            Theme.AplicarTema(this, ativado);

            ConfigManager.Configuracoes.ModoEscuro = ativado;
            ConfigManager.Guardar();
            header.BackColor = Color.FromArgb(25, 118, 210);

            txtUser.Font = new Font("Arial", 12, FontStyle.Bold);
            txtUser.ForeColor = Color.White;
            txtUser.BackColor = Color.FromArgb(25, 118, 210);
            txtFarmacia.Font = new Font("Arial", 9, FontStyle.Bold);
            txtFarmacia.ForeColor = Color.White;
            txtFarmacia.BackColor = Color.FromArgb(25, 118, 210);
            CarregarPerfil();

            AjustarTxtUser();
        }

        private void CarregarSettings()
        {
            // Define o estado inicial dos switchs
            switchDarkMode.Checked = ConfigManager.Configuracoes.ModoEscuro;
            switchKeepSession.Checked = ConfigManager.Configuracoes.ManterSessaoIniciada;
            switchNotifications.Checked = ConfigManager.Configuracoes.AtualizacoesAutomaticas;
            switchUpdates.Checked = ConfigManager.Configuracoes.AtualizacoesAutomaticas;

        }

        private void switchNotifications_CheckedChanged(object sender, EventArgs e)
        {
            ConfigManager.Configuracoes.NotificacoesAtivas = switchNotifications.Checked;
            ConfigManager.Guardar();
        }

        private void switchUpdates_CheckedChanged(object sender, EventArgs e)
        {
            ConfigManager.Configuracoes.AtualizacoesAutomaticas = switchUpdates.Checked;
            ConfigManager.Guardar();
        }

        private void switchKeepSession_CheckedChanged(object sender, EventArgs e)
        {
            ConfigManager.Configuracoes.ManterSessaoIniciada = switchKeepSession.Checked;
            ConfigManager.Configuracoes.UtilizadorAtual = Contas.Email;
            ConfigManager.Guardar();
        }
    }
}
