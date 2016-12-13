using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;     //ler o ficheiro app.config
using System.Data;
using System.Windows.Forms;

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
        public static void criarBD(string nome) {
            string nomeBD = System.IO.Path.GetFileNameWithoutExtension(nome);
            var ligacaoServidor = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30");
            ligacaoServidor.Open();
            string strSQL = $"CREATE DATABASE {nomeBD} ON PRIMARY (NAME={nomeBD}, FILENAME='{nome}' )";
            var comando = new SqlCommand(strSQL, ligacaoServidor);
            comando.ExecuteNonQuery();
            //criar as tabelas
            ligacaoServidor = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={nome};Integrated Security=True;Connect Timeout=30");
            ligacaoServidor.Open();
            strSQL = @"CREATE TABLE [dbo].[Leitores]
                        (

                            [nleitor] INT NOT NULL PRIMARY KEY identity,
                            nome varchar(40) not null,
	                        data_nasc date,
                            fotografia IMAGE,
	                        ativo BIT
                        )
                        CREATE TABLE[dbo].[Livros]
                        (
	                        [nlivro]
                                INT NOT NULL PRIMARY KEY identity,
                        nome varchar(100),
	                        ano int,
	                        data_aquisicao date,
                            preco decimal(4,2),
	                        capa varchar(300),
	                        estado bit
                        )
                        CREATE TABLE[dbo].[Emprestimos]
                        (
	                        [nemprestimo]
                                INT NOT NULL PRIMARY KEY identity,
                        nlivro int,
	                        nleitor int,
	                        data_emprestimo date,
                            data_devolve date,
	                        estado bit,
                            foreign key(nlivro) references Livros(nlivro),
	                        foreign key(nleitor) references Leitores(nleitor)
                        )";
            comando = new SqlCommand(strSQL, ligacaoServidor);
            comando.ExecuteNonQuery();
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

        public void atualizarLeitor(int nleitor, string nome, DateTime data, byte[] imagem = null) {
            string sql = @"UPDATE Leitores Set nome= @nome,data_nasc=@data_nasc ";
            if (imagem != null) sql += ", fotografia=@fotografia ";
            sql += " WHERE nleitor=@nleitor";
            SqlCommand comando = new SqlCommand(sql, ligacaoBD);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@data_nasc", data);
            if (imagem != null) comando.Parameters.AddWithValue("@fotografia", imagem);
            comando.Parameters.AddWithValue("@nleitor", nleitor);
            comando.ExecuteNonQuery();
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
        public void adicionarLivro(string nome, int ano, DateTime data, decimal preco, string capa) {
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
        public DataTable listarLivros(string text) {
            string strSQL = @"SELECT nlivro AS id,nome AS Nome
                            From Livros WHERE nome like @texto ORDER BY NOME";
            //WHERE nome LIKE '%" + text + "%' ORDER By Nome";
            //return devolveConsulta(strSQL);
            SqlCommand comando = new SqlCommand(strSQL, ligacaoBD);
            comando.Parameters.AddWithValue("@texto", "%"+text+"%");
            DataTable registos = new DataTable();

            SqlDataReader leitor = comando.ExecuteReader();
            registos.Load(leitor);

            return registos;
        }
        public DataTable listarLivros(int pagina, int nregistos) {
            string strSQL = @"select nlivro as id,nome AS Nome from 
                (select row_number() over (order by nome) as rownum, *
                from Livros) as p
                where rownum>=" + pagina + " and rownum<=" + (pagina + nregistos);


            return devolveConsulta(strSQL);
        }
        public int getNrLivros() {
            string strSQL = "Select count(*) from livros;";
            DataTable dados = devolveConsulta(strSQL);
            return int.Parse(dados.Rows[0][0].ToString());
        }
        public void atualizarLivro(int nlivro, string nome, int ano, DateTime data, decimal preco, string capa = null, bool estado = true) {
            string strSQL;
            SqlCommand comando = null;
            if (capa != null)
                strSQL = "UPDATE Livros set nome=@nome,ano=@ano,data_aquisicao=@data_aquisicao,preco=@preco,capa=@capa,estado=@estado ";
            else
                strSQL = "UPDATE Livros set nome=@nome,ano=@ano,data_aquisicao=@data_aquisicao,preco=@preco,estado=@estado ";

            strSQL += "WHERE nlivro=@nlivro;";
            try {
                comando = new SqlCommand(strSQL, ligacaoBD);

                comando.Parameters.AddWithValue("@nome", (string)nome);
                comando.Parameters.AddWithValue("@ano", (int)ano);
                comando.Parameters.AddWithValue("@data_aquisicao", (DateTime)data);
                comando.Parameters.AddWithValue("@preco", (decimal)preco);
                if (capa != null) comando.Parameters.AddWithValue("@capa", (string)capa);
                comando.Parameters.AddWithValue("@estado", (bool)estado);
                comando.Parameters.AddWithValue("@nlivro", (int)nlivro);

                comando.ExecuteNonQuery();
            } catch (Exception erro) {
                MessageBox.Show(erro.Message);
            }
        }
        #endregion
        #region Emprestimos
        public void adicionarEmprestimo(int nlivro, int nleitor, DateTime data_emp, DateTime data_devolve) {
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
                strSQL = @"UPDATE Livros SET estado=0 WHERE nlivro=" + nlivro;
                comando = new SqlCommand(strSQL, ligacaoBD);
                comando.Transaction = transacao;
                comando.ExecuteNonQuery();
            } catch (Exception erro) {
                MessageBox.Show(erro.Message);
                transacao.Rollback();
                return;
            }
            transacao.Commit();
        }
        public void devolverLivro(int nlivro) {
            string strSQL;
            SqlCommand comando;
            SqlTransaction transacao = ligacaoBD.BeginTransaction();
            try {
                //adicionar empréstimo
                strSQL = @"UPDATE Emprestimos SET estado=0,data_devolve=@data WHERE nlivro=@nlivro AND estado=1";
                comando = new SqlCommand(strSQL, ligacaoBD);
                comando.Transaction = transacao;
                comando.Parameters.AddWithValue("@nlivro", nlivro);
                comando.Parameters.AddWithValue("@data", DateTime.Now);
                comando.ExecuteNonQuery();
                //alterar o estado do livro
                strSQL = $@"UPDATE Livros SET estado=1 WHERE nlivro={nlivro}";
                comando = new SqlCommand(strSQL, ligacaoBD);
                comando.Transaction = transacao;
                comando.ExecuteNonQuery();
            } catch (Exception erro) {
                MessageBox.Show(erro.Message);
                transacao.Rollback();
                return;
            }
            transacao.Commit();
        }
        #endregion
    }
}
