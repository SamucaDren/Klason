using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klason_A
{

    public class Panel2 : Panel
    {
        public Panel2()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

    }

    public class Flow : FlowLayoutPanel
    {
        public Flow()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }
    }
    public class RoundedPanel : Panel
    {
        public int Radius = new int();
        public RoundedPanel(int R) { Radius = R; DoubleBufferedPanel(); }



        public int R { get { return Radius; } set { Radius = value; } }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, Radius, Radius, 180, 90);
            path.AddArc(Width - Radius, 0, Radius, Radius, 270, 90);
            path.AddArc(Width - Radius, Height - Radius, Radius, Radius, 0, 90);
            path.AddArc(0, Height - Radius, Radius, Radius, 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
        }

        public void DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

    }

    public class BotaoArredondado : Button
    {
        public int _radius = 1;

        public int Radius { get { return _radius; } set { _radius = value; } }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, _radius, _radius, 180, 90);
            path.AddArc(Width - _radius, 0, _radius, _radius, 270, 90);
            path.AddArc(Width - _radius, Height - _radius, _radius, _radius, 0, 90);
            path.AddArc(0, Height - _radius, _radius, _radius, 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
        }
    }

    public partial class FormArredondado : Form
    {
        public FormArredondado()
        {
            this.Paint += new PaintEventHandler(DesenharBordasArredondadas);
        }

        private void DesenharBordasArredondadas(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle bounds = this.ClientRectangle;
            int radius = 50;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90); // Canto superior esquerdo
                path.AddArc(bounds.X + bounds.Width - radius, bounds.Y, radius, radius, 270, 90); // Canto superior direito
                path.AddArc(bounds.X + bounds.Width - radius, bounds.Y + bounds.Height - radius, radius, radius, 0, 90); // Canto inferior direito
                path.AddArc(bounds.X, bounds.Y + bounds.Height - radius, radius, radius, 90, 90); // Canto inferior esquerdo
                path.CloseFigure();

                // Preenche o formulário com a cor de fundo
                graphics.FillPath(new SolidBrush(this.BackColor), path);
                this.Region = new Region(path);
            }
        }
    }
   
}
