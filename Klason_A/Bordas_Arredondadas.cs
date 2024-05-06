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
    public class RoundedPanel : Panel
    {
        public int Radius = new int();
        public RoundedPanel(int R) { Radius = R; }


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
    }
}
