using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;     //ler o ficheiro app.config

namespace m14_trabalho_modelo {
    class BaseDados {
        private static BaseDados instance;
        public static BaseDados Instance {
            get {
                if (instance == null)
                    instance = new BaseDados();
                return instance;
            }
        }
        private string strLigacao;
        private SqlConnection ligacaoBD;
        public BaseDados() {
            //ligação à bd
            strLigacao = ConfigurationManager.ConnectionStrings["sql"].ToString();
            ligacaoBD = new SqlConnection(strLigacao);
            ligacaoBD.Open();
        }
        ~BaseDados() {
            try {
                ligacaoBD.Close();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
        #region leitor
        public void adicionarLeitor(string nome, DateTime data, byte[] imagem) {
            string sql = @"INSERT INTO Leitores(nome,data_nasc,fotografia,ativo)
                VALUES (@nome,@data_nasc,@fotografia,@ativo);";
            SqlCommand comando = new SqlCommand(sql, ligacaoBD);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@data_nasc", data);
            comando.Parameters.AddWithValue("@fotografia", imagem);
            comando.Parameters.AddWithValue("@ativo", true);
            comando.ExecuteNonQuery();
        }
        #endregion
    }
}
