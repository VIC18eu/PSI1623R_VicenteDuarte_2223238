using System;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ProjetoFinal
{
    partial class Manager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manager));
            this.header = new System.Windows.Forms.Panel();
            this.ftPerfil = new System.Windows.Forms.PictureBox();
            this.txtFarmacia = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.Label();
            this.sidebar = new MaterialSkin.Controls.MaterialTabControl();
            this.home = new System.Windows.Forms.TabPage();
            this.chartPieValorMedicamentos = new LiveCharts.WinForms.PieChart();
            this.chartVendasMedicamento = new LiveCharts.WinForms.CartesianChart();
            this.chartEncomendasBalcao = new LiveCharts.WinForms.CartesianChart();
            this.chartVendas = new LiveCharts.WinForms.CartesianChart();
            this.panelResumo = new System.Windows.Forms.Panel();
            this.vendas = new System.Windows.Forms.TabPage();
            this.panelVendas = new System.Windows.Forms.Panel();
            this.headerVendas = new System.Windows.Forms.Panel();
            this.btnAdicionarVenda = new MaterialSkin.Controls.MaterialButton();
            this.btnPesquisarVendas = new MaterialSkin.Controls.MaterialButton();
            this.pesquisaVenda = new MaterialSkin.Controls.MaterialTextBox();
            this.reservas = new System.Windows.Forms.TabPage();
            this.stock = new System.Windows.Forms.TabPage();
            this.funcionarios = new System.Windows.Forms.TabPage();
            this.settings = new System.Windows.Forms.TabPage();
            this.groupAccount = new System.Windows.Forms.GroupBox();
            this.switchKeepSession = new MaterialSkin.Controls.MaterialSwitch();
            this.groupSystem = new System.Windows.Forms.GroupBox();
            this.switchNotifications = new MaterialSkin.Controls.MaterialSwitch();
            this.switchUpdates = new MaterialSkin.Controls.MaterialSwitch();
            this.comboLanguage = new MaterialSkin.Controls.MaterialComboBox();
            this.groupAppearance = new System.Windows.Forms.GroupBox();
            this.switchDarkMode = new MaterialSkin.Controls.MaterialSwitch();
            this.comboFontSize = new MaterialSkin.Controls.MaterialComboBox();
            this.sideBarImages = new System.Windows.Forms.ImageList(this.components);
            this.fundo = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);

            // Reservas
            this.headerReservas = new System.Windows.Forms.Panel();
            this.panelReservas = new System.Windows.Forms.Panel();
            this.btnAdicionarReserva = new MaterialSkin.Controls.MaterialButton();
            this.btnPesquisarReservas = new MaterialSkin.Controls.MaterialButton();
            this.pesquisaReserva = new MaterialSkin.Controls.MaterialTextBox();

            // Stock
            this.headerStock = new System.Windows.Forms.Panel();
            this.panelStock = new System.Windows.Forms.Panel();
            this.btnAdicionarStock = new MaterialSkin.Controls.MaterialButton();
            this.btnPesquisarStock = new MaterialSkin.Controls.MaterialButton();
            this.pesquisaStock = new MaterialSkin.Controls.MaterialTextBox();

            // Funcionários
            this.headerFuncionarios = new System.Windows.Forms.Panel();
            this.panelFuncionarios = new System.Windows.Forms.Panel();
            this.btnAdicionarFuncionario = new MaterialSkin.Controls.MaterialButton();
            this.btnPesquisarFuncionarios = new MaterialSkin.Controls.MaterialButton();
            this.pesquisaFuncionario = new MaterialSkin.Controls.MaterialTextBox();

            this.header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ftPerfil)).BeginInit();
            this.sidebar.SuspendLayout();
            this.home.SuspendLayout();
            this.vendas.SuspendLayout();
            this.headerVendas.SuspendLayout();
            this.settings.SuspendLayout();
            this.groupAccount.SuspendLayout();
            this.groupSystem.SuspendLayout();
            this.groupAppearance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();

            // 
            // header
            // 
            this.header.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.header.Controls.Add(this.ftPerfil);
            this.header.Controls.Add(this.txtFarmacia);
            this.header.Controls.Add(this.txtUser);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 30);
            this.header.Margin = new System.Windows.Forms.Padding(4);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1890, 87);
            this.header.TabIndex = 1;
            // 
            // ftPerfil
            // 
            this.ftPerfil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ftPerfil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ftPerfil.Location = new System.Drawing.Point(1780, 25);
            this.ftPerfil.Name = "ftPerfil";
            this.ftPerfil.Size = new System.Drawing.Size(55, 50);
            this.ftPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ftPerfil.TabIndex = 2;
            this.ftPerfil.TabStop = false;
            this.ftPerfil.Click += new System.EventHandler(this.AbrirPerfil);
            // 
            // txtFarmacia
            // 
            this.txtFarmacia.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtFarmacia.AutoSize = true;
            this.txtFarmacia.Location = new System.Drawing.Point(1693, 53);
            this.txtFarmacia.Name = "txtFarmacia";
            this.txtFarmacia.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFarmacia.Size = new System.Drawing.Size(79, 16);
            this.txtFarmacia.TabIndex = 1;
            this.txtFarmacia.Text = "A carregar...";
            this.txtFarmacia.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.txtFarmacia.Click += new System.EventHandler(this.txtFarmacia_Click);
            // 
            // txtUser
            // 
            this.txtUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtUser.Location = new System.Drawing.Point(1449, 27);
            this.txtUser.Name = "txtUser";
            this.txtUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 0;
            this.txtUser.Text = "A carregar...";
            this.txtUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtUser.Click += new System.EventHandler(this.AbrirPerfil);
            // 
            // sidebar
            // 
            this.sidebar.Controls.Add(this.home);
            this.sidebar.Controls.Add(this.vendas);
            this.sidebar.Controls.Add(this.reservas);
            this.sidebar.Controls.Add(this.stock);
            this.sidebar.Controls.Add(this.funcionarios);
            this.sidebar.Controls.Add(this.settings);
            this.sidebar.Depth = 0;
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sidebar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.sidebar.ImageList = this.sideBarImages;
            this.sidebar.Location = new System.Drawing.Point(0, 117);
            this.sidebar.Margin = new System.Windows.Forms.Padding(4);
            this.sidebar.MouseState = MaterialSkin.MouseState.HOVER;
            this.sidebar.Multiline = true;
            this.sidebar.Name = "sidebar";
            this.sidebar.SelectedIndex = 0;
            this.sidebar.Size = new System.Drawing.Size(1890, 985);
            this.sidebar.TabIndex = 2;
            // 
            // home
            // 
            this.home.AutoScroll = true;
            this.home.Controls.Add(this.chartPieValorMedicamentos);
            this.home.Controls.Add(this.chartVendasMedicamento);
            this.home.Controls.Add(this.chartEncomendasBalcao);
            this.home.Controls.Add(this.chartVendas);
            this.home.Controls.Add(this.panelResumo);
            this.home.ImageKey = "icons8-home-48.png";
            this.home.Location = new System.Drawing.Point(4, 47);
            this.home.Margin = new System.Windows.Forms.Padding(4);
            this.home.Name = "home";
            this.home.Padding = new System.Windows.Forms.Padding(4);
            this.home.Size = new System.Drawing.Size(1882, 934);
            this.home.TabIndex = 0;
            this.home.Text = "Inicio";
            this.home.UseVisualStyleBackColor = true;
            // 
            // chartPieValorMedicamentos
            // 
            this.chartPieValorMedicamentos.Location = new System.Drawing.Point(72, 1200);
            this.chartPieValorMedicamentos.Name = "chartPieValorMedicamentos";
            this.chartPieValorMedicamentos.Size = new System.Drawing.Size(679, 267);
            this.chartPieValorMedicamentos.TabIndex = 4;
            this.chartPieValorMedicamentos.Text = "% de lucro por Medicamento";
            // 
            // chartVendasMedicamento
            // 
            this.chartVendasMedicamento.Location = new System.Drawing.Point(72, 850);
            this.chartVendasMedicamento.Name = "chartVendasMedicamento";
            this.chartVendasMedicamento.Size = new System.Drawing.Size(700, 300);
            this.chartVendasMedicamento.TabIndex = 3;
            this.chartVendasMedicamento.Text = "Vendas de Medicamentos";
            // 
            // chartEncomendasBalcao
            // 
            this.chartEncomendasBalcao.Location = new System.Drawing.Point(72, 437);
            this.chartEncomendasBalcao.Name = "chartEncomendasBalcao";
            this.chartEncomendasBalcao.Size = new System.Drawing.Size(700, 300);
            this.chartEncomendasBalcao.TabIndex = 1;
            this.chartEncomendasBalcao.Text = "Balcão vs Encomendas";
            // 
            // chartVendas
            // 
            this.chartVendas.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chartVendas.Location = new System.Drawing.Point(72, 52);
            this.chartVendas.Name = "chartVendas";
            this.chartVendas.Size = new System.Drawing.Size(700, 300);
            this.chartVendas.TabIndex = 0;
            this.chartVendas.Text = "Gráfico de Vendas";
            // 
            // panelResumo
            // 
            this.panelResumo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelResumo.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelResumo.Location = new System.Drawing.Point(1566, 4);
            this.panelResumo.Name = "panelResumo";
            this.panelResumo.Size = new System.Drawing.Size(291, 1459);
            this.panelResumo.TabIndex = 2;
            // 
            // vendas
            // 
            this.vendas.Controls.Add(this.panelVendas);
            this.vendas.Controls.Add(this.headerVendas);
            this.vendas.ImageKey = "icons8-sell-48.png";
            this.vendas.Location = new System.Drawing.Point(4, 47);
            this.vendas.Name = "vendas";
            this.vendas.Padding = new System.Windows.Forms.Padding(3);
            this.vendas.Size = new System.Drawing.Size(1882, 934);
            this.vendas.TabIndex = 5;
            this.vendas.Text = "Vendas";
            this.vendas.UseVisualStyleBackColor = true;
            this.vendas.Click += new System.EventHandler(this.vendas_Click);
            // 
            // panelVendas
            // 
            this.panelVendas.AutoScroll = true;
            this.panelVendas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVendas.Location = new System.Drawing.Point(3, 103);
            this.panelVendas.Name = "panelVendas";
            this.panelVendas.Size = new System.Drawing.Size(1876, 828);
            this.panelVendas.TabIndex = 2;
            // 
            // headerVendas
            // 
            this.headerVendas.Controls.Add(this.btnAdicionarVenda);
            this.headerVendas.Controls.Add(this.btnPesquisarVendas);
            this.headerVendas.Controls.Add(this.pesquisaVenda);
            this.headerVendas.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerVendas.Location = new System.Drawing.Point(3, 3);
            this.headerVendas.Name = "headerVendas";
            this.headerVendas.Size = new System.Drawing.Size(1876, 100);
            this.headerVendas.TabIndex = 1;
            // 
            // btnAdicionarVenda
            // 
            this.btnAdicionarVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionarVenda.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdicionarVenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionarVenda.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAdicionarVenda.Depth = 0;
            this.btnAdicionarVenda.HighEmphasis = true;
            this.btnAdicionarVenda.Icon = null;
            this.btnAdicionarVenda.Location = new System.Drawing.Point(1730, 29);
            this.btnAdicionarVenda.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAdicionarVenda.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdicionarVenda.Name = "btnAdicionarVenda";
            this.btnAdicionarVenda.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAdicionarVenda.Size = new System.Drawing.Size(98, 36);
            this.btnAdicionarVenda.TabIndex = 4;
            this.btnAdicionarVenda.Text = "Adicionar";
            this.btnAdicionarVenda.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAdicionarVenda.UseAccentColor = false;
            this.btnAdicionarVenda.UseVisualStyleBackColor = true;
            this.btnAdicionarVenda.Click += new System.EventHandler(this.btnAdicionarVenda_Click);
            // 
            // btnPesquisarVendas
            // 
            this.btnPesquisarVendas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPesquisarVendas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarVendas.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPesquisarVendas.Depth = 0;
            this.btnPesquisarVendas.HighEmphasis = true;
            this.btnPesquisarVendas.Icon = null;
            this.btnPesquisarVendas.Location = new System.Drawing.Point(38, 29);
            this.btnPesquisarVendas.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPesquisarVendas.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPesquisarVendas.Name = "btnPesquisarVendas";
            this.btnPesquisarVendas.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPesquisarVendas.Size = new System.Drawing.Size(100, 36);
            this.btnPesquisarVendas.TabIndex = 3;
            this.btnPesquisarVendas.Text = "Pesquisar";
            this.btnPesquisarVendas.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPesquisarVendas.UseAccentColor = false;
            this.btnPesquisarVendas.UseVisualStyleBackColor = true;
            this.btnPesquisarVendas.Click += new System.EventHandler(this.btnPesquisarVendas_Click);
            // 
            // pesquisaVenda
            // 
            this.pesquisaVenda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pesquisaVenda.AnimateReadOnly = false;
            this.pesquisaVenda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pesquisaVenda.Depth = 0;
            this.pesquisaVenda.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.pesquisaVenda.LeadingIcon = null;
            this.pesquisaVenda.Location = new System.Drawing.Point(193, 22);
            this.pesquisaVenda.MaxLength = 50;
            this.pesquisaVenda.MouseState = MaterialSkin.MouseState.OUT;
            this.pesquisaVenda.Multiline = false;
            this.pesquisaVenda.Name = "pesquisaVenda";
            this.pesquisaVenda.Size = new System.Drawing.Size(992, 50);
            this.pesquisaVenda.TabIndex = 0;
            this.pesquisaVenda.Text = "";
            this.pesquisaVenda.TrailingIcon = null;
            // --- Reservas ---
            this.reservas.Controls.Add(this.panelReservas);
            this.reservas.Controls.Add(this.headerReservas);
            this.reservas.ImageKey = "icons8-calendar-48.png";
            this.reservas.Location = new Point(4, 47);
            this.reservas.Margin = new Padding(4);
            this.reservas.Name = "reservas";
            this.reservas.Padding = new Padding(4);
            this.reservas.Size = new Size(1882, 934);
            this.reservas.TabIndex = 1;
            this.reservas.Text = "Reservas";
            this.reservas.UseVisualStyleBackColor = true;

            // painel reservas
            this.panelReservas.AutoScroll = true;
            this.panelReservas.Dock = DockStyle.Fill;
            this.panelReservas.Location = new Point(3, 103);
            this.panelReservas.Name = "panelReservas";
            this.panelReservas.Size = new Size(1876, 828);
            this.panelReservas.TabIndex = 2;

            // header reservas com botões e pesquisa
            this.headerReservas.Controls.Add(this.btnAdicionarReserva);
            this.headerReservas.Controls.Add(this.btnPesquisarReservas);
            this.headerReservas.Controls.Add(this.pesquisaReserva);
            this.headerReservas.Dock = DockStyle.Top;
            this.headerReservas.Location = new Point(3, 3);
            this.headerReservas.Name = "headerReservas";
            this.headerReservas.Size = new Size(1876, 100);
            this.headerReservas.TabIndex = 1;

            // btnAdicionarReserva
            this.btnAdicionarReserva.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnAdicionarReserva.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.btnAdicionarReserva.Cursor = Cursors.Hand;
            this.btnAdicionarReserva.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAdicionarReserva.Depth = 0;
            this.btnAdicionarReserva.HighEmphasis = true;
            this.btnAdicionarReserva.Location = new Point(1730, 29);
            this.btnAdicionarReserva.Margin = new Padding(4, 6, 4, 6);
            this.btnAdicionarReserva.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdicionarReserva.Name = "btnAdicionarReserva";
            this.btnAdicionarReserva.Size = new Size(98, 36);
            this.btnAdicionarReserva.TabIndex = 4;
            this.btnAdicionarReserva.Text = "Adicionar";
            this.btnAdicionarReserva.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAdicionarReserva.UseVisualStyleBackColor = true;

            // btnPesquisarReservas
            this.btnPesquisarReservas.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.btnPesquisarReservas.Cursor = Cursors.Hand;
            this.btnPesquisarReservas.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPesquisarReservas.Depth = 0;
            this.btnPesquisarReservas.HighEmphasis = true;
            this.btnPesquisarReservas.Location = new Point(38, 29);
            this.btnPesquisarReservas.Margin = new Padding(4, 6, 4, 6);
            this.btnPesquisarReservas.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPesquisarReservas.Name = "btnPesquisarReservas";
            this.btnPesquisarReservas.Size = new Size(100, 36);
            this.btnPesquisarReservas.TabIndex = 3;
            this.btnPesquisarReservas.Text = "Pesquisar";
            this.btnPesquisarReservas.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPesquisarReservas.UseVisualStyleBackColor = true;

            // pesquisaReserva
            this.pesquisaReserva.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.pesquisaReserva.BorderStyle = BorderStyle.None;
            this.pesquisaReserva.Depth = 0;
            this.pesquisaReserva.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            this.pesquisaReserva.Location = new Point(193, 22);
            this.pesquisaReserva.MaxLength = 50;
            this.pesquisaReserva.Multiline = false;
            this.pesquisaReserva.Name = "pesquisaReserva";
            this.pesquisaReserva.Size = new Size(992, 50);
            this.pesquisaReserva.TabIndex = 0;
            this.pesquisaReserva.Text = "";

            // --- Stock ---
            this.stock.Controls.Add(this.panelStock);
            this.stock.Controls.Add(this.headerStock);
            this.stock.ImageKey = "icons8-box-48.png";
            this.stock.Location = new Point(4, 47);
            this.stock.Margin = new Padding(4);
            this.stock.Name = "stock";
            this.stock.Size = new Size(1882, 934);
            this.stock.TabIndex = 2;
            this.stock.Text = "Stock";
            this.stock.UseVisualStyleBackColor = true;

            this.panelStock.AutoScroll = true;
            this.panelStock.Dock = DockStyle.Fill;
            this.panelStock.Location = new Point(3, 103);
            this.panelStock.Name = "panelStock";
            this.panelStock.Size = new Size(1876, 828);
            this.panelStock.TabIndex = 2;

            this.headerStock.Controls.Add(this.btnAdicionarStock);
            this.headerStock.Controls.Add(this.btnPesquisarStock);
            this.headerStock.Controls.Add(this.pesquisaStock);
            this.headerStock.Dock = DockStyle.Top;
            this.headerStock.Location = new Point(3, 3);
            this.headerStock.Name = "headerStock";
            this.headerStock.Size = new Size(1876, 100);
            this.headerStock.TabIndex = 1;

            this.btnAdicionarStock.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnAdicionarStock.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.btnAdicionarStock.Cursor = Cursors.Hand;
            this.btnAdicionarStock.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAdicionarStock.Depth = 0;
            this.btnAdicionarStock.HighEmphasis = true;
            this.btnAdicionarStock.Location = new Point(1730, 29);
            this.btnAdicionarStock.Margin = new Padding(4, 6, 4, 6);
            this.btnAdicionarStock.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdicionarStock.Name = "btnAdicionarStock";
            this.btnAdicionarStock.Size = new Size(98, 36);
            this.btnAdicionarStock.TabIndex = 4;
            this.btnAdicionarStock.Text = "Adicionar";
            this.btnAdicionarStock.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAdicionarStock.UseVisualStyleBackColor = true;

            this.btnPesquisarStock.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.btnPesquisarStock.Cursor = Cursors.Hand;
            this.btnPesquisarStock.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPesquisarStock.Depth = 0;
            this.btnPesquisarStock.HighEmphasis = true;
            this.btnPesquisarStock.Location = new Point(38, 29);
            this.btnPesquisarStock.Margin = new Padding(4, 6, 4, 6);
            this.btnPesquisarStock.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPesquisarStock.Name = "btnPesquisarStock";
            this.btnPesquisarStock.Size = new Size(100, 36);
            this.btnPesquisarStock.TabIndex = 3;
            this.btnPesquisarStock.Text = "Pesquisar";
            this.btnPesquisarStock.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPesquisarStock.UseVisualStyleBackColor = true;

            this.pesquisaStock.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.pesquisaStock.BorderStyle = BorderStyle.None;
            this.pesquisaStock.Depth = 0;
            this.pesquisaStock.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            this.pesquisaStock.Location = new Point(193, 22);
            this.pesquisaStock.MaxLength = 50;
            this.pesquisaStock.Multiline = false;
            this.pesquisaStock.Name = "pesquisaStock";
            this.pesquisaStock.Size = new Size(992, 50);
            this.pesquisaStock.TabIndex = 0;
            this.pesquisaStock.Text = "";

            // --- Funcionários ---
            this.funcionarios.Controls.Add(this.panelFuncionarios);
            this.funcionarios.Controls.Add(this.headerFuncionarios);
            this.funcionarios.ImageKey = "icons8-contacts-48.png";
            this.funcionarios.Location = new Point(4, 47);
            this.funcionarios.Margin = new Padding(4);
            this.funcionarios.Name = "funcionarios";
            this.funcionarios.Size = new Size(1864, 934);
            this.funcionarios.TabIndex = 3;
            this.funcionarios.Text = "Funcionários";
            this.funcionarios.UseVisualStyleBackColor = true;

            this.panelFuncionarios.AutoScroll = true;
            this.panelFuncionarios.Dock = DockStyle.Fill;
            this.panelFuncionarios.Location = new Point(3, 103);
            this.panelFuncionarios.Name = "panelFuncionarios";
            this.panelFuncionarios.Size = new Size(1876, 828);
            this.panelFuncionarios.TabIndex = 2;

            this.headerFuncionarios.Controls.Add(this.btnAdicionarFuncionario);
            this.headerFuncionarios.Controls.Add(this.btnPesquisarFuncionarios);
            this.headerFuncionarios.Controls.Add(this.pesquisaFuncionario);
            this.headerFuncionarios.Dock = DockStyle.Top;
            this.headerFuncionarios.Location = new Point(3, 3);
            this.headerFuncionarios.Name = "headerFuncionarios";
            this.headerFuncionarios.Size = new Size(1876, 100);
            this.headerFuncionarios.TabIndex = 1;

            this.btnAdicionarFuncionario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnAdicionarFuncionario.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.btnAdicionarFuncionario.Cursor = Cursors.Hand;
            this.btnAdicionarFuncionario.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAdicionarFuncionario.Depth = 0;
            this.btnAdicionarFuncionario.HighEmphasis = true;
            this.btnAdicionarFuncionario.Location = new Point(1730, 29);
            this.btnAdicionarFuncionario.Margin = new Padding(4, 6, 4, 6);
            this.btnAdicionarFuncionario.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdicionarFuncionario.Name = "btnAdicionarFuncionario";
            this.btnAdicionarFuncionario.Size = new Size(98, 36);
            this.btnAdicionarFuncionario.TabIndex = 4;
            this.btnAdicionarFuncionario.Text = "Adicionar";
            this.btnAdicionarFuncionario.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAdicionarFuncionario.UseVisualStyleBackColor = true;

            this.btnPesquisarFuncionarios.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.btnPesquisarFuncionarios.Cursor = Cursors.Hand;
            this.btnPesquisarFuncionarios.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPesquisarFuncionarios.Depth = 0;
            this.btnPesquisarFuncionarios.HighEmphasis = true;
            this.btnPesquisarFuncionarios.Location = new Point(38, 29);
            this.btnPesquisarFuncionarios.Margin = new Padding(4, 6, 4, 6);
            this.btnPesquisarFuncionarios.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPesquisarFuncionarios.Name = "btnPesquisarFuncionarios";
            this.btnPesquisarFuncionarios.Size = new Size(100, 36);
            this.btnPesquisarFuncionarios.TabIndex = 3;
            this.btnPesquisarFuncionarios.Text = "Pesquisar";
            this.btnPesquisarFuncionarios.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPesquisarFuncionarios.UseVisualStyleBackColor = true;

            this.pesquisaFuncionario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.pesquisaFuncionario.BorderStyle = BorderStyle.None;
            this.pesquisaFuncionario.Depth = 0;
            this.pesquisaFuncionario.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            this.pesquisaFuncionario.Location = new Point(193, 22);
            this.pesquisaFuncionario.MaxLength = 50;
            this.pesquisaFuncionario.Multiline = false;
            this.pesquisaFuncionario.Name = "pesquisaFuncionario";
            this.pesquisaFuncionario.Size = new Size(992, 50);
            this.pesquisaFuncionario.TabIndex = 0;
            this.pesquisaFuncionario.Text = "";
            // 
            // settings
            // 
            this.settings.AutoScroll = true;
            this.settings.Controls.Add(this.groupAccount);
            this.settings.Controls.Add(this.groupSystem);
            this.settings.Controls.Add(this.groupAppearance);
            this.settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settings.ImageKey = "icons8-settings-48.png";
            this.settings.Location = new System.Drawing.Point(4, 47);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(1864, 934);
            this.settings.TabIndex = 4;
            this.settings.Text = "Definições";
            this.settings.UseVisualStyleBackColor = true;
            // 
            // groupAccount
            // 
            this.groupAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.groupAccount.Controls.Add(this.switchKeepSession);
            this.groupAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupAccount.Location = new System.Drawing.Point(0, 440);
            this.groupAccount.Margin = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.groupAccount.Name = "groupAccount";
            this.groupAccount.Padding = new System.Windows.Forms.Padding(10);
            this.groupAccount.Size = new System.Drawing.Size(1864, 130);
            this.groupAccount.TabIndex = 0;
            this.groupAccount.TabStop = false;
            this.groupAccount.Text = "Conta";
            // 
            // switchKeepSession
            // 
            this.switchKeepSession.Depth = 0;
            this.switchKeepSession.Location = new System.Drawing.Point(20, 35);
            this.switchKeepSession.Margin = new System.Windows.Forms.Padding(0);
            this.switchKeepSession.MouseLocation = new System.Drawing.Point(-1, -1);
            this.switchKeepSession.MouseState = MaterialSkin.MouseState.HOVER;
            this.switchKeepSession.Name = "switchKeepSession";
            this.switchKeepSession.Ripple = true;
            this.switchKeepSession.Size = new System.Drawing.Size(500, 70);
            this.switchKeepSession.TabIndex = 0;
            this.switchKeepSession.Text = " Manter Sessão Iniciada";
            this.switchKeepSession.CheckedChanged += new System.EventHandler(this.switchKeepSession_CheckedChanged);
            // 
            // groupSystem
            // 
            this.groupSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.groupSystem.Controls.Add(this.switchNotifications);
            this.groupSystem.Controls.Add(this.switchUpdates);
            this.groupSystem.Controls.Add(this.comboLanguage);
            this.groupSystem.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupSystem.Location = new System.Drawing.Point(0, 180);
            this.groupSystem.Name = "groupSystem";
            this.groupSystem.Padding = new System.Windows.Forms.Padding(10);
            this.groupSystem.Size = new System.Drawing.Size(1864, 260);
            this.groupSystem.TabIndex = 1;
            this.groupSystem.TabStop = false;
            this.groupSystem.Text = "Sistema";
            // 
            // switchNotifications
            // 
            this.switchNotifications.Checked = true;
            this.switchNotifications.CheckState = System.Windows.Forms.CheckState.Checked;
            this.switchNotifications.Depth = 0;
            this.switchNotifications.Location = new System.Drawing.Point(20, 30);
            this.switchNotifications.Margin = new System.Windows.Forms.Padding(0);
            this.switchNotifications.MouseLocation = new System.Drawing.Point(-1, -1);
            this.switchNotifications.MouseState = MaterialSkin.MouseState.HOVER;
            this.switchNotifications.Name = "switchNotifications";
            this.switchNotifications.Ripple = true;
            this.switchNotifications.Size = new System.Drawing.Size(500, 70);
            this.switchNotifications.TabIndex = 0;
            this.switchNotifications.Text = " Ativar Notificações";
            this.switchNotifications.CheckedChanged += new System.EventHandler(this.switchNotifications_CheckedChanged);
            // 
            // switchUpdates
            // 
            this.switchUpdates.Checked = true;
            this.switchUpdates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.switchUpdates.Depth = 0;
            this.switchUpdates.Location = new System.Drawing.Point(20, 80);
            this.switchUpdates.Margin = new System.Windows.Forms.Padding(0);
            this.switchUpdates.MouseLocation = new System.Drawing.Point(-1, -1);
            this.switchUpdates.MouseState = MaterialSkin.MouseState.HOVER;
            this.switchUpdates.Name = "switchUpdates";
            this.switchUpdates.Ripple = true;
            this.switchUpdates.Size = new System.Drawing.Size(500, 70);
            this.switchUpdates.TabIndex = 1;
            this.switchUpdates.Text = " Atualizações Automáticas";
            this.switchUpdates.CheckedChanged += new System.EventHandler(this.switchUpdates_CheckedChanged);
            // 
            // comboLanguage
            // 
            this.comboLanguage.AutoResize = false;
            this.comboLanguage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboLanguage.Depth = 0;
            this.comboLanguage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboLanguage.DropDownHeight = 174;
            this.comboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLanguage.DropDownWidth = 121;
            this.comboLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboLanguage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboLanguage.IntegralHeight = false;
            this.comboLanguage.ItemHeight = 43;
            this.comboLanguage.Items.AddRange(new object[] {
            "Português"});
            this.comboLanguage.Location = new System.Drawing.Point(20, 140);
            this.comboLanguage.MaxDropDownItems = 4;
            this.comboLanguage.MouseState = MaterialSkin.MouseState.OUT;
            this.comboLanguage.Name = "comboLanguage";
            this.comboLanguage.Size = new System.Drawing.Size(180, 49);
            this.comboLanguage.StartIndex = 0;
            this.comboLanguage.TabIndex = 2;
            // 
            // groupAppearance
            // 
            this.groupAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.groupAppearance.Controls.Add(this.switchDarkMode);
            this.groupAppearance.Controls.Add(this.comboFontSize);
            this.groupAppearance.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupAppearance.Location = new System.Drawing.Point(0, 0);
            this.groupAppearance.Name = "groupAppearance";
            this.groupAppearance.Padding = new System.Windows.Forms.Padding(10);
            this.groupAppearance.Size = new System.Drawing.Size(1864, 180);
            this.groupAppearance.TabIndex = 2;
            this.groupAppearance.TabStop = false;
            this.groupAppearance.Text = "Aparência";
            // 
            // switchDarkMode
            // 
            this.switchDarkMode.Depth = 0;
            this.switchDarkMode.Location = new System.Drawing.Point(20, 30);
            this.switchDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.switchDarkMode.MouseLocation = new System.Drawing.Point(-1, -1);
            this.switchDarkMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.switchDarkMode.Name = "switchDarkMode";
            this.switchDarkMode.Ripple = true;
            this.switchDarkMode.Size = new System.Drawing.Size(500, 70);
            this.switchDarkMode.TabIndex = 0;
            this.switchDarkMode.Text = " Modo Escuro";
            this.switchDarkMode.CheckedChanged += new System.EventHandler(this.switchDarkMode_CheckedChanged);
            // 
            // comboFontSize
            // 
            this.comboFontSize.AutoResize = false;
            this.comboFontSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboFontSize.Depth = 0;
            this.comboFontSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboFontSize.DropDownHeight = 174;
            this.comboFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFontSize.DropDownWidth = 121;
            this.comboFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboFontSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboFontSize.IntegralHeight = false;
            this.comboFontSize.ItemHeight = 43;
            this.comboFontSize.Items.AddRange(new object[] {
            "Pequena",
            "Média",
            "Grande"});
            this.comboFontSize.Location = new System.Drawing.Point(30, 90);
            this.comboFontSize.MaxDropDownItems = 4;
            this.comboFontSize.MouseState = MaterialSkin.MouseState.OUT;
            this.comboFontSize.Name = "comboFontSize";
            this.comboFontSize.Size = new System.Drawing.Size(180, 49);
            this.comboFontSize.StartIndex = 0;
            this.comboFontSize.TabIndex = 1;
            // 
            // sideBarImages
            // 
            this.sideBarImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("sideBarImages.ImageStream")));
            this.sideBarImages.TransparentColor = System.Drawing.Color.Transparent;
            this.sideBarImages.Images.SetKeyName(0, "icons8-box-48.png");
            this.sideBarImages.Images.SetKeyName(1, "icons8-calendar-48.png");
            this.sideBarImages.Images.SetKeyName(2, "icons8-contacts-48.png");
            this.sideBarImages.Images.SetKeyName(3, "icons8-home-48.png");
            this.sideBarImages.Images.SetKeyName(4, "icons8-settings-48.png");
            this.sideBarImages.Images.SetKeyName(5, "icons8-sell-48.png");
            // 
            // fundo
            // 
            this.fundo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fundo.Location = new System.Drawing.Point(0, 0);
            this.fundo.Name = "fundo";
            this.fundo.Size = new System.Drawing.Size(1659, 663);
            this.fundo.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Click += new System.EventHandler(this.txtFarmacia_Click);
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1890, 1102);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.header);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.sidebar;
            this.DrawerWidth = 250;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1360, 554);
            this.Name = "Manager";
            this.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.Resize += new System.EventHandler(this.Form_Resize);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ftPerfil)).EndInit();
            this.sidebar.ResumeLayout(false);
            this.home.ResumeLayout(false);
            this.vendas.ResumeLayout(false);
            this.headerVendas.ResumeLayout(false);
            this.headerVendas.PerformLayout();
            this.settings.ResumeLayout(false);
            this.groupAccount.ResumeLayout(false);
            this.groupSystem.ResumeLayout(false);
            this.groupAppearance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.Panel header;
        private MaterialSkin.Controls.MaterialTabControl sidebar;
        private System.Windows.Forms.TabPage home;
        private System.Windows.Forms.TabPage reservas;
        private System.Windows.Forms.TabPage stock;
        private System.Windows.Forms.TabPage funcionarios;
        private System.Windows.Forms.ImageList sideBarImages;
        private System.Windows.Forms.TabPage settings;
        private System.Windows.Forms.Label txtUser;
        private System.Windows.Forms.Label txtFarmacia;
        private System.Windows.Forms.PictureBox ftPerfil;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private MaterialSkin.Controls.MaterialLabel lblTema;
        private System.Windows.Forms.Panel fundo;
        private System.Windows.Forms.GroupBox groupAccount;
        private MaterialSkin.Controls.MaterialSwitch switchKeepSession;
        private System.Windows.Forms.GroupBox groupSystem;
        private MaterialSkin.Controls.MaterialSwitch switchNotifications;
        private MaterialSkin.Controls.MaterialSwitch switchUpdates;
        private MaterialSkin.Controls.MaterialComboBox comboLanguage;
        private System.Windows.Forms.GroupBox groupAppearance;
        private MaterialSkin.Controls.MaterialSwitch switchDarkMode;
        private MaterialSkin.Controls.MaterialComboBox comboFontSize;
        private LiveCharts.WinForms.CartesianChart chartVendas;
        private LiveCharts.WinForms.CartesianChart chartEncomendasBalcao;
        private System.Windows.Forms.Panel panelResumo;
        private LiveCharts.WinForms.CartesianChart chartVendasMedicamento;
        private LiveCharts.WinForms.PieChart chartPieValorMedicamentos;
        private TabPage vendas;
        private MaterialSkin.Controls.MaterialTextBox pesquisaVenda;
        private System.Windows.Forms.Panel headerVendas;
        private BindingSource bindingSource1;
        private MaterialSkin.Controls.MaterialButton btnPesquisarVendas;
        private System.Windows.Forms.Panel panelVendas;
        private MaterialSkin.Controls.MaterialButton btnAdicionarVenda;
        // Reservas
        private System.Windows.Forms.Panel headerReservas;
        private System.Windows.Forms.Panel panelReservas;
        private MaterialSkin.Controls.MaterialButton btnAdicionarReserva;
        private MaterialSkin.Controls.MaterialButton btnPesquisarReservas;
        private MaterialSkin.Controls.MaterialTextBox pesquisaReserva;

        // Stock
        private System.Windows.Forms.Panel headerStock;
        private System.Windows.Forms.Panel panelStock;
        private MaterialSkin.Controls.MaterialButton btnAdicionarStock;
        private MaterialSkin.Controls.MaterialButton btnPesquisarStock;
        private MaterialSkin.Controls.MaterialTextBox pesquisaStock;

        // Funcionários
        private System.Windows.Forms.Panel headerFuncionarios;
        private System.Windows.Forms.Panel panelFuncionarios;
        private MaterialSkin.Controls.MaterialButton btnAdicionarFuncionario;
        private MaterialSkin.Controls.MaterialButton btnPesquisarFuncionarios;
        private MaterialSkin.Controls.MaterialTextBox pesquisaFuncionario;

    }
}