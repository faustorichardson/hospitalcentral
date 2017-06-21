namespace hospitalcentral
{
    partial class frmPrintCitasMedicas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintCitasMedicas));
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.txtRecord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkPorRecord = new System.Windows.Forms.RadioButton();
            this.chkPorEspecialidad = new System.Windows.Forms.RadioButton();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this.chkTodos = new System.Windows.Forms.RadioButton();
            this.dtCitaMedicaDesde = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtCitaMedicaHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.Size = new System.Drawing.Size(275, 22);
            this.lblTituloForm.Text = "Gestion Impresion Citas Medicas";
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(384, 144);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(92, 45);
            this.btnSalir.TabIndex = 13;
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
            this.btnImprimir.Location = new System.Drawing.Point(384, 76);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(92, 45);
            this.btnImprimir.TabIndex = 12;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // txtRecord
            // 
            this.txtRecord.Location = new System.Drawing.Point(121, 306);
            this.txtRecord.MaxLength = 11;
            this.txtRecord.Name = "txtRecord";
            this.txtRecord.Size = new System.Drawing.Size(144, 20);
            this.txtRecord.TabIndex = 159;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 160;
            this.label1.Text = "RECORD #:";
            // 
            // chkPorRecord
            // 
            this.chkPorRecord.AutoSize = true;
            this.chkPorRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPorRecord.Location = new System.Drawing.Point(39, 276);
            this.chkPorRecord.Name = "chkPorRecord";
            this.chkPorRecord.Size = new System.Drawing.Size(97, 19);
            this.chkPorRecord.TabIndex = 161;
            this.chkPorRecord.Text = "Por Record";
            this.chkPorRecord.UseVisualStyleBackColor = true;
            // 
            // chkPorEspecialidad
            // 
            this.chkPorEspecialidad.AutoSize = true;
            this.chkPorEspecialidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPorEspecialidad.Location = new System.Drawing.Point(38, 209);
            this.chkPorEspecialidad.Name = "chkPorEspecialidad";
            this.chkPorEspecialidad.Size = new System.Drawing.Size(134, 19);
            this.chkPorEspecialidad.TabIndex = 162;
            this.chkPorEspecialidad.Text = "Por Especialidad";
            this.chkPorEspecialidad.UseVisualStyleBackColor = true;
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEspecialidad.FormattingEnabled = true;
            this.cmbEspecialidad.Location = new System.Drawing.Point(38, 240);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(293, 23);
            this.cmbEspecialidad.TabIndex = 176;
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Checked = true;
            this.chkTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTodos.Location = new System.Drawing.Point(38, 177);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(64, 19);
            this.chkTodos.TabIndex = 177;
            this.chkTodos.TabStop = true;
            this.chkTodos.Text = "Todos";
            this.chkTodos.UseVisualStyleBackColor = true;
            // 
            // dtCitaMedicaDesde
            // 
            this.dtCitaMedicaDesde.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtCitaMedicaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtCitaMedicaDesde.Location = new System.Drawing.Point(77, 85);
            this.dtCitaMedicaDesde.Name = "dtCitaMedicaDesde";
            this.dtCitaMedicaDesde.Size = new System.Drawing.Size(276, 22);
            this.dtCitaMedicaDesde.TabIndex = 179;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 16);
            this.label6.TabIndex = 178;
            this.label6.Text = "FECHA CITA:";
            // 
            // dtCitaMedicaHasta
            // 
            this.dtCitaMedicaHasta.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtCitaMedicaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtCitaMedicaHasta.Location = new System.Drawing.Point(77, 127);
            this.dtCitaMedicaHasta.Name = "dtCitaMedicaHasta";
            this.dtCitaMedicaHasta.Size = new System.Drawing.Size(276, 22);
            this.dtCitaMedicaHasta.TabIndex = 180;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 181;
            this.label2.Text = "DEL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 16);
            this.label3.TabIndex = 182;
            this.label3.Text = "AL:";
            // 
            // frmPrintCitasMedicas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 354);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtCitaMedicaHasta);
            this.Controls.Add(this.dtCitaMedicaDesde);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkTodos);
            this.Controls.Add(this.cmbEspecialidad);
            this.Controls.Add(this.chkPorEspecialidad);
            this.Controls.Add(this.chkPorRecord);
            this.Controls.Add(this.txtRecord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Name = "frmPrintCitasMedicas";
            this.Text = "frmPrintCitasMedicas";
            this.Load += new System.EventHandler(this.frmPrintCitasMedicas_Load);
            this.Controls.SetChildIndex(this.lblTituloForm, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtRecord, 0);
            this.Controls.SetChildIndex(this.chkPorRecord, 0);
            this.Controls.SetChildIndex(this.chkPorEspecialidad, 0);
            this.Controls.SetChildIndex(this.cmbEspecialidad, 0);
            this.Controls.SetChildIndex(this.chkTodos, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.dtCitaMedicaDesde, 0);
            this.Controls.SetChildIndex(this.dtCitaMedicaHasta, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TextBox txtRecord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton chkPorRecord;
        private System.Windows.Forms.RadioButton chkPorEspecialidad;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.RadioButton chkTodos;
        private System.Windows.Forms.DateTimePicker dtCitaMedicaDesde;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtCitaMedicaHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}