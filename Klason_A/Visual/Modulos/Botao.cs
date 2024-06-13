using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klason_A
{
    internal class Caixa_de_Texto
    {
        Cores_Fontes chave = new Cores_Fontes();
        private RoundedPanel Fundo_Texto = new RoundedPanel(42);
        private RichTextBox textBox1 = new RichTextBox();

        public Caixa_de_Texto(int Largura, int X, int Y, ref Panel panel)
        {
            Criar(Largura, X, Y);
            panel.Controls.Add(Fundo_Texto);
        }
        public Panel Caixa
        {
            get
            {
                return Fundo_Texto;
            }
        }
        public string Text
        {
            get { return TextBox.Text; }
            set { TextBox.Text = value; }
        }

        public RichTextBox TextBox { get => textBox1; set => textBox1 = value; }

        public void Altera_Cor(Color NovaCor)
        {
            TextBox.BackColor = NovaCor;
            Fundo_Texto.BackColor = NovaCor;
        }
        private void Criar(int Largura, int X, int Y)
        {

            Fundo_Texto.BackColor = chave.Branco;
            Fundo_Texto.Controls.Add(TextBox);
            Fundo_Texto.Size = new Size(Largura, 45);
            Fundo_Texto.TabIndex = 1;

            //textBox1.AcceptsReturn = true;

            TextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TextBox.BackColor = chave.Branco;
            TextBox.BorderStyle = BorderStyle.None;
            TextBox.Font = chave.H3_Font;
            TextBox.ForeColor = chave.Preto;
            
            TextBox.Location = new Point(20, 13);
            TextBox.Margin = new Padding(10);
            TextBox.Size = new Size(Largura - 20, 23);
            TextBox.TabIndex = 0;

        }
    }
    internal class Botao
    {

        RoundedPanel Caixa = new RoundedPanel(60);
        Button botao = new Button();

        public Botao(Panel local, string txt)
        {
            Cria_botao(local, txt);
        }

        public RoundedPanel Caixa_Botao
        {
            get
            {
                return Caixa;
            }
        }
        public Button ForClick
        {
            get
            {
                return botao;
            }
        }

        private void Cria_botao(Panel local, string txt)
        {
            //Caixa.Size = new Size(160, 40);
            Caixa.BackColor = Color.FromArgb(227, 238, 255);
            Caixa.Controls.Add(botao);
            botao.Dock = DockStyle.Fill;
            botao.Text = txt;
            botao.Visible = true;
            botao.BackColor = Color.FromArgb(227, 238, 255);
            botao.FlatAppearance.BorderSize = 0;
            botao.FlatStyle = FlatStyle.Flat;
            botao.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            botao.ForeColor = Color.FromArgb(40, 40, 40);
            local.Controls.Add(Caixa);
        }
    }
}