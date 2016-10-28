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
    class elementos {
        public int id { get; set; }
        public string texto { get; set; }
        public override string ToString() {
            return texto;
        }
    }
    public partial class fr_emprestimo : Form {
        public fr_emprestimo() {
            InitializeComponent();

            //preencher as comboboxes
            preencheCBLivros();
            preencheCBLeitores();
        }
        public void preencheCBLivros() {
            string strSQL = "SELECT nlivro,nome FROM livros WHERE estado is true ORDER BY nome;";
            DataTable dados = BaseDados.Instance.devolveConsulta(strSQL);
            cbLivro.Items.Clear();
            foreach (DataRow linha in dados.Rows)
                cbLivro.Items.Add(new elementos() { id = int.Parse(linha[0].ToString()), texto = linha[1].ToString() });
        }
        public void preencheCBLeitores() {

        }
        private void button1_Click(object sender, EventArgs e) {

        }
    }
}
