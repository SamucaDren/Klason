using System;
using System.Collections.Generic;
using System.Data;
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
            string aux = "SERVER=.\\SQLEXPRESS;Integrated Security = True";
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
            Desconectar();

            return ds;
        }
        public void Desconectar()
        {
            conn.Close();
        }
    }
}
