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
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            //verificar se a bd existe
            if (System.IO.File.Exists(@"C:\Users\Utilizador\Documents\bases de dados\m14_trabalho_modelo.mdf") == false)
                BaseDados.criarBD(@"C:\Users\Utilizador\Documents\bases de dados\m14_trabalho_modelo.mdf");
        }

        private void leitoresToolStripMenuItem_Click(object sender, EventArgs e) {
            fr_leitores f = new fr_leitores();
            f.Show();
        }

        private void livrosToolStripMenuItem_Click(object sender, EventArgs e) {
            fr_livros f = new fr_livros();
            f.Show();
        }

        private void empréstimosToolStripMenuItem_Click(object sender, EventArgs e) {
            fr_emprestimo f = new fr_emprestimo();
            f.Show();
        }

        private void devoluçãoToolStripMenuItem_Click(object sender, EventArgs e) {
            fr_devolve f = new fr_devolve();
            f.Show();
        }

        private void estatísticasToolStripMenuItem_Click(object sender, EventArgs e) {
            fr_consultas f = new fr_consultas();
            f.Show();
        }
    }
}
