using Conect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klason_A.Dominio
{
    public class Curso
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
        public void Deletar()
        {
            // Supondo que você tenha uma classe Conexao que gerencie a conexão com o banco de dados
            Conexao conn = new Conexao();

            // Montando o comando SQL para deletar o aluno com base no ID
            string aux = $"USE KlasonBanco; DELETE FROM curso WHERE CursoID = {CursoID};";

            // Executando o comando SQL
            conn.Executar(aux);
        }
        public void Atualizar()
        {
            // Supondo que você tenha uma classe Conexao que gerencie a conexão com o banco de dados
            Conexao conn = new Conexao();

            // Montando o comando SQL para deletar o aluno com base no ID
            string aux = $"" +
                $"USE KlasonBanco; " +
                $"UPDATE curso SET Categoria = '{Categoria}', Descricao = '{Descricao}', CaminhoImagem = '{ImgCapa}', Valor = {Valor.ToString().Replace(',', '.')}, Situacao='{Status}', ProfessorID = {ProfessorID}" +
                $" WHERE CursoID = {CursoID};";

            // Executando o comando SQL
            conn.Executar(aux);

        }
    }

}
