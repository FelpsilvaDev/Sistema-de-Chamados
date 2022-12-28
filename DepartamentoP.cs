using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using Entidades;

namespace Persistencia
{
    public class DepartamentoP
    {

        public void  Inserir(DepartamentoE depto)
        {
            ConexaoMysql conexao = new ConexaoMysql();
            //MySqlConnection cn = conexao.CriaConexao();

            string strQuery = "INSERT INTO tb_departamentos (descritivodept) values(@depto)";

            MySqlCommand comando = new MySqlCommand(strQuery,conexao.CriaConexao()); // passando parametros de conexao e comando para o Mysql Comannd

            comando.Parameters.AddWithValue("@depto", depto.NomeDepto);//passando parametros do comando
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

        public List<DepartamentoE> ListarDepartamentos() //Metodo para Listar registros do banco de dados
        {
            List<DepartamentoE> retornoLista = new List<DepartamentoE>(); // instanciando nova lista para os registro do tipo departamentoE 

            string strQuery = "SELECT A.codDept ,A.descritivodept , B.Nome FROM bd_chamados_hml.tb_departamentos A LEFT JOIN bd_chamados_hml.tb_gestores B on A.cod = B.cod where b.cod != 100"; //query no banco    
            ConexaoMysql conexao = new ConexaoMysql(); // instanciando Classe de conexao 

            try
            {
                MySqlCommand cmd = new MySqlCommand(strQuery, conexao.CriaConexao()); // passando parametros de conexao- abrindo conexao
                MySqlDataReader leitura = cmd.ExecuteReader(); //executando leitura no banco de dados

                while (leitura.Read()) // enquanto houver registros vai adicionar na lista criada
                {
                    DepartamentoE dep = new DepartamentoE(); // objeto para adicionar na lista

                    dep.Codigo = (int)leitura["codDept"]; // populando propriedades do objeto
                    dep.NomeDepto = leitura["descritivodept"].ToString();// populando propriedades do objeto
                    dep.NomeGestor = leitura["Nome"].ToString();

                    retornoLista.Add(dep); // adicionando registro na lista
                }
                return retornoLista;// retornando lista 

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
        public List<DepartamentoE> ListarModulos() //Metodo para Listar registros do banco de dados
        {
            List<DepartamentoE> retornoLista = new List<DepartamentoE>(); // instanciando nova lista para os registro do tipo departamentoE 

            string strQuery = "SELECT A.codDept ,A.descritivodept , B.Nome FROM bd_chamados_hml.tb_departamentos A LEFT JOIN bd_chamados_hml.tb_gestores B on A.cod = B.cod where b.cod = 100"; //query no banco    
            ConexaoMysql conexao = new ConexaoMysql(); // instanciando Classe de conexao 

            try
            {
                MySqlCommand cmd = new MySqlCommand(strQuery, conexao.CriaConexao()); // passando parametros de conexao- abrindo conexao
                MySqlDataReader leitura = cmd.ExecuteReader(); //executando leitura no banco de dados

                while (leitura.Read()) // enquanto houver registros vai adicionar na lista criada
                {
                    DepartamentoE dep = new DepartamentoE(); // objeto para adicionar na lista

                    dep.Codigo = (int)leitura["codDept"]; // populando propriedades do objeto
                    dep.NomeDepto = leitura["descritivodept"].ToString();// populando propriedades do objeto
                    dep.NomeGestor = leitura["Nome"].ToString();

                    retornoLista.Add(dep); // adicionando registro na lista
                }
                return retornoLista;// retornando lista 

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

        public void AlterarDepartamento(DepartamentoE dep)
        {
            ConexaoMysql conexao = new ConexaoMysql();
            string strQuery = "UPDATE tb_departamentos  SET descritivodept=@descri , cod = @codgestor WHERE codDept =@cod";

            MySqlCommand comando = new MySqlCommand(strQuery, conexao.CriaConexao()); // passando parametros de conexao e comando para o Mysql Comannd

            comando.Parameters.AddWithValue("@descri",dep.NomeDepto);//passando parametros do comando
            comando.Parameters.AddWithValue("@codgestor",dep.Codgestor);
            comando.Parameters.AddWithValue("@cod", dep.Codigo);

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

        public DepartamentoE PesquisarPorCodigo (int cod)
        {
            // instanciando nova lista para os registro do tipo departamentoE 
            DepartamentoE dep = new DepartamentoE(); // objeto para adicionar na lista
            string strQuery = "SELECT A.codDept , A.descritivodept , B.Nome FROM tb_departamentos A LEFT JOIN tb_gestores B on A.cod = B.cod WHERE codDept = @cod"; //query no banco    
            ConexaoMysql conexao = new ConexaoMysql(); // instanciando Classe de conexao 

            try
            {
                MySqlCommand cmd = new MySqlCommand(strQuery, conexao.CriaConexao()); // passando parametros de conexao- abrindo conexao
                cmd.Parameters.AddWithValue("@cod", cod);
                MySqlDataReader leitura = cmd.ExecuteReader(); //executando leitura no banco de dados

                while (leitura.Read()) // enquanto houver registros vai adicionar na lista criada
                {
                    dep.Codigo = (int)leitura["codDept"]; // populando propriedades do objeto
                    dep.NomeDepto = leitura["descritivodept"].ToString();// populando propriedades do objeto
                    dep.NomeGestor = leitura["Nome"].ToString();
                    


                }
                return dep;// retornando lista 

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
        public void ExcluirDepartamento(int codigo) //metodo para excluir um departamento
        {
            ConexaoMysql conexao = new ConexaoMysql();

            string strQuery = "DELETE FROM tb_departamentos WHERE codDept = @cod";

            try
            {
                MySqlCommand cmd = new MySqlCommand(strQuery, conexao.CriaConexao());
                cmd.Parameters.AddWithValue("@cod", codigo); // passando codigo a ser excluido do banco de dados
                cmd.ExecuteNonQuery();
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


    }
}
