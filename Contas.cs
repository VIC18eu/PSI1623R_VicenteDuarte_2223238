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
        public static bool Login(string email, string password)
        {
            MessageBox.Show("Succeso ao Iniciar Sessão!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        public static bool CriarConta(string email, string password)
        {
            MessageBox.Show("Conta registada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

    }
}
