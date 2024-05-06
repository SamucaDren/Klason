using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klason_A
{
    public partial class Pagina_Inicial : Form
    {
        public Pagina_Inicial()
        {
            InitializeComponent();
        }

        Cores_Fontes chave = new Cores_Fontes();
        PoupUp P1 = new PoupUp();
        PoupUp P2 = new PoupUp();
        PoupUp P3 = new PoupUp();
        PoupUp P4 = new PoupUp();
        PoupUp P6 = new PoupUp();
        public Pagina_Inicial(int i)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            Panel fundo = chave.AddFundo(this);
            fundo.Size = new Size(1920, 1080);
            Controls.Add(fundo);

            fundo.Controls.Clear();
            fundo.BackColor = Color.Transparent;
            Barra(fundo, i);
            Notificacoes(fundo);
            Thread aux = new Thread(() => Galeria(fundo)); ;
            aux.Start();


        }

        private void Pagina_Inicial_Load(object sender, EventArgs e)
        {


        }
        public void Barra(Panel Fundo_Janela, int i)
        {
            // Crie um novo painel para a barra de fundo
            Panel Fundo_Barra = new Panel();
            Fundo_Barra.Dock = DockStyle.Top;
            Fundo_Barra.Size = new Size(1920, 100);

            // Crie painéis para a parte do logo e a parte da informação
            Panel Parte_Logo = new Panel();
            Panel Parte_Info = new Panel();
            Parte_Info.Size = new Size(1220, 100);
            Parte_Logo.Size = new Size(200, 100);

            GraphicsPath path = new GraphicsPath();
            int radius = 80;

            path.AddLine(0, 0, Parte_Info.Width, 0);
            path.AddLine(Parte_Info.Width, 0, Parte_Info.Width, Parte_Info.Height);
            path.AddLine(Parte_Info.Width, Parte_Info.Height, 0, Parte_Info.Height);
            path.AddArc(0, Parte_Info.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            Parte_Info.Region = new Region(path);
            Parte_Info.BackColor = Color.White;
            Parte_Info.Dock = DockStyle.Right;
            // Adicione os painéis à barra de fundo
            Fundo_Barra.Controls.Add(Parte_Logo);
            Fundo_Barra.Controls.Add(Parte_Info);
            Caixa_de_Texto pesquisa = new Caixa_de_Texto(500, 40, 50 - 20, ref Parte_Info);
            pesquisa.Altera_Cor(chave.CinzaClaro);
            pesquisa.Caixa.Size = new Size(500, 40);

            RoundedPanel Perfil = new RoundedPanel(40);
            Perfil.Size = new Size(38, 38);
            Perfil.BackgroundImage = Properties.Resources.Perfil;
            Perfil.BackgroundImageLayout = ImageLayout.Stretch;
            Parte_Info.Controls.Add(Perfil);
            Perfil.Location = new Point(Parte_Info.Width - 80, 100 / 2 - 38 / 2);

            Panel info = new Panel();
            info.Size = new Size(26, 26);
            info.BackgroundImage = Properties.Resources.Info;
            info.BackgroundImageLayout = ImageLayout.Stretch;
            Parte_Info.Controls.Add(info);
            info.Location = new Point(Parte_Info.Width - 160, 100 / 2 - 28 / 2);


            Label area = new Label();
            area.Text = "Área do ";
            if (i == 1)
            {
                area.Text += "Aluno";
            }
            else if (i == 2)
            {
                area.Text += "Professor";
            }
            area.Font = chave.H3_Font_Sub;
            area.AutoSize = true;
            area.ForeColor = chave.Preto;

            Parte_Info.Controls.Add(area);
            area.Location = new Point(Parte_Info.Width - 220 - area.Width, 100 / 2 - area.Height / 2);

            Panel Logo = new Panel();
            Logo.BackgroundImage = Properties.Resources.Retângulo_2;
            Logo.BackgroundImageLayout = ImageLayout.Stretch;
            Logo.Size = new Size(150, 25);
            Parte_Logo.Controls.Add(Logo);
            Logo.Location = new Point(Parte_Logo.Width / 2 - Logo.Width / 2, Parte_Logo.Height / 2 - Logo.Height / 2);




            // Adicione a barra de fundo ao Fundo_Janela
            Fundo_Janela.Controls.Add(Fundo_Barra);

        }
        public void Notificacoes(Panel Fundo_Janela)
        {
            Panel Parte_Info = new Panel();
            //Parte_Info.Dock = DockStyle.Left;
            Fundo_Janela.Controls.Add(Parte_Info);
            Parte_Info.Size = new Size(1920 - 1220 - 400, 1000);
            Parte_Info.Location = new Point(0, 100 + 40);

            GraphicsPath path = new GraphicsPath();
            int radius = 80;
            int larg = Parte_Info.Width, alt = Parte_Info.Height;

            path.AddLine(larg, radius, larg, alt);
            path.AddLine(larg, alt, 0, alt);
            path.AddLine(0, alt, 0, 0);
            path.AddLine(0, 0, larg - radius, 0);
            path.AddArc(larg - radius, 0, radius, radius, 270, 90);

            path.CloseFigure();
            Parte_Info.Region = new Region(path);
            Parte_Info.BackColor = Color.White;

        }
        public void Galeria(Panel Fundo_Janela)
        {

            Button teste = new Button();
            Fundo_Janela.Controls.Add(teste);
            teste.Text = "Texte";
            teste.Size = new Size(100, 100);
            teste.AutoSize = true;
            teste.Visible = true;
            //teste.Dock = DockStyle.Bottom;
            teste.Location = new Point(1350, 600);

            teste.BackColor = chave.Vermelho;

            Panel Fundo_Galeria = new Panel();
            Fundo_Janela.Controls.Add(Fundo_Galeria);
            Fundo_Galeria.Location = new Point(340 - 10, 140 - 10);
            Fundo_Galeria.Size = new Size(1155 + 20, 620 + 20);
            Fundo_Galeria.AutoScroll = true;
            Fundo_Galeria.VerticalScroll.Visible = false;

            FlowLayoutPanel Scrool = new FlowLayoutPanel();
            Fundo_Galeria.Controls.Add(Scrool);
            Scrool.VerticalScroll.Visible = false;
            Scrool.Dock = DockStyle.Top;
            Scrool.AutoSize = true;
            teste.Click += (senders, e) => testepoup(Scrool);

        }
        private void testepoup(FlowLayoutPanel x)
        {

            PoupUp poup = new PoupUp();
            x.Controls.Add(poup.P);
        }
    }
}
