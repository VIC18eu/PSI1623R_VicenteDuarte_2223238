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
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Globalization;
using System.Data.Entity;
using System.Text.RegularExpressions;



namespace ProjetoFinal
{
    public partial class Manager : MaterialForm
    {
        public Manager()
        {
            InitializeComponent();
            this.Shown += Manager_Shown;
            sidebar.SelectedIndexChanged += CarregarTab;
            Theme.AplicarTema(this, ConfigManager.Configuracoes.ModoEscuro);
            AjustarTela();          
        }
        private void CarregarTab(object sender, EventArgs e)
        {
            Theme.AplicarTema(this, ConfigManager.Configuracoes.ModoEscuro);
            AjustarTela();
        }

        private void Manager_Shown(object sender, EventArgs e)
        {
            CarregarPerfil();
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            AjustarTela();
        }

        private void AjustarTela()
        {
            header.BackColor = Color.FromArgb(25, 118, 210);
            txtUser.Font = new Font("Arial", 12, FontStyle.Bold);
            txtUser.ForeColor = Color.White;
            txtUser.BackColor = Color.FromArgb(25, 118, 210);
            txtFarmacia.Font = new Font("Arial", 9, FontStyle.Bold);
            txtFarmacia.ForeColor = Color.White;
            txtFarmacia.BackColor = Color.FromArgb(25, 118, 210);

            CarregarPerfil();
            if (sidebar.SelectedTab == home)
            {
                CarregarHome();
            }
            if (sidebar.SelectedTab == vendas)
            {
                CarregarVendas();
            }
            if (sidebar.SelectedTab == reservas)
            {
                CarregarReservas();
            }
            if (sidebar.SelectedTab == stock)
            {
                CarregarStock();
                CarregarMedicamentos();
            }
            if (sidebar.SelectedTab == funcionarios)
            {
                CarregarFuncionarios();
            }
            if (sidebar.SelectedTab == settings)
            {
                CarregarSettings();
            }
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        }

