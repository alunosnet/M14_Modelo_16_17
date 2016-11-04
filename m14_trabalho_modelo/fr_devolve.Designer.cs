namespace m14_trabalho_modelo {
    partial class fr_devolve {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cbLivros = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbLivros
            // 
            this.cbLivros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLivros.FormattingEnabled = true;
            this.cbLivros.Location = new System.Drawing.Point(39, 44);
            this.cbLivros.Name = "cbLivros";
            this.cbLivros.Size = new System.Drawing.Size(199, 21);
            this.cbLivros.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(54, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "Devolver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fr_devolve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbLivros);
            this.Name = "fr_devolve";
            this.Text = "fr_devolve";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLivros;
        private System.Windows.Forms.Button button1;
    }
}