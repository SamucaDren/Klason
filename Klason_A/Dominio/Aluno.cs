using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Dominio

{
    public class Aluno
    {
        public string Nome { get; set; }
        public int AlunoID{ get; set; }
        public string telefone { get; set; }
        public string Email { get; set; }
        public string Senha{ get; set; }
        public string ImgPerfil { get; set; }
        public string Status { get; set; }

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
