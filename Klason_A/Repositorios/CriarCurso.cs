using Klason_A.Dominio;
using Klason_A.Visual.Modulos;
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
        Curso curso = new Curso();

        private barra Barra;
        private Panel fundo;
        private Cores_Fontes chave = new Cores_Fontes();
        private RoundedPanel AddImagem = new RoundedPanel(50);
        private Panel AddImagemIcon;
        private CalendarioTeste calendario;
        private Caixa_de_Texto caixaNome;
        private Caixa_de_Texto caixaDes;
        int pd = 30;
        RoundedPanel preview;
        BotaoArredondado CadastrarCurso;

        public CriarCurso()
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
            adiciona_Barra();
            AdicionaRetanguloImagem();
            AdicionaFormulario();
            AdicionaCalendario();
            AdicionaBotao();
            AdicionaPreview();


        }
        private void adiciona_Barra()
        {
            Barra = new barra(2, this);
            Barra.Fundo.Width = this.Width * 2;
            fundo.Controls.Add(Barra.Fundo);
        }
        private void AdicionaRetanguloImagem()
        {
            fundo.Controls.Add(AddImagem);
            AddImagem.Height = 300;
            AddImagem.Width = 1200;

            AddImagem.BackColor = chave.Branco;
            AddImagem.Location = new Point(315, 100+pd);

            AddImagemIcon = new Panel();
            AddImagem.Controls.Add(AddImagemIcon);
            AddImagemIcon.BackgroundImageLayout = ImageLayout.Stretch;
            AddImagemIcon.Size = new Size(80, 80);
            AddImagemIcon.BackgroundImage = Properties.Resources.Down;
            AddImagemIcon.Location = new Point(AddImagem.Width / 2 - AddImagemIcon.Width / 2, AddImagem.Height / 2 - AddImagemIcon.Height / 2 - pd);

            Label text = new Label();
            text.Text = "Selecione imagem\npara capa.";
            text.TextAlign = ContentAlignment.MiddleCenter;
            text.ForeColor = chave.Cinza;
            text.Font = chave.H3_Font_Sub;
            text.AutoSize = true;

            AddImagem.Controls.Add(text);

            text.Location = new Point(AddImagem.Width / 2 - text.Width / 2, AddImagemIcon.Location.Y+AddImagemIcon.Height+pd);
        }
        private void AdicionaFormulario()
        {
            Label nome = crialabel("Nome do curso:");
            fundo.Controls.Add(nome);
            nome.Location = new Point(AddImagem.Location.X, AddImagem.Location.Y + AddImagem.Height + pd);
            
            Label des = crialabel("Descrição:");
            fundo.Controls.Add(des);
            des.Location = new Point(AddImagem.Location.X, nome.Location.Y + nome.Height + pd);

            caixaNome = new Caixa_de_Texto(480, 0, 0,ref fundo);
            caixaNome.Caixa.Location = new Point(nome.Location.X + nome.Width + pd, nome.Location.Y-caixaNome.Caixa.Height/4);

            caixaDes = new Caixa_de_Texto(480, 0, 0, ref fundo);
            caixaDes.Caixa.Height = 180;
            caixaDes.Caixa.Location = new Point(caixaNome.Caixa.Location.X, des.Location.Y);
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
        private void AdicionaCalendario()
        {
            //fundo.Controls.Add(calendario);
            //calendario.Location = new Point(caixaNome.Caixa.Location.X + caixaNome.Caixa.Width + 30, caixaNome.Caixa.Location.Y);
            calendario = new CalendarioTeste();
            fundo.Controls.Add(calendario.Fundo);
            calendario.Fundo.Location = new Point(caixaNome.Caixa.Location.X + caixaNome.Caixa.Width + pd, caixaNome.Caixa.Location.Y);
            calendario.Fundo.Height = caixaDes.Caixa.Location.Y + caixaDes.Caixa.Height - caixaNome.Caixa.Location.Y+80;
            BotaoArredondado ad = new BotaoArredondado();
            ad.Text = ">";
            ad.Radius = 40;
            ad.Size = new Size(40,40);
            ad.TextAlign = ContentAlignment.MiddleCenter;
            ad.BackColor = chave.Verde;
            ad.FlatAppearance.BorderSize = 0;
            ad.FlatStyle = FlatStyle.Flat;
            ad.Font = chave.H3_Font_Sub;
            ad.ForeColor = chave.Branco;
            calendario.Fundo.Controls.Add(ad);
            ad.Location = new Point(calendario.Fundo.Width - 10 - ad.Width, calendario.Fundo.Height - 10 - ad.Height);

            ad.Click += (s, e) =>
            {
                foreach(DateTime t in calendario.Datas)
                {
                    Panel pd = new Panel();
                    pd.Dock = DockStyle.Top;
                    pd.Height = 15;
                    preview.Controls.Add(pd);
                    RoundedPanel itemAgenda = new RoundedPanel(20);
                    itemAgenda.Dock = DockStyle.Top;
                    itemAgenda.Height = 50;
                    itemAgenda.BackColor = chave.CinzaClaro;
                    preview.Controls.Add(itemAgenda);

                    Label Tx = new Label();
                    Tx.Text = $"Dia {t.Day} às {calendario.Hora}:{calendario.Minuto}\n{calendario.NomeMes(t.Month)}, de {t.Year}";
                    Tx.AutoSize = true;
                    Tx.Font = chave.H2_Notificacao;
                    Tx.ForeColor = chave.Preto;
                    Tx.Location = new Point(10, itemAgenda.Height / 2 - Tx.Height / 2-8);
                    itemAgenda.Controls.Add(Tx);

                }
                calendario.Datas.Clear();
                calendario.AdicionaDias();
            };

        }
        private void AdicionaPreview()
        {
            preview = new RoundedPanel(calendario.Fundo.Radius);
            fundo.Controls.Add(preview);
            preview.Width = 284;
            preview.BackColor = chave.Branco;
            preview.Height = calendario.Fundo.Height;
            preview.Padding = new Padding(pd/2, 50, pd / 2, pd/2);
            preview.Location = new Point(calendario.Fundo.Location.X + calendario.Fundo.Width+pd/2, calendario.Fundo.Location.Y);
            preview.AutoScroll = true;

            Label h1 = new Label();
            h1.Text = "Datas Disponíveis:";
            preview.Controls.Add(h1);
            h1.AutoSize = true;
            h1.Font = chave.H3_Font_Sub;
            h1.ForeColor = chave.Preto;
            h1.Location = new Point(14, 14);
        }
        private void AdicionaBotao()
        {
            CadastrarCurso = new BotaoArredondado();
            CadastrarCurso.Text = "CADASTRAR CURSO";
            CadastrarCurso.ForeColor = chave.Branco;
            CadastrarCurso.BackColor = chave.Verde;
            CadastrarCurso.FlatAppearance.BorderSize = 0;   
            CadastrarCurso.FlatStyle = FlatStyle.Flat;
            CadastrarCurso.Height = 50;
            CadastrarCurso.Width = 675;
            CadastrarCurso.Radius = 50;
            CadastrarCurso.Font = chave.H3_Font_Sub;
            fundo.Controls.Add(CadastrarCurso);
            CadastrarCurso.Location = new Point(AddImagem.Location.X, caixaDes.Caixa.Location.Y + caixaDes.Caixa.Height+pd);
        }

    }
}
