using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace ProjetoFinal
{
    public partial class FormEditarPreco : MaterialForm
    {
        public decimal NovoPreco { get; private set; }

        public FormEditarPreco(decimal precoAtual)
        {
            InitializeComponent();
            Theme.AplicarTema(this, ConfigManager.Configuracoes.ModoEscuro);
            txtPreco.Text = precoAtual.ToString("F2");
        }

        private void Cancelar(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPreco.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal novoPreco) && novoPreco >= 0)
            {
                NovoPreco = novoPreco;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Insira um preço válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