        private void CarregarHome()
        {
            ConstruirGraficos();
            AjustarHome();
            AplicarTemaHome();
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
                    AjustarTxtUser();
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
            AjustarTela();
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
                panelResumo.Height = 230;
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
            List<Aviso> avisos = ObterAvisos();

            bool modoPequeno = panelResumo.Dock == DockStyle.Top;
            Color corSeparador = MaterialSkinManager.Instance.Theme == MaterialSkinManager.Themes.DARK ? Color.DimGray : Color.Gray;

            if (modoPequeno)
            {
                // Layout horizontal
                int margem = 10;

                // Labels info
                int y = margem;
                foreach (var label in new[] { CriarLabel($"Total de Vendas: {totalVendas}", y), CriarLabel($"Valor Total Vendas: {valorTotal:C}", y += 30), CriarLabel($"Vendas por Reserva: {vendasReserva:C}", y += 30), CriarLabel($"Vendas Normais: {vendasNormal:C}", y += 30) })
                {
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

                // Avisos abaixo da linha
                int avisoY = 10;
                int avisosPorLinha = 2;
                int larguraAviso = 275;
                int espacamento = 10;

                for (int i = 0; i < avisos.Count; i++)
                {
                    var aviso = avisos[i];

                    int coluna = i % avisosPorLinha;
                    int linha = i / avisosPorLinha;
                    int avisoX = linhaVertical.Right + 10 + (coluna * (larguraAviso + espacamento));

                    var avisoPanel = new MaterialCard()
                    {
                        BackColor = Color.MistyRose,
                        AutoSize = true,
                        Padding = new Padding(5),
                        Margin = new Padding(0),
                        Width = larguraAviso,
                        Location = new Point(avisoX, avisoY)
                    };

                    // Título
                    var lblTitulo = new Label()
                    {
                        Text = aviso.Titulo,
                        AutoSize = true,
                        ForeColor = ConfigManager.Configuracoes.ModoEscuro ? Color.Red : Color.DarkRed,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        BackColor = Color.Transparent
                    };

                    // Descrição
                    var lblDescricao = new MaterialLabel()
                    {
                        Text = aviso.Descricao,
                        AutoSize = true,
                        ForeColor = ConfigManager.Configuracoes.ModoEscuro ? Color.White : Color.Black,
                        Font = new Font("Segoe UI", 9, FontStyle.Italic),
                        BackColor = Color.Transparent,
                        MaximumSize = new Size(larguraAviso - 10, 0)
                    };

                    avisoPanel.Controls.Add(lblTitulo);
                    avisoPanel.Controls.Add(lblDescricao);

                    lblTitulo.Location = new Point(0, 0);
                    lblDescricao.Location = new Point(0, lblTitulo.Bottom + 2);

                    panelResumo.Controls.Add(avisoPanel);

                    // Após 2 avisos (ou no último aviso), avança uma linha (aumenta o Y)
                    if (coluna == avisosPorLinha - 1 || i == avisos.Count - 1)
                    {
                        avisoY += avisoPanel.Height + espacamento;
                    }
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
                int avisoX = modoPequeno ? 320 : 10;
                int avisoY = modoPequeno ? 10 : linhaSeparadora.Bottom + 10;

                foreach (var aviso in avisos)
                {
                    var avisoPanel = new MaterialCard()
                    {
                        BackColor = Color.MistyRose,
                        AutoSize = true,
                        Padding = new Padding(5),
                        Margin = new Padding(0),
                        Width = 275,
                        Location = new Point(avisoX, avisoY)
                    };

                    // Label do título
                    var lblTitulo = new Label()
                    {
                        Text = aviso.Titulo,
                        AutoSize = true,
                        ForeColor = ConfigManager.Configuracoes.ModoEscuro ? Color.Red : Color.DarkRed,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        BackColor = Color.Transparent
                    };

                    // Label da descrição
                    var lblDescricao = new Label()
                    {
                        Text = aviso.Descricao,
                        AutoSize = true,
                        ForeColor = ConfigManager.Configuracoes.ModoEscuro ? Color.White : Color.Black,
                        Font = new Font("Segoe UI", 9, FontStyle.Italic),
                        BackColor = Color.Transparent,
                        MaximumSize = new Size(260, 0)
                    };

                    // Adiciona os dois labels ao painel
                    avisoPanel.Controls.Add(lblTitulo);
                    avisoPanel.Controls.Add(lblDescricao);

                    // Define posição manual para evitar sobreposição
                    lblTitulo.Location = new Point(0, 0);
                    lblDescricao.Location = new Point(0, lblTitulo.Bottom + 2);

                    panelResumo.Controls.Add(avisoPanel);
                    avisoY += avisoPanel.Height + 10;
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
                    .Where(v => v.Tipo == "Encomenda" && v.FarmaciaId == Contas.Farmacia)
                    .Sum(v => (decimal?)v.ValorTotal) ?? 0m;
            }
        }

        public decimal ObterVendasNormais()
        {
            using (var context = new Entities())
            {
                return context.Venda
                    .Where(v => v.Tipo == "Normal" && v.FarmaciaId == Contas.Farmacia)
                    .Sum(v => (decimal?)v.ValorTotal) ?? 0m;
            }
        }

        public int ObterTotalVendas()
        {
            using (var context = new Entities())
            {
                return context.Venda.Where(v => v.FarmaciaId == Contas.Farmacia).Count();
            }
        }

        public decimal ObterValorTotalVendas()
        {
            using (var context = new Entities())
            {
                // Somar o valor total das vendas, garantindo que não há valores nulos
                return context.Venda.Where(v => v.FarmaciaId == Contas.Farmacia).Sum(v => (decimal?)v.ValorTotal) ?? 0m;
            }
        }

        public List<Aviso> ObterAvisos()
        {
            using (var context = new Entities())
            {
                var avisos = new List<Aviso>();
                DateTime hoje = DateTime.Today;
                DateTime limiteData = hoje.AddDays(3);

                // Reservas pendentes com data de recolha nos próximos 3 dias
                int reservasPendentes = context.Reserva
                    .Count(r => r.Estado == "Pendente" && r.DataReserva >= hoje && r.DataReserva <= limiteData && r.FarmaciaId == Contas.Farmacia);

                if (reservasPendentes > 0)
                {
                    avisos.Add(new Aviso
                    {
                        Titulo = "Reservas Pendentes",
                        Descricao = $"Existem {reservasPendentes} reservas pendentes com recolha marcada para os próximos dias."
                    });
                }

                // Medicamentos com pouco stock
                var mPoucoStock = context.Stock
                    .Include(s => s.Medicamento)
                    .Where(m => m.Quantidade < 5 && m.FarmaciaId == Contas.Farmacia)
                    .ToList();

                foreach (var item in mPoucoStock)
                {
                    avisos.Add(new Aviso
                    {
                        Titulo = "Stock Baixo",
                        Descricao = $"{item.Medicamento.Nome} tem apenas {item.Quantidade} unidades no stock."
                    });
                }

                // Sem avisos
                if (!avisos.Any())
                {
                    avisos.Add(new Aviso
                    {
                        Titulo = "Sem Avisos",
                        Descricao = "Nenhuma ocorrência a reportar no momento."
                    });
                }

                return avisos;
            }
        }


        private void ConstruirGraficos()
        {
            int farmaciaId = Contas.Farmacia; // ID da farmácia atual

            System.Windows.Media.Brush corLegendas =  ConfigManager.Configuracoes.ModoEscuro ? System.Windows.Media.Brushes.WhiteSmoke : System.Windows.Media.Brushes.Black;

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
                    chartVendas.DefaultLegend.Foreground = corLegendas;

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
                    chartVendasMedicamento.DefaultLegend.Foreground = corLegendas;

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
                        .ToList();

                    // Calcular valor total
                    var valorTotalGlobal = valorPorMedicamento.Sum(v => v.ValorTotal);

                    // Separar os principais medicamentos e agrupar os restantes
                    var topMedicamentos = new List<(string Nome, decimal Valor)>();
                    decimal acumulado = 0;
                    decimal limitePercentagem = 0.90m;

                    foreach (var med in valorPorMedicamento)
                    {
                        if (acumulado / valorTotalGlobal < limitePercentagem && topMedicamentos.Count < 7)
                        {
                            topMedicamentos.Add((med.Nome, med.ValorTotal));
                            acumulado += med.ValorTotal;
                        }
                        else
                        {
                            break;
                        }
                    }

                    // Agrupar os restantes como "Outros"
                    decimal outrosValor = valorTotalGlobal - acumulado;

                    chartPieValorMedicamentos.Series = new SeriesCollection();

                    // Adicionar principais medicamentos
                    foreach (var med in topMedicamentos)
                    {
                        chartPieValorMedicamentos.Series.Add(new PieSeries
                        {
                            Title = med.Nome,
                            Values = new ChartValues<decimal> { med.Valor },
                            DataLabels = true,
                            LabelPoint = chartPoint => $"{chartPoint.Participation:P1}"
                        });
                    }

                    // Adicionar fatia "Outros", se aplicável
                    if (outrosValor > 0)
                    {
                        chartPieValorMedicamentos.Series.Add(new PieSeries
                        {
                            Title = "Outros",
                            Values = new ChartValues<decimal> { outrosValor },
                            DataLabels = true,
                            LabelPoint = chartPoint => $"{chartPoint.Participation:P1}"
                        });
                    }

                    chartPieValorMedicamentos.LegendLocation = LegendLocation.Right;
                    chartPieValorMedicamentos.DefaultLegend.Foreground = corLegendas;

                    if (!home.Controls.Contains(chartPieValorMedicamentos))
                        home.Controls.Add(chartPieValorMedicamentos);

                }
            }
        }

        private void AjustarTxtUser()
        {
            int maxRight = ftPerfil.Left - 10;

            txtUser.AutoSize = false;
            Size userTextSize = TextRenderer.MeasureText(txtUser.Text.Trim(), txtUser.Font);
            int userWidth = userTextSize.Width + 10;
            txtUser.Width = userWidth;
            txtUser.Height = userTextSize.Height;
            txtUser.Left = maxRight - userWidth;
            txtUser.TextAlign = ContentAlignment.MiddleLeft;
            txtUser.Padding = Padding.Empty;

            txtFarmacia.AutoSize = false;
            Size farmTextSize = TextRenderer.MeasureText(txtFarmacia.Text.Trim(), txtFarmacia.Font);
            int farmWidth = farmTextSize.Width + 10;
            txtFarmacia.Width = farmWidth;
            txtFarmacia.Height = farmTextSize.Height;
            txtFarmacia.Left = maxRight - farmWidth;
            txtFarmacia.Top = txtUser.Bottom + 2;
            txtFarmacia.TextAlign = ContentAlignment.MiddleLeft;
            txtFarmacia.Padding = Padding.Empty;
        }


        private void MostrarMenuFarmacias()
        {
            // Cria um novo ContextMenuStrip
            ContextMenuStrip menu = new ContextMenuStrip();

            // Opção de trocar de Farmácia
            var item = new ToolStripMenuItem("Trocar Farmácia");
            item.Click += (s, ev) =>
            {
                this.Hide();
                Farmacias farmaciasForm = new Farmacias();
                farmaciasForm.Show();
            };
            menu.Items.Add(item);

            // Exibe o menu abaixo do TextBox
            var ponto = txtFarmacia.PointToScreen(new Point(0, txtFarmacia.Height));
            menu.Show(ponto);
        }

        private void txtFarmacia_Click(object sender, EventArgs e)
        {
            MostrarMenuFarmacias();
        }


        // <-------- SETTINGS -------->

        private void switchDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            bool ativado = switchDarkMode.Checked;
            Theme.AplicarTema(this, ativado);

            ConfigManager.Configuracoes.ModoEscuro = ativado;
            ConfigManager.Guardar();
            AjustarTela();
        }

