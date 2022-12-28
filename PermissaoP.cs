using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Entidades;

namespace Persistencia
{
    public class PermissaoP
    {

        public void CadastrarPermissao(PermissaoE per)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strQuery = "INSERT INTO tb_permissoes (codpermissao,descricao) VALUES (@cod,@descricao)";

            MySqlCommand cmd = new MySqlCommand(strQuery, cn);

            cmd.Parameters.AddWithValue("@cod", per.Codigo);
            cmd.Parameters.AddWithValue("@descricao", per.Descricao);

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

        public List<PermissaoE> ListarPermissoes()
        {
            List<PermissaoE> lstpermissao = new List<PermissaoE>();

            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strQuery = "SELECT * FROM tb_permissoes";

            MySqlCommand cmd = new MySqlCommand(strQuery, cn);

            try
            {
                cn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PermissaoE permissao = new PermissaoE();

                    permissao.Codigo = Convert.ToInt32(reader["codpermissao"]);
                    permissao.Descricao = reader["descricao"].ToString();

                    lstpermissao.Add(permissao);
                    
                }

                return lstpermissao;
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        public bool ValidarPermissao(string email, int codpermissao)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strQuery = "SELECT cod from tb_users WHERE email = @email";

            MySqlCommand cmd = new MySqlCommand(strQuery, cn);

            cmd.Parameters.AddWithValue("@email",email);
            UsuarioE usuario = new UsuarioE();
            try
            {
                cn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    usuario.Codigo = Convert.ToInt32(reader["cod"]);
                }

                string strQuery1 = "SELECT * from tb_userpermissoes WHERE codpermissao = @cod AND cod = @cod2";

                MySqlCommand cmd2 = new MySqlCommand(strQuery1, cn);
                cmd2.Parameters.AddWithValue("@cod", codpermissao);
                cmd2.Parameters.AddWithValue("@cod2", usuario.Codigo);

                cn.Close();

                try
                {
                    cn.Open();
                    MySqlDataReader reader2 = cmd2.ExecuteReader();
                    
                    if (reader2.HasRows)
                    {

                        return true;

                    }
                    else
                    {

                        return false;
                    }

                    cn.Close();
                }
                catch (Exception)
                {
                    
                    throw;
                }
                 
            }
            catch (Exception)
            {
                
                throw;
            }

        }
    }
}
