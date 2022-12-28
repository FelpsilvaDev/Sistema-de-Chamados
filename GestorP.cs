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
    public class GestorP
    {

        public bool ValidarGestor(string email)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strquery = @"SELECT * FROM tb_gestores WHERE email = @email";

            MySqlCommand comando = new MySqlCommand(strquery, cn);

            comando.Parameters.AddWithValue("@email", email);

            try
            {
                cn.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                GestorE gestor = new GestorE();
                while (reader.Read())
                {
                    gestor.Nome = reader["nome"].ToString();
                    gestor.Email = reader["email"].ToString();
                    gestor.Cod = Convert.ToInt32(reader["cod"]);
                   //gestor.CodDepartamento = Convert.ToInt32(reader["codDept"]);
                }

                if (gestor.Nome != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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

        public void CadastrarGestor(GestorE gestor)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strquery = @"INSERT INTO tb_gestores (nome,email) VALUE (@nome,@email)";

            MySqlCommand comando = new MySqlCommand(strquery, cn);

            comando.Parameters.AddWithValue("@nome", gestor.Nome);
            comando.Parameters.AddWithValue("@email", gestor.Email);

    
            try
            {
                cn.Open();
                comando.ExecuteNonQuery();
                
                //cod = ResgataCod();

                //AlteraDept(cod, gestor.CodDepartamento);
            
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

        public List<GestorE> ListaGestor(string nome)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strquery = @"SELECT A.cod ,A.nome, A.email, B.descritivodept FROM tb_gestores  A
                                                                                LEFT JOIN tb_departamentos B
                                                                                on A.cod = B.cod WHERE A.nome LIKE @nome";

            MySqlCommand comando = new MySqlCommand(strquery, cn);
            List<GestorE> lstgestor = new List<GestorE>();

            comando.Parameters.AddWithValue("@nome",nome+"%");
            try
            {
                cn.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                
                while (reader.Read())
                {
                    GestorE gestor = new GestorE();
                    gestor.Nome = reader["nome"].ToString();
                    gestor.Email = reader["email"].ToString();
                    gestor.Cod = Convert.ToInt32(reader["cod"]);
                    gestor.Departamento = reader["descritivodept"].ToString(); ;
                    lstgestor.Add(gestor);
                }

                return lstgestor;
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

        public void AlterarGestor(GestorE gestor)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strquery = @"UPDATE tb_gestores SET nome=@nome, email=@email WHERE cod = @cod";

            MySqlCommand comando = new MySqlCommand(strquery, cn);

            comando.Parameters.AddWithValue("@nome", gestor.Nome);
            comando.Parameters.AddWithValue("@email", gestor.Email);
            comando.Parameters.AddWithValue("@cod", gestor.Cod);

            try
            {
                cn.Open();
                comando.ExecuteNonQuery();
                AlteraDept(gestor.Cod,gestor.CodDepartamento);
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

        public void AlterarGestor(GestorE gestor, Nullable<DateTime> dt1, Nullable<DateTime> dt2)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strquery = @"UPDATE tb_gestores SET nome=@nome, email=@email, dtferiasini = @dt1 ,dtferiasfim =@dt2 WHERE cod = @cod";

            MySqlCommand comando = new MySqlCommand(strquery, cn);

            comando.Parameters.AddWithValue("@nome", gestor.Nome);
            comando.Parameters.AddWithValue("@email", gestor.Email);
            comando.Parameters.AddWithValue("@cod", gestor.Cod);
            comando.Parameters.AddWithValue("@dt1", dt1);
            comando.Parameters.AddWithValue("@dt2", dt2);

            try
            {
                cn.Open();
                comando.ExecuteNonQuery();
                AlteraDept(gestor.Cod, gestor.CodDepartamento);
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

        public GestorE BuscarGestor(int cod)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strquery = @"SELECT cod , nome ,email , dtferiasini, dtferiasfim FROM tb_gestores WHERE cod = @cod";

            MySqlCommand comando = new MySqlCommand(strquery, cn);


            comando.Parameters.AddWithValue("@cod",cod );
            GestorE gestor = new GestorE();
            try
            {
                cn.Open();
                MySqlDataReader reader = comando.ExecuteReader();


                while (reader.Read())
                {
                   
                    gestor.Nome = reader["nome"].ToString();
                    gestor.Email = reader["email"].ToString();
                    gestor.Cod = Convert.ToInt32(reader["cod"]);


                    gestor.data1 = reader["dtferiasini"].ToString();
                    gestor.data2 = reader["dtferiasfim"].ToString() ;
             

              
                }

                return gestor;
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

        public string BuscarSetor(int departamento)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strquery = @"SELECT A.cod , B.email FROM tb_departamentos A
                                                          INNER JOIN tb_gestores B on A.cod = B.cod
                                                          WHERE A.coddept = @cod";

            MySqlCommand comando = new MySqlCommand(strquery, cn);

            comando.Parameters.AddWithValue("@cod", departamento);
            
            try
            {
                cn.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                string email = "";

                while (reader.Read())
                {
                    
                    email = reader["email"].ToString();
                
                }

                return email;
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

        public int BuscarGestorSetor(string email)
        {

            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strquery = @"SELECT A.coddept FROM tb_departamentos A
                                                         INNER JOIN tb_gestores B on A.cod = B.cod
                                                         WHERE B.email = @email";

            MySqlCommand comando = new MySqlCommand(strquery, cn);

            comando.Parameters.AddWithValue("@email", email);

            try
            {
                cn.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                int  cod = 0;

                while (reader.Read())
                {

                    cod = Convert.ToInt32(reader["coddept"]);

                }

                return cod;
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

        public List<GestorE> ListaTodoGestores()
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strquery = @"SELECT cod , nome FROM tb_gestores" ;

            MySqlCommand comando = new MySqlCommand(strquery, cn);
            List<GestorE> lstgestor = new List<GestorE>();

            try
            {
                cn.Open();
                MySqlDataReader reader = comando.ExecuteReader();


                while (reader.Read())
                {
                    GestorE gestor = new GestorE();
                    gestor.Nome = reader["nome"].ToString();
                    gestor.Cod = Convert.ToInt32(reader["cod"]);
                    lstgestor.Add(gestor);
                }

                return lstgestor;
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

        public int ResgataCod()
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strquery = @"SELECT MAX(cod) from tb_gestores";

            MySqlCommand comando = new MySqlCommand(strquery, cn);
            int codigo;
            try
            {
                cn.Open();
                codigo = Convert.ToInt32(comando.ExecuteScalar());

                return codigo;
            }
            catch (Exception)
            {
                
                throw;
            }
 

        }

        public void AlteraDept(int codGestor ,int codDept)
        {

            ConexaoMysql conexao = new ConexaoMysql();
            string strQuery = "UPDATE tb_departamentos  SET cod = @cod WHERE codDept =@coddept";

            MySqlCommand comando = new MySqlCommand(strQuery, conexao.CriaConexao()); // passando parametros de conexao e comando para o Mysql Comannd

            comando.Parameters.AddWithValue("@cod", codGestor);//passando parametros do comando
            comando.Parameters.AddWithValue("@coddept",codDept);

            try
            {
                comando.ExecuteNonQuery(); //Executando comando 
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexao.FechaConexao();// para todos os casos fecha conexao (try , catch)
            }

        }

        public int RetornaCodigoGestor(int cod)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strquery = @"SELECT cod FROM tb_departamentos                                                      
                                                     WHERE coddept = @cod";

            MySqlCommand comando = new MySqlCommand(strquery, cn);

            comando.Parameters.AddWithValue("@cod", cod);
            int codigo;

            try
            {
                cn.Open();
                codigo = Convert.ToInt32(comando.ExecuteScalar());
                return codigo;
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

        public int ResgataCodEmail(string email)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strquery = @"SELECT cod from tb_gestores WHERE email = @email";

            MySqlCommand comando = new MySqlCommand(strquery, cn);
            int codigo;
            comando.Parameters.AddWithValue("@email",email);
            try
            {
                cn.Open();
                codigo = Convert.ToInt32(comando.ExecuteScalar());

                return codigo;
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

        public void InsereRegistroFerias(DateTime data1 ,DateTime data2 , int codGestor)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strquery = @"INSERT INTO tb_infoferiasgest (dt1,dt2,cod) VALUE (@data1,@data2,@cod)";

            MySqlCommand comando = new MySqlCommand(strquery, cn);

            comando.Parameters.AddWithValue("@data1", data1);
            comando.Parameters.AddWithValue("@data2", data2);
            comando.Parameters.AddWithValue("@cod", codGestor);

            try
            {
                cn.Open();
                comando.ExecuteNonQuery();
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

        public bool ConsultaFerias(int codgestor , DateTime dt1 , DateTime dt2)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strquery = @"SELECT * from tb_infoferiasgest WHERE cod = @codgestor AND codigo in(select codigo from tb_infoferiasgest WHERE dt1 >= @data1 OR dt2 <= @data2) ";

            MySqlCommand comando = new MySqlCommand(strquery, cn);

            comando.Parameters.AddWithValue("@data1", dt1.ToShortDateString());
            comando.Parameters.AddWithValue("@data2",dt2.ToShortDateString());
            comando.Parameters.AddWithValue("@codgestor",codgestor);

            try
            {
                cn.Open();

                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }


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

        public bool ConsultaFeriasCorrente(int codgestor, DateTime dataatual)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strquery = @"SELECT * from tb_gestores WHERE cod = @codgestor";

            MySqlCommand comando = new MySqlCommand(strquery, cn);

            comando.Parameters.AddWithValue("@codgestor", codgestor);
            comando.Parameters.AddWithValue("@data1",dataatual);

            try
            {
                cn.Open();
                bool retorno = false;
                MySqlDataReader reader = comando.ExecuteReader();

                string datahoje = dataatual.ToShortDateString();

                dataatual = Convert.ToDateTime(datahoje);
                
                while (reader.Read())
                {
                    string dt1 = reader["dtferiasini"].ToString();
                    string dt2 = reader["dtferiasfim"].ToString();

                    if (dt1 != "" && dt2 != "")
                    {
                        if (dataatual >= Convert.ToDateTime(reader["dtferiasini"]) &&  dataatual <= Convert.ToDateTime(reader["dtferiasfim"]) )
                        {
                            retorno = true;
                        }
                        else
                        {
                            retorno = false;
                        }
                    }
                    
                }
                return retorno;
            }
            catch (Exception)
            {
                
                throw;
            }
            


        }


    }
}
