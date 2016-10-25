using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace m14_trabalho_modelo {
    public partial class fr_leitores : Form {
        public fr_leitores() {
            InitializeComponent();
        }

        private void btnEscolher_Click(object sender, EventArgs e) {
            OpenFileDialog cxDialogo = new OpenFileDialog();
            DialogResult resposta = cxDialogo.ShowDialog();
            if (resposta != DialogResult.OK) return;
            lblCaminho.Text = cxDialogo.FileName;
            ptbFotografia.Image = Image.FromFile(cxDialogo.FileName);
        }

        private void btnAdicionar_Click(object sender, EventArgs e) {
            //ler imagem para o vetor
            byte[] imagem = Utils.ImagemParaVetor(lblCaminho.Text);
            string nome = txtNome.Text;
            DateTime data = dtpData.Value;
            BaseDados.Instance.adicionarLeitor(nome, data, imagem);
            //limpar form
            txtNome.Text = "";
            ptbFotografia.Image = null;
            lblCaminho.Text = "";
            dtpData.Value = DateTime.Now;
            //TODO atualizar a gridview
        }
    }
}
