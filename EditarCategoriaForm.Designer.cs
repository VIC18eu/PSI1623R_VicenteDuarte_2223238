using System.Windows.Forms;
using MaterialSkin.Controls;

namespace ProjetoFinal
{
    partial class EditarCategoriaForm
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
        private MaterialLabel lblTitulo;
        private MaterialTextBox2 txtCategoria;
        private MaterialButton btnConfirmar;
        private MaterialButton btnCancelar;

        private void InitializeComponent()
        {
            this.lblTitulo = new MaterialSkin.Controls.MaterialLabel();
            this.txtCategoria = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnConfirmar = new MaterialSkin.Controls.MaterialButton();
            this.btnCancelar = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Depth = 0;
            this.lblTitulo.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitulo.Location = new System.Drawing.Point(67, 112);
            this.lblTitulo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(114, 19);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Nova Categoria:";
            // 
            // txtCategoria
            // 
            this.txtCategoria.AnimateReadOnly = false;
            this.txtCategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtCategoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCategoria.Depth = 0;
            this.txtCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtCategoria.HideSelection = true;
            this.txtCategoria.LeadingIcon = null;
            this.txtCategoria.Location = new System.Drawing.Point(70, 149);
            this.txtCategoria.MaxLength = 50;
            this.txtCategoria.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.PasswordChar = '\0';
            this.txtCategoria.PrefixSuffixText = null;
            this.txtCategoria.ReadOnly = false;
            this.txtCategoria.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCategoria.SelectedText = "";
            this.txtCategoria.SelectionLength = 0;
            this.txtCategoria.SelectionStart = 0;
            this.txtCategoria.ShortcutsEnabled = true;
            this.txtCategoria.Size = new System.Drawing.Size(400, 48);
            this.txtCategoria.TabIndex = 1;
            this.txtCategoria.TabStop = false;
            this.txtCategoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCategoria.TrailingIcon = null;
            this.txtCategoria.UseSystemPasswordChar = false;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.AutoSize = false;
            this.btnConfirmar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConfirmar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnConfirmar.Depth = 0;
            this.btnConfirmar.HighEmphasis = true;
            this.btnConfirmar.Icon = null;
            this.btnConfirmar.Location = new System.Drawing.Point(150, 250);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConfirmar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnConfirmar.Size = new System.Drawing.Size(120, 36);
            this.btnConfirmar.TabIndex = 2;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnConfirmar.UseAccentColor = false;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            this.btnConfirmar.Cursor = Cursors.Hand;

            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = false;
            this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancelar.Depth = 0;
            this.btnCancelar.HighEmphasis = false;
            this.btnCancelar.Icon = null;
            this.btnCancelar.Location = new System.Drawing.Point(290, 250);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancelar.Size = new System.Drawing.Size(120, 36);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnCancelar.UseAccentColor = false;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.Cursor = Cursors.Hand;
            // 
            // EditarCategoriaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 313);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.lblTitulo);
            this.MaximizeBox = false;
            this.Name = "EditarCategoriaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Categoria";
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        #endregion
    }
}