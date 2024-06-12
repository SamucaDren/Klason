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
using Dominio;
using Klason_A.Dominio;

namespace Klason_A
{
    public partial class Pagina_Inicial : Form
    {
        Panel AreaNot;
        private Panel fundo = new Panel();
        Flow Scrool = new Flow();

        public Pagina_Inicial()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        Cores_Fontes chave = new Cores_Fontes();

        public Pagina_Inicial(int i)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            fundo = chave.AddFundo(this);
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
            barra superior = new barra(i, this);

            
            // Adicione a barra de fundo ao Fundo_Janela
            fundo.Controls.Add(superior.Fundo);
            //superior.Fundo.Location = new Point(0, 0);
            superior.Fundo.BringToFront();
            

        }
        public void Notificacoes(Panel Fundo_Janela)
        {
            Panel Parte_Info = new Panel();
            Label NotName = new Label();

            //_parte_Info.Dock = DockStyle.Left;
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

            AreaNot = new Panel();
            NotName.Font = chave.H2_Font;
            NotName.ForeColor = chave.Preto;
            Parte_Info.Controls.Add(NotName);
            Parte_Info.Controls.Add(AreaNot);
            NotName.Location = new Point(20, 40);
            NotName.Text = "Notificações";
            NotName.AutoSize = true;
            AreaNot.Location = new Point(20, NotName.Location.Y + NotName.Height + 20);
            AreaNot.Size = new Size(Parte_Info.Width-40, Parte_Info.Height-AreaNot.Location.X);
            //AreaNot.BackColor = chave.Azul_Claro;
            AreaNot.Height = Fundo_Janela.Height +180;
            AreaNot.AutoScroll = true;

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
            //Fundo_Galeria.AutoScroll = true;
            Fundo_Galeria.VerticalScroll.Visible = false;
            Fundo_Galeria.HorizontalScroll.Visible = false;
            Fundo_Galeria.Controls.Add(Scrool);
            Scrool.AutoScroll = true;
            Scrool.Size = Fundo_Galeria.Size;
            Fundo_Galeria.Width -= 50;
            Scrool.Location = new Point(0, 0);
            Scrool.VerticalScroll.Visible = false;
            //Scrool.Dock = DockStyle.Top;
            Scrool.AutoScroll = true;
            LigaBanco();
            teste.Click += (senders, e) => testepoup(Scrool);

        }
        private void testepoup(FlowLayoutPanel x)
        {

            //PoupUp poup = new PoupUp();
            //poup.Form_Pai = this;
            //LigaBanco.Controls.Add(poup.P);
            ////LigaBanco.Name = "Teste";
            

            Notf n = new Notf();
            Panel y = new Panel();
            y.Height = 10;
            y.Dock = DockStyle.Top;
            AreaNot.Controls.Add(y);
           AreaNot.Controls.Add(n.Fundo);
        }
        private void LigaBanco()
        {
            foreach (Curso c in Program._cursos)
            {
                PoupUp cursox = new PoupUp(c);
                cursox.NomeMateria = c.Categoria;
                cursox.Descricao = c.Descricao;
                cursox.Form_Pai = this;
                Scrool.Controls.Add(cursox.P);
            }
        }
    }
}
