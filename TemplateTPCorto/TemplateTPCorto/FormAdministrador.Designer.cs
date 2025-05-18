namespace TemplateTPCorto
{
    partial class FormAdministrador
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
            this.btnAutorizaciones = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAutorizaciones
            // 
            this.btnAutorizaciones.Location = new System.Drawing.Point(220, 138);
            this.btnAutorizaciones.Margin = new System.Windows.Forms.Padding(4);
            this.btnAutorizaciones.Name = "btnAutorizaciones";
            this.btnAutorizaciones.Size = new System.Drawing.Size(285, 48);
            this.btnAutorizaciones.TabIndex = 3;
            this.btnAutorizaciones.Text = "Autorizaciones";
            this.btnAutorizaciones.UseVisualStyleBackColor = true;
            // 
            // FormAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAutorizaciones);
            this.Name = "FormAdministrador";
            this.Text = "FormAdministrador";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAutorizaciones;
    }
}