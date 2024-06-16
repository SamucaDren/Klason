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
        public void Deletar()
        {
            // Supondo que você tenha uma classe Conexao que gerencie a conexão com o banco de dados
            Conexao conn = new Conexao();

            // Montando o comando SQL para deletar o aluno com base no ID
            string aux = $"USE KlasonBanco; DELETE FROM disponibilidade WHERE DataDisponivelID= {DisponibilidadeID};";

            // Executando o comando SQL
            conn.Executar(aux);
        }

    }
}
