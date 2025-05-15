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
        public static Image PUBLICFOTO;
        public static string Nome;
        public Perfil()
        {
            InitializeComponent();
            CarregarPerfil();
            Nome = txtNome.Text;
            PUBLICFOTO = ftPerfil.Image;
        }

        private void CarregarPerfil()
        {
            btnClose.UseVisualStyleBackColor = false;
            btnClose.BackColor = Color.Red;

            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.BackColor = Color.Green;
            btnSalvar.ForeColor = Color.Green;

            using (var context = new Entities())
            {
                var user = context.Utilizador.FirstOrDefault(u => u.Email == Contas.Email);

                if (user != null)
                {
                    this.Text = "Perfil de " + user.Nome;
                    lblEmail.Text = user.Email;
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

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Selecionar Imagem";
            openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ftPerfil.Image = Image.FromFile(openFileDialog.FileName);
                ftPerfil.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Nome = txtNome.Text;
            PUBLICFOTO = ftPerfil.Image;
            string nome = txtNome.Text;
            if (ftPerfil.Image == null)
            {
                MessageBox.Show("Nenhuma imagem carregada.");
                return;
            }

            string imagemBase64;
            using (MemoryStream ms = new MemoryStream())
            {
                ftPerfil.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();
                imagemBase64 = Convert.ToBase64String(imageBytes);
            }

            // Atualizar na BD
            using (var contexto = new Entities())
            {
                var pessoa = contexto.Utilizador.Find(lblEmail.Text);

                if (pessoa == null)
                {
                    MessageBox.Show("Pessoa não encontrada.");
                    return;
                }

                pessoa.Nome = nome;
                pessoa.Imagem = imagemBase64;

                contexto.SaveChanges();
                this.Close();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
