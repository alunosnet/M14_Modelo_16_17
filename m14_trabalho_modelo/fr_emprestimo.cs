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

    public partial class fr_emprestimo : Form {
        public fr_emprestimo() {
            InitializeComponent();

            //preencher as comboboxes
            preencheCBLivros();
            preencheCBLeitores();
        }
        public void preencheCBLivros() {
            string strSQL = "SELECT nlivro,nome FROM livros WHERE estado=1 ORDER BY nome;";
            DataTable dados = BaseDados.Instance.devolveConsulta(strSQL);
            cbLivro.Items.Clear();
            foreach (DataRow linha in dados.Rows)
                cbLivro.Items.Add(new Elementos() { id = int.Parse(linha[0].ToString()), texto = linha[1].ToString() });
        }
        public void preencheCBLeitores() {
            string strSQL = "SELECT nleitor,nome FROM leitores WHERE ativo=1 ORDER BY nome;";
            DataTable dados = BaseDados.Instance.devolveConsulta(strSQL);
            cbLeitor.Items.Clear();
            foreach (DataRow linha in dados.Rows)
                cbLeitor.Items.Add(new Elementos() { id = int.Parse(linha[0].ToString()), texto = linha[1].ToString() });
        }
        private void button1_Click(object sender, EventArgs e) {
            //validar dados
            if(cbLeitor.SelectedIndex<0 || cbLivro.SelectedIndex < 0) {
                MessageBox.Show("Selecione um livro e um leitor");
                return;
            }
            //adicionar à base de dados
            int nlivro = ((Elementos)cbLivro.SelectedItem).id;
            int nleitor = ((Elementos)cbLeitor.SelectedItem).id;

            BaseDados.Instance.adicionarEmprestimo(nlivro, nleitor, dtpEmp.Value, dtpDevolve.Value);

            preencheCBLivros();
        }
    }
}
