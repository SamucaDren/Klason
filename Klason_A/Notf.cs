using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klason_A
{
    internal class Notf
    {
        private RoundedPanel _fundo = new RoundedPanel(20);
        private Panel icon = new Panel();
        private Label H1 = new Label();
        private Label H2 = new Label();
        Cores_Fontes chave = new Cores_Fontes();

        private string _titulo = "Nome da Matéria";
        private string _descricao = "Descrição da Mensagem";

        public RoundedPanel Fundo {  get { return _fundo; } set { _fundo = value; } }

        public Notf()
        {
            CriaNot();
        }

        private void CriaNot()
        {
            _fundo.Height = 100;
            _fundo.BackColor = chave.CinzaClaro;
            _fundo.Dock = DockStyle.Top;

            _fundo.Controls.Add(icon);
            icon.Height = 28;
            icon.Width = 28;
            icon.BackgroundImage = Properties.Resources.Notify;
            icon.BackgroundImageLayout = ImageLayout.Stretch;
            icon.Location = new System.Drawing.Point(10, _fundo.Height/2 - icon.Height/2);

            _fundo.Controls.Add(H1);
            H1.Font = chave.H1_Notificacao;
            H1.Text = _titulo;
            H1.AutoSize = true;
            H1.ForeColor = chave.Preto;
            H1.Location = new System.Drawing.Point(icon.Location.X + icon.Width + 10, 20);

            _fundo.Controls.Add(H2);
            H2.Font = chave.H2_Notificacao;
            H2.Text = _descricao;
            H2.Width = _fundo.Width - H1.Location.X - 20;
            H2.Height = 50;
            H2.AutoEllipsis = true;
            H2.ForeColor = chave.Cinza;
            H2.Location = new System.Drawing.Point (H1.Location.X, H1.Location.Y+20);

            

        }
    }
}
