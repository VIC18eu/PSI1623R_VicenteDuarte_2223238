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
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(  
                Primary.Blue800, Primary.Blue900, Primary.Blue800,
                Accent.Blue200, TextShade.WHITE);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() == string.Empty || txtPassword.Text.Trim() == string.Empty || txtConfirmarPass.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtUser.Text != txtUser.Text.Trim() || txtUser.Text != txtUser.Text.ToLower())
            {
                MessageBox.Show("O email deve ter o formato correto!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtUser.Text, pattern))
            {
                MessageBox.Show("O email deve ter o formato correto (ex: exemplo@dominio.com)!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPassword.Text.Trim() != txtConfirmarPass.Text.Trim())
            {
                MessageBox.Show("As passwords não correspondem!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Contas.CriarConta(txtUser.Text.Trim(), txtPassword.Text.Trim()))
            {
                this.Close();              // Fecha o registo após fechar o login
                Form1 form1 = new Form1();
                form1.ShowDialog();        // Mostra o Form1 controladamente
                return;
            }


        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

    }
}
