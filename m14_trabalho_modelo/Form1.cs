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
            
        }

        private void leitoresToolStripMenuItem_Click(object sender, EventArgs e) {
            fr_leitores f = new fr_leitores();
            f.Show();
        }
    }
}
