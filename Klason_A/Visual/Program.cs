using Conect;
using Dominio;
using Klason_A.Dominio;
using Klason_A.Visual.Modulos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klason_A
{
    

    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>

        static public List<Aluno> _alunos;
        static public List<Professor> _professores;
        static public List<Curso> _cursos;
        static private Conexao conect = new Conexao();
        static public void AtualizaBanco()
        {
            foreach (DataRow dr in conect.RetornaDataSet().Tables["aluno"].Rows)
            {
                Aluno aluno = new Aluno();

                aluno.Nome = $"{dr["Nome"]}";
                aluno.Email = $"{dr["Email"]}";
                aluno.AlunoID = int.Parse($"{dr["AlunoID"]}");
                aluno.Senha = $"{dr["Senha"]}";
                aluno.Status = $"{dr["Situacao"]}";

                _alunos.Add(aluno);
            }

            foreach (DataRow dr in conect.RetornaDataSet().Tables["curso"].Rows)
            {
                Curso curso = new Curso();
                curso.Descricao = $"{dr["Descricao"]}";
                curso.CursoID = (int)dr["CursoID"];
                curso.ProfessorID = (int)dr["ProfessorID"];
                curso.Status = $"{dr["Situacao"]}";
                curso.Categoria = $"{dr["Categoria"]}";
                curso.Valor = double.Parse($"{dr["Valor"]}");
                _cursos.Add(curso);
            }
            foreach (DataRow dr in conect.RetornaDataSet().Tables["professor"].Rows)
            {
                Professor prof = new Professor();

                prof.Nome = $"{dr["Nome"]}";
                prof.Email = $"{dr["Email"]}";
                prof.ProfessorID = (int)dr["ProfessorID"];
                prof.Senha = $"{dr["Senha"]}";
                prof.Status = $"{dr["Situacao"]}";

                _professores.Add(prof);
            }

        }
        [STAThread]

        static void Main()
        {
            _alunos = new List<Aluno>();
            _professores = new List<Professor>();
            _cursos = new List<Curso>();

            AtualizaBanco();
            Aluno aluno = new Aluno();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Login());
            //Application.Run(new Perfil(1, aluno));
        }
        
    }
}
