
namespace UI.Desktop
{
    partial class MateriaDesktop
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
            this.labelID = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtHs_Semanales = new System.Windows.Forms.TextBox();
            this.txtHs_Totales = new System.Windows.Forms.TextBox();
            this.txtID_Plan = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.labelHs_Semanales = new System.Windows.Forms.Label();
            this.labelHs_Totales = new System.Windows.Forms.Label();
            this.labelID_Plan = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.64398F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.35602F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.Controls.Add(this.labelID_Plan, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelHs_Totales, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelHs_Semanales, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtID_Plan, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelDescripcion, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtHs_Totales, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtHs_Semanales, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDescripcion, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelID, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.61111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.38889F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(372, 139);
            this.tableLayoutPanel1.TabIndex = 0;
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
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(98, 37);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(78, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(98, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(78, 20);
            this.txtID.TabIndex = 2;
            this.txtID.Text = "Autogenerado";
            // 
            // txtHs_Semanales
            // 
            this.txtHs_Semanales.Location = new System.Drawing.Point(98, 72);
            this.txtHs_Semanales.Name = "txtHs_Semanales";
            this.txtHs_Semanales.Size = new System.Drawing.Size(78, 20);
            this.txtHs_Semanales.TabIndex = 2;
            // 
            // txtHs_Totales
            // 
            this.txtHs_Totales.Location = new System.Drawing.Point(289, 3);
            this.txtHs_Totales.Name = "txtHs_Totales";
            this.txtHs_Totales.Size = new System.Drawing.Size(78, 20);
            this.txtHs_Totales.TabIndex = 2;
            // 
            // txtID_Plan
            // 
            this.txtID_Plan.Location = new System.Drawing.Point(289, 37);
            this.txtID_Plan.Name = "txtID_Plan";
            this.txtID_Plan.Size = new System.Drawing.Size(78, 20);
            this.txtID_Plan.TabIndex = 3;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(202, 106);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(289, 106);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Location = new System.Drawing.Point(3, 34);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(63, 13);
            this.labelDescripcion.TabIndex = 1;
            this.labelDescripcion.Text = "Descripcion";
            // 
            // labelHs_Semanales
            // 
            this.labelHs_Semanales.AutoSize = true;
            this.labelHs_Semanales.Location = new System.Drawing.Point(3, 69);
            this.labelHs_Semanales.Name = "labelHs_Semanales";
            this.labelHs_Semanales.Size = new System.Drawing.Size(88, 13);
            this.labelHs_Semanales.TabIndex = 2;
            this.labelHs_Semanales.Text = "Horas semanales";
            // 
            // labelHs_Totales
            // 
            this.labelHs_Totales.AutoSize = true;
            this.labelHs_Totales.Location = new System.Drawing.Point(202, 0);
            this.labelHs_Totales.Name = "labelHs_Totales";
            this.labelHs_Totales.Size = new System.Drawing.Size(69, 13);
            this.labelHs_Totales.TabIndex = 3;
            this.labelHs_Totales.Text = "Horas totales";
            // 
            // labelID_Plan
            // 
            this.labelID_Plan.AutoSize = true;
            this.labelID_Plan.Location = new System.Drawing.Point(202, 34);
            this.labelID_Plan.Name = "labelID_Plan";
            this.labelID_Plan.Size = new System.Drawing.Size(42, 13);
            this.labelID_Plan.TabIndex = 4;
            this.labelID_Plan.Text = "ID Plan";
            // 
            // MateriaDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 146);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MateriaDesktop";
            this.Text = "MateriaDesktop";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtID_Plan;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.TextBox txtHs_Totales;
        private System.Windows.Forms.TextBox txtHs_Semanales;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label labelHs_Semanales;
        private System.Windows.Forms.Label labelHs_Totales;
        private System.Windows.Forms.Label labelID_Plan;
    }
}