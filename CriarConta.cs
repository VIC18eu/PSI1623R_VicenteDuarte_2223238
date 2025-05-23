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
using System.Text.RegularExpressions;


namespace ProjetoFinal
{
    public partial class CriarConta : MaterialForm
    {

        public CriarConta()
        {
            InitializeComponent();
            Theme.AplicarTema(this, Theme.TemaAtual);

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() == string.Empty || txtPassword.Text.Trim() == string.Empty || txtConfirmarPass.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Contas.ValidarEmail(txtUser.Text))
            {
                return;
            }
            if (txtPassword.Text.Trim() != txtConfirmarPass.Text.Trim())
            {
                MessageBox.Show("As passwords não correspondem!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Contas.CriarConta(txtUser.Text.Trim(), txtPassword.Text.Trim()))
            {
                this.Hide();              // Fecha o registo após fechar o login
                Form1 form1 = new Form1();
                form1.Show();        // Mostra o Form1 controladamente
                return;
            }


        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            this.Hide();    
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
