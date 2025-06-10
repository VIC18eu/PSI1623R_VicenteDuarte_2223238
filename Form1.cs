using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinal
{
    public partial class Form1 : MaterialForm
    {

        public Form1()
        {
            InitializeComponent();
            Theme.AplicarTema(this, Theme.TemaAtual);
            lblCriarConta.Location = new Point((this.ClientSize.Width - lblCriarConta.Width) / 2, lblCriarConta.Location.Y);
        }

        private void lblCriarConta_Click(object sender, EventArgs e)
        {
            this.Hide();
            CriarConta criarConta = new CriarConta();
            criarConta.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() == string.Empty || txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Contas.Login(txtUser.Text, txtPassword.Text))
            {
                this.Hide();
                Farmacias farmacias = new Farmacias();
                farmacias.Show();
            }
        }
    }
}
