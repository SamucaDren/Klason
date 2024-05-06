using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klason_A
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Login_Inicio(AddFundo());
        }
        private Panel AddFundo()
        {
            Cores_Fontes chave = new Cores_Fontes();
            Panel Fundo_janela = new Panel();
            Fundo_janela.Dock = DockStyle.Fill;
            Fundo_janela.BackColor = chave.Azul_Claro;
            Fundo_janela.BackgroundImage = Properties.Resources.InicialBG;
            Fundo_janela.BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(Fundo_janela);
            return Fundo_janela;
        }
        private void Login_Inicio(Panel Fundo_janela)
        {
            Fundo_janela.Controls.Clear();
            Cores_Fontes chave = new Cores_Fontes();
            this.WindowState = FormWindowState.Maximized;
            int tamanho_do_Botao = 500;
            Panel Centro = new Panel();
            Centro.Size = new Size(tamanho_do_Botao, 350);
            Fundo_janela.Controls.Add(Centro);

            int centroX = (Fundo_janela.ClientSize.Width - Centro.Size.Width) / 2;
            int centroY = (Fundo_janela.ClientSize.Height - Centro.Size.Height) / 2;
            Centro.Location = new Point(centroX, centroY);


            //Criando Título
            Label H1 = new Label();
            H1.Text = "Seja Bem Vindo!";
            H1.TextAlign = ContentAlignment.MiddleCenter;
            H1.Font = chave.H1_Font;
            H1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            H1.Dock = DockStyle.Top;
            H1.Size = new Size(0, 100);

            int tam = 80;

            Botao SouProf = new Botao(Centro, "SOU PROFESSOR");
            SouProf.Caixa_Botao.Dock = DockStyle.Top;
            SouProf.Caixa_Botao.Size = new Size(0, 80);
            SouProf.Caixa_Botao.Radius = 80;
            SouProf.Caixa_Botao.Margin = new Padding(80, 80, 80, 80);
            SouProf.ForClick.Click += (sender, e) => login(2, Fundo_janela);

            Panel sep = new Panel();
            sep.Dock = DockStyle.Top;
            sep.Size = new Size(0, tam / 3);
            Centro.Controls.Add(sep);

            Botao SouAluno = new Botao(Centro, "SOU ALUNO");
            SouAluno.Caixa_Botao.Dock = DockStyle.Top;
            SouAluno.Caixa_Botao.Size = new Size(0, 80);
            SouAluno.Caixa_Botao.Radius = 80;
            SouAluno.ForClick.Click += (sender, e) => login(1, Fundo_janela);

            Panel sep2 = new Panel();
            sep2.Dock = DockStyle.Top;
            sep2.Size = new Size(0, tam / 2);
            Centro.Controls.Add(sep2);

            Centro.BackColor = Color.Transparent;
            Centro.Controls.Add(H1);
        }

        private void login(int i, Panel Fundo_Janela)
        {
            Cores_Fontes chave = new Cores_Fontes();
            //Fundo_Janela.Controls.Opacity = 0.5; // Valor entre 0 (totalmente transparente) e 1 (totalmente opaco)
            //this.Opacity = 0.5;
            // Limpa os controles dentro do Fundo_Janela
            Fundo_Janela.Controls.Clear();

            //Tamanho da Div do Centro
            int tamanho_do_Botao = 500;


            //Criação de um espaço no centro da tela
            Panel Centro = new Panel();
            Centro.Size = new Size(tamanho_do_Botao, 600);
            int centroX = (Fundo_Janela.ClientSize.Width - Centro.Size.Width) / 2;
            int centroY = (Fundo_Janela.ClientSize.Height - Centro.Size.Height) / 2;
            Centro.Location = new System.Drawing.Point(centroX, centroY + 50);
            Fundo_Janela.Controls.Add(Centro);

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
            Text01.Location = new System.Drawing.Point(Largura_da_Tela / 2 - (tamanho_do_Botao / 2), Altura_da_Tela / 2 - 40);
            Text01.Dock = DockStyle.Top;

            //Email
            Panel espaco01 = new Panel();
            espaco01.Controls.Add(Text01);
            espaco01.Controls.Add(login1.Caixa);
            login1.Caixa.Dock = DockStyle.Bottom;
            espaco01.Dock = DockStyle.Top;
            espaco01.Size = new Size(0, tam);
            espaco01.Margin = new Padding(5);
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


            //Botões
            Panel espaco03 = new Panel();
            espaco03.Dock = DockStyle.Top;
            espaco03.Size = new Size(0, 60);

            Botao entrar = new Botao(espaco03, "ENTRAR");
            entrar.Caixa_Botao.Dock = DockStyle.Left;
            entrar.Caixa_Botao.Size = new Size(tamanho_do_Botao / 2 - 10, 0);
            entrar.ForClick.Click += (sender, e) => transiti(i);

            Botao cadastrar = new Botao(espaco03, "CADASTRAR");
            cadastrar.Caixa_Botao.Dock = DockStyle.Right;
            cadastrar.Caixa_Botao.Size = new Size(tamanho_do_Botao / 2 - 10, 0);

            //Adicionando na Div do Centro
            Centro.Controls.Add(espaco03);
            Centro.Controls.Add(sep1);
            Centro.Controls.Add(espaco02);
            Centro.Controls.Add(sep);
            Centro.Controls.Add(espaco01);
            Centro.Controls.Add(sep2);
            Centro.Controls.Add(H2);
            Centro.Controls.Add(H1);
            Centro.BackColor = Color.Transparent;

            H1.TabIndex = 0;
            espaco01.TabIndex = 1;
            espaco02.TabIndex = 2;

            Botao back = new Botao(Fundo_Janela, "<");
            back.Caixa_Botao.Size = new Size(80, 80);
            back.Caixa_Botao.Radius = 80;
            back.Caixa_Botao.Location = new System.Drawing.Point(20, 20);
            back.ForClick.Click += (sender, e) => Login_Inicio(Fundo_Janela);
        }


        private void transiti(int i)
        {

            this.Close();
            Thread thread = new Thread(() =>
            {
                ///Application.Run(new Pagina_Inicial(i));
            });
            thread.Start();
        }
    }
}
