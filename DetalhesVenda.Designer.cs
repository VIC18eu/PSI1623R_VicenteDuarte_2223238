﻿using System.Windows.Forms;

namespace ProjetoFinal
{
    partial class DetalhesVenda
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
        private MaterialSkin.Controls.MaterialLabel lblId;
        private MaterialSkin.Controls.MaterialLabel lblCliente;
        private MaterialSkin.Controls.MaterialLabel lblTipo;
        private MaterialSkin.Controls.MaterialLabel lblData;
        private MaterialSkin.Controls.MaterialLabel lblTotal;
        private System.Windows.Forms.ListBox listBoxProdutos;

        private void InitializeComponent()
        {
            this.lblId = new MaterialSkin.Controls.MaterialLabel();
            this.lblCliente = new MaterialSkin.Controls.MaterialLabel();
            this.lblTipo = new MaterialSkin.Controls.MaterialLabel();
            this.lblData = new MaterialSkin.Controls.MaterialLabel();
            this.lblTotal = new MaterialSkin.Controls.MaterialLabel();
            this.listBoxProdutos = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Depth = 0;
            this.lblId.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblId.Location = new System.Drawing.Point(23, 85);
            this.lblId.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(73, 19);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID: (vazio)";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Depth = 0;
            this.lblCliente.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCliente.Location = new System.Drawing.Point(23, 117);
            this.lblCliente.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(106, 19);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente: (vazio)";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Depth = 0;
            this.lblTipo.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTipo.Location = new System.Drawing.Point(23, 149);
            this.lblTipo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(90, 19);
            this.lblTipo.TabIndex = 2;
            this.lblTipo.Text = "Tipo: (vazio)";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Depth = 0;
            this.lblData.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblData.Location = new System.Drawing.Point(23, 181);
            this.lblData.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(92, 19);
            this.lblData.TabIndex = 3;
            this.lblData.Text = "Data: (vazio)";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Depth = 0;
            this.lblTotal.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTotal.Location = new System.Drawing.Point(23, 213);
            this.lblTotal.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(95, 19);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Total: (vazio)";
            // 
            // listBoxProdutos
            // 
            this.listBoxProdutos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listBoxProdutos.FormattingEnabled = true;
            this.listBoxProdutos.ItemHeight = 23;
            this.listBoxProdutos.Location = new System.Drawing.Point(23, 256);
            this.listBoxProdutos.Name = "listBoxProdutos";
            this.listBoxProdutos.Size = new System.Drawing.Size(502, 165);
            this.listBoxProdutos.TabIndex = 5;
            // 
            // DetalhesVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 469);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.listBoxProdutos);
            this.MaximizeBox = false;
            this.Name = "DetalhesVenda";
            this.Padding = new System.Windows.Forms.Padding(3, 68, 3, 3);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalhes da Venda";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
    }
}