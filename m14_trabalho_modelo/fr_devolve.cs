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
    public partial class fr_devolve : Form {
        public fr_devolve() {
            InitializeComponent();
            preencheCBLivros();
        }
        public void preencheCBLivros() {
            string strSQL = "SELECT nlivro,nome FROM livros WHERE estado=0 ORDER BY nome;";
            DataTable dados = BaseDados.Instance.devolveConsulta(strSQL);
            cbLivros.Items.Clear();
            foreach (DataRow linha in dados.Rows)
                cbLivros.Items.Add(new Elementos() { id = int.Parse(linha[0].ToString()), texto = linha[1].ToString() });
        
        }
        private void button1_Click(object sender, EventArgs e) {
            if (cbLivros.SelectedIndex < 0) {
                MessageBox.Show("Selecione um livro");
                return;
            }
            int nlivro = ((Elementos)cbLivros.SelectedItem).id;

            BaseDados.Instance.devolverLivro(nlivro);
            preencheCBLivros();
        }
    }
}
