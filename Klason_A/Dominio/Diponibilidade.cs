using Conect;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klason_A.Dominio
{
    internal class Diponibilidade
    {
        public int DisponibilidadeID { get; set; }
        public int ProfessorID { get; set; }
        public DateTime Dia { get; set; }

        public void Inserir()
        {
            Conexao c = new Conexao();
           // string c 
        }

    }
}
