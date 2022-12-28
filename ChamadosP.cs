using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Entidades;
using System.Data.SqlTypes;

namespace Persistencia
{
    public class ChamadosP
    {

        public void InserirChamado(ChamadosE chamado)
        {
            MySqlConnection conexao = new MySqlConnection(Properties.Settings.Default.Conexao);
            //MySqlConnection cn = conexao.CriaConexao();

            string strQuery = "INSERT INTO tb_chamados (statusChamado,codCategoria,codSubcat,codDept,dataAbertura,usuario,descritivo,prioridade,dataFechamento,autorizacao, setor) "
                + "values(@status,@codigoCategoria,@codSubcat,@coddepar,@data,@usuario,@descri,@priori,@dataFechamento,@auto, @setor)";

            MySqlCommand comando = new MySqlCommand(strQuery, conexao); // passando parametros de conexao e comando para o Mysql Comannd
            comando.Parameters.AddWithValue("@status", "ABERTO");
            comando.Parameters.AddWithValue("@codigoCategoria", chamado.CodigoCategoria);
            comando.Parameters.AddWithValue("@codSubcat", chamado.CodigoSubcategoria);
            comando.Parameters.AddWithValue("@coddepar", chamado.CodigoDepartamento);
            comando.Parameters.AddWithValue("@data", chamado.DataAbertura);
            comando.Parameters.AddWithValue("@usuario", chamado.Usuario);
            comando.Parameters.AddWithValue("@descri", chamado.Descricao);
            comando.Parameters.AddWithValue("@priori", chamado.Prioridade);
            comando.Parameters.AddWithValue("@dataFechamento", chamado.DataFechamento);
            comando.Parameters.AddWithValue("@auto", chamado.Autorizacao);
            comando.Parameters.AddWithValue("@setor", chamado.setor);

            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }
        public void InserirChamadomecanico(ChamadosE chamado)
        {
            MySqlConnection conexao = new MySqlConnection(Properties.Settings.Default.Conexao);

            string strQuery = "INSERT INTO bd_chamados_hml.tb_chamados(statusChamado, codCategoria, codSubcat, codDept, dataAbertura, usuario, descritivo, prioridade, setor)" +
                "values(@status, @codigoCategoria, @codSubcat, @coddepar, @data, @usuario, @descri, @priori, @setor)";


            MySqlCommand comando = new MySqlCommand(strQuery, conexao); // passando parametros de conexao e comando para o Mysql 

            comando.Parameters.AddWithValue("@status", "ABERTO");
            comando.Parameters.AddWithValue("@codigoCategoria", chamado.CodigoCategoria);
            comando.Parameters.AddWithValue("@codSubcat", chamado.CodigoSubcategoria);
            comando.Parameters.AddWithValue("@coddepar", chamado.CodigoDepartamento);
            comando.Parameters.AddWithValue("@data", chamado.DataAbertura);
            comando.Parameters.AddWithValue("@usuario", chamado.Usuario);
            comando.Parameters.AddWithValue("@descri", chamado.Descricao);
            comando.Parameters.AddWithValue("@priori", chamado.Prioridade);
            comando.Parameters.AddWithValue("@setor", chamado.setor);

            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }
        public List<ChamadosE> ListarChamadosUsuario(string usuarioLogado, string status1, string status2, string status3)
        {
            List<ChamadosE> listaDeRetorno = new List<ChamadosE>();

            MySqlConnection conexao = new MySqlConnection(Properties.Settings.Default.Conexao);
            //MySqlConnection cn = conexao.CriaConexao();

            string strQuery = "SELECT C.codChamado,C.statusChamado,C.dataAbertura,C.dataFechamento,C.usuario,C.responsavel,C.prioridade,D.descritivodept,E.descritivoCat,"
                + "S.descritivoSubcat,C.descritivo,C.solucao, C.autorizacao from tb_chamados C "
                                                + "INNER JOIN tb_departamentos D on C.codDept = D.codDept "
                                                + "INNER JOIN tb_categoria E on C.codCategoria = E.codCategoria "
                                                + "INNER JOIN tb_subcategoria S on C.codsubcat = S.codsubcat  WHERE";

            MySqlCommand cmd = new MySqlCommand();

            if (usuarioLogado != "")
            {
                strQuery += " C.setor = 0 and C.usuario = @usuario and C.statusChamado in(select statusChamado from tb_chamados where C.statusChamado =@status1 or C.statusChamado =@status2 or C.statusChamado =@status3)";
                cmd.Parameters.AddWithValue("@usuario", usuarioLogado);
                cmd.Parameters.AddWithValue("@status1", status1);
                cmd.Parameters.AddWithValue("@status2", status2);
                cmd.Parameters.AddWithValue("@status3", status3);

            }
            else
            {
                strQuery += " C.setor = 0 and C.statusChamado between @status1 and @status3  ";
                cmd.Parameters.AddWithValue("@status1", status1);
                cmd.Parameters.AddWithValue("@status3", status3);
            }


            strQuery += " order by C.dataAbertura desc";
            cmd.CommandText = strQuery;
            cmd.Connection = conexao;

            try
            {
                conexao.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ChamadosE chamado = new ChamadosE();
                    chamado.Codigo = (int)reader["codChamado"];
                    chamado.Status = reader["statusChamado"].ToString();
                    chamado.Usuario = reader["usuario"].ToString();
                    chamado.Responsavel = reader["responsavel"].ToString();
                    chamado.DataAbertura = (DateTime)reader["dataAbertura"];

                    chamado.DataFechamento = reader["dataFechamento"].ToString();

                    if (chamado.DataFechamento.Equals(""))
                    {
                        chamado.DataFechamento = "";
                    }
                    chamado.Descricao = reader["descritivo"].ToString();
                    chamado.Solucao = reader["solucao"].ToString();
                    chamado.Prioridade = reader["prioridade"].ToString();
                    chamado.Departamento = reader["descritivodept"].ToString();
                    chamado.Categoria = reader["descritivocat"].ToString();
                    chamado.Subcategoria = reader["descritivosubcat"].ToString();
                    chamado.Autorizacao = reader["autorizacao"].ToString();
                    if (chamado.Autorizacao == "S")
                    {
                        chamado.Autorizacao = "SIM";
                    }
                    else if (chamado.Autorizacao == "N")
                    {
                        chamado.Autorizacao = "NÃO";
                    }
                    if (chamado.Autorizacao == "P")
                    {
                        chamado.Autorizacao = "PENDENTE";
                    }
                    else
                    {
                        chamado.Autorizacao = "";
                    }


                    listaDeRetorno.Add(chamado);

                }
                return listaDeRetorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }
        public List<ChamadosE> ListarChamadosUsuariomecanico(string status1, string status2, string status3)
        {
            List<ChamadosE> listaDeRetorno = new List<ChamadosE>();

            MySqlConnection conexao = new MySqlConnection(Properties.Settings.Default.Conexao);
            //MySqlConnection cn = conexao.CriaConexao();

            string strQuery = "SELECT C.codChamado,C.statusChamado,C.dataAbertura,C.dataFechamento,C.usuario,C.responsavel,C.prioridade,D.descritivodept,E.descritivoCat,"
                + "S.descritivoSubcat,C.descritivo,C.solucao, C.autorizacao from tb_chamados C "
                                                + "INNER JOIN tb_departamentos D on C.codDept = D.codDept "
                                                + "INNER JOIN tb_categoria E on C.codCategoria = E.codCategoria "
                                                + "INNER JOIN tb_subcategoria S on C.codsubcat = S.codsubcat WHERE ";

            MySqlCommand cmd = new MySqlCommand();


            strQuery += "C.setor = 1 and C.statusChamado between @status1 and @status3 ";
            cmd.Parameters.AddWithValue("@status1", status1);
            cmd.Parameters.AddWithValue("@status2", status2);
            cmd.Parameters.AddWithValue("@status3", status3);

            strQuery += " order by C.dataAbertura desc";
            cmd.CommandText = strQuery;
            cmd.Connection = conexao;

            try
            {
                conexao.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ChamadosE chamado = new ChamadosE();
                    chamado.Codigo = (int)reader["codChamado"];
                    chamado.Status = reader["statusChamado"].ToString();
                    chamado.Usuario = reader["usuario"].ToString();
                    chamado.Responsavel = reader["responsavel"].ToString();
                    chamado.DataAbertura = (DateTime)reader["dataAbertura"];

                    chamado.DataFechamento = reader["dataFechamento"].ToString();

                    if (chamado.DataFechamento.Equals(""))
                    {
                        chamado.DataFechamento = "";
                    }
                    chamado.Descricao = reader["descritivo"].ToString();
                    chamado.Solucao = reader["solucao"].ToString();
                    chamado.Prioridade = reader["prioridade"].ToString();
                    chamado.Departamento = reader["descritivodept"].ToString();
                    chamado.Categoria = reader["descritivocat"].ToString();
                    chamado.Subcategoria = reader["descritivosubcat"].ToString();
                    chamado.Autorizacao = reader["autorizacao"].ToString();
                    if (chamado.Autorizacao == "S")
                    {
                        chamado.Autorizacao = "SIM";
                    }
                    else if (chamado.Autorizacao == "N")
                    {
                        chamado.Autorizacao = "NÃO";
                    }
                    if (chamado.Autorizacao == "P")
                    {
                        chamado.Autorizacao = "PENDENTE";
                    }
                    else
                    {
                        chamado.Autorizacao = "";
                    }
                    listaDeRetorno.Add(chamado);
                }
                return listaDeRetorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }

