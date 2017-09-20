namespace hospitalcentral
{
    partial class frmPrintLicenciaMedica_Listado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintLicenciaMedica_Listado));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.rbPorFecha = new System.Windows.Forms.RadioButton();
            this.rbPorPersona = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.Size = new System.Drawing.Size(356, 22);
            this.lblTituloForm.Text = "Pantalla Genera Listado Licencias Medicas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 156;
            this.label1.Text = "HASTA:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 155;
            this.label3.Text = "DESDE:";
            // 
            // dtHasta
            // 
            this.dtHasta.Location = new System.Drawing.Point(97, 123);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(200, 20);
            this.dtHasta.TabIndex = 154;
            // 
            // dtDesde
            // 
            this.dtDesde.Location = new System.Drawing.Point(97, 85);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(200, 20);
            this.dtDesde.TabIndex = 153;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(329, 110);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(92, 45);
            this.btnSalir.TabIndex = 152;
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
            this.btnImprimir.Location = new System.Drawing.Point(329, 48);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(92, 45);
            this.btnImprimir.TabIndex = 151;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // rbPorFecha
            // 
            this.rbPorFecha.AutoSize = true;
            this.rbPorFecha.Checked = true;
            this.rbPorFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPorFecha.Location = new System.Drawing.Point(40, 48);
            this.rbPorFecha.Name = "rbPorFecha";
            this.rbPorFecha.Size = new System.Drawing.Size(97, 20);
            this.rbPorFecha.TabIndex = 157;
            this.rbPorFecha.TabStop = true;
            this.rbPorFecha.Text = "Por Fecha";
            this.rbPorFecha.UseVisualStyleBackColor = true;
            this.rbPorFecha.CheckedChanged += new System.EventHandler(this.rbPorFecha_CheckedChanged);
            // 
            // rbPorPersona
            // 
            this.rbPorPersona.AutoSize = true;
            this.rbPorPersona.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPorPersona.Location = new System.Drawing.Point(163, 48);
            this.rbPorPersona.Name = "rbPorPersona";
            this.rbPorPersona.Size = new System.Drawing.Size(112, 20);
            this.rbPorPersona.TabIndex = 158;
            this.rbPorPersona.Text = "Por Persona";
            this.rbPorPersona.UseVisualStyleBackColor = true;
            this.rbPorPersona.CheckedChanged += new System.EventHandler(this.rbPorPersona_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 159;
            this.label2.Text = "CEDULA:";
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(98, 167);
            this.txtCedula.Mask = "999-9999999-9";
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(89, 20);
            this.txtCedula.TabIndex = 160;
            // 
            // frmPrintLicenciaMedica_Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 217);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbPorPersona);
            this.Controls.Add(this.rbPorFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Name = "frmPrintLicenciaMedica_Listado";
            this.Text = "frmLicenciaMedica_Listado";
            this.Load += new System.EventHandler(this.frmPrintLicenciaMedica_Listado_Load);
            this.Controls.SetChildIndex(this.lblTituloForm, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.dtDesde, 0);
            this.Controls.SetChildIndex(this.dtHasta, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rbPorFecha, 0);
            this.Controls.SetChildIndex(this.rbPorPersona, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtCedula, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.RadioButton rbPorFecha;
        private System.Windows.Forms.RadioButton rbPorPersona;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtCedula;
    }
}