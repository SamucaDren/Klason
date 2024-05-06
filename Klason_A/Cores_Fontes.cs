using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Klason_A
{
    internal class Cores_Fontes
    {
        public Color Azul_Claro { get { return Color.FromArgb(201, 220, 247); } }
        public Color Preto { get { return Color.FromArgb(40, 40, 40); } }
        public Color Cinza { get { return Color.FromArgb(123, 123, 123); } }
        public Color Vermelho { get { return Color.FromArgb(229, 87, 87); } }
        public Color Verde { get { return Color.FromArgb(27, 120, 25); } }
        public Color Branco { get { return Color.FromArgb(255, 255, 255); } }

        public Color CinzaClaro { get { return Color.FromArgb(240, 240, 240); } }

        public Font H3_Font { get { return new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0); } }
        public Font H1_Font { get { return new Font("Arial", 36F, FontStyle.Bold, GraphicsUnit.Point, 0); } }
        public Font H2_Font { get { return new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point, 0); } }
        public Font H3_Font_Sub { get { return new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point, 0); } }


        public Panel AddFundo(Form X)
        {
            Cores_Fontes chave = new Cores_Fontes();
            Panel Fundo_janela = new Panel();
            Fundo_janela.Dock = DockStyle.Fill;
            Fundo_janela.BackColor = chave.Azul_Claro;
            Fundo_janela.BackgroundImage = Properties.Resources.InicialBG;
            Fundo_janela.BackgroundImageLayout = ImageLayout.Stretch;
            X.Controls.Add(Fundo_janela);
            return Fundo_janela;
        }
    }
}
