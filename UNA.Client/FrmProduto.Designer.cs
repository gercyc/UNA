namespace UNA.Client
{
    partial class FrmProduto
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
            this.gridProdutos = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtNumChamado = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.IdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescricaoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ncm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdUnidadeMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodUnidadeMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescricaoCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // gridProdutos
            // 
            this.gridProdutos.AllowUserToAddRows = false;
            this.gridProdutos.AllowUserToDeleteRows = false;
            this.gridProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProduto,
            this.CodigoProduto,
            this.DescricaoProduto,
            this.Ncm,
            this.IdUnidadeMedida,
            this.CodUnidadeMedida,
            this.IdCategoria,
            this.DescricaoCategoria});
            this.gridProdutos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.gridProdutos.Location = new System.Drawing.Point(12, 23);
            this.gridProdutos.Name = "gridProdutos";
            this.gridProdutos.Size = new System.Drawing.Size(810, 341);
            this.gridProdutos.TabIndex = 0;
            this.gridProdutos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridProdutos_CellMouseDoubleClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(753, 370);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(69, 29);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtNumChamado
            // 
            this.txtNumChamado.Location = new System.Drawing.Point(556, 375);
            this.txtNumChamado.Name = "txtNumChamado";
            this.txtNumChamado.Size = new System.Drawing.Size(100, 20);
            this.txtNumChamado.TabIndex = 2;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(678, 370);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(69, 29);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(12, 375);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(69, 29);
            this.btnNovo.TabIndex = 4;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(87, 375);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 29);
            this.button2.TabIndex = 5;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // IdProduto
            // 
            this.IdProduto.DataPropertyName = "IdProduto";
            this.IdProduto.HeaderText = "IdProduto";
            this.IdProduto.Name = "IdProduto";
            this.IdProduto.Visible = false;
            // 
            // CodigoProduto
            // 
            this.CodigoProduto.DataPropertyName = "CodigoProduto";
            this.CodigoProduto.HeaderText = "Código";
            this.CodigoProduto.Name = "CodigoProduto";
            // 
            // DescricaoProduto
            // 
            this.DescricaoProduto.DataPropertyName = "DescricaoProduto";
            this.DescricaoProduto.HeaderText = "Descrição";
            this.DescricaoProduto.Name = "DescricaoProduto";
            // 
            // Ncm
            // 
            this.Ncm.DataPropertyName = "Ncm";
            this.Ncm.HeaderText = "NCM";
            this.Ncm.Name = "Ncm";
            // 
            // IdUnidadeMedida
            // 
            this.IdUnidadeMedida.DataPropertyName = "IdUnidadeMedida";
            this.IdUnidadeMedida.HeaderText = "IdUnidadeMedida";
            this.IdUnidadeMedida.Name = "IdUnidadeMedida";
            this.IdUnidadeMedida.Visible = false;
            // 
            // CodUnidadeMedida
            // 
            this.CodUnidadeMedida.DataPropertyName = "CodUnidadeMedida";
            this.CodUnidadeMedida.HeaderText = "Unidade de Medida";
            this.CodUnidadeMedida.Name = "CodUnidadeMedida";
            // 
            // IdCategoria
            // 
            this.IdCategoria.DataPropertyName = "IdCategoria";
            this.IdCategoria.HeaderText = "IdCategoria";
            this.IdCategoria.Name = "IdCategoria";
            this.IdCategoria.Visible = false;
            // 
            // DescricaoCategoria
            // 
            this.DescricaoCategoria.DataPropertyName = "DescricaoCategoria";
            this.DescricaoCategoria.HeaderText = "Categoria";
            this.DescricaoCategoria.Name = "DescricaoCategoria";
            // 
            // FrmProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 411);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtNumChamado);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.gridProdutos);
            this.Name = "FrmProduto";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmProduto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridProdutos;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtNumChamado;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ncm;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdUnidadeMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodUnidadeMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoCategoria;
    }
}

