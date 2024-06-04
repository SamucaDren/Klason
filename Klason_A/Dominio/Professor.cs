using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klason_A.Dominio
{
    internal class Professor
    {
        public string Nome { get; set; }
        public int ProfessorID { get; set; }
        public string telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ImgPerfil { get; set; }
        public string Status { get; set; }
        public string Descricao { get; set; }

        public void Ativa()
        {
            Status = "Ativo";
        }

        public void Desativa()
        {
            Status = "Inativo";
        }
    }
}
