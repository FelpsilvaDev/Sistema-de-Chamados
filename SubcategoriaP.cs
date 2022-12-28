using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Entidades;

namespace Persistencia
{
    public class SubcategoriaP
    {
        public void InserirCategoria(SubcategoriaE cat)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strQuery = "INSERT INTO tb_subcategoria (descritivoSubcat,codCategoria) VALUES(@descri,@codCategoria)";

            MySqlCommand cmd = new MySqlCommand(strQuery, cn);

            cmd.Parameters.AddWithValue("@descri", cat.NomeSubcat);
            cmd.Parameters.AddWithValue("@codCategoria", cat.codigoCate);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

            }
        }
        public List<SubcategoriaE> Listar(int codigo)
        {
            List<SubcategoriaE> listaRetorno = new List<SubcategoriaE>();

            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);
            string Query = "SELECT S.codSubcat,S.descritivoSubcat, C.descritivoCat FROM tb_subcategoria S " +
                           "INNER JOIN tb_categoria C on S.codCategoria = C.codCategoria WHERE S.codCategoria = @cod";

            MySqlCommand cmd = new MySqlCommand(Query, cn);
            cmd.Parameters.AddWithValue("@cod", codigo);

            try
            {
                cn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SubcategoriaE cat = new SubcategoriaE();

                    cat.Codigo = (int)reader["codsubcat"];
                    cat.NomeSubcat = reader["descritivoSubcat"].ToString();
                    cat.NomeCategoria = reader["descritivoCat"].ToString();

                    listaRetorno.Add(cat);
                }

                return listaRetorno;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

            }


        }
        public SubcategoriaE PesquisarPorCodigo(int codigo)
        {

            SubcategoriaE cat = new SubcategoriaE();

            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);
            string Query = "SELECT S.codsubcat, S.descritivoSubcat,C.descritivoCat FROM tb_subcategoria S INNER JOIN tb_categoria C"
                + " on S.codcategoria = C.codcategoria where codsubcat = @cod ";


            MySqlCommand cmd = new MySqlCommand(Query, cn);
            cmd.Parameters.AddWithValue("@cod", codigo);

            try
            {
                cn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cat.Codigo = (int)reader["codsubcat"];
                    cat.NomeSubcat = reader["descritivoSubcat"].ToString();
                    cat.NomeCategoria = reader["descritivoCat"].ToString();

                }

                return cat;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

            }

        }
        public void AlterarCategoria(SubcategoriaE cat)
        {

            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strQuery = "UPDATE tb_subcategoria SET descritivoSubcat=@descri , codCategoria = @codcat WHERE codsubcat=@cod";

            MySqlCommand cmd = new MySqlCommand(strQuery, cn);

            cmd.Parameters.AddWithValue("@descri", cat.NomeSubcat);
            cmd.Parameters.AddWithValue("@codcat", cat.codigoCate);
            cmd.Parameters.AddWithValue("@cod", cat.Codigo);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

            }
        }
        public void DeletarCategoria(int codigo)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strQuery = "DELETE FROM tb_subcategoria  WHERE codsubcat=@cod";

            MySqlCommand cmd = new MySqlCommand(strQuery, cn);

            cmd.Parameters.AddWithValue("@cod", codigo);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

            }
        }
        public List<SubcategoriaE> PesquisarPorCategoria(string descricao)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);
            string Query = "SELECT S.codsubcat, S.descritivoSubcat FROM tb_subcategoria S INNER JOIN tb_categoria C"
                + " on S.codcategoria = C.codcategoria where C.descritivoCat = @descritivoCat order by S.descritivoSubcat";

            MySqlCommand cmd = new MySqlCommand(Query, cn);
            cmd.Parameters.AddWithValue("@descritivoCat", descricao);
            List<SubcategoriaE> lista = new List<SubcategoriaE>();

            try
            {
                cn.Open();

                MySqlDataReader leitura = cmd.ExecuteReader();

                while(leitura.Read())
                {
                    SubcategoriaE cat = new SubcategoriaE();

                    cat.Codigo = Convert.ToInt32(leitura["codsubcat"]);
                    cat.NomeSubcat = leitura["descritivoSubcat"].ToString();

                    lista.Add(cat);
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

            }

        }
    }
}