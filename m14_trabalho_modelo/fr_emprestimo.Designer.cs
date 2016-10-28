namespace m14_trabalho_modelo {
    partial class fr_emprestimo {
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpEmp = new System.Windows.Forms.DateTimePicker();
            this.dtpDevolve = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.cbLeitor = new System.Windows.Forms.ComboBox();
            this.cbLivro = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Leitor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Livro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Data Empréstimo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Data devolução";
            // 
            // dtpEmp
            // 
            this.dtpEmp.Location = new System.Drawing.Point(171, 96);
            this.dtpEmp.Name = "dtpEmp";
            this.dtpEmp.Size = new System.Drawing.Size(219, 20);
            this.dtpEmp.TabIndex = 1;
            // 
            // dtpDevolve
            // 
            this.dtpDevolve.Location = new System.Drawing.Point(171, 130);
            this.dtpDevolve.Name = "dtpDevolve";
            this.dtpDevolve.Size = new System.Drawing.Size(219, 20);
            this.dtpDevolve.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(462, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 58);
            this.button1.TabIndex = 2;
            this.button1.Text = "Registar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbLeitor
            // 
            this.cbLeitor.FormattingEnabled = true;
            this.cbLeitor.Location = new System.Drawing.Point(166, 34);
            this.cbLeitor.Name = "cbLeitor";
            this.cbLeitor.Size = new System.Drawing.Size(223, 21);
            this.cbLeitor.TabIndex = 3;
            // 
            // cbLivro
            // 
            this.cbLivro.FormattingEnabled = true;
            this.cbLivro.Location = new System.Drawing.Point(168, 65);
            this.cbLivro.Name = "cbLivro";
            this.cbLivro.Size = new System.Drawing.Size(221, 21);
            this.cbLivro.TabIndex = 4;
            // 
            // fr_emprestimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 180);
            this.Controls.Add(this.cbLivro);
            this.Controls.Add(this.cbLeitor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpDevolve);
            this.Controls.Add(this.dtpEmp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "fr_emprestimo";
            this.Text = "fr_emprestimo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEmp;
        private System.Windows.Forms.DateTimePicker dtpDevolve;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbLeitor;
        private System.Windows.Forms.ComboBox cbLivro;
    }
}