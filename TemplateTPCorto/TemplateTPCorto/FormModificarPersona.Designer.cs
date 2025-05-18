namespace TemplateTPCorto
{
    partial class FormModificarPersona
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
            this.lblLegajo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.lblFechaIngreso = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.cmbPersonas = new System.Windows.Forms.ComboBox();
            this.lblUsuarios = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLegajo
            // 
            this.lblLegajo.AutoSize = true;
            this.lblLegajo.Location = new System.Drawing.Point(273, 36);
            this.lblLegajo.Name = "lblLegajo";
            this.lblLegajo.Size = new System.Drawing.Size(39, 13);
            this.lblLegajo.TabIndex = 0;
            this.lblLegajo.Text = "Legajo";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(34, 100);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(273, 100);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(34, 171);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(26, 13);
            this.lblDNI.TabIndex = 3;
            this.lblDNI.Text = "DNI";
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.AutoSize = true;
            this.lblFechaIngreso.Location = new System.Drawing.Point(273, 171);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(111, 13);
            this.lblFechaIngreso.TabIndex = 7;
            this.lblFechaIngreso.Text = "Fecha de Ingreso:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(37, 251);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(207, 35);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(276, 251);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(207, 35);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.Location = new System.Drawing.Point(276, 187);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(207, 20);
            this.dtpFechaIngreso.TabIndex = 10;
            // 
            // txtLegajo
            //
            this.txtLegajo.Location = new System.Drawing.Point(276, 52);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.ReadOnly = true;
            this.txtLegajo.Size = new System.Drawing.Size(207, 20);
            this.txtLegajo.TabIndex = 11;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(37, 117);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(207, 20);
            this.txtNombre.TabIndex = 12;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(276, 117);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(207, 20);
            this.txtApellido.TabIndex = 13;
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(37, 186);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(207, 20);
            this.txtDNI.TabIndex = 14;
            // 
            // cmbPersonas
            // 
            this.cmbPersonas.FormattingEnabled = true;
            this.cmbPersonas.Location = new System.Drawing.Point(37, 52);
            this.cmbPersonas.Name = "cmbPersonas";
            this.cmbPersonas.Size = new System.Drawing.Size(207, 21);
            this.cmbPersonas.TabIndex = 15;
            this.cmbPersonas.SelectedIndexChanged += new System.EventHandler(this.cmbPersonas_SelectedIndexChanged);
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.AutoSize = true;
            this.lblUsuarios.Location = new System.Drawing.Point(37, 35);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Size = new System.Drawing.Size(102, 13);
            this.lblUsuarios.TabIndex = 16;
            this.lblUsuarios.Text = "Seleccionar Usuario";
            // 
            // FormModificarPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 311);
            this.Controls.Add(this.lblUsuarios);
            this.Controls.Add(this.cmbPersonas);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtLegajo);
            this.Controls.Add(this.dtpFechaIngreso);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblFechaIngreso);
            this.Controls.Add(this.lblDNI);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblLegajo);
            this.Name = "FormModificarPersona";
            this.Text = "Modificar Persona";
            this.Load += new System.EventHandler(this.FormModificarPersona_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLegajo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label lblFechaIngreso;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.ComboBox cmbPersonas;
        private System.Windows.Forms.Label lblUsuarios;
    }
}