
namespace UI.Desktop
{
    partial class UsuarioDesktop
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
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelConfirmarClave = new System.Windows.Forms.Label();
            this.labelClave = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtConfirmarClave = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.checkBoxHabilitado = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.76786F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.23214F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 336F));
            this.tableLayoutPanel1.Controls.Add(this.labelUsuario, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelApellido, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelConfirmarClave, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelClave, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtEmail, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelEmail, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtNombre, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtUsuario, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelNombre, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtApellido, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtClave, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtConfirmarClave, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxHabilitado, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.4375F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.5625F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(644, 193);
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
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(3, 31);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 2;
            this.labelNombre.Text = "Nombre";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Location = new System.Drawing.Point(222, 31);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(44, 13);
            this.labelApellido.TabIndex = 3;
            this.labelApellido.Text = "Apellido";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(3, 64);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(32, 13);
            this.labelEmail.TabIndex = 4;
            this.labelEmail.Text = "Email";
            // 
            // labelConfirmarClave
            // 
            this.labelConfirmarClave.AutoSize = true;
            this.labelConfirmarClave.Location = new System.Drawing.Point(222, 95);
            this.labelConfirmarClave.Name = "labelConfirmarClave";
            this.labelConfirmarClave.Size = new System.Drawing.Size(78, 13);
            this.labelConfirmarClave.TabIndex = 5;
            this.labelConfirmarClave.Text = "Confimar Clave";
            // 
            // labelClave
            // 
            this.labelClave.AutoSize = true;
            this.labelClave.Location = new System.Drawing.Point(3, 95);
            this.labelClave.Name = "labelClave";
            this.labelClave.Size = new System.Drawing.Size(34, 13);
            this.labelClave.TabIndex = 6;
            this.labelClave.Text = "Clave";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Location = new System.Drawing.Point(222, 64);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(43, 13);
            this.labelUsuario.TabIndex = 8;
            this.labelUsuario.Text = "Usuario";
            this.labelUsuario.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(53, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(163, 20);
            this.txtID.TabIndex = 9;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(53, 34);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(163, 20);
            this.txtNombre.TabIndex = 10;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(310, 34);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(163, 20);
            this.txtApellido.TabIndex = 11;
            // 
            // txtConfirmarClave
            // 
            this.txtConfirmarClave.Location = new System.Drawing.Point(310, 98);
            this.txtConfirmarClave.Name = "txtConfirmarClave";
            this.txtConfirmarClave.Size = new System.Drawing.Size(163, 20);
            this.txtConfirmarClave.TabIndex = 12;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(53, 67);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(163, 20);
            this.txtEmail.TabIndex = 13;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(310, 67);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(163, 20);
            this.txtUsuario.TabIndex = 14;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(53, 98);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(163, 20);
            this.txtClave.TabIndex = 15;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(222, 130);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 16;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(310, 130);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // checkBoxHabilitado
            // 
            this.checkBoxHabilitado.AutoSize = true;
            this.checkBoxHabilitado.Location = new System.Drawing.Point(222, 3);
            this.checkBoxHabilitado.Name = "checkBoxHabilitado";
            this.checkBoxHabilitado.Size = new System.Drawing.Size(73, 17);
            this.checkBoxHabilitado.TabIndex = 18;
            this.checkBoxHabilitado.Text = "Habilitado";
            this.checkBoxHabilitado.UseVisualStyleBackColor = true;
            this.checkBoxHabilitado.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // UsuarioDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 158);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UsuarioDesktop";
            this.Text = "Usuario";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelConfirmarClave;
        private System.Windows.Forms.Label labelClave;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtConfirmarClave;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox checkBoxHabilitado;
    }
}