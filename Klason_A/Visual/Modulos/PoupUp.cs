using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Dominio;
using Klason_A.Dominio;
<<<<<<< Updated upstream
=======
using Klason_A.Visual.Modulos;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using GoogleCloudStorageExample;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Runtime.Remoting.Lifetime;
using Klason_A.Repositorios;
using Microsoft.Extensions.DependencyInjection;
>>>>>>> Stashed changes

namespace Klason_A
{
    internal class PoupUp
    {
        Cores_Fontes chave = new Cores_Fontes();
        private RoundedPanel Fundo = new RoundedPanel(40);
        private RoundedPanel Img = new RoundedPanel(38);
        private RoundedPanel pict = new RoundedPanel(30);
        private Label H1 = new Label();
        private Label H2 = new Label();
        private Label preco = new Label();
        RoundedPanel Fundo2 = new RoundedPanel(50);
        private Form formPai = new Form();
        private Image imagem_Curso = Properties.Resources.IMGteste;
        private string descricao = "É com grande entusiasmo que convidamos vocês para se juntarem a nós em uma jornada fascinante pelo cosmos na nossa próxima aula de astronomia! vamos explorar os mistérios do universo e desvendar seus segredos mais profundos.";

        private Curso _curso;
        private BotaoArredondado Disp;
        private bool ISPROF;
        private List<Diponibilidade> marcados = new List<Diponibilidade>();
        public bool IsProf
        {
            set
            {
                ISPROF = value;
                if (value == true)
                {
                    isProf();
                }
            }
            get
            {
                return ISPROF;
            }
        }
        private void isProf()
        {
            Panel p = new Panel();
            p.BackgroundImage = Properties.Resources.menu_open_24dp_FILL0_wght400_GRAD0_opsz24;
            p.BackgroundImageLayout = ImageLayout.Stretch;
            p.Size = new Size(28, 28);
            Fundo.Controls.Add(p);
            p.BringToFront();
            p.Location = new Point(Fundo.Width - 50,268);

            p.Click += (s, e) =>
            {

                opcoes();
            };

        }
        private void opcoes()
        {
            RoundedPanel fun = new RoundedPanel(50);
            fun.BackColor = chave.CinzaClaro;
            fun.Size = new Size(200, 200);
            formPai.Controls.Add(fun);
            fun.BringToFront();
            fun.Location = new Point(Cursor.Position.X-fun.Width/2, Cursor.Position.Y-fun.Height/2);

            fun.Padding = new Padding(20);
            Button exlui = new Button();
            exlui.FlatAppearance.BorderSize = 0;
            exlui.FlatStyle = FlatStyle.Flat;
            exlui.Dock = DockStyle.Top;
            exlui.BackColor = chave.Branco;
            exlui.Text = "Exluir";
            exlui.Font = chave.H3_Font_Sub;
            fun.Controls.Add(exlui);
            exlui.Height = 40;
            exlui.Click += (s, e) => { _curso.Deletar();Program.AtualizaBanco();formPai.Controls.Remove(fun);Fundo.Visible = false ; };
            Button inativa = new Button();
            if(_curso.Status == "Ativo")
            {
                inativa.Dock = DockStyle.Top;
                inativa.BackColor = chave.Branco;
                inativa.Text = "Inativar";
                inativa.Font = chave.H3_Font_Sub;
                inativa.Click += (s, e) => { _curso.Desativa(); _curso.Atualizar(); Fundo.BackColor = chave.CinzaClaro; };
                fun.Controls.Add(inativa);
                inativa.Height = 40;

            }
            else
            {
                inativa.Dock = DockStyle.Top;
                inativa.BackColor = chave.Branco;
                inativa.Text = "Ativar";
                inativa.Font = chave.H3_Font_Sub;
                inativa.Click += (s, e) => { _curso.Ativa(); _curso.Atualizar(); Fundo.BackColor = chave.Branco; };
                fun.Controls.Add(inativa);
                inativa.Height = 40;
            }
            fun.MouseLeave += (s, e) =>
            {
                if (!fun.ClientRectangle.Contains(fun.PointToClient(Control.MousePosition)))
                    formPai.Controls.Remove(fun);
            };

        }

        public Form Form_Pai
        {
            set
            {
                formPai = value;
            }
        }

        public PoupUp( Curso x)
        {
            _curso = x;
            CriaPoupUp();
        }

        public Image Imagem
        {
            get { return imagem_Curso; }
            set { imagem_Curso=value; }
        }

