namespace m14_trabalho_modelo {
    partial class fr_leitores {
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
            this.txtNome = new System.Windows.Forms.TextBox();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.ptbFotografia = new System.Windows.Forms.PictureBox();
            this.dgvLeitores = new System.Windows.Forms.DataGridView();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnEscolher = new System.Windows.Forms.Button();
            this.lblCaminho = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFotografia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeitores)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Data Nascimento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fotografia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Id";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(138, 41);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(200, 20);
            this.txtNome.TabIndex = 1;
            // 
            // dtpData
            // 
            this.dtpData.Location = new System.Drawing.Point(138, 65);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(200, 20);
            this.dtpData.TabIndex = 2;
            // 
            // ptbFotografia
            // 
            this.ptbFotografia.Location = new System.Drawing.Point(138, 94);
            this.ptbFotografia.Name = "ptbFotografia";
            this.ptbFotografia.Size = new System.Drawing.Size(199, 139);
            this.ptbFotografia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbFotografia.TabIndex = 3;
            this.ptbFotografia.TabStop = false;
            // 
            // dgvLeitores
            // 
            this.dgvLeitores.AllowUserToAddRows = false;
            this.dgvLeitores.AllowUserToDeleteRows = false;
            this.dgvLeitores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeitores.Location = new System.Drawing.Point(367, 40);
            this.dgvLeitores.Name = "dgvLeitores";
            this.dgvLeitores.ReadOnly = true;
            this.dgvLeitores.Size = new System.Drawing.Size(150, 192);
            this.dgvLeitores.TabIndex = 4;
            this.dgvLeitores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLeitores_CellClick);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(32, 256);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(84, 30);
            this.btnAdicionar.TabIndex = 5;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnEscolher
            // 
            this.btnEscolher.Location = new System.Drawing.Point(144, 253);
            this.btnEscolher.Name = "btnEscolher";
            this.btnEscolher.Size = new System.Drawing.Size(192, 32);
            this.btnEscolher.TabIndex = 6;
            this.btnEscolher.Text = "Escolher...";
            this.btnEscolher.UseVisualStyleBackColor = true;
            this.btnEscolher.Click += new System.EventHandler(this.btnEscolher_Click);
            // 
            // lblCaminho
            // 
            this.lblCaminho.AutoSize = true;
            this.lblCaminho.Location = new System.Drawing.Point(146, 236);
            this.lblCaminho.Name = "lblCaminho";
            this.lblCaminho.Size = new System.Drawing.Size(0, 13);
            this.lblCaminho.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(367, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 24);
            this.button1.TabIndex = 8;
            this.button1.Text = "Atualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(367, 262);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 24);
            this.button2.TabIndex = 8;
            this.button2.Text = "Remover";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fr_leitores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 292);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblCaminho);
            this.Controls.Add(this.btnEscolher);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.dgvLeitores);
            this.Controls.Add(this.ptbFotografia);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fr_leitores";
            this.Text = "fr_leitores";
            ((System.ComponentModel.ISupportInitialize)(this.ptbFotografia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeitores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.PictureBox ptbFotografia;
        private System.Windows.Forms.DataGridView dgvLeitores;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnEscolher;
        private System.Windows.Forms.Label lblCaminho;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}