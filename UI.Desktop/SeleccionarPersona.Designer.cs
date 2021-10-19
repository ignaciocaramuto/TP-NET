
namespace UI.Desktop
{
    partial class SeleccionarPersona
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
            this.cbxTipoPersona = new System.Windows.Forms.ComboBox();
            this.dgvSeleccionarPersona = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccionarPersona)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxTipoPersona
            // 
            this.cbxTipoPersona.FormattingEnabled = true;
            this.cbxTipoPersona.Items.AddRange(new object[] {
            "Todos",
            "Alumnos",
            "Docentes",
            "No docentes"});
            this.cbxTipoPersona.Location = new System.Drawing.Point(0, 0);
            this.cbxTipoPersona.Name = "cbxTipoPersona";
            this.cbxTipoPersona.Size = new System.Drawing.Size(121, 21);
            this.cbxTipoPersona.TabIndex = 0;
            this.cbxTipoPersona.Text = "Mostrar:";
            // 
            // dgvSeleccionarPersona
            // 
            this.dgvSeleccionarPersona.AllowUserToAddRows = false;
            this.dgvSeleccionarPersona.AllowUserToDeleteRows = false;
            this.dgvSeleccionarPersona.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSeleccionarPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeleccionarPersona.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.apellido,
            this.nombre,
            this.TipoPersona});
            this.dgvSeleccionarPersona.Location = new System.Drawing.Point(3, 32);
            this.dgvSeleccionarPersona.MultiSelect = false;
            this.dgvSeleccionarPersona.Name = "dgvSeleccionarPersona";
            this.dgvSeleccionarPersona.ReadOnly = true;
            this.dgvSeleccionarPersona.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeleccionarPersona.Size = new System.Drawing.Size(354, 263);
            this.dgvSeleccionarPersona.TabIndex = 1;
            // 
            // id
            // 
            this.id.DataPropertyName = "ID";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // apellido
            // 
            this.apellido.DataPropertyName = "Apellido";
            this.apellido.HeaderText = "Apellido";
            this.apellido.Name = "apellido";
            this.apellido.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "Nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // TipoPersona
            // 
            this.TipoPersona.DataPropertyName = "DescTipoPersona";
            this.TipoPersona.HeaderText = "TipoPersona";
            this.TipoPersona.Name = "TipoPersona";
            this.TipoPersona.ReadOnly = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(201, 301);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(282, 301);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // SeleccionarPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 328);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvSeleccionarPersona);
            this.Controls.Add(this.cbxTipoPersona);
            this.Name = "SeleccionarPersona";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccionarPersona)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxTipoPersona;
        private System.Windows.Forms.DataGridView dgvSeleccionarPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoPersona;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
    }
}