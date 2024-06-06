using Dominio;
using Klason_A.Dominio;
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

namespace Klason_A.Visual.Modulos
{
    public partial class Perfil : Form
    {

        private Panel fundo;
        private Cores_Fontes chave = new Cores_Fontes();
        private barra Barra; 

        public Perfil( int i, Aluno a)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();

            this.WindowState = FormWindowState.Maximized;
            fundo = chave.AddFundo(this);
            //fundo.BackgroundImageLayout = ImageLayout.Zoom;
            fundo.Size = new Size(1920, 1080);
            Controls.Add(fundo);


            fundo.BackColor = Color.Transparent;
            Barra = new barra(i, this);
            //Barra.Fundo.Dock = DockStyle.None;
            Barra.Fundo.Width = this.Width*2;
            
            fundo.Controls.Add(Barra.Fundo);

            lado();
        }



        public void lado()
        {
            Panel ret = new Panel();
  
            int radius = 80;
          
            ret.Width = 250;
            ret.Height = 550;

            int larg = ret.Width, alt = ret.Height;
            GraphicsPath path = new GraphicsPath();
            path.AddLine(larg, 0, larg, alt-radius);
            path.AddArc(larg - radius, alt - radius, radius, radius, 0, 90);
            path.AddLine(larg-radius, alt, 0, alt);
            path.AddLine(0, alt, 0, 0);
            path.AddLine(0, 0, larg, 0);

            path.CloseFigure();
            ret.Region = new Region(path);
            ret.BackColor = Color.White;
            fundo.Controls.Add(ret);
            ret.Location = new Point(0, 0);
            ret.BringToFront();

            RoundedPanel foto = new RoundedPanel(2);
            foto.BackColor = chave.Verde;
            int tam = 250;
            foto.Size = new Size(tam, tam);
            foto.Radius = tam;
            fundo.Controls.Add(foto);
            foto.BringToFront();
            foto.Location = new Point(ret.Location.X+ret.Width-foto.Width/2, ret.Location.Y + ret.Height/2- foto.Width / 2+60);
            foto.BackgroundImage = Properties.Resources.Perfil_grande;
            foto.BackgroundImageLayout = ImageLayout.Stretch;

            Panel2 capa = new Panel2();  
            capa.BackColor = chave.Vermelho;
            capa.Size = new Size(1180, foto.Height+radius*2);
            
            


            RoundedPanel fundo_scrol = new RoundedPanel(10);
            fundo_scrol.BackColor = Color.Transparent;
            fundo_scrol.Height = 1000;
            fundo_scrol.Width = capa.Width;

            fundo.Controls.Add(fundo_scrol);
            fundo_scrol.Location = new Point(ret.Width + 70, 140);

            
            


            larg = capa.Width; alt = capa.Height;
            fundo_scrol.Controls.Add(capa);
            capa.Location = new Point(0, 0);
            GraphicsPath bord = new GraphicsPath();
            //bord.AddLine(larg, radius, larg, alt - radius);
            bord.AddArc(larg - radius, alt - radius, radius, radius, 0, 90);
            //bord.AddLine(larg - radius, alt, radius, alt);
            bord.AddArc(0, alt - radius, radius, radius, 90, 90);
            //bord.AddLine(0, alt-radius, 0, radius);
            bord.AddArc(-200, alt / 2 - foto.Height / 2-30, foto.Height+40, foto.Height+40, 270, 180);
            bord.AddArc(0, 0, radius, radius, 180, 90);
            //bord.AddLine(radius, 0, larg-radius, 0);
            bord.AddArc(larg - radius, 0, radius, radius, 270, 90);

            bord.CloseFigure();
            capa.Region = new Region(bord);
            capa.BackgroundImage = Properties.Resources.Capa_teste;
            capa.BackgroundImageLayout = ImageLayout.Stretch;
            //ret.BackColor = Color.White;


            Label H1 = new Label();
            H1.Text = "Cursos Matriculados";
            H1.Font = chave.H1_Font;
            fundo_scrol.Controls.Add(H1);
            H1.ForeColor = chave.Preto;
            H1.Location = new Point(0, capa.Height + 50); ;
            H1.BringToFront();
  
            H1.AutoSize = true;

            Flow f = new Flow();
            fundo_scrol.Controls.Add(f);
            f.Location = new Point(H1.Location.X, H1.Location.Y+H1.Height+20);
            f.FlowDirection = FlowDirection.LeftToRight;
            f.Width = capa.Width;
            f.AutoSize = true;
            //f.BackColor = chave.Verde;

            for(int i = 0; i< 5; i++)
            {
                Curso x = new Curso();
                PoupUp p = new PoupUp(x);
                // p.FormEscurecerTela = this;
                p.Form_Pai = this;
                f.Controls.Add(p.P);

            }


            f.Dock = DockStyle.Bottom;
            fundo_scrol.Height = 660;
            fundo_scrol.Width = fundo_scrol.Width + 60; ;
            fundo_scrol.AutoScroll = true;

            fundo_scrol.Scroll += (s, e) =>
            {
                foto.Visible = false;
            };







        }




    }
}
