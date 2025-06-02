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
using LiveCharts.Wpf;
using System.Globalization;
using System.Data.Entity;



namespace ProjetoFinal
{
    public partial class Manager : MaterialForm
    {
        public Manager()
        {
            bool modoEscuro = ConfigManager.Configuracoes.ModoEscuro;

            InitializeComponent();
            ConstruirGraficos();
            AjustarHome();
            AplicarTemaHome();
            Theme.AplicarTema(this, modoEscuro);

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
            AtualizarConteudoPanelResumo();
            AjustarTxtUser();


            this.header.Resize += (s, e) => AjustarTxtUser();


        }
        private void AplicarTemaHome()
        {
            bool modoEscuro = ConfigManager.Configuracoes.ModoEscuro;

            Color corTexto = modoEscuro ? Color.White : Color.Black;

            chartEncomendasBalcao.ForeColor = corTexto;
            chartPieValorMedicamentos.ForeColor = corTexto;
            chartVendas.ForeColor = corTexto;
            chartVendasMedicamento.ForeColor = corTexto;
        }


        private void Form_Resize(object sender, EventArgs e)
        {
            AjustarHome();
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

        private void AjustarHome()
        {
            int margem = 20;
            int espacamentoVertical = 20;
            int espacamentoHorizontal = 20;
            int alturaGrafico = 300;
            int larguraResumo = 300;

            bool modoEscuro = MaterialSkinManager.Instance.Theme == MaterialSkinManager.Themes.DARK;

            Color corFundo = modoEscuro ? Color.FromArgb(46, 46, 46) : Color.White;
            Color corTexto = modoEscuro ? Color.White : Color.Black;

            home.Controls.Clear();

            Panel panelHomeConteudo = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = corFundo
            };
            home.Controls.Add(panelHomeConteudo);

            panelHomeConteudo.PerformLayout();
            int larguraDisponivel = panelHomeConteudo.ClientSize.Width;
            if (larguraDisponivel == 0)
                larguraDisponivel = this.ClientSize.Width - 40;

            Control[] graficos = new Control[]
            {
                chartVendas,
                chartEncomendasBalcao,
                chartVendasMedicamento,
                chartPieValorMedicamentos
            };

            foreach (Control g in graficos)
            {
                if (g.Parent != null) g.Parent.Controls.Remove(g);
                g.ForeColor = corTexto;
                g.BackColor = corFundo;
            }

            if (panelResumo.Parent != null)
                panelResumo.Parent.Controls.Remove(panelResumo);

            if (larguraDisponivel >= 1600)
            {
                int larguraGrafico = (larguraDisponivel - larguraResumo - 3 * margem - espacamentoHorizontal) / 2;
                int posX1 = margem;
                int posX2 = posX1 + larguraGrafico + espacamentoHorizontal;
                int posY1 = margem;
                int posY2 = margem;

                for (int i = 0; i < graficos.Length; i++)
                {
                    var grafico = graficos[i];
                    grafico.Width = larguraGrafico;
                    grafico.Height = alturaGrafico;

                    if (i % 2 == 0)
                    {
                        grafico.Location = new Point(posX1, posY1);
                        posY1 += alturaGrafico + espacamentoVertical;
                    }
                    else
                    {
                        grafico.Location = new Point(posX2, posY2);
                        posY2 += alturaGrafico + espacamentoVertical;
                    }

                    panelHomeConteudo.Controls.Add(grafico);
                }

                panelResumo.Width = larguraResumo;
                panelResumo.Height = 200;
                panelResumo.Dock = DockStyle.Right;
                panelHomeConteudo.Controls.Add(panelResumo);
            }
            else if (larguraDisponivel >= 1100)
            {
                int larguraGrafico = larguraDisponivel - larguraResumo - (3 * margem + espacamentoHorizontal);
                larguraGrafico = Math.Min(larguraGrafico, 900);

                int posY = margem;

                foreach (var grafico in graficos)
                {
                    grafico.Width = larguraGrafico;
                    grafico.Height = alturaGrafico;
                    grafico.Location = new Point(margem, posY);
                    posY += alturaGrafico + espacamentoVertical;
                    panelHomeConteudo.Controls.Add(grafico);
                }

                panelResumo.Width = larguraResumo;
                panelResumo.Height = 200;
                panelResumo.Dock = DockStyle.Right;
                panelHomeConteudo.Controls.Add(panelResumo);
            }
            else
            {
                int larguraGrafico = larguraDisponivel - 2 * margem;
                larguraGrafico = Math.Min(larguraGrafico, 900);

                panelResumo.Dock = DockStyle.Top;
                panelResumo.Height = 200;
                panelHomeConteudo.Controls.Add(panelResumo);

                panelHomeConteudo.PerformLayout();

                int posY = panelResumo.Bottom + espacamentoVertical;

                foreach (var grafico in graficos)
                {
                    grafico.Width = larguraGrafico;
                    grafico.Height = alturaGrafico;
                    grafico.Location = new Point(margem, posY);
                    posY += alturaGrafico + espacamentoVertical;
                    panelHomeConteudo.Controls.Add(grafico);
                }
            }
            AtualizarConteudoPanelResumo();
        }

