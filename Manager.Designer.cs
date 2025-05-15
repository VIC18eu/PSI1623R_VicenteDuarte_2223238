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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manager));
            this.header = new System.Windows.Forms.Panel();
            this.ftPerfil = new System.Windows.Forms.PictureBox();
            this.txtFarmacia = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.Label();
            this.sidebar = new MaterialSkin.Controls.MaterialTabControl();
            this.home = new System.Windows.Forms.TabPage();
            this.reservas = new System.Windows.Forms.TabPage();
            this.stock = new System.Windows.Forms.TabPage();
            this.funcionarios = new System.Windows.Forms.TabPage();
            this.settings = new System.Windows.Forms.TabPage();
            this.sideBarImages = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ftPerfil)).BeginInit();
            this.sidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.header.Controls.Add(this.ftPerfil);
            this.header.Controls.Add(this.txtFarmacia);
            this.header.Controls.Add(this.txtUser);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 30);
            this.header.Margin = new System.Windows.Forms.Padding(4);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1667, 87);
            this.header.TabIndex = 1;
            // 
            // ftPerfil
            // 
            this.ftPerfil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ftPerfil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ftPerfil.Location = new System.Drawing.Point(1557, 25);
            this.ftPerfil.Name = "ftPerfil";
            this.ftPerfil.Size = new System.Drawing.Size(55, 50);
            this.ftPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ftPerfil.TabIndex = 2;
            this.ftPerfil.TabStop = false;
            this.ftPerfil.Click += new System.EventHandler(this.AbrirPerfil);
            // 
            // txtFarmacia
            // 
            this.txtFarmacia.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtFarmacia.AutoSize = true;
            this.txtFarmacia.Location = new System.Drawing.Point(1470, 53);
            this.txtFarmacia.Name = "txtFarmacia";
            this.txtFarmacia.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFarmacia.Size = new System.Drawing.Size(79, 16);
            this.txtFarmacia.TabIndex = 1;
            this.txtFarmacia.Text = "A carregar...";
            this.txtFarmacia.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.txtFarmacia.Click += new System.EventHandler(this.txtFarmacia_Click);
            // 
            // txtUser
            // 
            this.txtUser.AutoSize = true;
            this.txtUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtUser.Location = new System.Drawing.Point(1449, 27);
            this.txtUser.Name = "txtUser";
            this.txtUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 0;
            this.txtUser.Text = "A carregar...";
            this.txtUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtUser.Click += new System.EventHandler(this.AbrirPerfil);
            // 
            // sidebar
            // 
            this.sidebar.Controls.Add(this.home);
            this.sidebar.Controls.Add(this.reservas);
            this.sidebar.Controls.Add(this.stock);
            this.sidebar.Controls.Add(this.funcionarios);
            this.sidebar.Controls.Add(this.settings);
            this.sidebar.Depth = 0;
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sidebar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.sidebar.ImageList = this.sideBarImages;
            this.sidebar.Location = new System.Drawing.Point(0, 117);
            this.sidebar.Margin = new System.Windows.Forms.Padding(4);
            this.sidebar.MouseState = MaterialSkin.MouseState.HOVER;
            this.sidebar.Multiline = true;
            this.sidebar.Name = "sidebar";
            this.sidebar.SelectedIndex = 0;
            this.sidebar.Size = new System.Drawing.Size(1667, 714);
            this.sidebar.TabIndex = 2;
            // 
            // home
            // 
            this.home.ImageKey = "icons8-home-48.png";
            this.home.Location = new System.Drawing.Point(4, 47);
            this.home.Margin = new System.Windows.Forms.Padding(4);
            this.home.Name = "home";
            this.home.Padding = new System.Windows.Forms.Padding(4);
            this.home.Size = new System.Drawing.Size(1659, 663);
            this.home.TabIndex = 0;
            this.home.Text = "Inicio";
            this.home.UseVisualStyleBackColor = true;
            // 
            // reservas
            // 
            this.reservas.ImageKey = "icons8-calendar-48.png";
            this.reservas.Location = new System.Drawing.Point(4, 47);
            this.reservas.Margin = new System.Windows.Forms.Padding(4);
            this.reservas.Name = "reservas";
            this.reservas.Padding = new System.Windows.Forms.Padding(4);
            this.reservas.Size = new System.Drawing.Size(1659, 663);
            this.reservas.TabIndex = 1;
            this.reservas.Text = "Reservas";
            this.reservas.UseVisualStyleBackColor = true;
            // 
            // stock
            // 
            this.stock.ImageKey = "icons8-box-48.png";
            this.stock.Location = new System.Drawing.Point(4, 47);
            this.stock.Margin = new System.Windows.Forms.Padding(4);
            this.stock.Name = "stock";
            this.stock.Size = new System.Drawing.Size(1659, 663);
            this.stock.TabIndex = 2;
            this.stock.Text = "Stock";
            this.stock.UseVisualStyleBackColor = true;
            // 
            // funcionarios
            // 
            this.funcionarios.ImageKey = "icons8-contacts-48.png";
            this.funcionarios.Location = new System.Drawing.Point(4, 47);
            this.funcionarios.Margin = new System.Windows.Forms.Padding(4);
            this.funcionarios.Name = "funcionarios";
            this.funcionarios.Size = new System.Drawing.Size(1659, 663);
            this.funcionarios.TabIndex = 3;
            this.funcionarios.Text = "Funcionários";
            this.funcionarios.UseVisualStyleBackColor = true;
            // 
            // settings
            // 
            this.settings.ImageKey = "icons8-settings-48.png";
            this.settings.Location = new System.Drawing.Point(4, 47);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(1659, 663);
            this.settings.TabIndex = 4;
            this.settings.Text = "Definições";
            this.settings.UseVisualStyleBackColor = true;
            // 
            // sideBarImages
            // 
            this.sideBarImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("sideBarImages.ImageStream")));
            this.sideBarImages.TransparentColor = System.Drawing.Color.Transparent;
            this.sideBarImages.Images.SetKeyName(0, "icons8-box-48.png");
            this.sideBarImages.Images.SetKeyName(1, "icons8-calendar-48.png");
            this.sideBarImages.Images.SetKeyName(2, "icons8-contacts-48.png");
            this.sideBarImages.Images.SetKeyName(3, "icons8-home-48.png");
            this.sideBarImages.Images.SetKeyName(4, "icons8-settings-48.png");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 32);
            this.contextMenuStrip1.Click += new System.EventHandler(this.txtFarmacia_Click);
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1667, 831);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.header);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.sidebar;
            this.DrawerWidth = 250;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1200, 554);
            this.Name = "Manager";
            this.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ftPerfil)).EndInit();
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
        private System.Windows.Forms.ImageList sideBarImages;
        private System.Windows.Forms.TabPage settings;
        private System.Windows.Forms.Label txtUser;
        private System.Windows.Forms.Label txtFarmacia;
        private System.Windows.Forms.PictureBox ftPerfil;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}