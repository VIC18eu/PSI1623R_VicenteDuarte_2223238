using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinal
{
    internal class Contas
    {
        public static string Email;
        public static string Farmacia;
        public static bool Login(string email, string password)
        {
            using (var context = new Entities())
            {
                var utilizador = context.Utilizador.FirstOrDefault(u => u.Email == email && u.PalavraPasse == password);

                if (utilizador != null)
                {
                    Email = email;
                    Farmacia = "Default";
                    MessageBox.Show("Sucesso ao Iniciar Sessão!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Credenciais inválidas!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
        }

        public static bool CriarConta(string email, string password)
        {
            using (var context = new Entities())
            {
                bool existe = context.Utilizador.Any(u => u.Email == email);

                if (existe)
                {
                    MessageBox.Show("Já existe uma conta com esse e-mail.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                var random = new Random();
                int numeroAleatorio = random.Next(1000, 9999);

                var novoUtilizador = new Utilizador
                {
                    Email = email,
                    PalavraPasse = password,
                    Nome = "user" + numeroAleatorio
                };

                context.Utilizador.Add(novoUtilizador);
                context.SaveChanges();

                MessageBox.Show("Conta registada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
        }


    }
}
