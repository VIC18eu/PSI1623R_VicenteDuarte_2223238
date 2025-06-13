using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace ProjetoFinal
{
    public partial class EditarCategoriaForm : MaterialForm
    {
        public string NovaCategoria { get; private set; }

        public EditarCategoriaForm(string categoriaAtual)
        {
            InitializeComponent();
            Theme.AplicarTema(this, ConfigManager.Configuracoes.ModoEscuro);
            txtCategoria.Text = categoriaAtual;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            NovaCategoria = txtCategoria.Text.Trim();

            if (string.IsNullOrWhiteSpace(NovaCategoria))
            {
                MessageBox.Show("A categoria não pode estar vazia.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
