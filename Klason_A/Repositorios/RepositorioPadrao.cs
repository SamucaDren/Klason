using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Conect;


namespace Repositorios
{
    public class RepositorioPadrao<t>
    {
        Conexao con = new Conexao();
        
        public void Adicionar()
        {
            con.Conectar();

        }
    }
}
