namespace pyrenaction.Views.Connexion
{
    partial class ucConnexion
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonConnexion = new System.Windows.Forms.Button();
            this.labelMdp = new System.Windows.Forms.Label();
            this.inputMdp = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.inputLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonConnexion
            // 
            this.buttonConnexion.Location = new System.Drawing.Point(236, 223);
            this.buttonConnexion.Name = "buttonConnexion";
            this.buttonConnexion.Size = new System.Drawing.Size(87, 23);
            this.buttonConnexion.TabIndex = 46;
            this.buttonConnexion.Text = "Connexion";
            this.buttonConnexion.UseVisualStyleBackColor = true;
            // 
            // labelMdp
            // 
            this.labelMdp.AutoSize = true;
            this.labelMdp.Location = new System.Drawing.Point(78, 151);
            this.labelMdp.Name = "labelMdp";
            this.labelMdp.Size = new System.Drawing.Size(93, 17);
            this.labelMdp.TabIndex = 45;
            this.labelMdp.Text = "Mot de passe";
            // 
            // inputMdp
            // 
            this.inputMdp.Location = new System.Drawing.Point(199, 151);
            this.inputMdp.Name = "inputMdp";
            this.inputMdp.Size = new System.Drawing.Size(259, 22);
            this.inputMdp.TabIndex = 44;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(78, 123);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(43, 17);
            this.labelLogin.TabIndex = 43;
            this.labelLogin.Text = "Login";
            // 
            // inputLogin
            // 
            this.inputLogin.Location = new System.Drawing.Point(199, 123);
            this.inputLogin.Name = "inputLogin";
            this.inputLogin.Size = new System.Drawing.Size(259, 22);
            this.inputLogin.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 41;
            this.label1.Text = "Connexion";
            // 
            // ucConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonConnexion);
            this.Controls.Add(this.labelMdp);
            this.Controls.Add(this.inputMdp);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.inputLogin);
            this.Controls.Add(this.label1);
            this.Name = "ucConnexion";
            this.Size = new System.Drawing.Size(592, 320);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnexion;
        private System.Windows.Forms.Label labelMdp;
        private System.Windows.Forms.TextBox inputMdp;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox inputLogin;
        private System.Windows.Forms.Label label1;
    }
}