        public List<ChamadosE> ListarChamadosUsuario(string usuarioLogado, string status)
        {
            List<ChamadosE> listaDeRetorno = new List<ChamadosE>();

            MySqlConnection conexao = new MySqlConnection(Properties.Settings.Default.Conexao);
            //MySqlConnection cn = conexao.CriaConexao();


            string strQuery = "SELECT C.codChamado,C.statusChamado,C.dataAbertura,C.dataFechamento,C.usuario,C.responsavel,C.prioridade,D.descritivodept,E.descritivoCat,"
                + "S.descritivoSubcat,C.descritivo,C.solucao from tb_chamados C "
                                                + "INNER JOIN tb_departamentos D on C.codDept = D.codDept "
                                                + "INNER JOIN tb_categoria E on C.codCategoria = E.codCategoria "
                                                + "INNER JOIN tb_subcategoria S on C.codsubcat = S.codsubcat "
                                                + "WHERE C.statusChamado = @status";

            MySqlCommand cmd = new MySqlCommand();

            if (usuarioLogado != "")
            {
                strQuery += " and C.usuario = @usuario ";
                cmd.Parameters.AddWithValue("@usuario", usuarioLogado);
            }

            strQuery += " order by C.dataAbertura desc"; // para fazer busca de forma descendente por data

            cmd.Connection = conexao; //passando conexao
            cmd.CommandText = strQuery;// passando string QUERY

            cmd.Parameters.AddWithValue("@status", status);//passando o parametro de status
            try
            {
                conexao.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ChamadosE chamado = new ChamadosE();
                    chamado.Codigo = (int)reader["codChamado"];
                    chamado.Status = reader["statusChamado"].ToString();
                    chamado.Usuario = reader["usuario"].ToString();
                    chamado.Responsavel = reader["responsavel"].ToString();
                    chamado.DataAbertura = (DateTime)reader["dataAbertura"];

                    chamado.DataFechamento = reader["dataFechamento"].ToString();
                    if (chamado.DataFechamento == "")
                    {
                        chamado.DataFechamento = "";
                    }
                    chamado.Descricao = reader["descritivo"].ToString();
                    chamado.Solucao = reader["solucao"].ToString();
                    chamado.Prioridade = reader["prioridade"].ToString();
                    chamado.Departamento = reader["descritivodept"].ToString();
                    chamado.Categoria = reader["descritivocat"].ToString();
                    chamado.Subcategoria = reader["descritivosubcat"].ToString();

                    listaDeRetorno.Add(chamado);

                }

                return listaDeRetorno;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }



        }
        public List<ChamadosE> ListarChamadosMecanica(string usuarioLogado, string status)
        {
            List<ChamadosE> listaDeRetorno = new List<ChamadosE>();

            MySqlConnection conexao = new MySqlConnection(Properties.Settings.Default.Conexao);
            //MySqlConnection cn = conexao.CriaConexao();


            string strQuery = "SELECT C.codChamado,C.statusChamado,C.dataAbertura,C.dataFechamento,C.usuario,C.responsavel,C.prioridade,D.descritivodept,E.descritivoCat,"
                + "S.descritivoSubcat,C.descritivo,C.solucao from tb_chamados C "
                                                + "INNER JOIN tb_departamentos D on C.codDept = D.codDept "
                                                + "INNER JOIN tb_categoria E on C.codCategoria = E.codCategoria "
                                                + "INNER JOIN tb_subcategoria S on C.codsubcat = S.codsubcat "
                                                + "WHERE C.statusChamado = @status";

            MySqlCommand cmd = new MySqlCommand();

            if (usuarioLogado != "")
            {
                strQuery += " and C.usuario = @usuario ";
                cmd.Parameters.AddWithValue("@usuario", usuarioLogado);
            }

            strQuery += " and C.setor = 1";
            strQuery += " order by C.dataAbertura desc"; // para fazer busca de forma descendente por data

            cmd.Connection = conexao; //passando conexao
            cmd.CommandText = strQuery;// passando string QUERY

            cmd.Parameters.AddWithValue("@status", status);//passando o parametro de status
            try
            {
                conexao.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ChamadosE chamado = new ChamadosE();
                    chamado.Codigo = (int)reader["codChamado"];
                    chamado.Status = reader["statusChamado"].ToString();
                    chamado.Usuario = reader["usuario"].ToString();
                    chamado.Responsavel = reader["responsavel"].ToString();
                    chamado.DataAbertura = (DateTime)reader["dataAbertura"];

                    chamado.DataFechamento = reader["dataFechamento"].ToString();
                    if (chamado.DataFechamento == "")
                    {
                        chamado.DataFechamento = "";
                    }
                    chamado.Descricao = reader["descritivo"].ToString();
                    chamado.Solucao = reader["solucao"].ToString();
                    chamado.Prioridade = reader["prioridade"].ToString();
                    chamado.Departamento = reader["descritivodept"].ToString();
                    chamado.Categoria = reader["descritivocat"].ToString();
                    chamado.Subcategoria = reader["descritivosubcat"].ToString();

                    listaDeRetorno.Add(chamado);

                }

                return listaDeRetorno;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }



        }
        public ChamadosE PesquisarPorCodigo(int numeroChamado)
        {
            MySqlConnection conexao = new MySqlConnection(Properties.Settings.Default.Conexao);
            //MySqlConnection cn = conexao.CriaConexao();
            ChamadosE chamado = new ChamadosE();
            string strQuery = "SELECT C.codChamado,C.statusChamado,C.dataAbertura,C.dataFechamento,C.usuario,C.responsavel,C.prioridade,D.descritivodept,E.descritivoCat,"
                + "S.descritivoSubcat,C.descritivo,C.solucao, C.indevido , C.autorizacao from tb_chamados C "
                                                + "INNER JOIN tb_departamentos D on C.codDept = D.codDept "
                                                + "INNER JOIN tb_categoria E on C.codCategoria = E.codCategoria "
                                                + "INNER JOIN tb_subcategoria S on C.codsubcat = S.codsubcat "
                                                + "WHERE C.codChamado = @codigo ";

            MySqlCommand cmd = new MySqlCommand(strQuery, conexao);
            cmd.Parameters.AddWithValue("@codigo", numeroChamado);

            try
            {
                conexao.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    chamado.Codigo = (int)reader["codChamado"];
                    chamado.Status = reader["statusChamado"].ToString();
                    chamado.Usuario = reader["usuario"].ToString();
                    chamado.Responsavel = reader["responsavel"].ToString();
                    chamado.DataAbertura = (DateTime)reader["dataAbertura"];
                    chamado.DataFechamento = reader["dataFechamento"].ToString();
                    chamado.Descricao = reader["descritivo"].ToString();
                    chamado.Solucao = reader["solucao"].ToString();
                    chamado.Prioridade = reader["prioridade"].ToString();
                    chamado.Departamento = reader["descritivodept"].ToString();
                    chamado.Categoria = reader["descritivocat"].ToString();
                    chamado.Subcategoria = reader["descritivosubcat"].ToString();
                    chamado.Indevido = reader["indevido"].ToString();
                    chamado.Autorizacao = reader["autorizacao"].ToString();


                }

                return chamado;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }
        public void AlterarChamado(ChamadosE chamado, DateTime? dtfecha)
        {
            MySqlConnection conexao = new MySqlConnection(Properties.Settings.Default.Conexao);
            //MySqlConnection cn = conexao.CriaConexao();

            string strQuery = "UPDATE tb_chamados SET statusChamado=@status,dataAbertura=@data,usuario=@usuario,prioridade=@priori,dataFechamento=@dataFechamento,responsavel=@resp"
                + ",observacoesResponsavel = @obs,indevido=@indevido ,solucao = @solu "
                + "WHERE codChamado = @codChamado";

            MySqlCommand comando = new MySqlCommand(strQuery, conexao); // passando parametros de conexao e comando para o Mysql Comannd
            comando.Parameters.AddWithValue("@status", chamado.Status);
            // comando.Parameters.AddWithValue("@codigoCategoria", chamado.CodigoCategoria);
            //comando.Parameters.AddWithValue("@codSubcat", chamado.CodigoSubcategoria);
            //comando.Parameters.AddWithValue("@coddepar", chamado.CodigoDepartamento);
            comando.Parameters.AddWithValue("@data", chamado.DataAbertura);
            comando.Parameters.AddWithValue("@usuario", chamado.Usuario);
            comando.Parameters.AddWithValue("@descri", chamado.Descricao);
            comando.Parameters.AddWithValue("@priori", chamado.Prioridade);
            comando.Parameters.AddWithValue("@dataFechamento", dtfecha);
            comando.Parameters.AddWithValue("@resp", chamado.Responsavel);
            comando.Parameters.AddWithValue("@obs", chamado.ObservacoesResponsavel);
            comando.Parameters.AddWithValue("@indevido", chamado.Indevido);
            comando.Parameters.AddWithValue("@solu", chamado.Solucao);
            comando.Parameters.AddWithValue("@codChamado", chamado.Codigo);

            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }

        public List<ChamadosE> BuscarHistorico(ChamadosE chamado, DateTime datarange)
        {

            List<ChamadosE> listaDeRetorno = new List<ChamadosE>();
            MySqlConnection conexao = new MySqlConnection(Properties.Settings.Default.Conexao);
            string strQuery = "SELECT C.codChamado,C.statusChamado,C.dataAbertura,C.dataFechamento,C.usuario,C.responsavel,C.prioridade,D.descritivodept,E.descritivoCat,"
                + "S.descritivoSubcat,C.descritivo,C.solucao,C.indevido,C.observacoesResponsavel from tb_chamados C "
                                                + "INNER JOIN tb_departamentos D on C.codDept = D.codDept "
                                                + "INNER JOIN tb_categoria E on C.codCategoria = E.codCategoria "
                                                + "INNER JOIN tb_subcategoria S on C.codsubcat = S.codsubcat WHERE";
            MySqlCommand comando = new MySqlCommand();


            if (chamado.DataAbertura != null && datarange != null)
            {
                strQuery += " C.dataAbertura >= @data1 and C.dataAbertura <= @data2";
                comando.Parameters.AddWithValue("@data1", chamado.DataAbertura);
                comando.Parameters.AddWithValue("@data2", datarange);

            }
            if (chamado.Status != "" && chamado.Status != "TODOS")
            {
                strQuery += " and C.statusChamado=@status";
                comando.Parameters.AddWithValue("@status", chamado.Status);
            }
            if (chamado.CodigoCategoria != 0)
            {
                strQuery += " and C.codCategoria=@codigocat ";
                comando.Parameters.AddWithValue("@codigocat", chamado.CodigoCategoria);
            }
            if (chamado.CodigoSubcategoria != 0)
            {
                strQuery += " and C.codsubcat=@codigosub ";
                comando.Parameters.AddWithValue("@codigosub", chamado.CodigoSubcategoria);
            }
            if (chamado.CodigoDepartamento != 0)
            {
                strQuery += " and C.codDept=@codigodepar";
                comando.Parameters.AddWithValue("@codigodepar", chamado.CodigoDepartamento);
            }
            if (chamado.Usuario != null)
            {
                strQuery += " and C.usuario = @usuario";
                comando.Parameters.AddWithValue("@usuario", chamado.Usuario);
            }
            if (chamado.Responsavel != null)
            {
                strQuery += " and C.responsavel = @resp";
                comando.Parameters.AddWithValue("@resp", chamado.Responsavel);
            }

            strQuery += " and C.setor = @setor";
            comando.Parameters.AddWithValue("@setor", chamado.setor);

            strQuery += " ORDER BY C.dataAbertura DESC";
            comando.CommandText = strQuery;
            comando.Connection = conexao;

            try
            {
                conexao.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ChamadosE chama = new ChamadosE();
                    chama.Codigo = (int)reader["codChamado"];
                    chama.Status = reader["statusChamado"].ToString();
                    chama.Usuario = reader["usuario"].ToString();
                    chama.Responsavel = reader["responsavel"].ToString();
                    chama.DataAbertura = (DateTime)reader["dataAbertura"];
                    chama.DataFechamento = reader["dataFechamento"].ToString();
                    chama.Descricao = reader["descritivo"].ToString();
                    chama.Solucao = reader["solucao"].ToString();
                    chama.Prioridade = reader["prioridade"].ToString();
                    chama.Departamento = reader["descritivodept"].ToString();
                    chama.Categoria = reader["descritivocat"].ToString();
                    chama.Subcategoria = reader["descritivosubcat"].ToString();
                    chama.Indevido = reader["indevido"].ToString();
                    chama.ObservacoesResponsavel = reader["observacoesResponsavel"].ToString();

                    listaDeRetorno.Add(chama);

                }

                return listaDeRetorno;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }


        }

        public int BuscarUltimoChamadoAberto(ChamadosE chamado)
        {
            MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.Conexao);
            string strQuery = "SELECT MAX(codChamado) FROM tb_chamados";
            MySqlCommand comando = new MySqlCommand(strQuery, cn);
            //comando.Parameters.AddWithValue("@usuario", chamado.Usuario);

            try
            {
                cn.Open();
                int ultimoregistro = Convert.ToInt32(comando.ExecuteScalar());

                return ultimoregistro + 1;
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

        public List<ChamadosE> ListarParaAutorizações(int codgestor, int subcat1, int subcat2, int subcat3, string status)
        {
            List<ChamadosE> listaDeRetorno = new List<ChamadosE>();

            MySqlConnection conexao = new MySqlConnection(Properties.Settings.Default.Conexao);
            //MySqlConnection cn = conexao.CriaConexao();

            string strQuery = "SELECT C.codChamado,C.statusChamado,C.dataAbertura,C.dataFechamento,C.usuario,C.responsavel,C.prioridade,D.descritivodept,E.descritivoCat,"
                + "S.descritivoSubcat,C.descritivo,C.solucao from tb_chamados C "
                                                + "INNER JOIN tb_departamentos D on C.codDept = D.codDept "
                                                + "INNER JOIN tb_categoria E on C.codCategoria = E.codCategoria "
                                                + "INNER JOIN tb_subcategoria S on C.codsubcat = S.codsubcat  WHERE  C.autorizacao = @auto AND C.statusChamado = @status AND C.codDept IN (SELECT coddept FROM tb_departamentos WHERE cod = @cod) AND C.codsubcat BETWEEN @subcat AND @subcat3";

            MySqlCommand cmd = new MySqlCommand();

            cmd.Parameters.AddWithValue("@subcat", subcat1);
            cmd.Parameters.AddWithValue("@subcat2", subcat2);
            cmd.Parameters.AddWithValue("@subcat3", subcat3);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@cod", codgestor);
            cmd.Parameters.AddWithValue("@auto", "P");


            strQuery += " order by C.dataAbertura desc";
            cmd.CommandText = strQuery;
            cmd.Connection = conexao;

            try
            {
                conexao.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ChamadosE chamado = new ChamadosE();
                    chamado.Codigo = (int)reader["codChamado"];
                    chamado.Status = reader["statusChamado"].ToString();
                    chamado.Usuario = reader["usuario"].ToString();
                    chamado.Responsavel = reader["responsavel"].ToString();
                    chamado.DataAbertura = (DateTime)reader["dataAbertura"];

                    chamado.DataFechamento = reader["dataFechamento"].ToString();

                    if (chamado.DataFechamento.Equals(""))
                    {
                        chamado.DataFechamento = "";
                    }
                    chamado.Descricao = reader["descritivo"].ToString();
                    chamado.Solucao = reader["solucao"].ToString();
                    chamado.Prioridade = reader["prioridade"].ToString();
                    chamado.Departamento = reader["descritivodept"].ToString();
                    chamado.Categoria = reader["descritivocat"].ToString();
                    chamado.Subcategoria = reader["descritivosubcat"].ToString();

                    listaDeRetorno.Add(chamado);

                }

                return listaDeRetorno;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }

        public void AlteraAutorização(int cod, string autori, int codgestor)
        {
            MySqlConnection conexao = new MySqlConnection(Properties.Settings.Default.Conexao);
            //MySqlConnection cn = conexao.CriaConexao();

            string strQuery = "UPDATE tb_chamados SET autorizacao=@auto , cod = @cod WHERE codChamado = @codChamado";

            MySqlCommand comando = new MySqlCommand(strQuery, conexao); // passando parametros de conexao e comando para o Mysql Comannd

            comando.Parameters.AddWithValue("@auto", autori);
            comando.Parameters.AddWithValue("@codChamado", cod);
            comando.Parameters.AddWithValue("@cod", codgestor);

            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }

        }

        public List<ChamadosE> BuscaHistoricoGestor(int codGestor, DateTime dt1, DateTime dt2)
        {
            List<ChamadosE> listaDeRetorno = new List<ChamadosE>();
            MySqlConnection conexao = new MySqlConnection(Properties.Settings.Default.Conexao);
            string strQuery = "SELECT C.codChamado,C.statusChamado,C.dataAbertura,C.dataFechamento,C.usuario,C.responsavel,C.prioridade,D.descritivodept,E.descritivoCat,"
                + "S.descritivoSubcat,C.descritivo,C.solucao,C.indevido,C.observacoesResponsavel from tb_chamados C "
                                                + "INNER JOIN tb_departamentos D on C.codDept = D.codDept "
                                                + "INNER JOIN tb_categoria E on C.codCategoria = E.codCategoria "
                                                + "INNER JOIN tb_subcategoria S on C.codsubcat = S.codsubcat WHERE C.codDept in (select codDept from tb_departamentos WHERE cod = @cod) AND autorizacao = 'S'  AND dataAbertura BETWEEN @dt1 and @dt2 AND C.cod = @cod";
            MySqlCommand comando = new MySqlCommand(strQuery, conexao);
            comando.Parameters.AddWithValue("@cod", codGestor);
            comando.Parameters.AddWithValue("@dt1", dt1);
            comando.Parameters.AddWithValue("@dt2", dt2);

            try
            {
                conexao.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ChamadosE chama = new ChamadosE();
                    chama.Codigo = (int)reader["codChamado"];
                    chama.Status = reader["statusChamado"].ToString();
                    chama.Usuario = reader["usuario"].ToString();
                    chama.Responsavel = reader["responsavel"].ToString();
                    chama.DataAbertura = (DateTime)reader["dataAbertura"];
                    chama.DataFechamento = reader["dataFechamento"].ToString();
                    chama.Descricao = reader["descritivo"].ToString();
                    chama.Solucao = reader["solucao"].ToString();
                    chama.Prioridade = reader["prioridade"].ToString();
                    chama.Departamento = reader["descritivodept"].ToString();
                    chama.Categoria = reader["descritivocat"].ToString();
                    chama.Subcategoria = reader["descritivosubcat"].ToString();
                    chama.Indevido = reader["indevido"].ToString();
                    chama.ObservacoesResponsavel = reader["observacoesResponsavel"].ToString();

                    listaDeRetorno.Add(chama);

                }

                return listaDeRetorno;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }


        }

        public List<ChamadosE> BuscaHistoricoGestor(DateTime dt1, DateTime dt2, int coddept)
        {
            List<ChamadosE> listaDeRetorno = new List<ChamadosE>();
            MySqlConnection conexao = new MySqlConnection(Properties.Settings.Default.Conexao);
            string strQuery = "SELECT C.codChamado,C.statusChamado,C.dataAbertura,C.dataFechamento,C.usuario,C.responsavel,C.prioridade,D.descritivodept,E.descritivoCat,"
                + "S.descritivoSubcat,C.descritivo,C.solucao,C.indevido,C.observacoesResponsavel from tb_chamados C "
                                                + "INNER JOIN tb_departamentos D on C.codDept = D.codDept "
                                                + "INNER JOIN tb_categoria E on C.codCategoria = E.codCategoria "
                                                + "INNER JOIN tb_subcategoria S on C.codsubcat = S.codsubcat WHERE C.codDept = @coddept AND autorizacao = 'S'  AND dataAbertura BETWEEN @dt1 and @dt2";
            MySqlCommand comando = new MySqlCommand(strQuery, conexao);
            comando.Parameters.AddWithValue("@coddept", coddept);
            comando.Parameters.AddWithValue("@dt1", dt1);
            comando.Parameters.AddWithValue("@dt2", dt2);

            try
            {
                conexao.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ChamadosE chama = new ChamadosE();
                    chama.Codigo = (int)reader["codChamado"];
                    chama.Status = reader["statusChamado"].ToString();
                    chama.Usuario = reader["usuario"].ToString();
                    chama.Responsavel = reader["responsavel"].ToString();
                    chama.DataAbertura = (DateTime)reader["dataAbertura"];
                    chama.DataFechamento = reader["dataFechamento"].ToString();
                    chama.Descricao = reader["descritivo"].ToString();
                    chama.Solucao = reader["solucao"].ToString();
                    chama.Prioridade = reader["prioridade"].ToString();
                    chama.Departamento = reader["descritivodept"].ToString();
                    chama.Categoria = reader["descritivocat"].ToString();
                    chama.Subcategoria = reader["descritivosubcat"].ToString();
                    chama.Indevido = reader["indevido"].ToString();
                    chama.ObservacoesResponsavel = reader["observacoesResponsavel"].ToString();

                    listaDeRetorno.Add(chama);

                }

                return listaDeRetorno;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }


        }

        public List<ChamadosE> BuscaHistoricoGestor(int codgestor)
        {
            List<ChamadosE> listaDeRetorno = new List<ChamadosE>();
            MySqlConnection conexao = new MySqlConnection(Properties.Settings.Default.Conexao);
            string strQuery = "SELECT C.codChamado,C.statusChamado,C.dataAbertura,C.dataFechamento,C.usuario,C.responsavel,C.prioridade,D.descritivodept,E.descritivoCat,"
                + "S.descritivoSubcat,C.descritivo,C.solucao,C.indevido,C.observacoesResponsavel from tb_chamados C "
                                                + "INNER JOIN tb_departamentos D on C.codDept = D.codDept "
                                                + "INNER JOIN tb_categoria E on C.codCategoria = E.codCategoria "
                                                + "INNER JOIN tb_subcategoria S on C.codsubcat = S.codsubcat WHERE C.codDept in (select codDept from tb_departamentos WHERE cod = @cod) AND autorizacao <> 'P' ";
            MySqlCommand comando = new MySqlCommand(strQuery, conexao);
            comando.Parameters.AddWithValue("@cod", codgestor);

            try
            {
                conexao.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ChamadosE chama = new ChamadosE();
                    chama.Codigo = (int)reader["codChamado"];
                    chama.Status = reader["statusChamado"].ToString();
                    chama.Usuario = reader["usuario"].ToString();
                    chama.Responsavel = reader["responsavel"].ToString();
                    chama.DataAbertura = (DateTime)reader["dataAbertura"];
                    chama.DataFechamento = reader["dataFechamento"].ToString();
                    chama.Descricao = reader["descritivo"].ToString();
                    chama.Solucao = reader["solucao"].ToString();
                    chama.Prioridade = reader["prioridade"].ToString();
                    chama.Departamento = reader["descritivodept"].ToString();
                    chama.Categoria = reader["descritivocat"].ToString();
                    chama.Subcategoria = reader["descritivosubcat"].ToString();
                    chama.Indevido = reader["indevido"].ToString();
                    chama.ObservacoesResponsavel = reader["observacoesResponsavel"].ToString();

                    listaDeRetorno.Add(chama);

                }

                return listaDeRetorno;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }


        }



    }

}
