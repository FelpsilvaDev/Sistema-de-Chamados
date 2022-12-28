using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using MySql.Data.MySqlClient;

namespace Persistencia
{
    public class AcompanhamentoP
    {

        public void InserirAcompanhamento ( AcompanhamentoE acomp )
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strQuery = @"INSERT INTO tb_acompanhamentos VALUE (@codChamado , @dataModifier , @descricao , @usuarioComent)";

            MySqlCommand cmd =new MySqlCommand(strQuery, cn);

            cmd.Parameters.AddWithValue("@codChamado", acomp.CodigoChamado);
            cmd.Parameters.AddWithValue("@dataModifier", acomp.DataModificacao);
            cmd.Parameters.AddWithValue("@descricao", acomp.Descricao);
            cmd.Parameters.AddWithValue("@usuarioComent", acomp.UsuarioComent);

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
                if(cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }

        }
        public List<AcompanhamentoE> listarAcompanhamentos(int codigo)
        {
            List<AcompanhamentoE> listaRetorno = new List<AcompanhamentoE>();
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strQuery = @"SELECT * FROM tb_acompanhamentos WHERE codChamado = @cod ORDER BY dataModif desc";

            MySqlCommand cmd = new MySqlCommand(strQuery, cn);
            cmd.Parameters.AddWithValue("@cod", codigo);
            try
            {
                cn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    AcompanhamentoE acomp = new AcompanhamentoE();

                    acomp.CodigoChamado = (int)reader["codChamado"];
                    acomp.DataModificacao = (DateTime)reader["dataModif"];
                    acomp.UsuarioComent = (string)reader["usercoment"];
                    acomp.Descricao = (string)reader["descritivo"];

                    listaRetorno.Add(acomp);

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
    }
}
