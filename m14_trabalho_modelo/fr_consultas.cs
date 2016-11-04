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
    public partial class fr_consultas : Form {
        public fr_consultas() {
            InitializeComponent();
        }

        private void consulta1ToolStripMenuItem_Click(object sender, EventArgs e) {
            //listar nome dos livros emprestados
            string sql = "select nome from livros where estado=0;";
            dataGridView1.DataSource = BaseDados.Instance.devolveConsulta(sql);
        }

        private void consulta2ToolStripMenuItem_Click(object sender, EventArgs e) {
            //listar nome dos leitores com livros emprestados
            string sql = @"select DISTINCT nome from leitores
                            inner join emprestimos on leitores.nleitor=emprestimos.nleitor
                            WHERE emprestimos.estado=0;";
            dataGridView1.DataSource = BaseDados.Instance.devolveConsulta(sql);
        }

        private void consulta3ToolStripMenuItem_Click(object sender, EventArgs e) {
            //listar nome do livro com mais emprestimos
            string sql = @"select nome from livros
                            where nlivro=(select top 1 nlivro from emprestimos
                                            group by nlivro order by count(*) desc);";
            dataGridView1.DataSource = BaseDados.Instance.devolveConsulta(sql);
        }

        private void consulta4ToolStripMenuItem_Click(object sender, EventArgs e) {
            //leitor com mais empréstimos
            string sql = @"select nome from leitores
                            where nleitor=(select top 1 nleitor from emprestimos
                            group by nleitor order by count(*) desc);";
            dataGridView1.DataSource = BaseDados.Instance.devolveConsulta(sql);
        }

        private void consulta5ToolStripMenuItem_Click(object sender, EventArgs e) {
            //nome do primeiro livro emprestado
            string sql = @"select nome from livros
                            where nlivro=(select top 1 nlivro from emprestimos
                            order by nemprestimo asc);";
            dataGridView1.DataSource = BaseDados.Instance.devolveConsulta(sql);
        }

        private void consutla6ToolStripMenuItem_Click(object sender, EventArgs e) {
            //número de empréstimos por livro (nome, nr empréstimos)
            string sql = @"select nome,count(emprestimos.nlivro)
                            from emprestimos right join livros
                            on livros.nlivro=emprestimos.nlivro
                            group by livros.nome;";
            dataGridView1.DataSource = BaseDados.Instance.devolveConsulta(sql);
        }
    }
}
