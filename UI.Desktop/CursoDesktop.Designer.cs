
namespace UI.Desktop
{
    partial class CursoDesktop
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtIDComision = new System.Windows.Forms.TextBox();
            this.labelIDComision = new System.Windows.Forms.Label();
            this.txtIDMateria = new System.Windows.Forms.TextBox();
            this.labelIDMateria = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.labelAñoCalendario = new System.Windows.Forms.Label();
            this.txtAñoCalendario = new System.Windows.Forms.TextBox();
            this.labelCupo = new System.Windows.Forms.Label();
            this.txtCupo = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.88172F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.11828F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtIDComision, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelIDComision, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtIDMateria, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelIDMateria, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelAñoCalendario, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAñoCalendario, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelCupo, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtCupo, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.4375F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.5625F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(435, 192);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(52, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(129, 20);
            this.txtID.TabIndex = 0;
            this.txtID.Text = "Autogenerado";
            // 
            // txtIDComision
            // 
            this.txtIDComision.Location = new System.Drawing.Point(52, 88);
            this.txtIDComision.Name = "txtIDComision";
            this.txtIDComision.Size = new System.Drawing.Size(129, 20);
            this.txtIDComision.TabIndex = 2;
            // 
            // labelIDComision
            // 
            this.labelIDComision.AutoSize = true;
            this.labelIDComision.Location = new System.Drawing.Point(3, 85);
            this.labelIDComision.Name = "labelIDComision";
            this.labelIDComision.Size = new System.Drawing.Size(43, 39);
            this.labelIDComision.TabIndex = 4;
            this.labelIDComision.Text = "ID Comisión";
            // 
            // txtIDMateria
            // 
            this.txtIDMateria.Location = new System.Drawing.Point(52, 44);
            this.txtIDMateria.Name = "txtIDMateria";
            this.txtIDMateria.Size = new System.Drawing.Size(129, 20);
            this.txtIDMateria.TabIndex = 1;
            // 
            // labelIDMateria
            // 
            this.labelIDMateria.AutoSize = true;
            this.labelIDMateria.Location = new System.Drawing.Point(3, 41);
            this.labelIDMateria.Name = "labelIDMateria";
            this.labelIDMateria.Size = new System.Drawing.Size(42, 26);
            this.labelIDMateria.TabIndex = 2;
            this.labelIDMateria.Text = "ID Materia";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(3, 0);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(18, 13);
            this.labelID.TabIndex = 1;
            this.labelID.Text = "ID";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(187, 140);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(272, 140);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelAñoCalendario
            // 
            this.labelAñoCalendario.AutoSize = true;
            this.labelAñoCalendario.Location = new System.Drawing.Point(187, 0);
            this.labelAñoCalendario.Name = "labelAñoCalendario";
            this.labelAñoCalendario.Size = new System.Drawing.Size(78, 13);
            this.labelAñoCalendario.TabIndex = 3;
            this.labelAñoCalendario.Text = "Año calendario";
            // 
            // txtAñoCalendario
            // 
            this.txtAñoCalendario.Location = new System.Drawing.Point(272, 3);
            this.txtAñoCalendario.Name = "txtAñoCalendario";
            this.txtAñoCalendario.Size = new System.Drawing.Size(148, 20);
            this.txtAñoCalendario.TabIndex = 3;
            // 
            // labelCupo
            // 
            this.labelCupo.AutoSize = true;
            this.labelCupo.Location = new System.Drawing.Point(187, 41);
            this.labelCupo.Name = "labelCupo";
            this.labelCupo.Size = new System.Drawing.Size(32, 13);
            this.labelCupo.TabIndex = 8;
            this.labelCupo.Text = "Cupo";
            // 
            // txtCupo
            // 
            this.txtCupo.Location = new System.Drawing.Point(272, 44);
            this.txtCupo.Name = "txtCupo";
            this.txtCupo.Size = new System.Drawing.Size(148, 20);
            this.txtCupo.TabIndex = 4;
            // 
            // CursoDesktop
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 217);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CursoDesktop";
            this.Text = "CursoDesktop";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelCupo;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label labelAñoCalendario;
        private System.Windows.Forms.TextBox txtIDComision;
        private System.Windows.Forms.Label labelIDComision;
        private System.Windows.Forms.TextBox txtIDMateria;
        private System.Windows.Forms.Label labelIDMateria;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtAñoCalendario;
        private System.Windows.Forms.TextBox txtCupo;
    }
}