        private void AtualizarConteudoPanelResumo()
        {
            panelResumo.Controls.Clear();

            // Obter dados
            int totalVendas = ObterTotalVendas();
            decimal valorTotal = ObterValorTotalVendas();
            decimal vendasReserva = ObterVendasPorReserva();
            decimal vendasNormal = ObterVendasNormais();
            List<string> avisos = ObterAvisos();

            bool modoPequeno = panelResumo.Dock == DockStyle.Top;
            Color corSeparador = MaterialSkinManager.Instance.Theme == MaterialSkinManager.Themes.DARK ? Color.DimGray : Color.Gray;

            if (modoPequeno)
            {
                // Layout horizontal
                int margem = 10;

                // Labels info
                int y = margem;
                foreach (var label in new[]
                    {
                        CriarLabel($"Total de Vendas: {totalVendas}", y),
                        CriarLabel($"Valor Total Vendas: {valorTotal:C}", y += 30),
                        CriarLabel($"Vendas por Reserva: {vendasReserva:C}", y += 30),
                        CriarLabel($"Vendas Normais: {vendasNormal:C}", y += 30)
                    }
                ){
                    label.Location = new Point(margem, label.Location.Y);
                    panelResumo.Controls.Add(label);
                }

                // Linha vertical
                Panel linhaVertical = new Panel()
                {
                    Width = 2,
                    Height = panelResumo.Height - 20,
                    BackColor = corSeparador,
                    Location = new Point(300, 10)
                };
                panelResumo.Controls.Add(linhaVertical);

                // Avisos à direita da linha
                int avisoX = linhaVertical.Right + 10;
                int avisoY = 10;
                foreach (var aviso in avisos)
                {
                    var lbl = new Label()
                    {
                        Text = aviso,
                        AutoSize = true,
                        ForeColor = Color.Red,
                        Font = new Font("Segoe UI", 10, FontStyle.Italic),
                        Location = new Point(avisoX, avisoY)
                    };
                    panelResumo.Controls.Add(lbl);
                    avisoY += 25;
                }
            }
            else
            {
                // Layout vertical (modo médio ou grande)
                int y = 10;
                foreach (var label in new[]
                {
                    CriarLabel($"Total de Vendas: {totalVendas}", y),
                    CriarLabel($"Valor Total Vendas: {valorTotal:C}", y += 30),
                    CriarLabel($"Vendas por Reserva: {vendasReserva:C}", y += 30),
                    CriarLabel($"Vendas Normais: {vendasNormal:C}", y += 30)
                })
                {
                    panelResumo.Controls.Add(label);
                }

                // Linha horizontal
                Panel linhaSeparadora = new Panel()
                {
                    Width = panelResumo.Width - 20,
                    Height = 2,
                    BackColor = corSeparador,
                    Location = new Point(10, y += 50)
                };
                panelResumo.Controls.Add(linhaSeparadora);

                // Avisos abaixo da linha
                int avisoY = linhaSeparadora.Bottom + 10;
                foreach (var aviso in avisos)
                {
                    var lbl = new Label()
                    {
                        Text = aviso,
                        AutoSize = true,
                        ForeColor = Color.Red,
                        Font = new Font("Segoe UI", 10, FontStyle.Italic),
                        Location = new Point(10, avisoY)
                    };
                    panelResumo.Controls.Add(lbl);
                    avisoY += 25;
                }
            }
        }

