using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ProjetoFinal
{
    public partial class Farmacias : MaterialForm
    {
        public Farmacias()
        {
            InitializeComponent();
            CriarCardsFarmacias();
            Theme.AplicarTema(this, Theme.TemaAtual);
        }
        private FlowLayoutPanel painelCards; // Tornar o painel global para recriar os cards
        private List<Farmacia> todasFarmacias; // Guardar as farmácias carregadas

        private void CriarCardsFarmacias()
        {
            this.Padding = new Padding(0, 64, 0, 0); // 64px é a altura da titlebar
            this.Controls.Clear(); // Para recarregar o layout se necessário

            // Layout principal
            TableLayoutPanel layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1,
                BackColor = this.BackColor
            };
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70)); // barra superior
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // cards

            // Painel superior com botão e pesquisa
            Panel barraSuperior = new Panel
            {
                Dock = DockStyle.Fill,
                Height = 100,
                Padding = new Padding(20, 10, 20, 0),
                BackColor = this.BackColor
            };

            // Botão de pesquisa
            MaterialButton btnPesquisar = new MaterialButton
            {
                Text = "Pesquisar",
                AutoSize = false,
                Width = 110,
                HighEmphasis = true,
                Margin = new Padding(0, 0, 10, 0)
            };

            // Caixa de pesquisa
            TextBox txtPesquisa = new TextBox
            {
                Width = 300,
                Font = new Font("Segoe UI", 14F),
                Margin = new Padding(0)
            };

            // Botão "Adicionar"
            MaterialButton btnAdicionar = new MaterialButton
            {
                Text = "Adicionar",
                AutoSize = false,
                Width = 120,
                HighEmphasis = true,
                Anchor = AnchorStyles.Right,
                Margin = new Padding(0)
            };
            btnAdicionar.Click += BtnAdicionar_Click;

            // Layout da barra: botão, texto, botão
            TableLayoutPanel barraConteudo = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
            };
            barraConteudo.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));       // botão pesquisar
            barraConteudo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));  // textbox
            barraConteudo.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));       // botão adicionar
            barraConteudo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1F));   // preenchimento

            barraConteudo.Controls.Add(btnPesquisar, 0, 0);
            barraConteudo.Controls.Add(txtPesquisa, 1, 0);
            barraConteudo.Controls.Add(btnAdicionar, 2, 0);

            barraSuperior.Controls.Add(barraConteudo);
            layout.Controls.Add(barraSuperior, 0, 0);

            // Painel dos cards
            painelCards = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                Padding = new Padding(20)
            };
            layout.Controls.Add(painelCards, 0, 1);
            this.Controls.Add(layout);

            // Carregar farmácias do banco
            using (var context = new Entities())
            {
                todasFarmacias = context.Farmacia
                    .Where(f => f.DonoEmail == Contas.Email)
                    .ToList();
            }

            MostrarCards(todasFarmacias);

            // Evento de clique no botão "Pesquisar"
            btnPesquisar.Click += (s, e) =>
            {
                string termo = txtPesquisa.Text.ToLower().Trim();
                var filtradas = todasFarmacias
                    .Where(f => f.Nome.ToLower().Contains(termo))
                    .ToList();
                MostrarCards(filtradas);
            };

        }

        private void MostrarCards(List<Farmacia> farmacias)
        {
            painelCards.Controls.Clear();

            if (farmacias == null || farmacias.Count == 0)
            {
                return;
            }

            foreach (var farmacia in farmacias)
            {
                Panel card = new Panel
                {
                    Width = 300,
                    Height = 160,
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10)
                };

                TableLayoutPanel cardLayout = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    RowCount = 2,
                    ColumnCount = 1
                };
                cardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
                cardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                card.Controls.Add(cardLayout);

                FlowLayoutPanel content = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.TopDown,
                    Dock = DockStyle.Fill,
                    Padding = new Padding(10),
                    WrapContents = false
                };

                var lblNome = new MaterialLabel
                {
                    Text = farmacia.Nome,
                    Font = new Font("Roboto", 12F, FontStyle.Bold),
                    AutoSize = true
                };

                var spacer = new Label { Height = 8, Width = 1 };

                var lblEndereco = new MaterialLabel
                {
                    Text = "Endereço: " + farmacia.Endereco,
                    FontType = MaterialSkin.MaterialSkinManager.fontType.Body2,
                    AutoSize = true
                };

                var lblEmail = new MaterialLabel
                {
                    Text = "Email: " + farmacia.Email,
                    FontType = MaterialSkin.MaterialSkinManager.fontType.Body2,
                    AutoSize = true
                };

                content.Controls.Add(lblNome);
                content.Controls.Add(spacer);
                content.Controls.Add(lblEndereco);
                content.Controls.Add(lblEmail);

                Panel btnPanel = new Panel
                {
                    Dock = DockStyle.Fill,
                    Padding = new Padding(0, 0, 10, 10)
                };

                var btnSelecionar = new MaterialButton
                {
                    Text = "Selecionar",
                    Tag = farmacia,
                    Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                    Dock = DockStyle.Right,
                    Width = 120,
                    Cursor = Cursors.Hand
                };
                btnSelecionar.Click += BtnSelecionar_Click;

                btnPanel.Controls.Add(btnSelecionar);
                cardLayout.Controls.Add(content, 0, 0);
                cardLayout.Controls.Add(btnPanel, 0, 1);

                painelCards.Controls.Add(card);
            }
            Theme.AplicarTema(this, Theme.TemaAtual);

        }

        private void BtnSelecionar_Click(object sender, EventArgs e)
        {
            if (sender is MaterialButton btn && btn.Tag is Farmacia farmacia)
            {
                Contas.Farmacia = farmacia.Id;
                var managerForm = new Manager();
                managerForm.Show();
                this.Hide();
            }
        }
        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            AdicionarFarmacia adicionarFarmacia = new AdicionarFarmacia();
            adicionarFarmacia.ShowDialog();
            CriarCardsFarmacias();
        }
    } 
}
