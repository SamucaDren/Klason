using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Klason_A.Visual
{
    public partial class Cadastro : Form
    {
        private Panel Fundo_janela;
        private Panel _coluna01;
        readonly Cores_Fontes chave = new Cores_Fontes();
        private int Largura_da_Tela = 1920, Altura_da_Tela = 1080;
        private int tamanho_do_Botao = 500;
        Caixa_de_Texto nome, email, telefone, senha;
        int i;
        public Cadastro(int i)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            AddFundo();
            this.i = i;

            if (i == 1)
                CadastrandoAluno();

            }

        private void AddFundo()
        {
            Fundo_janela = new Panel();
            Fundo_janela.BackColor = chave.Azul_Claro;
            Fundo_janela.BackgroundImage = Properties.Resources.InicialBG;
            Fundo_janela.BackgroundImageLayout = ImageLayout.Stretch;
            Fundo_janela.Dock = DockStyle.Fill;
            this.Controls.Add(Fundo_janela);

            _coluna01 = new Panel();
            _coluna01.Size = new Size(tamanho_do_Botao, 650);

            int centroX = Largura_da_Tela / 2 - (tamanho_do_Botao / 2) ;
            int centroY = Altura_da_Tela / 2 - 500;
            _coluna01.Location = new Point(centroX, centroY + 80);
            Fundo_janela.Controls.Add(_coluna01);
        }

        private void CadastrandoAluno()
        {
            // Criando Título
            Panel botoes = new Panel();
            Label H1 = new Label();

            H1.Text = "Cadastro Aluno";
            H1.TextAlign = ContentAlignment.TopCenter;
            H1.Font = chave.H1_Font;
            H1.Dock = DockStyle.Top;
            H1.Size = new Size(0, 100);
            _coluna01.Controls.Add(H1);
            _coluna01.BackColor = Color.Transparent;

            // Adicionar Campo Nome
            AdicionarCampo("Nome:", nome, 110);

            // Adicionar Campo Email
            AdicionarCampo("Email:", email, 190);

            // Adicionar Campo Telefone
            AdicionarCampo("Telefone:",  telefone, 270);

            // Adicionar Campo Senha
            AdicionarCampo("Senha:", senha, 350);


            Panel caixaMaior = new Panel();
            caixaMaior.Height = 90;
            caixaMaior.Dock = DockStyle.Bottom;
            _coluna01.Controls.Add(caixaMaior);


            // Botão Cancelar
            BotaoArredondado a = botao("CADASTRAR");
            botoes.Controls.Add(a);
            a.Dock = DockStyle.Right;
           

            BotaoArredondado e = botao("CANCELAR");
            botoes.Controls.Add(e);
            e.Dock = DockStyle.Left;


            _coluna01.Controls.Add(botoes);
            botoes.Height = 40;
            botoes.Dock = DockStyle.Bottom;

           


            Panel logo = new Panel();
            logo.BackgroundImage = Properties.Resources.Retângulo_2;
            logo.BackgroundImageLayout = ImageLayout.Stretch;
            Fundo_janela.Controls.Add(logo);
            logo.Size = new Size(210, 36);
            logo.Location = new Point(Largura_da_Tela/2 - logo.Width/2, 890);

            }

        private void AdicionarCampo(string labelText, Caixa_de_Texto campo, int top)
        {
            // Adicionar Label
            Panel caixas = new Panel();
            Panel txt = new Panel();
            
            Label lbl = new Label();
            lbl.Text = labelText;
            lbl.Font = chave.H4_Font;
            lbl.Height = 40;
            lbl.Dock = DockStyle.Top;
            lbl.Location = new Point(10, top);
            _coluna01.Controls.Add(lbl);

            // Adicionar TextBox
            campo = new Caixa_de_Texto(tamanho_do_Botao, 10, top + 30, ref caixas);
            campo.Text = "Insira aqui";
            campo.Caixa.Location = new Point(lbl.Location.X, lbl.Location.Y+lbl.Height+10);
            campo.Caixa.Size = new Size(tamanho_do_Botao, 40);
            campo.Caixa.Dock = DockStyle.Left;

            txt.Controls.Add(campo.Caixa);
            txt.Height = 40;
            txt.Dock = DockStyle.Bottom;
            

            caixas.Controls.Add(lbl);
            caixas.Controls.Add(txt);
            //caixas.Location = new Point()
            caixas.Dock = DockStyle.Bottom;
            _coluna01.Controls.Add(caixas);
            caixas.Height = 78;

            Panel caixaMaior = new Panel();
            caixaMaior.Height = 20;
            caixaMaior.Dock = DockStyle.Bottom;
            _coluna01.Controls.Add(caixaMaior);




        }

        private BotaoArredondado botao(string texto)
        {
            BotaoArredondado _cadastra = CriaBotao01(texto);
            _cadastra.Dock = DockStyle.Bottom;
            _cadastra.Width = tamanho_do_Botao / 2 - 10;
            _cadastra.Radius = 40;
            return _cadastra;
            //_cadastra.Size = new Size(tamanho_do_Botao / 2 -10, 40);

        }



        //private void botaoCancelar()
        //{
        //    BotaoArredondado _cancela = CriaBotao01("CANCELAR");
        //    _cancela.Dock = DockStyle.Bottom;
        //    _cancela.Width = tamanho_do_Botao / 2 - 10;
        //    _cancela.Radius = 40;
        //    _cancela.Controls.Add(_cancela);
        //    //_cadastra.Size = new Size(tamanho_do_Botao / 2 -10, 40);

        //}



        private BotaoArredondado CriaBotao01(string txt)
        {
            BotaoArredondado SouProf_ = new BotaoArredondado();
            SouProf_.Radius = 80;

            SouProf_.Size = new Size(tamanho_do_Botao / 2 - 10, 80);

            SouProf_.Text = txt;
            SouProf_.BackColor = Color.FromArgb(227, 238, 255);
            SouProf_.FlatAppearance.BorderSize = 0;
            SouProf_.FlatStyle = FlatStyle.Flat;
            SouProf_.Font = chave.H3_Font_Sub;
            SouProf_.ForeColor = chave.Preto;
            return SouProf_;
        }


    }
}



