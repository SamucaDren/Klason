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
using static System.Net.Mime.MediaTypeNames;

namespace Klason_A.Repositorios
{
    public partial class CriarCurso : Form
    {
        Curso curso = new Curso();
        List<Aula> aulas = new List<Aula>();

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
                    AddData(t);
                }
                calendario.Datas.Clear();
                calendario.AdicionaDias();
            };

        }
        private void AddData(DateTime day)
        {
            Panel lix = new Panel();
            lix.Size = new Size(20, 20);
            lix.BackgroundImage = Properties.Resources.Lixeira;
            lix.BackgroundImageLayout = ImageLayout.Stretch;

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
            Tx.Text = $"Dia {day.Day} às {calendario.Hora}:{calendario.Minuto}\n{calendario.NomeMes(day.Month)} de {day.Year}";
            Tx.AutoSize = true;
            Tx.Font = chave.H2_Notificacao;
            Tx.ForeColor = chave.Preto;
            Tx.Location = new Point(10, itemAgenda.Height / 2 - Tx.Height / 2 - 8);
            itemAgenda.Controls.Add(Tx);

            itemAgenda.Controls.Add(lix);
            lix.Location = new Point(itemAgenda.Width - lix.Width - 10, itemAgenda.Height / 2 - lix.Height / 2);
            lix.BackColor = chave.CinzaClaro;
            lix.Click += (s, e) =>
            {
                preview.Controls.Remove(itemAgenda);
                preview.Controls.Remove(pd);
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

            CadastrarCurso.Click += (s, e) => { conclui(); };
        }


        private void conclui()
        {
            FormArredondado Final = new FormArredondado();
            Final.Text = "Concluir Cadastro";

            Size TamTab = new Size(800, 600);
            int pdi = 40;

            Final.Size = TamTab;
            Final.MaximumSize = TamTab; ;
            Final.ShowInTaskbar = false;
            Final.FormBorderStyle = FormBorderStyle.None;
            Final.StartPosition = FormStartPosition.CenterParent;

            Panel Fundo = new Panel();
            Final.Controls.Add(Fundo);
            Fundo.Dock = DockStyle.Fill;

            BotaoArredondado back = new BotaoArredondado();
            back.Size = new Size(40, 40);
            back.BackColor = chave.Azul_Claro;
            back.Radius = 40;
            back.FlatStyle = FlatStyle.Flat;
            back.FlatAppearance.BorderSize = 0;

            back.Click += (senders, e) => Final.Close();
            back.Text = "<";
            back.Font = chave.H3_Font_Sub;
            back.ForeColor = chave.Preto;
            Fundo.Controls.Add(back);
            back.Location = new Point(pdi / 2, pdi / 2);
            
            Label H1 = new Label();
            H1.Text = "Concluindo Cadastro de Curso:";
            H1.Font = chave.H2_Font;
            H1.ForeColor = chave.Preto;
            H1.AutoSize = true;
            H1.Location = new Point(80, 80);
            Fundo.Controls.Add(H1);

            Label labelValor = crialabel("Valor da Mensalidade:");
            Fundo.Controls.Add(labelValor);
            labelValor.ForeColor = chave.Cinza;
            labelValor.Location = new Point(H1.Location.X, H1.Location.Y + 80);

            Label sifrao = new Label();
            sifrao.Text = "R$";
            sifrao.Font = chave.H3_Font;
            sifrao.ForeColor = chave.Preto;
            sifrao.AutoSize = true;
            
            Caixa_de_Texto Valor = new Caixa_de_Texto(200, 0, 0, ref Fundo);
            Valor.TextBox.Location = new Point(40, Valor.TextBox.Location.Y);
            Valor.Caixa.Controls.Add(sifrao);
            sifrao.Location = new Point(10, Valor.TextBox.Location.Y);
            Valor.Text = "00,00";
            Valor.Caixa.Location = new Point(labelValor.Location.X + labelValor.Width + 100, labelValor.Location.Y - 15);

            BotaoArredondado conc = new BotaoArredondado();
            conc.Height = 50;
            conc.FlatAppearance.BorderSize = 0;
            conc.FlatStyle = FlatStyle.Flat;
            conc.Radius = 50;
            conc.Width = Final.Width - 80;
            conc.BackColor = chave.Verde;
            Fundo.Controls.Add(conc);
            conc.Location = new Point(40, Fundo.Height - conc.Height);
            conc.Text = "CONCLUIR";
            conc.ForeColor = chave.Branco;
            conc.Font = chave.H3_Font_Sub;
            conc.Click += (s, e) =>
            {
                curso.Categoria = caixaNome.Text.Trim();
                curso.Descricao = caixaDes.Text.Trim();
                curso.ProfessorID = 4;
                curso.ImgCapa = null;
                curso.Valor = double.Parse(Valor.Text);
                curso.Ativa();
                curso.Inserir();
                Program.AtualizaBanco();
                Final.Close();
            };

            Label Qutd = crialabel("Quantidade Máxima de Alunos:");
            Fundo.Controls.Add(Qutd);
            Qutd.ForeColor = chave.Cinza;
            Qutd.Location = new Point(H1.Location.X, labelValor.Location.Y + 80);

            Caixa_de_Texto QuantidadeAlunos = new Caixa_de_Texto(200, 0, 0, ref Fundo);
            QuantidadeAlunos.Caixa.Location = new Point(Valor.Caixa.Location.X, Valor.Caixa.Location.Y + 80);


            Final.ShowDialog();

        }
    }
}
