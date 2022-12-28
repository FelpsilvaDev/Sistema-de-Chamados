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
    public class UsuperP
    {

        public void LiberarAcesso(UsuperE us)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strQuery = "INSERT INTO tb_userpermissoes (cod,codpermissao) VALUES (@cod1,@cod2)";

            MySqlCommand cmd = new MySqlCommand(strQuery, cn);


            cmd.Parameters.AddWithValue("@cod1", us.CodUsuario);
            cmd.Parameters.AddWithValue("@cod2", us.CodPermissao);
 
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

        public void RevogarAcesso(int cod)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strQuery = "DELETE FROM tb_userpermissoes WHERE codigo = @cod";

            MySqlCommand cmd = new MySqlCommand(strQuery, cn);

            cmd.Parameters.AddWithValue("@cod", cod);

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

        public List<UsuperE>ListarPermissoes(int coduser)
        {
            List<UsuperE> lstPermissao = new List<UsuperE>();

            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strQuery = "SELECT A.codigo , B.descricao FROM tb_userpermissoes A INNER JOIN tb_permissoes B on A.codpermissao = B.codpermissao " +
                              "WHERE cod = @cod";

            MySqlCommand cmd = new MySqlCommand(strQuery, cn);

            cmd.Parameters.AddWithValue("@cod", coduser);

            try
            {
                cn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    UsuperE usu = new UsuperE();

                    usu.Codigo = Convert.ToInt32(reader["codigo"]);
                    usu.NomePerm = reader["descricao"].ToString();

                    lstPermissao.Add(usu);


                }

                return lstPermissao;
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
