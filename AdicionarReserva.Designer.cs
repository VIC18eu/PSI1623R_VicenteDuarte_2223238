namespace ProjetoFinal
{
    partial class AdicionarReserva
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
        private MaterialSkin.Controls.MaterialLabel lblCliente;
        private MaterialSkin.Controls.MaterialLabel lblProdutos;
        private MaterialSkin.Controls.MaterialTextBox txtCliente;
        private MaterialSkin.Controls.MaterialTextBox txtQuantidade; // NOVO
        private MaterialSkin.Controls.MaterialComboBox cmbMedicamento; // NOVO

        // ListBox
        private System.Windows.Forms.ListBox listProdutos;

        // Botões
        private MaterialSkin.Controls.MaterialButton btnAdicionarProduto; // NOVO
        private MaterialSkin.Controls.MaterialButton btnRemoverProduto; // NOVO
        private MaterialSkin.Controls.MaterialButton btnGuardar;


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdicionarReserva));
            this.lblCliente = new MaterialSkin.Controls.MaterialLabel();
            this.lblProdutos = new MaterialSkin.Controls.MaterialLabel();
            this.txtCliente = new MaterialSkin.Controls.MaterialTextBox();
            this.cmbMedicamento = new MaterialSkin.Controls.MaterialComboBox();
            this.txtQuantidade = new MaterialSkin.Controls.MaterialTextBox();
            this.listProdutos = new System.Windows.Forms.ListBox();
            this.btnAdicionarProduto = new MaterialSkin.Controls.MaterialButton();
            this.btnRemoverProduto = new MaterialSkin.Controls.MaterialButton();
            this.btnGuardar = new MaterialSkin.Controls.MaterialButton();
            this.lblTipo = new MaterialSkin.Controls.MaterialLabel();
            this.txtDataReserva = new MaterialSkin.Controls.MaterialTextBox();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Depth = 0;
            this.lblCliente.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCliente.Location = new System.Drawing.Point(30, 259);
            this.lblCliente.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(121, 19);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.Text = "Nome do Cliente:";
            // 
            // lblProdutos
            // 
            this.lblProdutos.AutoSize = true;
            this.lblProdutos.Depth = 0;
            this.lblProdutos.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblProdutos.Location = new System.Drawing.Point(23, 471);
            this.lblProdutos.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblProdutos.Name = "lblProdutos";
            this.lblProdutos.Size = new System.Drawing.Size(155, 19);
            this.lblProdutos.TabIndex = 6;
            this.lblProdutos.Text = "Produtos Comprados:";
            // 
            // txtCliente
            // 
            this.txtCliente.AnimateReadOnly = false;
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCliente.Depth = 0;
            this.txtCliente.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCliente.Hint = "Ex: João Silva";
            this.txtCliente.LeadingIcon = null;
            this.txtCliente.Location = new System.Drawing.Point(28, 281);
            this.txtCliente.MaxLength = 50;
            this.txtCliente.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCliente.Multiline = false;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(400, 50);
            this.txtCliente.TabIndex = 5;
            this.txtCliente.Text = "";
            this.txtCliente.TrailingIcon = null;
            // 
            // cmbMedicamento
            // 
            this.cmbMedicamento.AutoResize = false;
            this.cmbMedicamento.BackColor = System.Drawing.Color.White;
            this.cmbMedicamento.Depth = 0;
            this.cmbMedicamento.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbMedicamento.DropDownHeight = 174;
            this.cmbMedicamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedicamento.DropDownWidth = 121;
            this.cmbMedicamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbMedicamento.ForeColor = System.Drawing.Color.Black;
            this.cmbMedicamento.IntegralHeight = false;
            this.cmbMedicamento.ItemHeight = 43;
            this.cmbMedicamento.Location = new System.Drawing.Point(26, 383);
            this.cmbMedicamento.MaxDropDownItems = 4;
            this.cmbMedicamento.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbMedicamento.Name = "cmbMedicamento";
            this.cmbMedicamento.Size = new System.Drawing.Size(252, 49);
            this.cmbMedicamento.StartIndex = 0;
            this.cmbMedicamento.TabIndex = 6;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.AnimateReadOnly = false;
            this.txtQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuantidade.Depth = 0;
            this.txtQuantidade.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtQuantidade.Hint = "Qtd";
            this.txtQuantidade.LeadingIcon = null;
            this.txtQuantidade.Location = new System.Drawing.Point(289, 383);
            this.txtQuantidade.MaxLength = 5;
            this.txtQuantidade.MouseState = MaterialSkin.MouseState.OUT;
            this.txtQuantidade.Multiline = false;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(100, 50);
            this.txtQuantidade.TabIndex = 7;
            this.txtQuantidade.Text = "";
            this.txtQuantidade.TrailingIcon = null;
            // 
            // listProdutos
            // 
            this.listProdutos.ItemHeight = 16;
            this.listProdutos.Location = new System.Drawing.Point(26, 499);
            this.listProdutos.Name = "listProdutos";
            this.listProdutos.Size = new System.Drawing.Size(454, 100);
            this.listProdutos.TabIndex = 8;
            // 
            // btnAdicionarProduto
            // 
            this.btnAdicionarProduto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdicionarProduto.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAdicionarProduto.Depth = 0;
            this.btnAdicionarProduto.HighEmphasis = true;
            this.btnAdicionarProduto.Icon = null;
            this.btnAdicionarProduto.Location = new System.Drawing.Point(396, 390);
            this.btnAdicionarProduto.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAdicionarProduto.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdicionarProduto.Name = "btnAdicionarProduto";
            this.btnAdicionarProduto.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAdicionarProduto.Size = new System.Drawing.Size(98, 36);
            this.btnAdicionarProduto.TabIndex = 9;
            this.btnAdicionarProduto.Text = "Adicionar";
            this.btnAdicionarProduto.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAdicionarProduto.UseAccentColor = false;
            this.btnAdicionarProduto.Click += new System.EventHandler(this.BtnAdicionarProduto_Click);
            // 
            // btnRemoverProduto
            // 
            this.btnRemoverProduto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemoverProduto.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRemoverProduto.Depth = 0;
            this.btnRemoverProduto.HighEmphasis = true;
            this.btnRemoverProduto.Icon = null;
            this.btnRemoverProduto.Location = new System.Drawing.Point(487, 523);
            this.btnRemoverProduto.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRemoverProduto.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRemoverProduto.Name = "btnRemoverProduto";
            this.btnRemoverProduto.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRemoverProduto.Size = new System.Drawing.Size(64, 36);
            this.btnRemoverProduto.TabIndex = 10;
            this.btnRemoverProduto.Text = "X";
            this.btnRemoverProduto.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRemoverProduto.UseAccentColor = false;
            this.btnRemoverProduto.Click += new System.EventHandler(this.BtnRemoverProduto_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGuardar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnGuardar.Depth = 0;
            this.btnGuardar.HighEmphasis = true;
            this.btnGuardar.Icon = null;
            this.btnGuardar.Location = new System.Drawing.Point(388, 650);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnGuardar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnGuardar.Size = new System.Drawing.Size(140, 36);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar Venda";
            this.btnGuardar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnGuardar.UseAccentColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Depth = 0;
            this.lblTipo.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTipo.Location = new System.Drawing.Point(30, 124);
            this.lblTipo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(121, 19);
            this.lblTipo.TabIndex = 2;
            this.lblTipo.Text = "Data de Recolha:";
            // 
            // txtDataReserva
            // 
            this.txtDataReserva.AnimateReadOnly = false;
            this.txtDataReserva.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDataReserva.Depth = 0;
            this.txtDataReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDataReserva.Hint = "Ex: DD/MM/AAAA";
            this.txtDataReserva.LeadingIcon = null;
            this.txtDataReserva.Location = new System.Drawing.Point(27, 150);
            this.txtDataReserva.MaxLength = 50;
            this.txtDataReserva.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDataReserva.Multiline = false;
            this.txtDataReserva.Name = "txtDataReserva";
            this.txtDataReserva.Size = new System.Drawing.Size(400, 50);
            this.txtDataReserva.TabIndex = 12;
            this.txtDataReserva.Text = "";
            this.txtDataReserva.TrailingIcon = null;
            // 
            // AdicionarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 725);
            this.Controls.Add(this.txtDataReserva);
            this.Controls.Add(this.btnRemoverProduto);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblProdutos);
            this.Controls.Add(this.cmbMedicamento);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.listProdutos);
            this.Controls.Add(this.btnAdicionarProduto);
            this.Controls.Add(this.btnGuardar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AdicionarReserva";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Nova Venda";
            this.ResumeLayout(false);
            this.PerformLayout();

        }




        #endregion

        private MaterialSkin.Controls.MaterialLabel lblTipo;
        private MaterialSkin.Controls.MaterialTextBox txtDataReserva;
    }
}