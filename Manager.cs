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

namespace ProjetoFinal
{
    public partial class Manager : MaterialForm
    {
        public Manager()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue800, Primary.Blue900, Primary.Blue800,
                Accent.Blue200, TextShade.WHITE);

            InitializeComponent();

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

        }
        private void CarregarPerfil()
        {
            using (var context = new Entities())
            {
                var user = context.Utilizador.FirstOrDefault(u => u.Email == Contas.Email);

                if (user != null)
                {
                    txtUser.Text = user.Nome;
                    txtFarmacia.Text = Contas.Farmacia;

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
            AjustarTxtUser();
        }

        private void AjustarTxtUser()
        {
            // Largura máxima disponível antes da imagem
            int maxRight = ftPerfil.Left - 10; // deixa um pequeno espaço de 10px

            // Medir a largura que o texto vai ocupar
            using (Graphics g = txtUser.CreateGraphics())
            {
                SizeF textSize = g.MeasureString(txtUser.Text, txtUser.Font);

                // Calcula a nova posição Left para a label, para que o lado direito fique alinhado em maxRight
                int newLeft = (int)(maxRight - textSize.Width);

                if (newLeft < 0) newLeft = 0; // Evita sair da tela

                txtUser.Left = newLeft;

                // Ajusta a largura da label para o texto
                txtUser.Width = (int)textSize.Width;
            }
        }

        private void txtFarmacia_Click(object sender, EventArgs e)
        {

        }
    }
}
