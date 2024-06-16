using Conect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klason_A.Dominio
{
    internal class Curso
    {
        //public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public int ProfessorID {  get; set; }
        public int CursoID { get; set; }
        public string ImgCapa { get; set; }
        public string Status { get; set; }
        public string Categoria { get; set; }

        public void Ativa()
        {
            Status = "Ativo";
        }

        public void Desativa()
        {
            Status = "Inativo";
        }

        public void Inserir()
        {
            Conexao c = new Conexao();
            string aux = $"USE KlasonBanco; INSERT INTO curso(Categoria, Descricao, CaminhoImagem, Valor, Situacao, ProfessorID) VALUES('{Categoria}','{Descricao}','{ImgCapa}',{Valor.ToString().Replace(',','.')},'{Status}', {ProfessorID});";
            c.Executar(aux);
        }
    }

}
