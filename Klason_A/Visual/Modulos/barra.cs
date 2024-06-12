using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Dominio;
using Klason_A.Visual;
using Klason_A.Visual.Modulos;

namespace Klason_A
{
    internal class barra
    {
        private Panel _fundo_Barra = new Panel();
        private Panel _parte_Logo = new Panel();
        private Panel _parte_Info = new Panel();
        private Cores_Fontes chave = new Cores_Fontes();
        private Caixa_de_Texto _pesquisa;
        private RoundedPanel _perfil = new RoundedPanel(40);
        private Panel _info = new Panel();
        private Panel _logo = new Panel();
        private Label _area = new Label();
        private int info_op = 0;
        int i;

        Form _form;

        private RoundedPanel _fundoInfo;

        public barra(int i, Form x)
        {
            _form = x;
            cria_barra(i);
        }

        public Panel Fundo { get => _fundo_Barra; set => _fundo_Barra = value; }
        public Panel ParteLogo { get => _parte_Logo; set => _parte_Logo = value; }
        public Panel ParteInfo { get => _parte_Info; set => _parte_Info = value; }

        private void cria_barra(int i)

        {
            this.i = i;
            // Crie um novo painel para a barra de fundo
            _fundo_Barra = new Panel();
            _fundo_Barra.Dock = DockStyle.Top;
            _fundo_Barra.Size = new Size(1920, 100);

            // Crie painéis para a parte do logo e a parte da informação
            _parte_Info.Size = new Size(1220, 100);
            _parte_Logo.Size = new Size(200, 100);

            GraphicsPath path = new GraphicsPath();
            int radius = 80;

            path.AddLine(0, 0, ParteInfo.Width, 0);
            path.AddLine(_parte_Info.Width, 0, _parte_Info.Width, _parte_Info.Height);
            path.AddLine(_parte_Info.Width, _parte_Info.Height, 0, _parte_Info.Height);
            path.AddArc(0, _parte_Info.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            _parte_Info.Region = new Region(path);
            _parte_Info.BackColor = Color.White;
            _parte_Info.Dock = DockStyle.Right;

            // Adicione os painéis à barra de fundo
            _fundo_Barra.Controls.Add(ParteLogo);
            _fundo_Barra.Controls.Add(ParteInfo);


            _pesquisa = new Caixa_de_Texto(500, 40, 50 - 20, ref _parte_Info);
            _pesquisa.Altera_Cor(chave.CinzaClaro);
            _pesquisa.Caixa.Size = new Size(500, 40);
            _pesquisa.Caixa.Location = new Point(28, ParteInfo.Height / 2 - _pesquisa.Caixa.Height / 2);

            
            _perfil.Size = new Size(38, 38);
            _perfil.BackgroundImage = Properties.Resources.Perfil_grande;
            _perfil.BackgroundImageLayout = ImageLayout.Stretch;
            _parte_Info.Controls.Add(_perfil);
            _perfil.Location = new Point(ParteInfo.Width - 80, 100 / 2 - 38 / 2);
            _perfil.Click += (s, e) =>
            {
                abrePerfil();
            };
            
            _info.Size = new Size(26, 26);
            _info.BackgroundImage = Properties.Resources.Info;
            _info.BackgroundImageLayout = ImageLayout.Stretch;
            _parte_Info.Controls.Add(_info);
            _info.Location = new Point(ParteInfo.Width - 160, 100 / 2 - 28 / 2);

            _info.Click += (s, e) =>
            {
                if(info_op == 0)
                {
                    info_op = 1;
                    AbreInfo();
                }
                else
                {
                    _fundoInfo.Visible = false;
                    _fundoInfo = null;
                    _form.Controls.Remove(_fundoInfo);
                    info_op = 0;
                }
                

            };
            
            _area.Text = "Área do ";
            if (i == 1)
            {
                _area.Text += "Aluno";
            }
            else if (i == 2)
            {
                _area.Text += "Professor";
            }
            _area.Font = chave.H3_Font_Sub;
            _area.AutoSize = true;
            _area.ForeColor = chave.Preto;

            _parte_Info.Controls.Add(_area);
            _area.Location = new Point(ParteInfo.Width - 220 - _area.Width, 100 / 2 - _area.Height / 2);

            
            _logo.BackgroundImage = Properties.Resources.Retângulo_2;
            _logo.BackgroundImageLayout = ImageLayout.Stretch;
            _logo.Size = new Size(150, 25);
            _parte_Logo.Controls.Add(_logo);
            _parte_Logo.BackColor = Color.Transparent;
            _logo.BackColor = Color.Transparent;
            _logo.Location = new Point(ParteLogo.Width / 2 - _logo.Width / 2, ParteLogo.Height / 2 - _logo.Height / 2);
        }
        private void AbreInfo()
        {
            _fundoInfo = new RoundedPanel(40);
            _fundoInfo.Visible = true;

            _fundoInfo.Height = 400;
            _fundoInfo.Width = 250;

            _fundoInfo.BorderStyle = BorderStyle.None;
            _form.Controls.Add(_fundoInfo);
            _fundoInfo.Location = new Point(Cursor.Position.X-_fundoInfo.Width/2, Cursor.Position.Y);
            _fundoInfo.BackColor = chave.CinzaClaro;
            _fundoInfo.BringToFront();

            Panel logo = new Panel();
            logo.BackgroundImage = Properties.Resources.Retângulo_2;
            logo.Size = new Size(150, 25);
            logo.BackgroundImageLayout = ImageLayout.Stretch;

            logo.Click += (s, e) =>
            {
                abreHome();
            };


            _fundoInfo.Controls.Add(logo);
            logo.Location = new Point(_fundoInfo.Width / 2 - logo.Width / 2, 20);

            Panel opcoe = new Panel();
            opcoe.BackColor = Color.Transparent;
            opcoe.Width = _fundoInfo.Width-40;
            opcoe.Height = 310;

            opcoe.Location = new Point(20, logo.Location.Y+logo.Height+20);

            _fundoInfo.Controls.Add(opcoe);

            BotaoArredondado sair = new BotaoArredondado();
            sair.Text = "Sair";
            sair.Dock = DockStyle.Top;
            sair.Height = 50;
            sair.Font = chave.H4_Font;
            sair.FlatStyle = FlatStyle.Flat;
            sair.BackColor = chave.CinzaClaro;
            sair.FlatAppearance.BorderSize = 0;
            opcoe.Controls.Add(sair);



            BotaoArredondado matriculados = new BotaoArredondado();
            matriculados.Text = "Cursos Matriculados";
            matriculados.Dock = DockStyle.Top;
            matriculados.Height = 50;
            matriculados.Font = chave.H4_Font;
            matriculados.FlatAppearance.BorderSize = 0;
            matriculados.FlatStyle = FlatStyle.Flat;
            matriculados.BackColor = chave.CinzaClaro;

            opcoe.Controls.Add(matriculados);

            BotaoArredondado perfil = new BotaoArredondado();
            perfil.Text = "Perfil";
            perfil.Dock = DockStyle.Top;
            perfil.Height = 50;
            perfil.Font = chave.H4_Font;
            perfil.FlatAppearance.BorderSize = 0;
            perfil.FlatStyle = FlatStyle.Flat;
            perfil.BackColor = chave.CinzaClaro;

            opcoe.Controls.Add(perfil);


            perfil.Click += (s, e) =>
            {
                abrePerfil();
            };



            sair.TextAlign = ContentAlignment.MiddleLeft;
            perfil.TextAlign = ContentAlignment.MiddleLeft;
            matriculados.TextAlign = ContentAlignment.MiddleLeft;



        }
        private void abrePerfil()
        {
            Thread x = new Thread(() =>
            {
                Aluno alAux = new Aluno();
                Perfil p = new Perfil(i, alAux);
                p.ShowDialog();
            });
            x.Start();
            _form.Close();
        }
        private void abreHome()
        {
            Thread x = new Thread(() =>
            {
                //Aluno alAux = new Aluno();
                Pagina_Inicial p = new Pagina_Inicial(i);
                p.ShowDialog();
            });
            x.Start();
            _form.Close();
        }

        private void sair()
        {
            Thread x = new Thread(() =>
            {
                //Aluno alAux = new Aluno();
                Login P = new Login();
                p.ShowDialog();
            });
            x.Start();
            _form.Close();
        }

    }
}