        public string NomeMateria
        {
            get { return H1.Text; }
            set { H1.Text = value; }
        }

        public string NomeProfessor
        {
            get { return H2.Text; }
            set { H2.Text = value; }
        }

        public string Descricao
        {
            get
            {
                return descricao;
            }
            set { descricao = value; }
        }

        double Valor
        {
            set
            {
                preco.Text = "R$ " + value.ToString("0,00");
            }
        }

        public RoundedPanel P
        {
            get { return Fundo; }
            set { Fundo = value; }
        }

        public void CriaPoupUp()
        {
            Fundo.Size = new Size(353, 418);
            Fundo.Location = new Point(500, 150);
            Fundo.BackColor = Color.White;
            if(_curso.Status == "Inativo")
            {
                Fundo.BackColor = chave.CinzaClaro;
            }
            
            Fundo.Controls.Add(Img);
            Img.BackColor = chave.Azul_Claro;
            Img.Size = new Size(Fundo.Width - 2, 251);
            Img.Location = new Point(1, 1);
            Img.Controls.Add(pict);
<<<<<<< Updated upstream
=======

            string nomeArquivo = $"{_curso.ImgCapa}.png";
            string pastaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string pasta = Path.Combine(pastaDocumentos, "Klason");

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            string destino = Path.Combine(pasta, nomeArquivo);

            if (_curso.ImgCapa != null && _curso.ImgCapa != DBNull.Value.ToString())
            {
                if (!File.Exists(destino))
                {
                    AddNoDrive c = new AddNoDrive();
                    Console.WriteLine($"Iniciando download do arquivo {_curso.ImgCapa} para o destino {destino}.");
                    Thread baixa = new Thread(() =>
                    {
                        c.download(_curso.ImgCapa, destino);
                        imagem_Curso = Image.FromFile(destino);
                    });
                    baixa.Start();
                }

                else { imagem_Curso = Image.FromFile(destino); }
            }

>>>>>>> Stashed changes
            pict.BackgroundImage = imagem_Curso;
            pict.BackgroundImageLayout = ImageLayout.Stretch;
            pict.Dock = DockStyle.Fill;
            int p = 20;
            Img.Padding = new Padding(p, p, p, p);

            //Botao Disp = new Botao(Fundo, "VER DISPONIBILIDADE");
            //Disp.Caixa_Botao.Size = new Size(Fundo.Width - 40, 42);
            //Disp.Caixa_Botao.R = Disp.Caixa_Botao.Height;
            //Disp.Caixa_Botao.BackColor = chave.Verde;
            //Disp.ForClick.BackColor = chave.Verde;
            //Disp.ForClick.ForeColor = Color.White;
            //Disp.Caixa_Botao.Location = new Point(p, Fundo.Height - Disp.Caixa_Botao.Height - p);
            //Disp.ForClick.Click += (senders, e) => Abre_Curso();

            
            Disp = new BotaoArredondado();
            Fundo.Controls.Add(Disp);
            Disp.Size = new Size(Fundo.Width - 40, 42);
            Disp.Radius = Disp.Height*2 -40;
            Disp.Text = "VER DISPPONIBILIDADE";
            Disp.BackColor = chave.Verde;
            Disp.ForeColor = chave.Branco;
            Disp.Location = new Point(p, Fundo.Height - Disp.Height - p);
            Disp.Click += (senders, e) => Abre_Curso();
            Disp.Font = chave.H3_Font_Sub;
            Disp.FlatStyle = FlatStyle.Flat;   
            Disp.FlatAppearance.BorderSize = 0;




            H1.Font = chave.H3_Font_Sub;
            H1.Text = _curso.Categoria;
            H1.Location = new Point(p, Img.Height + p);
            H1.ForeColor = chave.Preto;
            H1.AutoSize = true;

            H2.Font = chave.H3_Font;
            H2.Text = "Professor da Matéria";
            foreach(Professor x in Program._professores)
            {
                if(x.ProfessorID == _curso.ProfessorID)
                {
                    H2.Text = x.Nome;
                }
            }

            H2.Location = new Point(p, Img.Height + 5 + p + H1.Height);
            H2.ForeColor = chave.Cinza;
            H2.AutoSize = true;

            preco.Font = chave.H3_Font_Sub;
            preco.Text = _curso.Valor.ToString("R$ 00.00");
            preco.Location = new Point(p, Img.Height + H1.Height + p + H2.Height);
            preco.ForeColor = chave.Verde;
            preco.AutoSize = true;

            Fundo.Controls.Add(H1);
            Fundo.Controls.Add(H2);
            Fundo.Controls.Add(preco);
            Fundo.Margin = new Padding(10);
        }

