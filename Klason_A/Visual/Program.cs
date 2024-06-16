using Conect;
using Dominio;
using Klason_A.Dominio;
using Klason_A.Repositorios;
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
<<<<<<< Updated upstream
=======
        static public List<Diponibilidade> _diponibilidades = new List<Diponibilidade>();
        static public List<Aula> _aulas = new List<Aula>();
>>>>>>> Stashed changes
        static private Conexao conect = new Conexao();
        static public Aluno UserAluno;
        static public void AtualizaBanco()
        {
            _alunos.Clear();
            _professores.Clear();
            _cursos.Clear();
<<<<<<< Updated upstream

            foreach (DataRow dr in conect.RetornaDataSet().Tables["aluno"].Rows)
=======
            _aulas.Clear();
            _diponibilidades.Clear();
            DataSet ds = conect.RetornaDataSet();
            foreach (DataRow dr in ds.Tables["aluno"].Rows)
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
            foreach (DataRow dr in ds.Tables["disponibilidade"].Rows)
            {
                Diponibilidade disp = new Diponibilidade();

                disp.DisponibilidadeID = (int)dr["DataDisponivelID"];
                disp.ProfessorID = (int)dr["ProfessorId"];
                disp.Dia = (DateTime)dr["DataDisponivel"];
                disp.Dia = disp.Dia.AddHours((int)dr["Hora"]);
                disp.Dia = disp.Dia.AddMinutes((int)dr["Minuto"]);

                _diponibilidades.Add(disp);
            }
            foreach (DataRow dr in ds.Tables["aula"].Rows)
            {
                Aula disp = new Aula();
                disp.AlunoID = int.Parse($"{dr["AlunoID"]}");
                disp.CursoID = (int)dr["CursoID"];
                disp.Dia = (DateTime)dr["Dia"];
                disp.Dia = disp.Dia.AddHours((int)dr["Hora"]);
                disp.Dia = disp.Dia.AddMinutes((int)dr["Minuto"]);
                disp.AulaID = (int)dr["AulaID"];

                _aulas.Add(disp);
            }
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
=======
            Professor pro = new Professor();
            foreach (Professor prof in _professores)
            {
                if (prof.ProfessorID == 4)
                {
                    pro = prof;
                }
            } 
            CriarCurso x = new CriarCurso(new Curso());
            x.Prof = pro;
>>>>>>> Stashed changes

            Application.Run(x);
            //Application.Run(new Perfil(1, aluno));
        }
        
    }
}
