using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoFinal
{
    partial class FormEditarPreco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditarPreco));
            this.btnConfirmar = new MaterialSkin.Controls.MaterialButton();
            this.btnCancelar = new MaterialSkin.Controls.MaterialButton();
            this.txtPreco = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConfirmar.AutoSize = false;
            this.btnConfirmar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnConfirmar.Depth = 0;
            this.btnConfirmar.HighEmphasis = true;
            this.btnConfirmar.Icon = null;
            this.btnConfirmar.Location = new System.Drawing.Point(180, 230);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConfirmar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnConfirmar.Size = new System.Drawing.Size(120, 36);
            this.btnConfirmar.TabIndex = 2;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnConfirmar.UseAccentColor = true;
            this.btnConfirmar.Click += new EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelar.AutoSize = false;
            this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancelar.Depth = 0;
            this.btnCancelar.HighEmphasis = true;
            this.btnCancelar.Icon = null;
            this.btnCancelar.Location = new System.Drawing.Point(340, 230);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancelar.Size = new System.Drawing.Size(120, 36);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnCancelar.UseAccentColor = false;
            this.btnCancelar.Click += new EventHandler(this.Cancelar);
            // 
            // txtPreco
            // 
            this.txtPreco.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPreco.AnimateReadOnly = false;
            this.txtPreco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtPreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPreco.Depth = 0;
            this.txtPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPreco.HideSelection = true;
            this.txtPreco.Hint = "Insira o novo preço...";
            this.txtPreco.LeadingIcon = null;
            this.txtPreco.Location = new System.Drawing.Point(160, 129);
            this.txtPreco.MaxLength = 10;
            this.txtPreco.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.PasswordChar = '\0';
            this.txtPreco.PrefixSuffixText = null;
            this.txtPreco.ReadOnly = false;
            this.txtPreco.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPreco.SelectedText = "";
            this.txtPreco.SelectionLength = 0;
            this.txtPreco.SelectionStart = 0;
            this.txtPreco.ShortcutsEnabled = true;
            this.txtPreco.Size = new System.Drawing.Size(320, 48);
            this.txtPreco.TabIndex = 0;
            this.txtPreco.TabStop = false;
            this.txtPreco.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPreco.TrailingIcon = null;
            this.txtPreco.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(160, 95);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(86, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Novo Preço:";
            // 
            // FormEditarPreco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 320);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormEditarPreco";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alterar Preço do Medicamento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private MaterialSkin.Controls.MaterialButton btnConfirmar;
        private MaterialSkin.Controls.MaterialButton btnCancelar;
        private MaterialSkin.Controls.MaterialTextBox2 txtPreco;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}