        public void Abre_Curso()
        {
<<<<<<< Updated upstream
            FormArredondado Curso = new FormArredondado();
            curso_aberto(Curso);
           
=======
            if (IsProf != true)
            {
                FormArredondado Curso = new FormArredondado();
                curso_aberto(Curso);
            }
;
>>>>>>> Stashed changes
        }

        public void curso_aberto(FormArredondado janela)
        {
            Size TamTab = new Size(900, 700 + 50);
            int pdi = 40;

            janela.Size = TamTab;
            janela.MaximumSize = TamTab; ;
            janela.ShowInTaskbar = false;
            janela.FormBorderStyle = FormBorderStyle.None;
            janela.StartPosition = FormStartPosition.CenterParent;
            janela.BackColor = chave.Vermelho;
            Button Fechar = new Button();
            RoundedPanel Fundo = new RoundedPanel(50);
            janela.Controls.Add(Fundo);
            Fundo.Dock = DockStyle.Fill;
            Fundo.BackColor = Color.White;

            janela.FormClosed += (senders, e) => formPai.Opacity = 1;

            RoundedPanel imagem = new RoundedPanel(30);
            imagem.BackgroundImage = imagem_Curso;
            imagem.Size = new Size(janela.Width - pdi*2, 300);
            Fundo.Controls.Add(imagem);
            imagem.Location = new Point(pdi, pdi);
            imagem.BackgroundImageLayout = ImageLayout.Stretch;

            RoundedPanel back = new RoundedPanel(40);
            back.Size = new Size(40, 40);
            back.Controls.Add(Fechar);

            Fechar.Dock = DockStyle.Fill;
            Fechar.FlatStyle = FlatStyle.Flat;
            Fechar.FlatAppearance.BorderSize = 0;

            Fechar.Click += (senders, e) => janela.Close();
            Fechar.Text = "<";
            Fechar.Font = chave.H3_Font_Sub;
            Fechar.ForeColor = chave.Preto;
            imagem.Controls.Add(back);
            back.Location = new Point(pdi/2, pdi/2);


            Label H1 = new Label();
            Fundo.Controls.Add(H1);
            H1.Text = this.H1.Text;
            H1.Font = chave.H1_Font;
            H1.ForeColor = chave.Preto;
            H1.Location = new Point(pdi-20, imagem.Location.Y + imagem.Height + pdi);
            H1.AutoSize = true;

            Label H2 = new Label();
            Fundo.Controls.Add(H2);
            H2.Text = this.H2.Text;
            H2.Font = chave.H3_Font_Sub;
            H2.AutoSize = true;
            H2.ForeColor = chave.Cinza;
            H2.Location = new Point(pdi - 10, H1.Location.Y+H1.Height+50);

            Label H3 = new Label();
            Fundo.Controls.Add(H3);
            H3.Text = descricao;
            H3.Size = new Size(480, 80);
            H3.Font = chave.H3_Font;
            H3.ForeColor = chave.Cinza;
            H3.Location = new Point(pdi - 10, H2.Location.Y + pdi-10);


<<<<<<< Updated upstream
            Botao Disp = new Botao(Fundo, "AGENDAR AULA");
            Fundo.Controls.Add(Disp.Caixa_Botao);
            Disp.Caixa_Botao.Size = new Size(480, 60);
            Disp.Caixa_Botao.BackColor = chave.Verde;
            Disp.ForClick.BackColor = chave.Verde;
            Disp.ForClick.ForeColor = Color.White;
            Disp.Caixa_Botao.Location = new Point(50-10, H3.Location.Y+H3.Height+pdi);
=======
            Disp.Font = chave.H3_Font_Sub;
            Disp.FlatStyle = FlatStyle.Flat;
            Disp.FlatAppearance.BorderSize = 0;
            Disp.Size = new Size(450, 60);
            Disp.Radius = 60;
            Disp.BackColor = chave.Verde;
            Disp.ForeColor = Color.White;
            Disp.Location = new Point(50-10, H3.Location.Y+H3.Height+pdi);
            Disp.Text = "AGENDAR AULA";
            Disp.Click += (s, e) =>
            {
                foreach(Diponibilidade x in marcados)
                {
                    Aula au = new Aula();
                    au.CursoID = _curso.CursoID;
                    au.AlunoID = Program.UserAluno.AlunoID;
                    au.Dia = x.Dia;
                    au.Inserir();
                    x.Deletar();
                }
                Program.AtualizaBanco();
            };
>>>>>>> Stashed changes
            
            RoundedPanel Horas = new RoundedPanel(40);
            FlowLayoutPanel horarios = new FlowLayoutPanel();
            Horas.Controls.Add(horarios);
            Fundo.Controls.Add(Horas);
            horarios.Dock = DockStyle.Fill;
            int lr = imagem.Width - (Disp.Caixa_Botao.Location.X + Disp.Caixa_Botao.Width);
            Horas.Size = new Size(lr+20, 280);
            Horas.Location = new Point(Disp.Caixa_Botao.Location.X-20 + Disp.Caixa_Botao.Width + pdi, Disp.Caixa_Botao.Location.Y+Disp.Caixa_Botao.Height-Horas.Height);
            horarios.BackColor = Color.White;
<<<<<<< Updated upstream
            cria_horario(horarios, 20, "Março", "18h", "21h");
=======
            
            foreach(Diponibilidade d in Program._diponibilidades)
            {
                if(d.ProfessorID == prof.ProfessorID)
                {
                    cria_horario(horarios,d, lr);
                }
            }
>>>>>>> Stashed changes
            SaveFileDialog nova = new SaveFileDialog();

            Thread t = new Thread(() =>
            {
                janela.StartPosition = FormStartPosition.CenterScreen;
                janela.ShowDialog();
            });
            t.Start();
            FormEscurecerTela(janela);

        }

