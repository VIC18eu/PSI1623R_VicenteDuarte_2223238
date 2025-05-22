using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Windows.Forms;

namespace ProjetoFinal
{
    internal class Theme
    {
        public static bool TemaAtual => ConfigManager.Configuracoes?.ModoEscuro ?? false;

        public static void AplicarTema(MaterialForm form, bool modoEscuro)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(form);
            materialSkinManager.Theme = modoEscuro ? MaterialSkinManager.Themes.DARK : MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue800, Primary.Blue900, Primary.Blue800,
                Accent.Blue200, TextShade.WHITE);
        }
    }
}
