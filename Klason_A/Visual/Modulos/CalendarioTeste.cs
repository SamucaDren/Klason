using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klason_A.Visual.Modulos
{
    internal class CalendarioTeste
    {
        private Cores_Fontes chave = new Cores_Fontes();

        private RoundedPanel fundo;
        int year = 2024;  // Ano desejado
        int month = 5;
        int DiaAtual;
        int MesAtual;
        int AnoAtual;
        Flow Dias;
        Label NomeDoMes = new Label();
        Button prox = new Button();
        Button ant = new Button();
        NumericUpDown hora;
        NumericUpDown minu;

        List<DateTime> datas = new List<DateTime>();


        int MesSelecionado;
        int AnoSelecionado;

        public CalendarioTeste()
        {

            Hoje();
            MesSelecionado = MesAtual;
            AnoSelecionado = AnoAtual;
            Cria();
        }
        public RoundedPanel Fundo { get => fundo; set => fundo = value; }
        public List<DateTime> Datas { get => datas; set => datas = value; }
        public int Hora
        {
            get { return (int)hora.Value; }
        }
        public int Minuto
        {
            get { return (int)minu.Value; }
        }
        private void Hoje()
        {
            DateTime currentDateTime = DateTime.Now;
            DiaAtual = currentDateTime.Day;
            MesAtual = currentDateTime.Month;
            AnoAtual = currentDateTime.Year;
        }
        private void Cria()
        {
            fundo = new RoundedPanel(30);
            fundo.BackColor = chave.Branco;
            Dias = new Flow();
            //Dias.BackColor = chave.Verde;
            fundo.Controls.Add(Dias);
            Dias.Width = fundo.Width - 18;
            Dias.Height = 150;
            Dias.Location = new System.Drawing.Point(9, 90);
            
            Panel div = new Panel();
            fundo.Controls.Add(div);
            div.Height = 2;
            div.Width = fundo.Width - 20;
            div.BackColor = chave.Cinza;
            div.Location = new System.Drawing.Point(10, Dias.Location.Y + Dias.Height + 15);
            AdicionaDias();
            AdicionaLabel();
            AdicionaHora();

        }
        public void AdicionaDias()
        {
            Dias.Controls.Clear();

            DayOfWeek dayOfWeek = new DateTime(AnoSelecionado, MesSelecionado, 1).DayOfWeek;

            int mais = 0;
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    mais = 0;
                    break;
                case DayOfWeek.Monday:
                    mais = 1;
                    break;
                case DayOfWeek.Tuesday:
                    mais = 2;
                    break;
                case DayOfWeek.Wednesday:
                    mais = 3;
                    break;
                case DayOfWeek.Thursday:
                    mais = 4;
                    break;
                case DayOfWeek.Friday:
                    mais = 5;
                    break;
                case DayOfWeek.Saturday:
                    mais = 6;
                    break;
            }

            int daysInMonth = DateTime.DaysInMonth(AnoAtual, MesSelecionado);
            for (int i = 0; i < mais; i++)
            {
                AddDia(0);
            }
            for (int day = 1; day <= daysInMonth; day++)
            {
                AddDia(day);
            }
        }
        private void AddDia(int day)
        {
            RoundedPanel dia = new RoundedPanel(5);
            dia.Size = new System.Drawing.Size(20, 20);
            dia.BackColor = chave.CinzaClaro;
            Dias.Controls.Add(dia);
            if (day > 0)
            {
                Label d = new Label();
                d.Font = chave.H4_Font;
                d.ForeColor = chave.Preto;
                //d.Dock = DockStyle.Fill;
                d.AutoSize = true;
                d.Text = day.ToString();
                dia.Controls.Add(d);
                d.Location = new System.Drawing.Point(dia.Width / 2 - d.Width / 2);
                d.Click += (s, e) =>
                {
                    if(dia.BackColor == chave.CinzaClaro)
                    {
                        dia.BackColor = chave.Verde;
                        d.ForeColor = chave.Branco;
                        DateTime dt = new System.DateTime(AnoSelecionado, MesSelecionado, int.Parse(d.Text));
                        Datas.Add(dt);
                    }

                };
            }



        }
        private void AdicionaLabel()
        {
            NomeDoMes.Font = chave.H3_Font_Sub;
            //NomeDoMes.AutoSize = true;
            NomeDoMes.Height = 40;
            NomeDoMes.Width = Fundo.Width;
            NomeDoMes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            NomeDoMes.ForeColor = chave.Preto;
            NomeDoMes.Text = NomeMes(MesSelecionado);
            NomeDoMes.Location = new System.Drawing.Point(fundo.Width / 2 - NomeDoMes.Width / 2, 5);
            fundo.Controls.Add(NomeDoMes);

            Label sem = new Label();
            sem.Text = "D    S   T    Q    Q   S    S";
            sem.Font = chave.H1_Notificacao;
            sem.AutoSize = true;
            sem.ForeColor = chave.Cinza;
            fundo.Controls.Add(sem);
            sem.Location = new System.Drawing.Point(12, 50);

            fundo.Controls.Add(prox);
            prox.Text = ">";
            prox.Width = 40;
            prox.Height = 40;
            prox.Font = chave.H3_Font_Sub;
            prox.FlatStyle = FlatStyle.Flat;
            prox.FlatAppearance.BorderSize = 0;
            prox.Location = new System.Drawing.Point(fundo.Width-prox.Width-2, 5);
            prox.BringToFront();

            fundo.Controls.Add(ant);
            ant.Text = "<";
            ant.Width = 40;
            ant.Height = 40;
            ant.Font = chave.H3_Font_Sub;
            ant.FlatStyle = FlatStyle.Flat;
            ant.FlatAppearance.BorderSize = 0;
            ant.Location = new System.Drawing.Point(5, 5);
            ant.BringToFront();



            prox.Click += (s, e) =>
            {
                if (MesSelecionado == 12)
                {
                    MesSelecionado = 1;
                    AnoSelecionado++;
                }
                else
                {
                    MesSelecionado++;
                }
                
                AdicionaDias();
                NomeDoMes.Text = NomeMes(MesSelecionado);
            };
            ant.Click += (s, e) =>
            {
                if (MesSelecionado == 1)
                {
                    MesSelecionado = 12;
                    AnoSelecionado--;
                }
                else
                {
                    MesSelecionado--;
                }

                AdicionaDias();
                NomeDoMes.Text = NomeMes(MesSelecionado);
            };


        }
        public string NomeMes(int i)
        {
            switch (i)
            {
                case 1:
                    return "Janeiro";
                    break;
                case 2:
                    return "Fevereiro";
                    break;
                case 3:
                    return "Março";
                    break;
                case 4:
                    return "Abril";
                    break;
                case 5:
                    return "Maio";
                    break;
                case 6:
                    return "Junho";
                    break;
                case 7:
                    return "Julho";
                    break;
                case 8:
                    return "Agosto";
                    break;
                case 9:
                    return "Setembro";
                    break;
                case 10:
                    return "Outubro";
                    break;
                case 11:
                    return "Novembro";
                    break;
                case 12:
                    return "Dezembro";
                    break;


            }
            return " ";
        }
        private void AdicionaHora()
        {
            hora = new NumericUpDown();
            hora.Value = 15;
            fundo.Controls.Add(hora);
            hora.Font = chave.H3_Font_Sub;
            hora.ForeColor = chave.Preto;
            hora.Width = 50;
            hora.Location = new System.Drawing.Point(12, Dias.Location.Y + Dias.Height + 42);
            hora.Maximum = 23; hora.Minimum = 0;
            hora.BringToFront();
            hora.BorderStyle = BorderStyle.None;

            Label lbl = new Label();
            fundo.Controls.Add(lbl);
            lbl.Text = ":";
            lbl.Font = hora.Font;
            lbl.ForeColor = chave.Preto;
            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(hora.Width + hora.Location.X, hora.Location.Y);
            lbl.BringToFront();

            minu = new NumericUpDown();
            minu.Value = 30;
            fundo.Controls.Add(minu);
            minu.Font = chave.H3_Font_Sub;
            minu.ForeColor = chave.Preto;
            minu.Width = 50;
            minu.Location = new System.Drawing.Point(hora.Location.X+hora.Width+16, hora.Location.Y);

            minu.BorderStyle = BorderStyle.None;
            minu.Maximum = 59; minu.Minimum = 0;
            minu.BringToFront();

        }

    }
}
