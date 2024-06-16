using Conect;
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


        public void Inserir()
        {
            Conexao conn = new Conexao();
            string aux = $"USE KlasonBanco; INSERT INTO ";
        }
        public void Deletar(int id)
        {
            // Supondo que você tenha uma classe Conexao que gerencie a conexão com o banco de dados
            Conexao conn = new Conexao();

            // Montando o comando SQL para deletar o aluno com base no ID
            string aux = $"USE KlasonBanco; DELETE FROM aluno WHERE AlunoID = {AlunoID};";

            // Executando o comando SQL
            conn.Executar(aux);
        }

    }
}
