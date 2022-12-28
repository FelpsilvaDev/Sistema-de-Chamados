using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Persistencia
{
    public class ConexaoMysql
    {
        MySqlConnection cn = new MySqlConnection();
        public MySqlConnection CriaConexao()
        {
            try
            {
                cn.ConnectionString = @"Persist Security Info=false;Server =172.16.40.23;Database=bd_chamados;Uid =system;pwd =manager";

                cn.Open();

                return cn;
            }
            catch (Exception)
            {

                throw;
            }
           

        }

        public void FechaConexao()
        {
            cn.Close();
        }
    }
}
