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

namespace ProjetoFinal
{
    public partial class Manager : MaterialForm
    {
        public Manager()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue800, Primary.Blue900, Primary.Blue800,
                Accent.Blue200, TextShade.WHITE);

            InitializeComponent();

            header.BackColor = Color.FromArgb(25, 118, 210);
            this.FormBorderStyle = FormBorderStyle.None;

            txtUser.Font = new Font("Arial", 12, FontStyle.Bold);
            txtUser.ForeColor = Color.White;
            txtUser.BackColor = Color.FromArgb(25, 118, 210);
            txtFarmacia.Font = new Font("Arial", 9, FontStyle.Bold);
            txtFarmacia.ForeColor = Color.White;
            txtFarmacia.BackColor = Color.FromArgb(25, 118, 210);

        }
    }
}
