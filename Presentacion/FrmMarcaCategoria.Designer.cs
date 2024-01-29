namespace Presentacion
{
    partial class FrmMarcaCategoria
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
            this.dgvMarcaCategoria = new System.Windows.Forms.DataGridView();
            this.btnAgregarMC = new System.Windows.Forms.Button();
            this.btnEliminarMC = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tbxMarCat = new System.Windows.Forms.TextBox();
            this.btnModificarMC = new System.Windows.Forms.Button();
            this.btnFiltrarMC = new System.Windows.Forms.Button();
            this.txbFiltroMC = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcaCategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMarcaCategoria
            // 
            this.dgvMarcaCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcaCategoria.Location = new System.Drawing.Point(31, 25);
            this.dgvMarcaCategoria.Name = "dgvMarcaCategoria";
            this.dgvMarcaCategoria.Size = new System.Drawing.Size(351, 158);
            this.dgvMarcaCategoria.TabIndex = 0;
            // 
            // btnAgregarMC
            // 
            this.btnAgregarMC.BackColor = System.Drawing.Color.RosyBrown;
            this.btnAgregarMC.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarMC.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAgregarMC.Location = new System.Drawing.Point(44, 249);
            this.btnAgregarMC.Name = "btnAgregarMC";
            this.btnAgregarMC.Size = new System.Drawing.Size(100, 44);
            this.btnAgregarMC.TabIndex = 1;
            this.btnAgregarMC.Text = "Agregar";
            this.btnAgregarMC.UseVisualStyleBackColor = false;
            this.btnAgregarMC.Click += new System.EventHandler(this.btnAgregarMC_Click);
            // 
            // btnEliminarMC
            // 
            this.btnEliminarMC.BackColor = System.Drawing.Color.RosyBrown;
            this.btnEliminarMC.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarMC.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnEliminarMC.Location = new System.Drawing.Point(157, 249);
            this.btnEliminarMC.Name = "btnEliminarMC";
            this.btnEliminarMC.Size = new System.Drawing.Size(100, 44);
            this.btnEliminarMC.TabIndex = 2;
            this.btnEliminarMC.Text = "Eliminar";
            this.btnEliminarMC.UseVisualStyleBackColor = false;
            this.btnEliminarMC.Click += new System.EventHandler(this.btnEliminarMC_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Black;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnCancelar.Location = new System.Drawing.Point(297, 335);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(113, 34);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tbxMarCat
            // 
            this.tbxMarCat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxMarCat.Location = new System.Drawing.Point(31, 223);
            this.tbxMarCat.Name = "tbxMarCat";
            this.tbxMarCat.Size = new System.Drawing.Size(351, 20);
            this.tbxMarCat.TabIndex = 4;
            // 
            // btnModificarMC
            // 
            this.btnModificarMC.BackColor = System.Drawing.Color.RosyBrown;
            this.btnModificarMC.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarMC.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnModificarMC.Location = new System.Drawing.Point(272, 249);
            this.btnModificarMC.Name = "btnModificarMC";
            this.btnModificarMC.Size = new System.Drawing.Size(100, 44);
            this.btnModificarMC.TabIndex = 5;
            this.btnModificarMC.Text = "Modificar";
            this.btnModificarMC.UseVisualStyleBackColor = false;
            this.btnModificarMC.Click += new System.EventHandler(this.btnModificarMC_Click);
            // 
            // btnFiltrarMC
            // 
            this.btnFiltrarMC.BackColor = System.Drawing.Color.Pink;
            this.btnFiltrarMC.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarMC.Location = new System.Drawing.Point(171, 335);
            this.btnFiltrarMC.Name = "btnFiltrarMC";
            this.btnFiltrarMC.Size = new System.Drawing.Size(113, 34);
            this.btnFiltrarMC.TabIndex = 6;
            this.btnFiltrarMC.Text = "Filtar";
            this.btnFiltrarMC.UseVisualStyleBackColor = false;
            this.btnFiltrarMC.Click += new System.EventHandler(this.btnFiltrarMC_Click);
            // 
            // txbFiltroMC
            // 
            this.txbFiltroMC.Location = new System.Drawing.Point(12, 343);
            this.txbFiltroMC.Name = "txbFiltroMC";
            this.txbFiltroMC.Size = new System.Drawing.Size(153, 20);
            this.txbFiltroMC.TabIndex = 7;
            // 
            // FrmMarcaCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(422, 376);
            this.Controls.Add(this.txbFiltroMC);
            this.Controls.Add(this.btnFiltrarMC);
            this.Controls.Add(this.btnModificarMC);
            this.Controls.Add(this.tbxMarCat);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminarMC);
            this.Controls.Add(this.btnAgregarMC);
            this.Controls.Add(this.dgvMarcaCategoria);
            this.Name = "FrmMarcaCategoria";
            this.Text = "Marca";
            this.Load += new System.EventHandler(this.FrmMarcaCategoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcaCategoria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMarcaCategoria;
        private System.Windows.Forms.Button btnAgregarMC;
        private System.Windows.Forms.Button btnEliminarMC;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox tbxMarCat;
        private System.Windows.Forms.Button btnModificarMC;
        private System.Windows.Forms.Button btnFiltrarMC;
        private System.Windows.Forms.TextBox txbFiltroMC;
    }
}