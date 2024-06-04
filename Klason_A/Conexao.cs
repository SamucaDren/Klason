using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conect
{
    public class Conexao
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public void Conectar()
        {
            string aux = "SERVER=.\\SQLEXPRESS;Database=KasonBanco;UID=sa;PWD=123";
            conn.ConnectionString = aux;
            conn.Open();
            //string aux2= "Integrated Security=SSPI;TrustServerCertificate=True";
            //Executar(aux2);
        }
        public void Executar(string sql)
        {
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
        public void Desconectar()
        {
            conn.Close();
        }
    }
}