        private void cria_horario(FlowLayoutPanel X, int Dia, string Mes, string HoraI, string HoraF)
        {
            RoundedPanel Fundo = new RoundedPanel(20);
            Fundo.Size = new Size(X.Width, 100);
            Fundo.BackColor = chave.CinzaClaro;
            X.Controls.Add(Fundo);
            Panel icon = new Panel();
            icon.BackgroundImage = Properties.Resources.Hora;
            icon.Size = new Size(30, 30);
            icon.BackgroundImageLayout = ImageLayout.Stretch;
            Fundo.Controls.Add(icon);
            icon.Location = new Point(20, 100 / 2 - 30 / 2);
            int i = 0;

            Label H1 = new Label();
            H1.Text = "Dia " + Dia + " de " + Mes + " | das " + HoraI + " às " + HoraF;
            H1.Font = chave.H4_Font;
            H1.AutoSize = true;
            Fundo.Controls.Add(H1);
            H1.Location = new Point(icon.Location.X+40,100/2-H1.Height/2);
            H1.ForeColor = chave.Cinza;


            Fundo.Click += (senders, e) =>
            {
                if (i == 0)
                {
                    H1.ForeColor = Color.White;
                    Fundo.BackColor = chave.Verde;
                    marcados.Add(disp);
                    icon.BackgroundImage = Properties.Resources.Check;
                    i= 1;
                }
                else
                {
                    H1.ForeColor = chave.Cinza;
                    Fundo.BackColor = chave.CinzaClaro;
                    marcados.Remove(disp);
                    icon.BackgroundImage = Properties.Resources.Hora;
                    i = 0;
                }
            };
            H1.Click += (senders, e) =>
            {
                if (i == 0)
                {
                    H1.ForeColor = Color.White;
                    Fundo.BackColor = chave.Verde;
                    icon.BackgroundImage = Properties.Resources.Check;
                    i = 1;
                }
                else
                {
                    H1.ForeColor = chave.Cinza;
                    Fundo.BackColor = chave.CinzaClaro;
                    icon.BackgroundImage = Properties.Resources.Hora;
                    i = 0;
                }
            };
            icon.Click += (senders, e) =>
            {
                if (i == 0)
                {
                    H1.ForeColor = Color.White;
                    Fundo.BackColor = chave.Verde;
                    icon.BackgroundImage = Properties.Resources.Check;
                    i = 1;
                }
                else
                {
                    H1.ForeColor = chave.Cinza;
                    Fundo.BackColor = chave.CinzaClaro;
                    icon.BackgroundImage = Properties.Resources.Hora;
                    i = 0;
                }
            };

        }
        public void FormEscurecerTela( Form po)
        {
            Form es = new Form();
            es.FormBorderStyle = FormBorderStyle.None;
            es.BackColor = Color.Black;
            es.Opacity = 0.5; // Opacidade de 50%
            es.WindowState = FormWindowState.Maximized;
            po.FormClosing += (sender, e) =>
            {
                es.Close();
            };
            es.ShowDialog();
        }
    }
}