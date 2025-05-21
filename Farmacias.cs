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
        }
        private void CriarCardsFarmacias()
        {
            this.Padding = new Padding(0, 64, 0, 0); // 64px é a altura da titlebar

            // Layout principal
            TableLayoutPanel layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1,
                BackColor = this.BackColor
            };
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60)); // barra superior
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // cards

            // Painel superior com botão e pesquisa
            Panel barraSuperior = new Panel
            {
                Dock = DockStyle.Fill,
                Height = 100,
                Padding = new Padding(20, 10, 20, 0),
                BackColor = this.BackColor
            };

            // Caixa de pesquisa
            TextBox txtPesquisa = new TextBox
            {
                Width = 350,
                Font = new Font("Segoe UI", 15F),
                Margin = new Padding(0, 0, 0, 0)
            };

            // Botão "Adicionar" estilo Material
            MaterialButton btnAdicionar = new MaterialButton
            {
                Text = "Adicionar",
                Dock = DockStyle.None,
                Anchor = AnchorStyles.Right,
                AutoSize = false,
                Width = 120,
                HighEmphasis = true,
                Margin = new Padding(0)
            };
            btnAdicionar.Click += BtnAdicionar_Click;

            // Layout da barra: pesquisa à esquerda, botão à direita
            TableLayoutPanel barraConteudo = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
            };
            barraConteudo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F)); // pesquisa
            barraConteudo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F)); // botão
            barraConteudo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1F)); // preenchimento

            barraConteudo.Controls.Add(txtPesquisa, 0, 0);
            barraConteudo.Controls.Add(btnAdicionar, 1, 0);

            barraSuperior.Controls.Add(barraConteudo);
            layout.Controls.Add(barraSuperior, 0, 0);

            // Painel de conteúdo (cards)
            FlowLayoutPanel painel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                Padding = new Padding(20)
            };
            layout.Controls.Add(painel, 0, 1);
            this.Controls.Add(layout);


            using (var context = new Entities())
            {
                var farmacias = context.Farmacia.Where(f => f.DonoEmail == Contas.Email).ToList();

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

                    // Container principal dentro do card
                    TableLayoutPanel cardLayout = new TableLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        RowCount = 2,
                        ColumnCount = 1
                    };
                    cardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 75F)); // conteúdo
                    cardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F)); // botão
                    card.Controls.Add(cardLayout);

                    // Conteúdo do card
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

                    var spacer = new Label
                    {
                        Height = 8,
                        Width = 1 // não importa, é só espaçamento vertical
                    };

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

                    // Botão alinhado à direita
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

                    painel.Controls.Add(card);
                }
            }
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
            CriarCardsFarmacias();
        }
    } 
}
