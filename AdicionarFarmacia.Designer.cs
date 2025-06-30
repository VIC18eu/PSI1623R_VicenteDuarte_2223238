namespace ProjetoFinal
{
    partial class AdicionarFarmacia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdicionarFarmacia));
            this.txtNome = new MaterialSkin.Controls.MaterialTextBox();
            this.txtEndereco = new MaterialSkin.Controls.MaterialTextBox();
            this.txtEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.btnCriar = new MaterialSkin.Controls.MaterialButton();
            this.txtTelefone = new MaterialSkin.Controls.MaterialTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.AnimateReadOnly = false;
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNome.Depth = 0;
            this.txtNome.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtNome.Hint = "Nome da Farmácia";
            this.txtNome.LeadingIcon = null;
            this.txtNome.Location = new System.Drawing.Point(50, 120);
            this.txtNome.MaxLength = 50;
            this.txtNome.MouseState = MaterialSkin.MouseState.OUT;
            this.txtNome.Multiline = false;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(450, 50);
            this.txtNome.TabIndex = 0;
            this.txtNome.Text = "";
            this.txtNome.TrailingIcon = null;
            // 
            // txtEndereco
            // 
            this.txtEndereco.AnimateReadOnly = false;
            this.txtEndereco.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEndereco.Depth = 0;
            this.txtEndereco.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtEndereco.Hint = "Endereço da Farmácia";
            this.txtEndereco.LeadingIcon = null;
            this.txtEndereco.Location = new System.Drawing.Point(50, 200);
            this.txtEndereco.MaxLength = 100;
            this.txtEndereco.MouseState = MaterialSkin.MouseState.OUT;
            this.txtEndereco.Multiline = false;
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(450, 50);
            this.txtEndereco.TabIndex = 1;
            this.txtEndereco.Text = "";
            this.txtEndereco.TrailingIcon = null;
            // 
            // txtEmail
            // 
            this.txtEmail.AnimateReadOnly = false;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Depth = 0;
            this.txtEmail.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtEmail.Hint = "Email da Farmácia";
            this.txtEmail.LeadingIcon = null;
            this.txtEmail.Location = new System.Drawing.Point(50, 280);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.txtEmail.Multiline = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(450, 50);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.Text = "";
            this.txtEmail.TrailingIcon = null;
            // 
            // btnCriar
            // 
            this.btnCriar.AutoSize = false;
            this.btnCriar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCriar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCriar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCriar.Depth = 0;
            this.btnCriar.HighEmphasis = true;
            this.btnCriar.Icon = null;
            this.btnCriar.Location = new System.Drawing.Point(180, 470);
            this.btnCriar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCriar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCriar.Size = new System.Drawing.Size(180, 45);
            this.btnCriar.TabIndex = 3;
            this.btnCriar.Text = "Criar Farmácia";
            this.btnCriar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCriar.UseAccentColor = false;
            this.btnCriar.UseVisualStyleBackColor = true;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // txtTelefone
            // 
            this.txtTelefone.AnimateReadOnly = false;
            this.txtTelefone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelefone.Depth = 0;
            this.txtTelefone.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTelefone.Hint = "Telefone da Farmácia";
            this.txtTelefone.LeadingIcon = null;
            this.txtTelefone.Location = new System.Drawing.Point(50, 358);
            this.txtTelefone.MaxLength = 100;
            this.txtTelefone.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTelefone.Multiline = false;
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(450, 50);
            this.txtTelefone.TabIndex = 4;
            this.txtTelefone.Text = "";
            this.txtTelefone.TrailingIcon = null;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(617, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(331, 498);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // AdicionarFarmacia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(948, 578);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnCriar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AdicionarFarmacia";
            this.Padding = new System.Windows.Forms.Padding(0, 80, 0, 0);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criar nova Farmácia";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox txtNome;
        private MaterialSkin.Controls.MaterialTextBox txtEndereco;
        private MaterialSkin.Controls.MaterialTextBox txtEmail;
        private MaterialSkin.Controls.MaterialButton btnCriar;
        private MaterialSkin.Controls.MaterialTextBox txtTelefone;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}