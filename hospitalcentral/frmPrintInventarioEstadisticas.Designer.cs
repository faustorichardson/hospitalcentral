namespace hospitalcentral
{
    partial class frmPrintInventarioEstadisticas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintInventarioEstadisticas));
            this.rbSalida = new System.Windows.Forms.RadioButton();
            this.rbEntrada = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.chkSenasa = new System.Windows.Forms.CheckBox();
            this.chkAccionCivica = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.Size = new System.Drawing.Size(415, 22);
            this.lblTituloForm.Text = "ESTADISTICAS DE INVENTARIO LABORATORIO";
            // 
            // rbSalida
            // 
            this.rbSalida.AutoSize = true;
            this.rbSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSalida.Location = new System.Drawing.Point(89, 86);
            this.rbSalida.Name = "rbSalida";
            this.rbSalida.Size = new System.Drawing.Size(69, 17);
            this.rbSalida.TabIndex = 172;
            this.rbSalida.Text = "SALIDA";
            this.rbSalida.UseVisualStyleBackColor = true;
            // 
            // rbEntrada
            // 
            this.rbEntrada.AutoSize = true;
            this.rbEntrada.Checked = true;
            this.rbEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEntrada.Location = new System.Drawing.Point(89, 50);
            this.rbEntrada.Name = "rbEntrada";
            this.rbEntrada.Size = new System.Drawing.Size(84, 17);
            this.rbEntrada.TabIndex = 171;
            this.rbEntrada.TabStop = true;
            this.rbEntrada.Text = "ENTRADA";
            this.rbEntrada.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 170;
            this.label1.Text = "HASTA:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 169;
            this.label3.Text = "DESDE:";
            // 
            // dtHasta
            // 
            this.dtHasta.Location = new System.Drawing.Point(91, 175);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(200, 20);
            this.dtHasta.TabIndex = 168;
            // 
            // dtDesde
            // 
            this.dtDesde.Location = new System.Drawing.Point(91, 131);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(200, 20);
            this.dtDesde.TabIndex = 167;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(338, 141);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(92, 45);
            this.btnSalir.TabIndex = 166;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(338, 79);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(92, 45);
            this.btnImprimir.TabIndex = 165;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // chkSenasa
            // 
            this.chkSenasa.AutoSize = true;
            this.chkSenasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSenasa.Location = new System.Drawing.Point(187, 50);
            this.chkSenasa.Name = "chkSenasa";
            this.chkSenasa.Size = new System.Drawing.Size(75, 17);
            this.chkSenasa.TabIndex = 173;
            this.chkSenasa.Text = "SENASA";
            this.chkSenasa.UseVisualStyleBackColor = true;
            // 
            // chkAccionCivica
            // 
            this.chkAccionCivica.AutoSize = true;
            this.chkAccionCivica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAccionCivica.Location = new System.Drawing.Point(187, 86);
            this.chkAccionCivica.Name = "chkAccionCivica";
            this.chkAccionCivica.Size = new System.Drawing.Size(116, 17);
            this.chkAccionCivica.TabIndex = 174;
            this.chkAccionCivica.Text = "ACCION CIVICA";
            this.chkAccionCivica.UseVisualStyleBackColor = true;
            // 
            // frmPrintInventarioEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 232);
            this.Controls.Add(this.chkAccionCivica);
            this.Controls.Add(this.chkSenasa);
            this.Controls.Add(this.rbSalida);
            this.Controls.Add(this.rbEntrada);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Name = "frmPrintInventarioEstadisticas";
            this.Text = "frmPrintInventarioEstadisticas";
            this.Load += new System.EventHandler(this.frmPrintInventarioEstadisticas_Load);
            this.Controls.SetChildIndex(this.lblTituloForm, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.dtDesde, 0);
            this.Controls.SetChildIndex(this.dtHasta, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rbEntrada, 0);
            this.Controls.SetChildIndex(this.rbSalida, 0);
            this.Controls.SetChildIndex(this.chkSenasa, 0);
            this.Controls.SetChildIndex(this.chkAccionCivica, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbSalida;
        private System.Windows.Forms.RadioButton rbEntrada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.CheckBox chkSenasa;
        private System.Windows.Forms.CheckBox chkAccionCivica;
    }
}