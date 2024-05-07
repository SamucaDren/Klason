using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public Form Form_Pai
        {
            set
            {
                formPai = value;
            }
        }

        public PoupUp()
        {
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
            Cores_Fontes chave = new Cores_Fontes();

            Fundo.Controls.Add(Img);
            Img.BackColor = chave.Azul_Claro;
            Img.Size = new Size(Fundo.Width - 2, 251);
            Img.Location = new Point(1, 1);

            Img.Controls.Add(pict);
            pict.BackgroundImage = imagem_Curso;
            pict.BackgroundImageLayout = ImageLayout.Stretch;
            pict.Dock = DockStyle.Fill;
            int p = 20;
            Img.Padding = new Padding(p, p, p, p);

            Botao Disp = new Botao(Fundo, "VER DISPONIBILIDADE");
            Disp.Caixa_Botao.Size = new Size(Fundo.Width - 40, 42);
            Disp.Caixa_Botao.R = Disp.Caixa_Botao.Height;
            Disp.Caixa_Botao.BackColor = chave.Verde;
            Disp.ForClick.BackColor = chave.Verde;
            Disp.ForClick.ForeColor = Color.White;
            Disp.Caixa_Botao.Location = new Point(p, Fundo.Height - Disp.Caixa_Botao.Height - p);
            Disp.ForClick.Click += (senders, e) => Abre_Curso();

            H1.Font = chave.H3_Font_Sub;
            H1.Text = "Nome da Matéria";
            H1.Location = new Point(p, Img.Height + p);
            H1.ForeColor = chave.Preto;
            H1.AutoSize = true;

            H2.Font = chave.H3_Font;
            H2.Text = "Professor da Matéria";
            H2.Location = new Point(p, Img.Height + 5 + p + H1.Height);
            H2.ForeColor = chave.Cinza;
            H2.AutoSize = true;

            preco.Font = chave.H3_Font_Sub;
            preco.Text = "R$ 50,00";
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
            Form Curso = new Form();
            curso_aberto(Curso);
           
        }

        public void curso_aberto(Form janela)
        {
            //formPai.Opacity = 0.5;
            
            janela.Size = new Size(900, 700);
            janela.MaximumSize = new Size(900, 700); ;
            janela.ShowInTaskbar = false;
            janela.FormBorderStyle = FormBorderStyle.None;
            janela.StartPosition = FormStartPosition.CenterParent;
            janela.BackColor = chave.Azul_Claro;
            Button Fechar = new Button();
            RoundedPanel Fundo = new RoundedPanel(50);
            janela.Controls.Add(Fundo);
            Fundo.Dock = DockStyle.Fill;
            Fundo.BackColor = Color.White;
            
            janela.FormClosed += (senders, e) => formPai.Opacity = 1;

            RoundedPanel imagem = new RoundedPanel(30);
            imagem.BackgroundImage = imagem_Curso;
            imagem.Size = new Size(janela.Width - 100, 300);
            Fundo.Controls.Add(imagem);
            imagem.Location = new Point(40, 40);
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
            back.Location = new Point(10, 10);


            janela.ShowDialog();
            
        }


    }
}