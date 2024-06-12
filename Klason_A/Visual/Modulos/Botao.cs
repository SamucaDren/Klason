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
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public void Altera_Cor(Color NovaCor)
        {
            textBox1.BackColor = NovaCor;
            Fundo_Texto.BackColor = NovaCor;
        }
        private void Criar(int Largura, int X, int Y)
        {

            Fundo_Texto.BackColor = chave.Branco;
            Fundo_Texto.Controls.Add(textBox1);
            Fundo_Texto.Size = new Size(Largura, 45);
            Fundo_Texto.TabIndex = 1;

            //textBox1.AcceptsReturn = true;

            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = chave.Branco;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = chave.H3_Font;
            textBox1.ForeColor = chave.Preto;
            
            textBox1.Location = new Point(20, 13);
            textBox1.Margin = new Padding(10);
            textBox1.Size = new Size(Largura - 20, 23);
            textBox1.TabIndex = 0;

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