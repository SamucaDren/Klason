using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klason_A.Repositorios
{
    public partial class CriarCurso : Form
    {
        private barra Barra;
        private Panel fundo;
        private Cores_Fontes chave = new Cores_Fontes();
        private RoundedPanel AddImagem = new RoundedPanel(50);
        private Panel AddImagemIcon;
        public CriarCurso(int i)
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
            adiciona_Barra(i);
            AdicionaRetanguloImagem();
            AdicionaFormulario();

        }
        private void adiciona_Barra(int i)
        {
            Barra = new barra(i, this);
            Barra.Fundo.Width = this.Width * 2;
            fundo.Controls.Add(Barra.Fundo);
        }

        private void AdicionaRetanguloImagem()
        {
            fundo.Controls.Add(AddImagem);
            AddImagem.Height = 300;
            AddImagem.Width = 1100;

            AddImagem.BackColor = chave.Branco;
            AddImagem.Location = new Point(315, 170);

            AddImagemIcon = new Panel();
            AddImagem.Controls.Add(AddImagemIcon);
            AddImagemIcon.BackgroundImageLayout = ImageLayout.Stretch;
            AddImagemIcon.Size = new Size(80, 80);
            AddImagemIcon.BackgroundImage = Properties.Resources.Down;
            AddImagemIcon.Location = new Point(AddImagem.Width / 2 - AddImagemIcon.Width / 2, AddImagem.Height / 2 - AddImagemIcon.Height / 2 - 30);

            Label text = new Label();
            text.Text = "Selecione imagem\npara capa.";
            text.TextAlign = ContentAlignment.MiddleCenter;
            text.ForeColor = chave.Cinza;
            text.Font = chave.H3_Font_Sub;
            text.AutoSize = true;

            AddImagem.Controls.Add(text);

            text.Location = new Point(AddImagem.Width / 2 - text.Width / 2, AddImagemIcon.Location.Y+AddImagemIcon.Height +20);
        }


        private void AdicionaFormulario()
        {
            Label nome = crialabel("Nome do curso:");
            fundo.Controls.Add(nome);
            nome.Location = new Point(AddImagem.Location.X, AddImagem.Location.Y + AddImagem.Height + 50);
            
            Label des = crialabel("Descrição:");
            fundo.Controls.Add(des);
            des.Location = new Point(AddImagem.Location.X, nome.Location.Y + nome.Height + 50);

            Caixa_de_Texto caixaNome = new Caixa_de_Texto(480, nome.Location.X+nome.Width+30,nome.Location.Y,ref fundo);
            caixaNome.

        }

        private Label crialabel(string tx)
        {
            Label p = new Label();
            p.Text = tx;
            p.AutoSize = true;
            p.Font = chave.H3_Font_Sub;
            p.ForeColor = chave.Preto;
            p.TextAlign = ContentAlignment.MiddleLeft;

            return p;
        }


    }
}
