namespace ProjetoFinal
{
    partial class Manager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.header = new System.Windows.Forms.Panel();
            this.sidebar = new MaterialSkin.Controls.MaterialTabControl();
            this.home = new System.Windows.Forms.TabPage();
            this.reservas = new System.Windows.Forms.TabPage();
            this.stock = new System.Windows.Forms.TabPage();
            this.funcionarios = new System.Windows.Forms.TabPage();
            this.sidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 24);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1250, 71);
            this.header.TabIndex = 1;
            // 
            // sidebar
            // 
            this.sidebar.Controls.Add(this.home);
            this.sidebar.Controls.Add(this.reservas);
            this.sidebar.Controls.Add(this.stock);
            this.sidebar.Controls.Add(this.funcionarios);
            this.sidebar.Depth = 0;
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sidebar.Location = new System.Drawing.Point(0, 95);
            this.sidebar.MouseState = MaterialSkin.MouseState.HOVER;
            this.sidebar.Multiline = true;
            this.sidebar.Name = "sidebar";
            this.sidebar.SelectedIndex = 0;
            this.sidebar.Size = new System.Drawing.Size(1250, 580);
            this.sidebar.TabIndex = 2;
            // 
            // home
            // 
            this.home.Location = new System.Drawing.Point(4, 22);
            this.home.Name = "home";
            this.home.Padding = new System.Windows.Forms.Padding(3);
            this.home.Size = new System.Drawing.Size(1242, 554);
            this.home.TabIndex = 0;
            this.home.Text = "Inicio";
            this.home.UseVisualStyleBackColor = true;
            // 
            // reservas
            // 
            this.reservas.Location = new System.Drawing.Point(4, 22);
            this.reservas.Name = "reservas";
            this.reservas.Padding = new System.Windows.Forms.Padding(3);
            this.reservas.Size = new System.Drawing.Size(1242, 554);
            this.reservas.TabIndex = 1;
            this.reservas.Text = "Reservas";
            this.reservas.UseVisualStyleBackColor = true;
            // 
            // stock
            // 
            this.stock.Location = new System.Drawing.Point(4, 22);
            this.stock.Name = "stock";
            this.stock.Size = new System.Drawing.Size(1242, 554);
            this.stock.TabIndex = 2;
            this.stock.Text = "Stock";
            this.stock.UseVisualStyleBackColor = true;
            // 
            // funcionarios
            // 
            this.funcionarios.Location = new System.Drawing.Point(4, 22);
            this.funcionarios.Name = "funcionarios";
            this.funcionarios.Size = new System.Drawing.Size(1242, 554);
            this.funcionarios.TabIndex = 3;
            this.funcionarios.Text = "Funcionários";
            this.funcionarios.UseVisualStyleBackColor = true;
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 675);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.header);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.sidebar;
            this.DrawerWidth = 250;
            this.MinimumSize = new System.Drawing.Size(900, 450);
            this.Name = "Manager";
            this.Padding = new System.Windows.Forms.Padding(0, 24, 0, 0);
            this.sidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel header;
        private MaterialSkin.Controls.MaterialTabControl sidebar;
        private System.Windows.Forms.TabPage home;
        private System.Windows.Forms.TabPage reservas;
        private System.Windows.Forms.TabPage stock;
        private System.Windows.Forms.TabPage funcionarios;
    }
}