using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;     //ler o ficheiro app.config
using System.Data;

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
        public DataTable devolveConsulta(string strSQL) {
            SqlCommand comando = new SqlCommand(strSQL, ligacaoBD);
            DataTable registos = new DataTable();

            SqlDataReader leitor = comando.ExecuteReader();
            registos.Load(leitor);

            return registos;
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
        //lista todos os leitores
        public DataTable listarLeitores() {
            string strSQL = "SELECT nleitor AS id,nome AS Nome,ativo FROM Leitores ORDER BY nome";

            //executar a consulta
            return devolveConsulta(strSQL);
        }

        public void atualizarLeitor(string nome, DateTime data, byte[] imagem,int nleitor) {
            string sql = @"UPDATE Leitores Set nome= @nome,data_nasc=@data_nasc,
                        fotografia=@fotografia
                          WHERE nleitor=@nleitor";
            SqlCommand comando = new SqlCommand(sql, ligacaoBD);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@data_nasc", data);
            comando.Parameters.AddWithValue("@fotografia", imagem);
            comando.Parameters.AddWithValue("@nleitor", nleitor);
            comando.ExecuteNonQuery();
        }


        public DataTable listarLivros(string text) {
            string strSQL = @"SELECT nlivro AS id,nome AS Nome
                            From Livros
                            WHERE nome LIKE '%"+text+"%' ORDER By Nome";
            return devolveConsulta(strSQL);
        }


        public void removeLeitor(int nleitor) {
            string sql = @"DELETE FROM Leitores
                          WHERE nleitor=@nleitor";
            SqlCommand comando = new SqlCommand(sql, ligacaoBD);
            
            comando.Parameters.AddWithValue("@nleitor", nleitor);
            comando.ExecuteNonQuery();
        }
        #endregion
        #region Livro
        public void adicionarLivro(string nome,int ano, DateTime data, decimal preco,string capa) {
            string sql = @"INSERT INTO Livros(nome,ano,data_aquisicao,preco,capa,estado)
                VALUES (@nome,@ano,@data,@preco,@capa,@estado);";
            SqlCommand comando = new SqlCommand(sql, ligacaoBD);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@ano", ano);
            comando.Parameters.AddWithValue("@data", data);
            comando.Parameters.AddWithValue("@preco", preco);
            comando.Parameters.AddWithValue("@capa", capa);
            comando.Parameters.AddWithValue("@estado", true);
            comando.ExecuteNonQuery();
        }
        //lista todos os leitores
        public DataTable listarLivros() {
            string strSQL = "SELECT nlivro AS id,nome AS Nome FROM Livros ORDER BY nome";

            //executar a consulta
            return devolveConsulta(strSQL);
        }
        #endregion
        #region Emprestimos
        public void adicionarEmprestimo(int nlivro,int nleitor,DateTime data_emp,DateTime data_devolve) {
            //vamos utilizar transações!!!!
            string strSQL;
            SqlCommand comando;
            SqlTransaction transacao = ligacaoBD.BeginTransaction();
            try {
                //adicionar empréstimo
                strSQL = @"INSERT INTO emprestimos(nlivro,nleitor,data_emprestimo,data_devolve,estado)
                        VALUES (@nlivro,@nleitor,@data_emp,@data_devolve,@estado)";
                comando = new SqlCommand(strSQL, ligacaoBD);
                comando.Transaction = transacao;
                comando.Parameters.AddWithValue("@nlivro", nlivro);
                comando.Parameters.AddWithValue("@nleitor", nleitor);
                comando.Parameters.AddWithValue("@data_emp", data_emp);
                comando.Parameters.AddWithValue("@data_devolve", data_devolve);
                comando.Parameters.AddWithValue("@estado", true);
                comando.ExecuteNonQuery();
                //alterar o estado do livro
                strSQL = @"UPDATE Livros SET estado=false WHERE nlivro=" + nlivro;
                comando = new SqlCommand(strSQL, ligacaoBD);
                comando.Transaction = transacao;
                comando.ExecuteNonQuery();
            }
            catch(Exception erro) {
                transacao.Rollback();
                return;
            }
            transacao.Commit();
        }
        #endregion
    }
}
