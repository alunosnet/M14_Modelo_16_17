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

    public partial class fr_livros : Form {
        const int registosPorPagina = 5;
        public fr_livros() {
            InitializeComponent();
            atualizarGrelha();
            atualizaNrPaginas();
        }
        private void atualizaNrPaginas() {
            comboBox1.Items.Clear();
            int nRegistos = BaseDados.Instance.getNrLivros();
            int nPaginas = (int)Math.Ceiling(nRegistos / (float)registosPorPagina);
            for (int i = 1; i <= nPaginas; i++)
                comboBox1.Items.Add(i);
        }
        //ADICIONAR
        private void button1_Click(object sender, EventArgs e) {
            //adicionar livro
            string nome = txtNome.Text;
            int ano = int.Parse(txtAno.Text);
            DateTime data = dtpData.Value;
            decimal preco = decimal.Parse(txtPreco.Text);
            string capa = lblCaminho.Text;
            //guardar imagem na pasta
            //verificar se a pasta existe
            string pastaImagens = Application.UserAppDataPath;
            if (Directory.Exists(pastaImagens) == false)
                Directory.CreateDirectory(pastaImagens);
            //gerar nome para imagem
            string nomeImagem = DateTime.Now.Ticks.ToString();
            string[] partesDoNome = capa.Split('\\');
            //gerar o caminho completo para imagem
            nomeImagem = pastaImagens + "\\" + nomeImagem + partesDoNome[partesDoNome.Length - 1];
            //copiar o ficheiro
            File.Copy(capa, nomeImagem);
            //inserir registo na bd
            BaseDados.Instance.adicionarLivro(nome, ano, data, preco, nomeImagem);
            //atualizar a grelha
            atualizarGrelha();
            atualizaNrPaginas();
            //limpar form
            txtAno.Text = "";
            txtNome.Text = "";
            txtPreco.Text = "";
            ptbCapa.Image = null;
            dtpData.Text = DateTime.Now.ToString();
        }

        private void atualizarGrelha() {
            if(comboBox1.SelectedIndex==-1)
                dgvLivros.DataSource = BaseDados.Instance.listarLivros();
            else {
                int pagina = comboBox1.SelectedIndex + 1;
                if (pagina <= 0) pagina = 1;
                int primeiroRegisto = (pagina - 1) * registosPorPagina+1;
                dgvLivros.DataSource = BaseDados.Instance.listarLivros(primeiroRegisto,registosPorPagina);
            }
        }

        //escolher
        private void button2_Click(object sender, EventArgs e) {
            OpenFileDialog cxDialogo = new OpenFileDialog();
            DialogResult resposta = cxDialogo.ShowDialog();
            if (resposta != DialogResult.OK) return;
            lblCaminho.Text = cxDialogo.FileName;
            ptbCapa.Image = Image.FromFile(cxDialogo.FileName);
        }
        //pesquisar
        private void button3_Click(object sender, EventArgs e) {
            dgvLivros.DataSource = BaseDados.Instance.listarLivros(txtPesquisa.Text);
        }

        private void dgvLivros_CellClick(object sender, DataGridViewCellEventArgs e) {
            //nlivro
            int nlinha = dgvLivros.CurrentCell.RowIndex;
            int nlivro = int.Parse(dgvLivros.Rows[nlinha].Cells[0].Value.ToString());

            DataTable dados = BaseDados.Instance.devolveConsulta("Select * from livros where nlivro=" + nlivro);
            txtNome.Text = dados.Rows[0][1].ToString();
            txtAno.Text = dados.Rows[0][2].ToString();
            dtpData.Text = dados.Rows[0][3].ToString();
            txtPreco.Text = dados.Rows[0][4].ToString();
            //capa
            if (File.Exists(dados.Rows[0][5].ToString()))
                ptbCapa.Image = Image.FromFile(dados.Rows[0][5].ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            atualizarGrelha();
        }

    }
}