        private Label CriarLabel(string texto, int y)
        {
            return new Label()
            {
                Text = texto,
                AutoSize = true,
                ForeColor = panelResumo.ForeColor,
                Location = new Point(10, y),
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
        }

        public decimal ObterVendasPorReserva()
        {
            using (var context = new Entities())
            {
                return context.Venda
                    .Where(v => v.Tipo == "Encomenda")
                    .Sum(v => (decimal?)v.ValorTotal) ?? 0m;
            }
        }

        public decimal ObterVendasNormais()
        {
            using (var context = new Entities())
            {
                return context.Venda
                    .Where(v => v.Tipo == "Normal")
                    .Sum(v => (decimal?)v.ValorTotal) ?? 0m;
            }
        }

        public int ObterTotalVendas()
        {
            using (var context = new Entities())
            {
                return context.Venda.Count();
            }
        }

        public decimal ObterValorTotalVendas()
        {
            using (var context = new Entities())
            {
                // Somar o valor total das vendas, garantindo que não há valores nulos
                return context.Venda.Sum(v => (decimal?)v.ValorTotal) ?? 0m;
            }
        }

        public List<string> ObterAvisos()
        {
            using (var context = new Entities())
            {
                var avisos = new List<string>();

                DateTime limiteData = DateTime.Now.AddDays(-7);

                int reservasPendentes = context.Reserva.Count(r => r.Estado == "Pendente" && r.DataReserva <= limiteData);
                var mPoucoStock =  context.Stock.Where(m => m.Quantidade < 5);
                    
                if (reservasPendentes > 0)
                {
                    avisos.Add($"Existem {reservasPendentes} reservas pendentes há mais de 3 dias.");
                }

                foreach (var item in mPoucoStock)
                {
                    avisos.Add($"{item.Medicamento.Nome} está com pouco stock.");
                }

                if (avisos.Count == 0)
                {
                    avisos.Add("Sem avisos no momento.");
                }

                return avisos;
            }
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
                var totalVendasMes = new double[mesesLabels.Length];

                foreach (var item in vendasPorTipoMes)
                {
                    {
                        var mesNome = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(item.Mes);
                        int idx = mesIndex[mesNome];

                        if (item.Tipo == "encomenda")
                            encomendas[idx] = item.Quantidade;
                        else if (item.Tipo == "normal" || item.Tipo == "balcão" || item.Tipo == "balcao")
                            balcao[idx] = item.Quantidade;

                        totalVendasMes[idx] = encomendas[idx] + balcao[idx];
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
                        },
                        new LineSeries
                        {
                            Title = "Total",
                            Values = new ChartValues<double>(totalVendasMes),
                            PointGeometry = DefaultGeometries.Triangle,
                            PointGeometrySize = 6,
                            StrokeDashArray = new System.Windows.Media.DoubleCollection { 2 } // linha tracejada opcional
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

                    // ===== Gráfico Vendas por Medicamento - barras =====
                    var vendasPorMedicamento = context.VendaProduto
                        .Where(vp => vp.Venda.FarmaciaId == farmaciaId)
                        .Include(vp => vp.Medicamento)
                        .Include(vp => vp.Venda)
                        .GroupBy(vp => vp.Medicamento.Nome)
                        .Select(g => new
                        {
                            Nome = g.Key,
                            Quantidade = g.Sum(vp => vp.Quantidade)
                        })
                        .OrderByDescending(g => g.Quantidade)
                        .Take(10)
                        .ToList();


                    // Extrair dados
                    var nomesMedicamentos = vendasPorMedicamento.Select(v => v.Nome).ToArray();
                    var quantidadesVendidas = new ChartValues<int>(vendasPorMedicamento.Select(v => v.Quantidade));

                    // Criar gráfico
                    chartVendasMedicamento.Series = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = "Vendas por Medicamento",
                        Values = quantidadesVendidas
                    }
                };

                    chartVendasMedicamento.AxisX.Clear();
                    chartVendasMedicamento.AxisX.Add(new Axis
                    {
                        Title = "Medicamento",
                        Labels = nomesMedicamentos,
                        LabelsRotation = 15
                    });

                    chartVendasMedicamento.AxisY.Clear();
                    chartVendasMedicamento.AxisY.Add(new Axis
                    {
                        Title = "Quantidade Vendida",
                        LabelFormatter = v => v.ToString("N0")
                    });

                    chartVendasMedicamento.LegendLocation = LegendLocation.Top;

                    if (!home.Controls.Contains(chartVendasMedicamento))
                        home.Controls.Add(chartVendasMedicamento);

                    // ===== Gráfico Pie: Percentagem do valor por medicamento =====
                    var valorPorMedicamento = context.VendaProduto
                        .Where(vp => vp.Venda.FarmaciaId == farmaciaId)
                        .Include(vp => vp.Medicamento)
                        .Include(vp => vp.Venda)
                        .GroupBy(vp => vp.Medicamento.Nome)
                        .Select(g => new
                        {
                            Nome = g.Key,
                            ValorTotal = g.Sum(vp => vp.Quantidade * vp.PrecoUnitario)
                        })
                        .OrderByDescending(g => g.ValorTotal)
                        .Take(10) // Podes ajustar para mostrar só os 10 maiores
                        .ToList();

                    // Criar gráfico Pie
                    chartPieValorMedicamentos.Series = new SeriesCollection();

                    foreach (var med in valorPorMedicamento)
                    {
                        chartPieValorMedicamentos.Series.Add(new PieSeries
                        {
                            Title = med.Nome,
                            Values = new ChartValues<decimal> { med.ValorTotal },
                            DataLabels = true,
                            LabelPoint = chartPoint => $"{chartPoint.Participation:P1}" // percentagem
                        });
                    }

                    chartPieValorMedicamentos.LegendLocation = LegendLocation.Right;

                    if (!home.Controls.Contains(chartPieValorMedicamentos))
                        home.Controls.Add(chartPieValorMedicamentos);

                    if (!home.Controls.Contains(chartVendas))
                        home.Controls.Add(chartVendas);
                }
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
            AplicarTemaHome();
            AtualizarConteudoPanelResumo();

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
