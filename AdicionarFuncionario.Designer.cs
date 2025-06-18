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
            this.txtPesquisaFuncionario.Location = new System.Drawing.Point(109, 116);
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
            this.txtCategoria.Location = new System.Drawing.Point(146, 285);
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
            this.btnConfirmar.Location = new System.Drawing.Point(68, 363);
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
            this.btnCancelar.Location = new System.Drawing.Point(445, 363);
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
            this.comboResultados.Location = new System.Drawing.Point(109, 201);
            this.comboResultados.MaxDropDownItems = 4;
            this.comboResultados.MouseState = MaterialSkin.MouseState.OUT;
            this.comboResultados.Name = "comboResultados";
            this.comboResultados.Size = new System.Drawing.Size(370, 49);
            this.comboResultados.StartIndex = 0;
            this.comboResultados.TabIndex = 1;
            // 
            // AdicionarFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 446);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}