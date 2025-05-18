namespace TemplateTPCorto
{
    partial class FormDesbloquearCredencial
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
            this.btnBuscarDC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLegajoDC = new System.Windows.Forms.TextBox();
            this.lblUsuarioDC = new System.Windows.Forms.Label();
            this.txtUsuarioDC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDC = new System.Windows.Forms.Button();
            this.lblAsignarDC = new System.Windows.Forms.Label();
            this.txtNuevaContraseñaDC = new System.Windows.Forms.TextBox();
            this.btnSalirDC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBuscarDC
            // 
            this.btnBuscarDC.Location = new System.Drawing.Point(280, 126);
            this.btnBuscarDC.Name = "btnBuscarDC";
            this.btnBuscarDC.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarDC.TabIndex = 0;
            this.btnBuscarDC.Text = "Buscar";
            this.btnBuscarDC.UseVisualStyleBackColor = true;
            this.btnBuscarDC.Click += new System.EventHandler(this.btnBuscarDC_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Legajo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtLegajoDC
            // 
            this.txtLegajoDC.Location = new System.Drawing.Point(172, 61);
            this.txtLegajoDC.Name = "txtLegajoDC";
            this.txtLegajoDC.Size = new System.Drawing.Size(100, 22);
            this.txtLegajoDC.TabIndex = 2;
            // 
            // lblUsuarioDC
            // 
            this.lblUsuarioDC.AutoSize = true;
            this.lblUsuarioDC.Location = new System.Drawing.Point(356, 61);
            this.lblUsuarioDC.Name = "lblUsuarioDC";
            this.lblUsuarioDC.Size = new System.Drawing.Size(54, 16);
            this.lblUsuarioDC.TabIndex = 3;
            this.lblUsuarioDC.Text = "Usuario";
            // 
            // txtUsuarioDC
            // 
            this.txtUsuarioDC.Location = new System.Drawing.Point(453, 61);
            this.txtUsuarioDC.Name = "txtUsuarioDC";
            this.txtUsuarioDC.Size = new System.Drawing.Size(100, 22);
            this.txtUsuarioDC.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(399, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // btnDC
            // 
            this.btnDC.Location = new System.Drawing.Point(280, 319);
            this.btnDC.Name = "btnDC";
            this.btnDC.Size = new System.Drawing.Size(130, 53);
            this.btnDC.TabIndex = 7;
            this.btnDC.Text = "Desbloquear Credencial";
            this.btnDC.UseVisualStyleBackColor = true;
            this.btnDC.Click += new System.EventHandler(this.btnDC_Click);
            // 
            // lblAsignarDC
            // 
            this.lblAsignarDC.AutoSize = true;
            this.lblAsignarDC.Location = new System.Drawing.Point(132, 260);
            this.lblAsignarDC.Name = "lblAsignarDC";
            this.lblAsignarDC.Size = new System.Drawing.Size(168, 16);
            this.lblAsignarDC.TabIndex = 8;
            this.lblAsignarDC.Text = "Asignar Nueva Contraseña";
            // 
            // txtNuevaContraseñaDC
            // 
            this.txtNuevaContraseñaDC.Location = new System.Drawing.Point(359, 257);
            this.txtNuevaContraseñaDC.Name = "txtNuevaContraseñaDC";
            this.txtNuevaContraseñaDC.Size = new System.Drawing.Size(100, 22);
            this.txtNuevaContraseñaDC.TabIndex = 9;
            // 
            // btnSalirDC
            // 
            this.btnSalirDC.Location = new System.Drawing.Point(577, 319);
            this.btnSalirDC.Name = "btnSalirDC";
            this.btnSalirDC.Size = new System.Drawing.Size(130, 53);
            this.btnSalirDC.TabIndex = 10;
            this.btnSalirDC.Text = "Salir";
            this.btnSalirDC.UseVisualStyleBackColor = true;
            this.btnSalirDC.Click += new System.EventHandler(this.btnSalirDC_Click);
            // 
            // FormDesbloquearCredencial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalirDC);
            this.Controls.Add(this.txtNuevaContraseñaDC);
            this.Controls.Add(this.lblAsignarDC);
            this.Controls.Add(this.btnDC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsuarioDC);
            this.Controls.Add(this.lblUsuarioDC);
            this.Controls.Add(this.txtLegajoDC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscarDC);
            this.Name = "FormDesbloquearCredencial";
            this.Text = "FormDesbloquearCredencial";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarDC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLegajoDC;
        private System.Windows.Forms.Label lblUsuarioDC;
        private System.Windows.Forms.TextBox txtUsuarioDC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDC;
        private System.Windows.Forms.Label lblAsignarDC;
        private System.Windows.Forms.TextBox txtNuevaContraseñaDC;
        private System.Windows.Forms.Button btnSalirDC;
    }
}