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
using MaterialSkin.Controls;

namespace ProjetoFinal
{
    public partial class Perfil : MaterialForm
    {
        public Perfil()
        {

            InitializeComponent();
            CarregarPerfil();
        }

        private void CarregarPerfil()
        {
            btnClose.UseVisualStyleBackColor = false;
            btnClose.BackColor = Color.Red;

            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.BackColor = Color.Green;

            using (var context = new Entities())
            {
                var user = context.Utilizador.FirstOrDefault(u => u.Email == Contas.Email);

                if (user != null)
                {
                    this.Text = "Perfil de " + user.Nome;
                    lblEmail.Text = "Email: " + user.Email;
                    lblPassword.Text = "Password: ";
                    foreach (var item in user.PalavraPasse)
                    {
                        lblPassword.Text += "*";
                    }
                    txtNome.Text = user.Nome;

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

    }
}
