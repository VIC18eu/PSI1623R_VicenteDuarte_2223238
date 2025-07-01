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
    public partial class AdicionarFuncionario : MaterialForm
    {
        public AdicionarFuncionario()
        {
            InitializeComponent();
            Theme.AplicarTema(this, ConfigManager.Configuracoes.ModoEscuro);
            CarregarFuncionarios();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (comboResultados.SelectedItem == null)
            {
                MessageBox.Show("Selecione um funcionário da lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string categoria = txtCategoria.Text.Trim();
            if (string.IsNullOrEmpty(categoria))
            {
                MessageBox.Show("Insira a categoria do funcionário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Extrair o email da string "Nome (email)"
            string selecionado = comboResultados.SelectedItem.ToString();
            string email = selecionado.Substring(selecionado.LastIndexOf('(') + 1).TrimEnd(')');

            // Substitui este valor pelo FarmaciaId da farmácia atualmente logada/selecionada
            int farmaciaId = Contas.Farmacia;

            try
            {
                using (var context = new Entities())
                {
                    // Verifica se já existe esse funcionário na farmácia
                    bool jaExiste = context.Funcionario.Any(f => f.EmailUtilizador == email && f.FarmaciaId == farmaciaId);

                    if (jaExiste)
                    {
                        MessageBox.Show("Este funcionário já está associado a esta farmácia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var novoFuncionario = new Funcionario
                    {
                        EmailUtilizador = email,
                        FarmaciaId = farmaciaId,
                        Categoria = categoria
                    };

                    context.Funcionario.Add(novoFuncionario);
                    context.SaveChanges();

                    MessageBox.Show("Funcionário adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar funcionário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private List<Utilizador> todosFuncionarios = new List<Utilizador>();

        private void CarregarFuncionarios()
        {
            try
            {
                using (var context = new Entities())
                {
                    int farmaciaId = Contas.Farmacia;

                    var emailsFuncionariosExistentes = context.Funcionario
                        .Where(f => f.FarmaciaId == farmaciaId)
                        .Select(f => f.EmailUtilizador)
                        .ToList();

                    todosFuncionarios = context.Utilizador
                        .Where(u => !emailsFuncionariosExistentes.Contains(u.Email) && u.Email != Contas.Email)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar funcionários: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtPesquisaFuncionario_TextChanged(object sender, EventArgs e)
        {
            string textoPesquisa = txtPesquisaFuncionario.Text.ToLower();

            var resultadosFiltrados = todosFuncionarios
                .Where(u => u.Nome.ToLower().Contains(textoPesquisa) || u.Email.ToLower().Contains(textoPesquisa))
                .ToList();

            comboResultados.Items.Clear();

            foreach (var utilizador in resultadosFiltrados)
            {
                comboResultados.Items.Add($"{utilizador.Nome} ({utilizador.Email})");
            }

            if (comboResultados.Items.Count > 0) comboResultados.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboResultados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selecionado = comboResultados.SelectedItem.ToString();
            string email = selecionado.Substring(selecionado.LastIndexOf('(') + 1).TrimEnd(')');

            using (var entities = new Entities())
            {
                var utilizador = entities.Utilizador.FirstOrDefault(u => u.Email == email);

                if (utilizador != null)
                {
                    lblEmail.Text = utilizador.Email;
                    lblNome.Text = utilizador.Nome;

                    if (!string.IsNullOrEmpty(utilizador.Imagem))
                    {
                        try
                        {
                            byte[] imageBytes = Convert.FromBase64String(utilizador.Imagem);
                            using (var ms = new MemoryStream(imageBytes))
                            {
                                pfpFuncionario.Image = Image.FromStream(ms);
                            }
                        }
                        catch
                        {
                            pfpFuncionario.Image = Properties.Resources.pfpDefault;
                        }
                    }
                    else
                    {
                        pfpFuncionario.Image = Properties.Resources.pfpDefault;
                    }
                }
            }
        }

    }
}
