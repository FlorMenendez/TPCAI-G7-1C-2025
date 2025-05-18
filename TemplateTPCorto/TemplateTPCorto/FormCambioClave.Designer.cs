namespace TemplateTPCorto
{
    partial class FormCambioClave
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
            this.lblNuevaClave = new System.Windows.Forms.Label();
            this.txtNuevaClave = new System.Windows.Forms.TextBox();
            this.btnCambiarClave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNuevaClave
            // 
            this.lblNuevaClave.AutoSize = true;
            this.lblNuevaClave.Location = new System.Drawing.Point(53, 50);
            this.lblNuevaClave.Name = "lblNuevaClave";
            this.lblNuevaClave.Size = new System.Drawing.Size(96, 13);
            this.lblNuevaClave.TabIndex = 0;
            this.lblNuevaClave.Text = "Nueva Contraseña";
 
            // 
            // txtNuevaClave
            // 
            this.txtNuevaClave.Location = new System.Drawing.Point(155, 47);
            this.txtNuevaClave.Name = "txtNuevaClave";
            this.txtNuevaClave.Size = new System.Drawing.Size(100, 20);
            this.txtNuevaClave.TabIndex = 1;
            // 
            // btnCambiarClave
            // 
            this.btnCambiarClave.Location = new System.Drawing.Point(82, 96);
            this.btnCambiarClave.Name = "btnCambiarClave";
            this.btnCambiarClave.Size = new System.Drawing.Size(173, 23);
            this.btnCambiarClave.TabIndex = 2;
            this.btnCambiarClave.Text = "Cambiar Clave";
            this.btnCambiarClave.UseVisualStyleBackColor = true;
            this.btnCambiarClave.Click += new System.EventHandler(this.btnCambiarClave_Click);
            // 
            // FormCambioClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 157);
            this.Controls.Add(this.btnCambiarClave);
            this.Controls.Add(this.txtNuevaClave);
            this.Controls.Add(this.lblNuevaClave);
            this.Name = "FormCambioClave";
            this.Text = "Cambiar Contraseña";
            this.Load += new System.EventHandler(this.FormCambioClave_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNuevaClave;
        private System.Windows.Forms.TextBox txtNuevaClave;
        private System.Windows.Forms.Button btnCambiarClave;
    }
}