using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using MySql.Data.MySqlClient;
using System.Data;
using MySql.Data;

namespace Persistencia
{
   public class CategoriaP
   {
        public void InserirCategoria(CategoriaE cat)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strQuery = "INSERT INTO tb_categoria (descritivoCat, setor) VALUES(@descri, @setor)";

            MySqlCommand cmd = new MySqlCommand(strQuery, cn);

            cmd.Parameters.AddWithValue("@descri",cat.Nomecategoria);
            cmd.Parameters.AddWithValue("@setor", cat.setor);
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

        public List<CategoriaE> Listar()
        {
            List<CategoriaE> listaRetorno = new List<CategoriaE>();

            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);
            string Query = "SELECT * FROM tb_categoria where setor =0";

            MySqlCommand cmd = new MySqlCommand(Query, cn);

            try
            {
                cn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CategoriaE cat = new CategoriaE();

                    cat.Codigo = (int)reader["codCategoria"];
                    cat.Nomecategoria = reader["descritivoCat"].ToString();

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
                if(cn.State==ConnectionState.Open)
                {
                    cn.Close();
                }     

            }


        }
        public List<CategoriaE> Listarcatmanut()
        {
            List<CategoriaE> listaRetorno = new List<CategoriaE>();

            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);
            string Query = "SELECT * FROM tb_categoria where setor = 1";

            MySqlCommand cmd = new MySqlCommand(Query, cn);

            try
            {
                cn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CategoriaE cat = new CategoriaE();

                    cat.Codigo = (int)reader["codCategoria"];
                    cat.Nomecategoria = reader["descritivoCat"].ToString();

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

        public CategoriaE PesquisarPorCodigo(int codigo)
        {

            CategoriaE cat = new CategoriaE();

            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);
            string Query = "SELECT * FROM tb_categoria where codCategoria = @cod ";


            MySqlCommand cmd = new MySqlCommand(Query, cn);
            cmd.Parameters.AddWithValue("@cod", codigo);

            try
            {
                cn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                   

                    cat.Codigo = (int)reader["codCategoria"];
                    cat.Nomecategoria = reader["descritivoCat"].ToString();

                   
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

        public void AlterarCategoria(CategoriaE cat)
        {

            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strQuery = "UPDATE tb_categoria SET descritivoCat=@descri WHERE codCategoria=@cod";

            MySqlCommand cmd = new MySqlCommand(strQuery, cn);

            cmd.Parameters.AddWithValue("@descri", cat.Nomecategoria);
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

            string strQuery = "DELETE FROM tb_categoria  WHERE codCategoria=@cod";

            MySqlCommand cmd = new MySqlCommand(strQuery, cn);

            cmd.Parameters.AddWithValue("@cod",codigo);

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
   }
}
