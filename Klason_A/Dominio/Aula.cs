using Conect;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Klason_A.Dominio
{
    internal class Aula
    {
        public int AulaID { get; set; }
        public int CursoID { get; set; }
        public int AlunoID { get; set; }
        public DateTime Dia { get; set; }
        
        public void Inserir()
        {
            Conexao c = new Conexao();
            string aux = $"USE KlasonBanco; INSERT INTO aula(AlunoID, CursoID, Dia, Hora, Minuto) VALUES('{AlunoID}','{CursoID}','{Dia.Year}-{Dia.Month}-{Dia.Day}', {Dia.Hour}, {Dia.Minute});";
            c.Executar(aux);
        }

    }
}
