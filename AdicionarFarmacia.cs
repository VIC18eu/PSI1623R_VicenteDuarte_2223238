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
    public partial class AdicionarFarmacia : MaterialForm
    {
        public AdicionarFarmacia()
        {
            InitializeComponent();
            Theme.AplicarTema(this, Theme.TemaAtual);
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string endereco = txtEndereco.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Verifica se os campos estão preenchidos
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(endereco) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Preencha todos os campos.", "Campos obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Contas.ValidarEmail(email))
            {
                return;
            }

            try
            {
                using (var context = new Entities())
                {
                    var novaFarmacia = new Farmacia
                    {
                        Nome = nome,
                        Endereco = endereco,
                        Email = email,
                        DonoEmail = Contas.Email
                    };

                    context.Farmacia.Add(novaFarmacia);
                    context.SaveChanges();
                }

                MessageBox.Show("Farmácia criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Fecha o modal
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar a farmácia: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
