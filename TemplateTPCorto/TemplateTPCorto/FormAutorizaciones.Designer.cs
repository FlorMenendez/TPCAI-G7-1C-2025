namespace TemplateTPCorto
{
    partial class FormAutorizaciones
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
            this.tabControlOps = new System.Windows.Forms.TabControl();
            this.Persona = new System.Windows.Forms.TabPage();
            this.Credencial = new System.Windows.Forms.TabPage();
            this.dgvPersona = new System.Windows.Forms.DataGridView();
            this.btnAprobarPersona = new System.Windows.Forms.Button();
            this.btnRechazarPersona = new System.Windows.Forms.Button();
            this.dgvCredencial = new System.Windows.Forms.DataGridView();
            this.btnAprobarCred = new System.Windows.Forms.Button();
            this.btnRechazarCred = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.tabControlOps.SuspendLayout();
            this.Persona.SuspendLayout();
            this.Credencial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersona)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCredencial)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlOps
            // 
            this.tabControlOps.Controls.Add(this.Persona);
            this.tabControlOps.Controls.Add(this.Credencial);
            this.tabControlOps.Location = new System.Drawing.Point(12, 12);
            this.tabControlOps.Name = "tabControlOps";
            this.tabControlOps.SelectedIndex = 0;
            this.tabControlOps.Size = new System.Drawing.Size(422, 339);
            this.tabControlOps.TabIndex = 0;
            // 
            // Persona
            // 
            this.Persona.Controls.Add(this.btnRechazarPersona);
            this.Persona.Controls.Add(this.btnAprobarPersona);
            this.Persona.Controls.Add(this.dgvPersona);
            this.Persona.Location = new System.Drawing.Point(4, 22);
            this.Persona.Name = "Persona";
            this.Persona.Padding = new System.Windows.Forms.Padding(3);
            this.Persona.Size = new System.Drawing.Size(414, 313);
            this.Persona.TabIndex = 0;
            this.Persona.Text = "Persona";
            this.Persona.UseVisualStyleBackColor = true;
            this.Persona.Click += new System.EventHandler(this.Persona_Click);
            // 
            // Credencial
            // 
            this.Credencial.Controls.Add(this.btnRechazarCred);
            this.Credencial.Controls.Add(this.btnAprobarCred);
            this.Credencial.Controls.Add(this.dgvCredencial);
            this.Credencial.Location = new System.Drawing.Point(4, 22);
            this.Credencial.Name = "Credencial";
            this.Credencial.Padding = new System.Windows.Forms.Padding(3);
            this.Credencial.Size = new System.Drawing.Size(414, 313);
            this.Credencial.TabIndex = 1;
            this.Credencial.Text = "Credencial";
            this.Credencial.UseVisualStyleBackColor = true;
            // 
            // dgvPersona
            // 
            this.dgvPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersona.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPersona.Location = new System.Drawing.Point(3, 3);
            this.dgvPersona.Name = "dgvPersona";
            this.dgvPersona.Size = new System.Drawing.Size(408, 250);
            this.dgvPersona.TabIndex = 0;
            // 
            // btnAprobarPersona
            // 
            this.btnAprobarPersona.Location = new System.Drawing.Point(43, 270);
            this.btnAprobarPersona.Name = "btnAprobarPersona";
            this.btnAprobarPersona.Size = new System.Drawing.Size(139, 23);
            this.btnAprobarPersona.TabIndex = 1;
            this.btnAprobarPersona.Text = "Aprobar Persona";
            this.btnAprobarPersona.UseVisualStyleBackColor = true;
            this.btnAprobarPersona.Click += new System.EventHandler(this.btnAprobarPersona_Click);
            // 
            // btnRechazarPersona
            // 
            this.btnRechazarPersona.Location = new System.Drawing.Point(230, 270);
            this.btnRechazarPersona.Name = "btnRechazarPersona";
            this.btnRechazarPersona.Size = new System.Drawing.Size(139, 23);
            this.btnRechazarPersona.TabIndex = 2;
            this.btnRechazarPersona.Text = "Rechazar Persona";
            this.btnRechazarPersona.UseVisualStyleBackColor = true;
            this.btnRechazarPersona.Click += new System.EventHandler(this.btnRechazarPersona_Click);
            // 
            // dgvCredencial
            // 
            this.dgvCredencial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCredencial.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvCredencial.Location = new System.Drawing.Point(3, 3);
            this.dgvCredencial.Name = "dgvCredencial";
            this.dgvCredencial.Size = new System.Drawing.Size(408, 250);
            this.dgvCredencial.TabIndex = 0;
            // 
            // btnAprobarCred
            // 
            this.btnAprobarCred.Location = new System.Drawing.Point(42, 272);
            this.btnAprobarCred.Name = "btnAprobarCred";
            this.btnAprobarCred.Size = new System.Drawing.Size(138, 23);
            this.btnAprobarCred.TabIndex = 1;
            this.btnAprobarCred.Text = "Aprobar Cred.";
            this.btnAprobarCred.UseVisualStyleBackColor = true;
            this.btnAprobarCred.Click += new System.EventHandler(this.btnAprobarCred_Click);
            // 
            // btnRechazarCred
            // 
            this.btnRechazarCred.Location = new System.Drawing.Point(229, 272);
            this.btnRechazarCred.Name = "btnRechazarCred";
            this.btnRechazarCred.Size = new System.Drawing.Size(138, 23);
            this.btnRechazarCred.TabIndex = 2;
            this.btnRechazarCred.Text = "Rechazar Cred.";
            this.btnRechazarCred.UseVisualStyleBackColor = true;
            this.btnRechazarCred.Click += new System.EventHandler(this.btnRechazarCred_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(153, 370);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(124, 25);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // FormAutorizaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 407);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.tabControlOps);
            this.Name = "FormAutorizaciones";
            this.Text = "Autorizaciones";
            this.Load += new System.EventHandler(this.FormAutorizaciones_Load);
            this.tabControlOps.ResumeLayout(false);
            this.Persona.ResumeLayout(false);
            this.Credencial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersona)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCredencial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlOps;
        private System.Windows.Forms.TabPage Persona;
        private System.Windows.Forms.TabPage Credencial;
        private System.Windows.Forms.DataGridView dgvPersona;
        private System.Windows.Forms.Button btnRechazarPersona;
        private System.Windows.Forms.Button btnAprobarPersona;
        private System.Windows.Forms.Button btnRechazarCred;
        private System.Windows.Forms.Button btnAprobarCred;
        private System.Windows.Forms.DataGridView dgvCredencial;
        private System.Windows.Forms.Button btnVolver;
    }
}