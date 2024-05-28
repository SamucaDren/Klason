using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Klason_A
{
    public partial class Form1 : Form
    {
        Panel Fundo_janela;//fundo da janela
        private Panel _coluna01;//coluna Login01

        readonly Cores_Fontes chave = new Cores_Fontes();
        private int Largura_da_Tela = 1920, Altura_da_Tela = 1080;
        private int tamanho_do_Botao = 500;


        public Form1()
        {
            InitializeComponent();
            
            AddFundo();
            this.Size = new Size(Largura_da_Tela, Altura_da_Tela);

            Login_Inicio();
            this.WindowState = FormWindowState.Maximized;
        }

        //Para adicionar o fundo com o background na janela
        private void AddFundo()
        {
            Fundo_janela = new Panel();
            Fundo_janela.BackColor = chave.Azul_Claro;
            Fundo_janela.BackgroundImage = Properties.Resources.InicialBG;
            Fundo_janela.BackgroundImageLayout = ImageLayout.Stretch;
            Fundo_janela.Dock = DockStyle.Fill;
            this.Controls.Add(Fundo_janela);
        }

        //Paginal Incial para escolher se é aluno ou professor
        private void Login_Inicio()
        {
            int t = this.Size.Width;
            int p = this.Size.Height;

            Fundo_janela.Controls.Clear();
            
            _coluna01 = new Panel();
            _coluna01.Size = new Size(tamanho_do_Botao, 350);
            
            int centroX = (t-tamanho_do_Botao)/2;
            int centroY = (p-_coluna01.Size.Height)/2;
            _coluna01.Location = new System.Drawing.Point(centroX, centroY-50);
            Fundo_janela.Controls.Add(_coluna01);

            //Criando Título
            Label H1 = new Label();
            H1.Text = "Seja Bem Vindo!";
            H1.TextAlign = ContentAlignment.MiddleCenter;
            H1.Font = chave.H1_Font;
            H1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            H1.Dock = DockStyle.Top;
            H1.Size = new Size(0, 100);

            int tam = 80;

            //Botão Sou Professor
            BotaoArredondado SouProf_ = CriaBotao01("SOU PROFESSOR");
            SouProf_.Click += (sender, e) => transitio(2);
            SouProf_.Dock = DockStyle.Top;

            _coluna01.Controls.Add(SouProf_);

            //Espaço01
            Panel sep = new Panel();
            sep.Dock = DockStyle.Top;
            sep.Size = new Size(0, tam / 3);
            _coluna01.Controls.Add(sep);

            //Botão Sou Aluno
            BotaoArredondado SouAluno_ = CriaBotao01("SOU ALUNO");
            SouAluno_.Click += (sender, e) => transitio(1);
            SouAluno_.Dock = DockStyle.Top;
            _coluna01.Controls.Add(SouAluno_);
            

            //Espaço02
            Panel sep2 = new Panel();
            sep2.Dock = DockStyle.Top;
            sep2.Size = new Size(0, tam / 2);
            _coluna01.Controls.Add(sep2);


            _coluna01.BackColor = Color.Transparent;
            _coluna01.Controls.Add(H1);
        }

        private BotaoArredondado CriaBotao01(string txt)
        {
            BotaoArredondado SouProf_ = new BotaoArredondado();
            SouProf_.Radius = 80;

            SouProf_.Size = new Size(0, 80);
            
            SouProf_.Text = txt;
            SouProf_.BackColor = Color.FromArgb(227, 238, 255);
            SouProf_.FlatAppearance.BorderSize = 0;
            SouProf_.FlatStyle = FlatStyle.Flat;
            SouProf_.Font = chave.H3_Font_Sub;
            SouProf_.ForeColor = chave.Preto;
            return SouProf_;
        }

        private void transitio(int i)
        {
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 1;
            t.Start();
            int som = 200;
            t.Tick += (s, e) =>
            {

                _coluna01.Location = new Point(_coluna01.Location.X-(som+=20), _coluna01.Location.Y);
                if(_coluna01.Location.X <0-_coluna01.Width-50)
                {
                    t.Stop();
                    login(i, Fundo_janela);
                }
            };
            
        }
       

        private void login(int i, Panel Fundo_Janela)
        {
            // Limpa os controles dentro do Fundo_Janela
            Fundo_Janela.Controls.Clear();

            //Tamanho da Div do _coluna01
            int tamanho_do_Botao = 500;


            //Criação de um espaço no centro da tela
            Panel Centro = new Panel();
            Centro.Size = new Size(tamanho_do_Botao, 600);

            //Criando Título
            Label H1 = new Label();
            H1.Text = "Olá ";
            if (i == 1) { H1.Text += " Aluno!"; }
            if (i == 2) { H1.Text += " Professor!"; }

            H1.TextAlign = ContentAlignment.MiddleCenter;
            H1.Font = chave.H1_Font;
            H1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            H1.Dock = DockStyle.Top;
            H1.Size = new Size(0, 80);

            //Criando SubTitulo
            Label H2 = new Label();
            H2.Text = "Faça o seu login:";
            H2.TextAlign = ContentAlignment.MiddleCenter;
            H2.Font = chave.H2_Font;
            H2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            H2.Dock = DockStyle.Top;
            H2.Size = new Size(0, 50);
            H2.ForeColor = chave.Preto;

            //Craiando caixas de texto
            Caixa_de_Texto login1 = new Caixa_de_Texto(tamanho_do_Botao, Largura_da_Tela / 2 - (tamanho_do_Botao / 2), Altura_da_Tela / 2, ref Centro);
            Caixa_de_Texto login2 = new Caixa_de_Texto(tamanho_do_Botao, Largura_da_Tela / 2 - (tamanho_do_Botao / 2), Altura_da_Tela / 2 + 150, ref Fundo_Janela);


            //pading caseiro kkk
            int tam = 80;

            Panel sep = new Panel();
            sep.Dock = DockStyle.Top;
            sep.Size = new Size(0, tam / 3);

            Panel sep1 = new Panel();
            sep1.Dock = DockStyle.Top;
            sep1.Size = new Size(0, tam / 3);

            Panel sep2 = new Panel();
            sep2.Dock = DockStyle.Top;
            sep2.Size = new Size(0, tam / 3);


            //texto "E-mail:"
            Label Text01 = new Label();
            Text01.Text = "E-mail:";
            Text01.Font = chave.H3_Font;
            Text01.Location = new Point(Largura_da_Tela / 2 - (tamanho_do_Botao / 2), Altura_da_Tela / 2 - 40);
            Text01.Dock = DockStyle.Top;

            //Email
            Panel espaco01 = new Panel();
            espaco01.Controls.Add(Text01);
            espaco01.Controls.Add(login1.Caixa);
            login1.Caixa.Dock = DockStyle.Bottom;
            espaco01.Dock = DockStyle.Top;
            espaco01.Size = new Size(0, tam);
            espaco01.Padding = new Padding(5);

            //texto "Senha:"
            Label Text02 = new Label();
            Text02.Text = "Senha:";
            Text02.Font = chave.H3_Font;
            Text02.Location = new System.Drawing.Point(Largura_da_Tela / 2 - (tamanho_do_Botao / 2), Altura_da_Tela / 2 + 110);

            //Senha
            Panel espaco02 = new Panel();
            espaco02.Controls.Add(Text02);
            espaco02.Controls.Add(login2.Caixa);
            Text02.Dock = DockStyle.Top;
            login2.Caixa.Dock = DockStyle.Bottom;
            espaco02.Dock = DockStyle.Top;
            espaco02.Size = new Size(0, tam);
            espaco02.Margin = new Padding(5);
            espaco02.Padding = new Padding(5);

            Panel espaco03 = new Panel();
            espaco03.Dock = DockStyle.Top;
            espaco03.Size = new Size(0, 60);
            espaco01.BackColor = Color.Transparent;

            //Botões
            BotaoArredondado _entrar = CriaBotao01("ENTRAR");
            _entrar.Dock = DockStyle.Left;
            _entrar.Click += (s, e) => { transiti(i);};
            _entrar.Width = tamanho_do_Botao / 2-10;
            _entrar.Radius = _entrar.Height-20;
            espaco03.Controls.Add(_entrar);


            BotaoArredondado _cadastra = CriaBotao01("CADASTRAR");
            _cadastra.Dock = DockStyle.Right;
            _cadastra.Click += (s, e) => {  };//Ainda tenho que criar a tela de cadastro
            _cadastra.Width = tamanho_do_Botao / 2-10;
            _cadastra.Radius = _cadastra.Height - 20;
            espaco03.Controls.Add(_cadastra);

            //Adicionando na Div do _coluna01
            Centro.Controls.Add(espaco03);
            Centro.Controls.Add(sep1);
            Centro.Controls.Add(espaco02);
            Centro.Controls.Add(sep);
            Centro.Controls.Add(espaco01);
            Centro.Controls.Add(sep2);
            Centro.Controls.Add(H2);
            Centro.Controls.Add(H1);
            Centro.BackColor = Color.Transparent;

            BotaoArredondado _back = CriaBotao01("<");
            _back.Size = new Size(80, 80);
            //_back.Location = new Point(20, 20);
            _back.Radius = 80;
            _back.Click += (sender, e) => Login_Inicio();
            Fundo_janela.Controls.Add(_back);

          

            

            Centro.Visible = false;
            Fundo_Janela.Controls.Add(Centro);
            Centro.Location = new System.Drawing.Point(this.Width, this.Height/2 - Centro.Size.Height / 2);
            _back.Visible = true;
            _back.Location = new Point(0, 20);
            int centroX = (this.Width / 2 - Centro.Size.Width / 2);
            int centroY = (this.Height / 2 - Centro.Size.Height / 2) ;
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 1;
            t.Start();
            int som = 150;
            int som01 = 1;

            t.Tick += (s, e) =>
            {
                
                while (_back.Location.X < 20)
                {
                    _back.Location = new Point(_back.Location.X + (som01), _back.Location.Y);
                }

                Centro.Location = new Point(Centro.Location.X - (som-=9), Centro.Location.Y);
                Centro.Visible = true;
                if (Centro.Location.X <= centroX)
                {
                    Centro.Location = new Point(centroX, centroY);
                    t.Stop();
                }
            };
        }

        private void transiti(int i)
        {

            this.Close();
            Thread thread = new Thread(() =>
            {
                Pagina_Inicial P = new Pagina_Inicial(i);
                P.ShowDialog();
            });
            thread.Start();
        }
    }
}
