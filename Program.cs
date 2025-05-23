using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoFinal.Properties;

namespace ProjetoFinal
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConfigManager.Carregar();

            var settings = ConfigManager.Load(); // Ex: método que lê o JSON

            if (settings.ManterSessaoIniciada && !string.IsNullOrEmpty(settings.UtilizadorAtual))
            {
                // Ir diretamente para o formulário principal
                Contas.Email = settings.UtilizadorAtual;
                Application.Run(new Farmacias());
            }
            else
            {
                // Mostrar login
                Application.Run(new Form1());
            }
        }
    }
}
