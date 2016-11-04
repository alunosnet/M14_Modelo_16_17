using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace m14_trabalho_modelo {
    public partial class fr_leitores : Form {
        public fr_leitores() {
            InitializeComponent();
            atualizaGrelha();
        }

        private void btnEscolher_Click(object sender, EventArgs e) {
            OpenFileDialog cxDialogo = new OpenFileDialog();
            DialogResult resposta = cxDialogo.ShowDialog();
            if (resposta != DialogResult.OK) return;
            lblCaminho.Text = cxDialogo.FileName;
            ptbFotografia.Image = Image.FromFile(cxDialogo.FileName);
        }

        private void btnAdicionar_Click(object sender, EventArgs e) {
            if(lblCaminho.Text==String.Empty) {
                MessageBox.Show("Tem de escolher uma imagem","Erro");
                return;
            }
            //ler imagem para o vetor
            byte[] imagem = Utils.ImagemParaVetor(lblCaminho.Text);
            string nome = txtNome.Text;
            DateTime data = dtpData.Value;
            BaseDados.Instance.adicionarLeitor(nome, data, imagem);
            //limpar form
            txtNome.Text = "";
            ptbFotografia.Image = null;
            GC.Collect();
            lblCaminho.Text = "";
            dtpData.Value = DateTime.Now;
            //TODO atualizar a gridview

            atualizaGrelha();
        }

        private void atualizaGrelha() {
            dgvLeitores.DataSource = BaseDados.Instance.listarLeitores();
        }

        private void dgvLeitores_CellClick(object sender, DataGridViewCellEventArgs e) {
            ptbFotografia.Image = null;
            GC.Collect();
            //a linha clicada
            int nlinha = dgvLeitores.CurrentCell.RowIndex;
            //id do leitor 
            int nleitor = int.Parse(dgvLeitores.Rows[nlinha].Cells[0].Value.ToString());
            //pesquisar
            string strSQL = "SELECT * FROM leitores WHERE nleitor=" + nleitor;
            DataTable dados = BaseDados.Instance.devolveConsulta(strSQL);
            //nome
            txtNome.Text = dados.Rows[0][1].ToString();
            //data nascimento
            dtpData.Text = dados.Rows[0][2].ToString();
            //fotografia
            byte[] imagem = (byte[])dados.Rows[0][3];
            //gerar nome ficheiro temporário com imagem
            Utils.VetorParaImagem(imagem, "imagem_temp.jpg");
            ptbFotografia.Image = Image.FromFile("imagem_temp.jpg");
            dados.Dispose();
        }
        //atualizar
        private void button1_Click(object sender, EventArgs e) {
            //a linha clicada
            int nlinha = dgvLeitores.CurrentCell.RowIndex;
            //id do leitor 
            int nleitor = int.Parse(dgvLeitores.Rows[nlinha].Cells[0].Value.ToString());
            string nome = txtNome.Text;
            DateTime data = dtpData.Value;
            if (lblCaminho.Text != String.Empty) {
                //ler imagem para o vetor
                byte[] imagem = Utils.ImagemParaVetor(lblCaminho.Text);

                BaseDados.Instance.atualizarLeitor(nleitor, nome, data, imagem);
            }else {

                BaseDados.Instance.atualizarLeitor(nleitor, nome, data);
            }
            //limpar form
            txtNome.Text = "";
            ptbFotografia.Image = null;
            GC.Collect();
            lblCaminho.Text = "";
            dtpData.Value = DateTime.Now;
          
            atualizaGrelha();
        }

        private void button2_Click(object sender, EventArgs e) {
            //a linha clicada
            int nlinha = dgvLeitores.CurrentCell.RowIndex;
            //id do leitor 
            int nleitor = int.Parse(dgvLeitores.Rows[nlinha].Cells[0].Value.ToString());
            BaseDados.Instance.removeLeitor(nleitor);
            //limpar form
            txtNome.Text = "";
            ptbFotografia.Image = null;
            GC.Collect();
            lblCaminho.Text = "";
            dtpData.Value = DateTime.Now;

            atualizaGrelha();
        }
    }
}
