using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Data.SqlClient;

namespace Conect
{
    public class Conexao
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        //SqlConnection conn;

        public void Conectar()
        {
            string aux = "SERVER=.\\SQLEXPRESS;Integrated Security = True";
            string x = "Server = tcp:klasonserver.database.windows.net,1433; Initial Catalog =KlasonBanco; Persist Security Info = False; User ID =usuarioKlason; Password =Klason2024.; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            conn.ConnectionString = x;
            conn.Open();
        }
        public void Executar(string sql)
        {
            Conectar();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            Desconectar();
        }
        public DataSet RetornaDataSet()
        {
            Conectar();
            DataSet ds = new DataSet("KlasonTabelas");

            SqlDataAdapter adapter = new SqlDataAdapter($"USE KlasonBanco; SELECT * FROM aluno", conn);
            DataTable alunotable = new DataTable("aluno");
            adapter.Fill(alunotable);
            ds.Tables.Add(alunotable);

            SqlDataAdapter adapter02 = new SqlDataAdapter($"USE KlasonBanco; SELECT * FROM professor", conn);
            DataTable professortable = new DataTable("professor");
            adapter02.Fill(professortable);
            ds.Tables.Add(professortable);

            SqlDataAdapter adapter03 = new SqlDataAdapter($"USE KlasonBanco; SELECT * FROM curso", conn);
            DataTable cursotable = new DataTable("curso");
            adapter03.Fill(cursotable);
            ds.Tables.Add(cursotable);

            SqlDataAdapter adapter04 = new SqlDataAdapter($"USE KlasonBanco; SELECT * FROM aula", conn);
            DataTable aulatable = new DataTable("aula");
            adapter04.Fill(aulatable);
            ds.Tables.Add(aulatable);

            Desconectar();

            return ds;
        }
        public void Desconectar()
        {
            conn.Close();
        }
    }
}