        private void CarregarSettings()
        {
            // Define o estado inicial dos switchs
            switchDarkMode.Checked = ConfigManager.Configuracoes.ModoEscuro;
            switchKeepSession.Checked = ConfigManager.Configuracoes.ManterSessaoIniciada;
            switchNotifications.Checked = ConfigManager.Configuracoes.AtualizacoesAutomaticas;
            switchUpdates.Checked = ConfigManager.Configuracoes.AtualizacoesAutomaticas;

            using (var entities = new Entities())
            {
                var farmacia = entities.Farmacia.FirstOrDefault(f => f.Id == Contas.Farmacia);

                textPharmacyEmail.Text = farmacia.Email;
                textPharmacyAddress.Text = farmacia.Endereco;
                textPharmacyName.Text = farmacia.Nome;
                textPharmacyPhone.Text = farmacia.Telefone;
            }

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

        private void btnSavePharmacy_Click(object sender, EventArgs e)
        {
            string name = textPharmacyName.Text.Trim();
            string email = textPharmacyEmail.Text.Trim();
            string phone = textPharmacyPhone.Text.Trim();
            string address = textPharmacyAddress.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Por favor, insira o nome da farmácia.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPharmacyName.Focus();
                return;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Por favor, insira um email válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPharmacyEmail.Focus();
                return;
            }

            string phoneDigits = Regex.Replace(phone, @"\D", "");
            if (phoneDigits.Length < 8 || phoneDigits.Length > 15)
            {
                MessageBox.Show("Por favor, insira um número de telefone válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPharmacyPhone.Focus();
                return;
            }

            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Por favor, insira o endereço da farmácia.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPharmacyAddress.Focus();
                return;
            }

            try
            {
                using (var context = new Entities()) { 
                    var farmacia = context.Farmacia.SingleOrDefault(f => f.Id == Contas.Farmacia);

                    if (farmacia == null)
                    {
                        MessageBox.Show("Farmácia não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    farmacia.Nome = name;
                    farmacia.Email = email;
                    farmacia.Telefone = phone;
                    farmacia.Endereco = address;

                    context.SaveChanges();
                }

                MessageBox.Show("Informações da farmácia atualizadas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AjustarTela();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar a farmácia: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        // <-------- Tab de Vendas -------->

        private void vendas_Click(object sender, EventArgs e)
        {
            CarregarVendas();
        }

        private void CarregarVendas(string filtro = "")
        {
            panelVendas.Controls.Clear();

            using (var context = new Entities())
            {
                var listaVendas = context.Venda
                    .Where(v => v.Farmacia.Id == Contas.Farmacia)
                    .OrderByDescending(v => v.DataVenda)
                    .ToList();


                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    filtro = filtro.Trim().ToLower();

                    // Mapeia termos do utilizador para os valores reais na BD
                    if (filtro == "balcão")
                    {
                        filtro = "normal";
                    }
                    else if (filtro == "reserva")
                    {
                        filtro = "encomenda";
                    }

                    // Filtro por ID com "#"
                    if (filtro.StartsWith("#") && int.TryParse(filtro.Substring(1), out int idFiltro))
                    {
                        listaVendas = listaVendas.Where(v => v.Id == idFiltro).ToList();
                    }
                    else
                    {
                        listaVendas = listaVendas.Where(v =>
                            v.DataVenda.ToString("dd/MM/yyyy HH:mm").ToLower().Contains(filtro) ||
                            v.ValorTotal.ToString("F2").Replace(",", ".").Contains(filtro.Replace(",", ".")) ||
                            (v.Tipo != null && v.Tipo.ToLower().Contains(filtro)) ||
                            (v.Cliente != null && v.Cliente.ToLower().Contains(filtro)) || // filtro por nome do cliente
                            v.Id.ToString().Contains(filtro)
                        ).ToList();
                    }
                }

                int yOffset = 10;

                foreach (var venda in listaVendas)
                {
                    var card = new MaterialSkin.Controls.MaterialCard
                    {
                        Width = panelVendas.Width - 30,
                        Height = 170,
                        BackColor = Color.White,
                        Location = new Point(10, yOffset),
                        Padding = new Padding(10),
                        Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                        Tag = venda.Id,
                        Cursor = Cursors.Hand
                    };

                    var lblTitulo = new Label
                    {
                        Text = $"Venda #{venda.Id}",
                        Font = new Font("Segoe UI", 11, FontStyle.Bold),
                        Location = new Point(10, 10),
                        AutoSize = true
                    };

                    var lblValor = new Label
                    {
                        Text = $"{venda.ValorTotal:C}",
                        Font = new Font("Segoe UI", 11),
                        AutoSize = true,
                        Anchor = AnchorStyles.Top | AnchorStyles.Right
                    };
                    lblValor.Location = new Point(card.Width - lblValor.Width - 5, 10);

                    var lblData = new Label
                    {
                        Text = $"Data: {venda.DataVenda:dd/MM/yyyy HH:mm}",
                        Font = new Font("Segoe UI", 10),
                        Location = new Point(10, 40),
                        AutoSize = true
                    };

                    var lblTipo = new Label
                    {
                        Text = "Tipo: " + (venda.Tipo?.ToLower() == "encomenda" ? "Reserva" : "Balcão"),
                        Font = new Font("Segoe UI", 10),
                        Location = new Point(10, 65),
                        AutoSize = true
                    };

                    var lblCliente = new Label
                    {
                        Text = $"Cliente: {venda.Cliente ?? "Desconhecido"}",
                        Font = new Font("Segoe UI", 10),
                        Location = new Point(10, 90),
                        AutoSize = true
                    };

                    var btnRemover = new Button
                    {
                        Text = "Remover",
                        BackColor = Color.FromArgb(220, 53, 69),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Size = new Size(100, 30),
                        Location = new Point(card.Width - 120, card.Height - 40),
                        Tag = venda.Id,
                        Anchor = AnchorStyles.Top | AnchorStyles.Right,
                        Cursor = Cursors.Hand
                    };

                    btnRemover.Click += (s, e) =>
                    {
                        var resultado = MessageBox.Show(
                            "Tem a certeza que deseja remover esta venda?",
                            "Confirmar remoção",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        if (resultado == DialogResult.Yes)
                        {
                            int idVenda = (int)((Button)s).Tag;

                            using (var entities = new Entities())
                            {
                                var produtos = entities.VendaProduto.Where(vp => vp.VendaId == idVenda).ToList();
                                entities.VendaProduto.RemoveRange(produtos);

                                var vendaRemover = entities.Venda.Find(idVenda);
                                if (vendaRemover != null)
                                {
                                    entities.Venda.Remove(vendaRemover);
                                    entities.SaveChanges();
                                }
                            }

                            CarregarVendas(filtro); // Reaplica o filtro após remoção
                        }
                    };

                    card.Click += (s, e) =>
                    {
                        int idVenda = (int)((MaterialSkin.Controls.MaterialCard)s).Tag;
                        var detalhesForm = new DetalhesVenda(idVenda);
                        detalhesForm.ShowDialog();
                        AjustarTela();
                    };


                    card.Controls.Add(lblTitulo);
                    card.Controls.Add(lblValor);
                    card.Controls.Add(lblData);
                    card.Controls.Add(lblTipo);
                    card.Controls.Add(lblCliente);
                    card.Controls.Add(btnRemover);

                    panelVendas.Controls.Add(card);
                    yOffset += card.Height + 10;
                }
            }
        }

        private void btnPesquisarVendas_Click(object sender, EventArgs e)
        {
            string termo = pesquisaVenda.Text;
            CarregarVendas(termo);
        }

        private void btnAdicionarVenda_Click(object sender, EventArgs e)
        {
            AdicionarVenda adicionarVenda = new AdicionarVenda();
            adicionarVenda.ShowDialog();
            AjustarTela();
        }

        // <-------- Tab de Reservas -------->

        private void CarregarReservas(string filtro = "")
        {
            panelReservas.Controls.Clear();

            bool modoEscuro = ConfigManager.Configuracoes.ModoEscuro;

            Color corFundoCard = modoEscuro ? Color.FromArgb(60, 60, 60) : Color.White;
            Color corTextoPrincipal = modoEscuro ? Color.White : Color.FromArgb(30, 30, 30);
            Color corTextoSecundario = modoEscuro ? Color.LightGray : Color.Gray;
            Color corSombra = modoEscuro ? Color.FromArgb(60, 0, 0, 0) : Color.FromArgb(60, 0, 0, 0);

            int larguraCard = 170;
            int alturaCard = 170;
            int espacamento = 20;

            int cardsPorLinha = Math.Max(1, (panelReservas.Width - espacamento) / (larguraCard + espacamento));

            using (var context = new Entities())
            {
                var reservas = context.Reserva.Where(r => r.FarmaciaId == Contas.Farmacia).ToList();

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    filtro = filtro.Trim().ToLower();
                    reservas = reservas.Where(r =>
                        r.NomeCliente?.ToLower().Contains(filtro) == true ||
                        r.Estado?.ToLower().Contains(filtro) == true ||
                        (r.DataReserva.HasValue && r.DataReserva.Value.ToString("dd/MM/yyyy HH:mm").ToLower().Contains(filtro))
                    ).ToList();
                }

                var listaFiltrada = reservas.OrderBy(r => r.DataReserva).ToList();


                for (int i = 0; i < listaFiltrada.Count; i++)
                {
                    var reserva = listaFiltrada[i];

                    var card = new MaterialCard
                    {
                        Width = larguraCard,
                        Height = alturaCard,
                        BackColor = corFundoCard,
                        Location = new Point(
                            espacamento + (i % cardsPorLinha) * (larguraCard + espacamento),
                            espacamento + (i / cardsPorLinha) * (alturaCard + espacamento)
                        ),
                        Padding = new Padding(10),
                        Cursor = Cursors.Hand,
                        Tag = reserva.Id
                    };

                    Label lblNome = new Label
                    {
                        Text = reserva.NomeCliente,
                        Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold),
                        ForeColor = corTextoPrincipal,
                        Location = new Point(5, 10),
                        AutoSize = true
                    };
                    card.Controls.Add(lblNome);

                    Label lblData = new Label
                    {
                        Text = reserva.DataReserva?.ToString("dd/MM/yyyy HH:mm") ?? "Sem data",
                        Font = new Font("Segoe UI", 9, FontStyle.Regular),
                        ForeColor = corTextoSecundario,
                        Location = new Point(5, 40),
                        AutoSize = true
                    };
                    card.Controls.Add(lblData);

                    Label lblEstado = new Label
                    {
                        Text = "Estado: " + reserva.Estado,
                        Font = new Font("Segoe UI", 9, FontStyle.Italic),
                        ForeColor = reserva.Estado == "Cancelado" ? Color.Red :
                                    reserva.Estado == "Confirmado" ? Color.DarkSeaGreen : Color.DarkOrange,
                        Location = new Point(5, 65),
                        AutoSize = true,
                    };
                    card.Controls.Add(lblEstado);

                    panelReservas.Controls.Add(card);

                    card.Click += (s, e) =>
                    {
                        DetalhesReserva detalhesReserva = new DetalhesReserva((int)card.Tag);
                        detalhesReserva.ShowDialog();
                        AjustarTela();
                    };
                }
            }
        }

        private void btnAdicionarReserva_Click(object sender, EventArgs e)
        {
            AdicionarReserva adicionarReserva = new AdicionarReserva();
            adicionarReserva.ShowDialog();
            AjustarTela();
        }

        private void btnPesquisaReserva_Click(object sender, EventArgs e)
        {
            string termo = pesquisaReserva.Text;
            CarregarReservas(termo);
        }

        // <-------- Tab de Stock -------->
        private void CarregarStock(string filtro = "")
        {
            panelStock.Controls.Clear();

            using (var context = new Entities())
            {
                var listaStock = context.Stock
                    .Where(s => s.FarmaciaId == Contas.Farmacia)
                    .OrderBy(s => s.Medicamento.Nome)
                    .ToList();

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    filtro = filtro.Trim().ToLower();

                    if (filtro.StartsWith("#") && int.TryParse(filtro.Substring(1), out int idFiltro))
                    {
                        listaStock = listaStock.Where(s => s.Id == idFiltro).ToList();
                    }
                    else
                    {
                        listaStock = listaStock.Where(s =>
                            s.Quantidade.ToString().Contains(filtro) ||
                            s.Preco.ToString("F2").Replace(",", ".").Contains(filtro.Replace(",", ".")) ||
                            s.Medicamento.Nome.ToLower().Contains(filtro)
                        ).ToList();
                    }
                }

                int yOffset = 10;

                foreach (var stock in listaStock)
                {
                    var card = new MaterialSkin.Controls.MaterialCard
                    {
                        Width = panelStock.Width - 30,
                        Height = 160,
                        BackColor = Color.White,
                        Location = new Point(10, yOffset),
                        Padding = new Padding(10),
                        Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                        Tag = stock.Id,
                        Cursor = Cursors.Default
                    };

                    var lblTitulo = new Label
                    {
                        Text = stock.Medicamento?.Nome ?? "Medicamento Desconhecido",
                        Font = new Font("Segoe UI", 11, FontStyle.Bold),
                        Location = new Point(10, 10),
                        AutoSize = true
                    };

                    var lblQuantidade = new Label
                    {
                        Text = $"Quantidade: {stock.Quantidade}",
                        Font = new Font("Segoe UI", 10),
                        Location = new Point(10, 40),
                        AutoSize = true
                    };

                    var lblPreco = new Label
                    {
                        Text = $"Preço: {stock.Preco:C}",
                        Font = new Font("Segoe UI", 10),
                        Location = new Point(10, 65),
                        AutoSize = true
                    };

                    int removeButtonX = card.Width - 120;
                    int removeButtonY = card.Height - 40;

                    var txtQuantidadeAdicionar = new MaterialSkin.Controls.MaterialTextBox2
                    {
                        Location = new Point(removeButtonX - 45, removeButtonY - 65),
                        Size = new Size(80, 30),
                        Hint = "Qtd.",
                        MaxLength = 5,
                        Anchor = AnchorStyles.Top | AnchorStyles.Right
                    };

                    var btnAdicionar = new MaterialSkin.Controls.MaterialButton
                    {
                        Text = "+",
                        Location = new Point(removeButtonX + 60, removeButtonY - 60),
                        Size = new Size(50, 30),
                        Tag = stock.Id,
                        UseAccentColor = true,
                        Anchor = AnchorStyles.Top | AnchorStyles.Right
                    };

                    btnAdicionar.Click += (s, e) =>
                    {
                        int idStock = (int)((MaterialSkin.Controls.MaterialButton)s).Tag;

                        if (int.TryParse(txtQuantidadeAdicionar.Text, out int quantidadeAdicionar) && quantidadeAdicionar > 0)
                        {
                            using (var entities = new Entities())
                            {
                                var stockSelecionado = entities.Stock.Find(idStock);
                                if (stockSelecionado != null)
                                {
                                    stockSelecionado.Quantidade += quantidadeAdicionar;
                                    entities.SaveChanges();
                                }
                            }

                            CarregarStock(filtro);
                        }
                        else
                        {
                            MessageBox.Show("Insira uma quantidade válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    };

                    var btnRemover = new Button
                    {
                        Text = "Remover",
                        BackColor = Color.FromArgb(220, 53, 69),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Size = new Size(100, 30),
                        Location = new Point(removeButtonX, removeButtonY),
                        Tag = stock.Id,
                        Anchor = AnchorStyles.Top | AnchorStyles.Right,
                        Cursor = Cursors.Hand,
                    };

                    btnRemover.Click += (s, e) =>
                    {
                        var resultado = MessageBox.Show(
                            "Tem a certeza que deseja remover este item de stock?",
                            "Confirmar remoção",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        if (resultado == DialogResult.Yes)
                        {
                            int idStock = (int)((Button)s).Tag;

                            using (var entities = new Entities())
                            {
                                var stockRemover = entities.Stock.Find(idStock);
                                if (stockRemover != null)
                                {
                                    entities.Stock.Remove(stockRemover);
                                    entities.SaveChanges();
                                }
                            }

                            CarregarStock(filtro);
                        }
                    };

                    var btnEditarPreco = new Button
                    {
                        Text = "🖉",
                        Tag = stock.Id,
                        Location = new Point(lblPreco.Right + 5, lblPreco.Top - 5),
                        Size = new Size(35, 35),
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.Transparent,
                        ForeColor = Color.DimGray,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        Cursor = Cursors.Hand,
                        TabStop = false
                    };

                    btnEditarPreco.FlatAppearance.BorderSize = 0;
                    btnEditarPreco.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    btnEditarPreco.FlatAppearance.MouseOverBackColor = Color.Transparent;


                    btnEditarPreco.Click += (s, e) =>
                    {
                        int idStock = (int)((Button)s).Tag;

                        using (var entities = new Entities())
                        {
                            var stockEditar = entities.Stock.FirstOrDefault(m => m.Id == idStock);
                            if (stockEditar != null)
                            {
                                using (var formEditar = new FormEditarPreco(stockEditar.Preco))
                                {
                                    if (formEditar.ShowDialog() == DialogResult.OK)
                                    {
                                        stockEditar.Preco = formEditar.NovoPreco;
                                        entities.SaveChanges();
                                    }
                                    AjustarTela();
                                }
                            }
                        }
                    };


                    card.Controls.Add(lblTitulo);
                    card.Controls.Add(lblQuantidade);
                    card.Controls.Add(lblPreco);
                    card.Controls.Add(txtQuantidadeAdicionar);
                    card.Controls.Add(btnAdicionar);
                    card.Controls.Add(btnRemover);
                    card.Controls.Add(btnEditarPreco);

                    panelStock.Controls.Add(card);
                    yOffset += card.Height + 10;
                }
            }
        }

        private void btnAdicionarMedicamento_Click(object sender, EventArgs e)
        {
            if (cmbMedicamentos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um medicamento para adicionar ao stock.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtem o ID do medicamento selecionado
            int medicamentoId = (int)cmbMedicamentos.SelectedValue;

            using (var context = new Entities())
            {
                var novoStock = new Stock
                {
                    MedicamentoId = medicamentoId,
                    FarmaciaId = Contas.Farmacia,
                    Quantidade = 0,
                    Preco = (decimal)1.0,
                };

                context.Stock.Add(novoStock);
                context.SaveChanges();
            }

            MessageBox.Show("Medicamento adicionado ao stock com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CarregarMedicamentos();
            CarregarStock();
        }


        private void CarregarMedicamentos()
        {
            using (var context = new Entities())
            {
                // Obtém IDs dos medicamentos que já estão no Stock
                var idsNoStock = context.Stock.Select(s => s.MedicamentoId).ToList();

                // Seleciona medicamentos que NÃO estão no stock
                var medicamentosNaoAdicionados = context.Medicamento
                    .Where(m => !idsNoStock.Contains(m.Id))
                    .OrderBy(m => m.Nome)
                    .ToList();

                // Liga os dados à ComboBox
                cmbMedicamentos.DataSource = medicamentosNaoAdicionados;
                cmbMedicamentos.DisplayMember = "Nome";   // Mostra o nome do medicamento
                cmbMedicamentos.ValueMember = "Id";       // Guarda o Id como valor
            }
        }


        private void btnPesquisarStock_Click(object sender, EventArgs e)
        {
            string termo = pesquisaStock.Text;
            CarregarStock(termo);
        }

        // <-------- Tab de Funcionários -------->

        private void CarregarFuncionarios(string filtro = "")
        {
            panelFuncionarios.Controls.Clear();

            bool modoEscuro = ConfigManager.Configuracoes.ModoEscuro;

            Color corFundoCard = modoEscuro ? Color.FromArgb(60, 60, 60) : Color.White;
            Color corTextoPrincipal = modoEscuro ? Color.White : Color.FromArgb(30, 30, 30);
            Color corTextoSecundario = modoEscuro ? Color.LightGray : Color.Gray;

            int larguraCard = 260;
            int alturaCard = 240;
            int espacamento = 20;

            int cardsPorLinha = Math.Max(1, (panelFuncionarios.Width - espacamento) / (larguraCard + espacamento));

            using (var context = new Entities())
            {
                var funcionarios = context.Funcionario.Include(f => f.Utilizador).Where(f => f.FarmaciaId == Contas.Farmacia).ToList();

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    filtro = filtro.Trim().ToLower();
                    funcionarios = funcionarios.Where(f =>
                        f.EmailUtilizador.ToLower().Contains(filtro) ||
                        (f.Utilizador?.Nome?.ToLower().Contains(filtro) ?? false) ||
                        (f.Categoria?.ToLower().Contains(filtro) ?? false)
                    ).ToList();
                }

                for (int i = 0; i < funcionarios.Count; i++)
                {
                    var funcionario = funcionarios[i];

                    var card = new MaterialCard
                    {
                        Width = larguraCard,
                        Height = alturaCard,
                        BackColor = corFundoCard,
                        Location = new Point(
                            espacamento + (i % cardsPorLinha) * (larguraCard + espacamento),
                            espacamento + (i / cardsPorLinha) * (alturaCard + espacamento)
                        ),
                        Padding = new Padding(10),
                        Tag = funcionario.EmailUtilizador
                    };

                    // Imagem do funcionário
                    PictureBox pictureBox = new PictureBox
                    {
                        Size = new Size(60, 60),
                        Location = new Point(5, 5),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Image = funcionario.Utilizador?.Imagem != null
                            ? Image.FromStream(new MemoryStream(Convert.FromBase64String(funcionario.Utilizador.Imagem)))
                            : Properties.Resources.pfpDefault
                    };
                    card.Controls.Add(pictureBox);

                    // Nome
                    Label lblNome = new Label
                    {
                        Text = funcionario.Utilizador?.Nome ?? funcionario.EmailUtilizador,
                        Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold),
                        ForeColor = corTextoPrincipal,
                        Location = new Point(75, 10),
                        AutoSize = true
                    };
                    card.Controls.Add(lblNome);

                    // Email
                    Label lblEmail = new Label
                    {
                        Text = funcionario.EmailUtilizador,
                        Font = new Font("Segoe UI", 9),
                        ForeColor = corTextoSecundario,
                        Location = new Point(75, 35),
                        AutoSize = true,
                        AutoEllipsis = true
                    };
                    card.Controls.Add(lblEmail);

                    // Categoria
                    Label lblCategoria = new Label
                    {
                        Text = "Categoria: " + (funcionario.Categoria ?? "Sem categoria"),
                        Font = new Font("Segoe UI", 9, FontStyle.Italic),
                        ForeColor = corTextoSecundario,
                        Location = new Point(5, 70),
                        AutoSize = true,
                        AutoEllipsis = true
                    };
                    card.Controls.Add(lblCategoria);

                    // Botão "Alterar Categoria"
                    MaterialButton btnEditar = new MaterialButton
                    {
                        Text = "🖉 Categoria",
                        Size = new Size(180, 30),
                        Location = new Point(10, 185),
                        HighEmphasis = true,
                        Tag = funcionario,
                        Cursor = Cursors.Hand
                    };
                    btnEditar.Click += (s, e) =>
                    {
                        var f = (Funcionario)((MaterialButton)s).Tag;

                        using (var form = new EditarCategoriaForm(f.Categoria))
                        {
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                using (var ctx = new Entities())
                                {
                                    var funcionarioAtualizar = ctx.Funcionario.Find(f.EmailUtilizador, f.FarmaciaId);
                                    if (funcionarioAtualizar != null)
                                    {
                                        funcionarioAtualizar.Categoria = form.NovaCategoria;
                                        ctx.SaveChanges();
                                    }
                                }

                            }
                            AjustarTela();
                        }
                    };

                    card.Controls.Add(btnEditar);

                    MaterialButton btnRemover = new MaterialButton
                    {
                        Text = "Remover",
                        Size = new Size(180, 30),
                        Location = new Point(155, 185),
                        HighEmphasis = false,
                        Tag = funcionario,
                        Cursor = Cursors.Hand
                    };
                    btnRemover.Click += (s, e) =>
                    {
                        var f = (Funcionario)((MaterialButton)s).Tag;
                        var confirm = MessageBox.Show($"Deseja remover {f.EmailUtilizador}?", "Confirmar Remoção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (confirm == DialogResult.Yes)
                        {
                            using (var ctx = new Entities())
                            {
                                var func = ctx.Funcionario.Find(f.EmailUtilizador, f.FarmaciaId);
                                if (func != null)
                                {
                                    ctx.Funcionario.Remove(func);
                                    ctx.SaveChanges();
                                    CarregarFuncionarios(filtro);
                                }
                            }
                        }
                    };
                    card.Controls.Add(btnRemover);

                    panelFuncionarios.Controls.Add(card);
                }
            }
        }


        private void btnAdicionarFuncionario_Click(object sender, EventArgs e)
        {
            AdicionarFuncionario adicionarFuncionario = new AdicionarFuncionario();
            adicionarFuncionario.ShowDialog();

            AjustarTela();
        }

        private void btnPesquisarFuncionarios_Click(object sender, EventArgs e)
        {
            string filtro = pesquisaFuncionario.Text;
            CarregarFuncionarios(filtro);
        }

        private void btnDeletePharmacy_Click(object sender, EventArgs e)
        {
            if (Contas.Farmacia <= 0)
            {
                MessageBox.Show("Nenhuma farmácia selecionada para eliminar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show(
                "Tens a certeza que queres eliminar esta farmácia? Esta ação não pode ser desfeita.",
                "Confirmar Eliminação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (var context = new Entities())
                    {
                        var farmacia = context.Farmacia.SingleOrDefault(f => f.Id == Contas.Farmacia);

                        if (farmacia == null)
                        {
                            MessageBox.Show("Farmácia não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        context.Farmacia.Remove(farmacia);
                        context.SaveChanges();
                    }

                    MessageBox.Show("Farmácia eliminada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Farmacias farmacias = new Farmacias();
                    farmacias.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao eliminar a farmácia: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

    }
}
