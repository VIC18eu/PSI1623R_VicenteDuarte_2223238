namespace ProjetoFinal
{
    partial class AdicionarFuncionario
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
        private MaterialSkin.Controls.MaterialTextBox txtPesquisaFuncionario;
        private MaterialSkin.Controls.MaterialComboBox comboResultados;
        private MaterialSkin.Controls.MaterialTextBox txtCategoria;
        private MaterialSkin.Controls.MaterialButton btnConfirmar;
        private MaterialSkin.Controls.MaterialButton btnCancelar;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdicionarFuncionario));
            this.txtPesquisaFuncionario = new MaterialSkin.Controls.MaterialTextBox();
            this.txtCategoria = new MaterialSkin.Controls.MaterialTextBox();
            this.btnConfirmar = new MaterialSkin.Controls.MaterialButton();
            this.btnCancelar = new MaterialSkin.Controls.MaterialButton();
            this.comboResultados = new MaterialSkin.Controls.MaterialComboBox();
            this.pfpFuncionario = new System.Windows.Forms.PictureBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.lblNome = new MaterialSkin.Controls.MaterialLabel();
            this.lblEmail = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pfpFuncionario)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPesquisaFuncionario
            // 
            this.txtPesquisaFuncionario.AnimateReadOnly = false;
            this.txtPesquisaFuncionario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPesquisaFuncionario.Depth = 0;
            this.txtPesquisaFuncionario.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPesquisaFuncionario.Hint = "Procurar Funcionário";
            this.txtPesquisaFuncionario.LeadingIcon = null;
            this.txtPesquisaFuncionario.Location = new System.Drawing.Point(55, 153);
            this.txtPesquisaFuncionario.MaxLength = 100;
            this.txtPesquisaFuncionario.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPesquisaFuncionario.Multiline = false;
            this.txtPesquisaFuncionario.Name = "txtPesquisaFuncionario";
            this.txtPesquisaFuncionario.Size = new System.Drawing.Size(370, 50);
            this.txtPesquisaFuncionario.TabIndex = 0;
            this.txtPesquisaFuncionario.Text = "";
            this.txtPesquisaFuncionario.TrailingIcon = null;
            this.txtPesquisaFuncionario.TextChanged += new System.EventHandler(this.TxtPesquisaFuncionario_TextChanged);
            // 
            // txtCategoria
            // 
            this.txtCategoria.AnimateReadOnly = false;
            this.txtCategoria.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCategoria.Depth = 0;
            this.txtCategoria.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCategoria.Hint = "Categoria";
            this.txtCategoria.LeadingIcon = null;
            this.txtCategoria.Location = new System.Drawing.Point(571, 299);
            this.txtCategoria.MaxLength = 50;
            this.txtCategoria.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCategoria.Multiline = false;
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(300, 50);
            this.txtCategoria.TabIndex = 2;
            this.txtCategoria.Text = "";
            this.txtCategoria.TrailingIcon = null;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConfirmar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnConfirmar.Depth = 0;
            this.btnConfirmar.HighEmphasis = true;
            this.btnConfirmar.Icon = null;
            this.btnConfirmar.Location = new System.Drawing.Point(55, 381);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConfirmar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnConfirmar.Size = new System.Drawing.Size(105, 36);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnConfirmar.UseAccentColor = false;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancelar.Depth = 0;
            this.btnCancelar.HighEmphasis = true;
            this.btnCancelar.Icon = null;
            this.btnCancelar.Location = new System.Drawing.Point(339, 381);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancelar.Size = new System.Drawing.Size(96, 36);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnCancelar.UseAccentColor = false;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // comboResultados
            // 
            this.comboResultados.AutoResize = false;
            this.comboResultados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboResultados.Depth = 0;
            this.comboResultados.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboResultados.DropDownHeight = 174;
            this.comboResultados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboResultados.DropDownWidth = 300;
            this.comboResultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboResultados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboResultados.FormattingEnabled = true;
            this.comboResultados.Hint = "Selecionar Funcionário";
            this.comboResultados.IntegralHeight = false;
            this.comboResultados.ItemHeight = 43;
            this.comboResultados.Location = new System.Drawing.Point(55, 258);
            this.comboResultados.MaxDropDownItems = 4;
            this.comboResultados.MouseState = MaterialSkin.MouseState.OUT;
            this.comboResultados.Name = "comboResultados";
            this.comboResultados.Size = new System.Drawing.Size(370, 49);
            this.comboResultados.StartIndex = 0;
            this.comboResultados.TabIndex = 1;
            this.comboResultados.SelectedIndexChanged += new System.EventHandler(this.comboResultados_SelectedIndexChanged);
            // 
            // pfpFuncionario
            // 
            this.pfpFuncionario.Location = new System.Drawing.Point(571, 120);
            this.pfpFuncionario.Name = "pfpFuncionario";
            this.pfpFuncionario.Size = new System.Drawing.Size(150, 150);
            this.pfpFuncionario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pfpFuncionario.TabIndex = 5;
            this.pfpFuncionario.TabStop = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(742, 153);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(47, 19);
            this.materialLabel1.TabIndex = 6;
            this.materialLabel1.Text = "Nome:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(744, 230);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(45, 19);
            this.materialLabel2.TabIndex = 7;
            this.materialLabel2.Text = "Email:";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Depth = 0;
            this.lblNome.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNome.Location = new System.Drawing.Point(811, 153);
            this.lblNome.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(61, 19);
            this.lblNome.TabIndex = 8;
            this.lblNome.Text = "Nenhum";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Depth = 0;
            this.lblEmail.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblEmail.Location = new System.Drawing.Point(809, 229);
            this.lblEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(61, 19);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Nenhum";
            // 
            // AdicionarFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 458);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.pfpFuncionario);
            this.Controls.Add(this.txtPesquisaFuncionario);
            this.Controls.Add(this.comboResultados);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AdicionarFuncionario";
            this.Sizable = false;
            this.Text = "Adicionar Funcionário";
            ((System.ComponentModel.ISupportInitialize)(this.pfpFuncionario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pfpFuncionario;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel lblNome;
        private MaterialSkin.Controls.MaterialLabel lblEmail;
    }
}