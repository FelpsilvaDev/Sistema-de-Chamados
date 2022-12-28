using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using MySql.Data.MySqlClient;
using System.Data;

namespace Persistencia
{
    public class UsuarioP
    {
        public void CadastrarUser(UsuarioE usuario)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strQuery = "INSERT INTO tb_users (nome,email,ativo) VALUES (@nome,@email,@ativo)";

            MySqlCommand cmd = new MySqlCommand(strQuery, cn);


            cmd.Parameters.AddWithValue("@nome", usuario.Nome);
            cmd.Parameters.AddWithValue("@email", usuario.Email);
            cmd.Parameters.AddWithValue("@ativo", usuario.ativo);

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

        public void AlterarUser(UsuarioE usuario)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strQuery = "UPDATE tb_users  SET cod=@cod, nome=@nome, email=@email, ativo=@ativo";

            MySqlCommand cmd = new MySqlCommand(strQuery, cn);

            cmd.Parameters.AddWithValue("@cod", usuario.Codigo);
            cmd.Parameters.AddWithValue("@nome", usuario.Nome);
            cmd.Parameters.AddWithValue("@email", usuario.Email);
            cmd.Parameters.AddWithValue("@ativo", usuario.ativo);

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

        public List<UsuarioE> ListarUsuarios()
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strQuery = "SELECT * FROM  tb_users";

            MySqlCommand cmd = new MySqlCommand(strQuery, cn);

            List<UsuarioE> lstusers = new List<UsuarioE>();
            try
            {
                cn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    UsuarioE usuario = new UsuarioE();
                    usuario.Codigo = Convert.ToInt32(reader["cod"]);
                    usuario.Nome =  reader["nome"].ToString();
                    usuario.Email = reader["email"].ToString();
                    usuario.ativo = reader["ativo"].ToString();

                    lstusers.Add(usuario);
                }
                return lstusers;
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

        public UsuarioE PesquisarPorCodigo(int cod)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strQuery = "SELECT * FROM  tb_users where cod = @cod";

            MySqlCommand cmd = new MySqlCommand(strQuery, cn);

            UsuarioE usuario = new UsuarioE();
            cmd.Parameters.AddWithValue("@cod", cod);
            try
            {
                cn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    
                    usuario.Codigo = Convert.ToInt32(reader["cod"]);
                    usuario.Nome = reader["nome"].ToString();
                    usuario.Email = reader["email"].ToString();
                    usuario.ativo = reader["ativo"].ToString();
                   

                }
                return usuario;
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
