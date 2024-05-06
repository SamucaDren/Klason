using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klason_A
{
    internal class PoupUp
    {
        private RoundedPanel Fundo = new RoundedPanel(40);
        private RoundedPanel Img = new RoundedPanel(38);
        private RoundedPanel pict = new RoundedPanel(30);
        private Label H1 = new Label();
        private Label H2 = new Label();
        private Label preco = new Label();
        RoundedPanel Fundo2 = new RoundedPanel(50);

        public PoupUp()
        {
            CriaPoupUp();
        }

        public Image Imagem
        {
            get { return pict.BackgroundImage; }
            set { pict.BackgroundImage = value; }
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
            pict.BackgroundImage = Properties.Resources.IMGteste;
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
            Curso.Size = new Size(1046, 779);
            Curso.ShowInTaskbar = false;
            Curso.MaximumSize = new Size(1046, 779);

            Curso.ShowDialog();
        }
    }
}