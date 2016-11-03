using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m14_trabalho_modelo {
    class Elementos {
        public int id { get; set; }
        public string texto { get; set; }
        public override string ToString() {
            return texto;
        }
    }
}
