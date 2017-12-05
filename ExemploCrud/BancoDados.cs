using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ExemploCrud {
    public class BancoDados {
        SqlConnection cn; // instancia a classe que contem metodos para conexão com o banco de dados.
        SqlCommand comandos; // classe de comandos do SQL
        SqlDataReader rd;

        public bool Adicionar (Categoria cat) {
            bool retorno = false;

            try {
                cn = new SqlConnection (@"Data Source =.\sqlexpress; Initial Catalog = Papelaria; User Id = sa; Password = senai@123"); // caminho do banco de dados a ser executado, com o respectivo ID e Password.
                cn.Open (); // abre o banco de dados acima
                comandos = new SqlCommand (); // instanciando a classe de comandos do SQL
                comandos.Connection = cn;

                comandos.CommandType = CommandType.Text; // o metodo que vai ser incluido os valores no banco de dados
                comandos.CommandText = "insert into Categorias(titulo) values(@vt)"; // .text para incluir um valor no banco de dados conforme comando (INSERT)
                comandos.Parameters.AddWithValue ("@vt", cat.Titulo);

                int r = comandos.ExecuteNonQuery (); // isso retorna quantas linhas foram modificadas (igual no SQL MANAGER)
                if (r > 0)
                    retorno = true;

                comandos.Parameters.Clear ();

            } catch (SqlException se) {
                throw new Exception ("Erro ao tentar cadastrar." + se.Message); // mostrar erro para o usuario caso não der certo o try
            } catch (Exception ex) {
                throw new Exception ("Erro inesperado!!" + ex.Message);
            } finally {
                cn.Close ();
            }
            return retorno;
        }
        public bool Atualizar (Categoria cat) {
            bool retorno = false;

            try {
                cn = new SqlConnection (@"Data Source =.\sqlexpress; Initial Catalog = Papelaria; User Id = sa; Password = senai@123"); // caminho do banco de dados a ser executado, com o respectivo ID e Password.
                cn.Open (); // abre o banco de dados acima
                comandos = new SqlCommand (); // instanciando a classe de comandos do SQL
                comandos.Connection = cn;

                comandos.CommandType = CommandType.Text; // o metodo que vai ser incluido os valores no banco de dados
                comandos.CommandText = "update Categorias set titulo=@vt where idcategoria=@vi"; // .text para incluir um valor no banco de dados conforme comando (UPDATE)
                comandos.Parameters.AddWithValue ("@vt", cat.Titulo);
                comandos.Parameters.AddWithValue ("@vi", cat.IDCategoria);

                int r = comandos.ExecuteNonQuery (); // isso retorna quantas linhas foram modificadas (igual no SQL MANAGER)
                if (r > 0)
                    retorno = true;

                comandos.Parameters.Clear ();

            } catch (SqlException se) {
                throw new Exception ("Erro ao tentar atualizar." + se.Message); // mostrar erro para o usuario caso não der certo o try
            } catch (Exception ex) {
                throw new Exception ("Erro inesperado!!" + ex.Message);
            } finally {
                cn.Close ();
            }
            return retorno;
        }
        public bool Apagar (Categoria cat) {
            bool retorno = false;

            try {
                cn = new SqlConnection (@"Data Source =.\sqlexpress; Initial Catalog = Papelaria; User Id = sa; Password = senai@123"); // caminho do banco de dados a ser executado, com o respectivo ID e Password.
                cn.Open (); // abre o banco de dados acima
                comandos = new SqlCommand (); // instanciando a classe de comandos do SQL
                comandos.Connection = cn;

                comandos.CommandType = CommandType.Text; // o metodo que vai ser incluido os valores no banco de dados
                comandos.CommandText = "delete from Categorias where idcategoria=@vi"; // .text para incluir um valor no banco de dados conforme comando (DELETE)
                comandos.Parameters.AddWithValue ("@vi", cat.IDCategoria);

                int r = comandos.ExecuteNonQuery (); // isso retorna quantas linhas foram modificadas (igual no SQL MANAGER)
                if (r > 0)
                    retorno = true;

                comandos.Parameters.Clear ();

            } catch (SqlException se) {
                throw new Exception ("Erro ao tentar apagar." + se.Message); // mostrar erro para o usuario caso não der certo o try
            } catch (Exception ex) {
                throw new Exception ("Erro inesperado!!" + ex.Message);
            } finally {
                cn.Close ();
            }
            return retorno;
        }

        public List<Categoria> ListarCategorias (int ID) { //para retornar uma lista de todos os resultados da pesquisa
            List<Categoria> lista = new List<Categoria> ();
            try {
                cn = new SqlConnection (@"Data source = .\sqlexpress; Initial catalog = Papelaria; User ID = sa; Password = senai@123"); // abrir o banco de dados
                cn.Open ();
                comandos = new SqlCommand ();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.Text; // o metodo de edição do db
                comandos.CommandText = "Select * from categorias where idcategoria = @vi"; //um comandText para selecionar todos itens da tabela categorias onde o idCategoria for o pesquisado pelo usuario
                comandos.Parameters.AddWithValue ("@vi", ID);
                rd = comandos.ExecuteReader (); // executa a pesquisa do SELECT acima e retorna o resultado da pesquisa no RD

                while (rd.Read ()) {
                    lista.Add (new Categoria { IDCategoria = rd.GetInt32 (0), Titulo = rd.GetString (1) });
                }
                comandos.Parameters.Clear ();

            } catch (SqlException se) {
                throw new Exception ("Erro ao tentar listar." + se.Message);
            } catch (Exception ex) {
                throw new Exception ("Erro Inesperado!" + ex.Message);
            } finally {
                cn.Close ();
            }
            return lista;
        }
        public List<Categoria> ListarCategorias (string Titulo) { //para retornar uma lista de todos os resultados da pesquisa
            List<Categoria> lista = new List<Categoria> ();
            try {
                cn = new SqlConnection (@"Data source = .\sqlexpress; Initial catalog = Papelaria; User ID = sa; Password = senai@123"); // abrir o banco de dados
                cn.Open ();
                comandos = new SqlCommand ();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.Text; // o metodo de edição do db
                comandos.CommandText = "Select * from categorias where Titulo like @vt"; //um comandText para selecionar todos itens da tabela categorias onde o idCategoria for o pesquisado pelo usuario
                comandos.Parameters.AddWithValue ("@vt", Titulo);
                rd = comandos.ExecuteReader (); // executa a pesquisa do SELECT acima e retorna o resultado da pesquisa no RD

                while (rd.Read ()) {
                    lista.Add (new Categoria { IDCategoria = rd.GetInt32 (0), Titulo = rd.GetString (1) });
                }
                comandos.Parameters.Clear ();

            } catch (SqlException se) {
                throw new Exception ("Erro ao tentar listar." + se.Message);
            } catch (Exception ex) {
                throw new Exception ("Erro Inesperado!" + ex.Message);
            } finally {
                cn.Close ();
            }
            return lista;
        }

    }
}