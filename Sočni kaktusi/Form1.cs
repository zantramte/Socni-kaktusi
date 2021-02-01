using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Sočni_kaktusi
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer Igra = new WindowsMediaPlayer();

        WindowsMediaPlayer Igra_2 = new WindowsMediaPlayer();

        public void Razporedi_kaktuse()
        {
            for (int indeks = 0; indeks < panel1.Controls.Count; indeks++)
            {
                if (panel1.Controls[indeks] is Label)
                {
                    int sedaj = Kaktusi.Kaktus.Next(Kaktusi.Puscavski_emoji.Count);
                    panel1.Controls[indeks].Text = Convert.ToString(Kaktusi.Puscavski_emoji[sedaj]);
                    Kaktusi.Puscavski_emoji.RemoveAt(sedaj);
                }
            }
        }

        public void Razporedi_vse_potrebno()
        {
            for (int indeks = 0; indeks < panel1.Controls.Count; indeks++)
            {
                panel1.Controls[indeks].Visible = true;
            }

            Kaktusi.Poskusi = 3;

            label6.Text = Convert.ToString(Kaktusi.Poskusi);

            Kaktusi.Polni_Puscavske_Crke();

            Kaktusi.Izbrani_kaktusek();

            Razporedi_kaktuse();
        }

        public Form1()
        {
            InitializeComponent();

            Igra.URL = "music.mp3";

            Igra.settings.volume = 70;

            Igra.settings.setMode("loop", true);

            Show();

            MessageBox.Show("ŽIVJO! Smo kaktusi in danes se boš z nami igral/a igrico ugibanja smeškota!", "Kaktusi sporočajo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Razporedi_vse_potrebno();
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            Igra_2.URL = "smeh.mp3";
            PictureBox kaktus = sender as PictureBox;
            kaktus.Image = Properties.Resources.kk2;
            Cursor = Cursors.Hand;

            for (int indeks = 0; indeks < panel1.Controls.Count; indeks++)
            {
                if ((panel1.Controls[indeks] is Label) && (panel1.Controls[indeks].Location.X == (kaktus.Location.X + 48)))
                {
                    panel1.Controls[indeks].ForeColor = Color.DarkGreen;
                }
            }
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            PictureBox kaktus = sender as PictureBox;
            kaktus.Image = Properties.Resources.kk1;
            Cursor = Cursors.Default;

            for (int indeks = 0; indeks < panel1.Controls.Count; indeks++)
            {
                if ((panel1.Controls[indeks] is Label) && (panel1.Controls[indeks].Location.X == (kaktus.Location.X + 48)))
                {
                    panel1.Controls[indeks].ForeColor = Color.White;
                }
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Igra_2.URL = "blop.mp3";

            Razporedi_vse_potrebno();
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;

            pictureBox7.Image = Properties.Resources.s55;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;

            pictureBox7.Image = Properties.Resources.s44;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            PictureBox kaktus = sender as PictureBox;

            for (int indeks = 0; indeks < panel1.Controls.Count; indeks++)
            {
                if ((panel1.Controls[indeks] is Label) && (panel1.Controls[indeks].Location.X == (kaktus.Location.X + 48)))
                {
                    Kaktusi.Izbrani_kaktus = panel1.Controls[indeks].Text;
                    kaktus.Visible = false;
                    panel1.Controls[indeks].Visible = false;

                    if (Kaktusi.Preveri_kaktus() == true)
                    {
                        Igra_2.URL = "prav.mp3";

                        MessageBox.Show("BRAVO! V mislih sem imel črko " + Kaktusi.Izbrani_kaktus + "!", "Kaktus sporoča", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        Razporedi_vse_potrebno();

                        Kaktusi.Polni_Puscavske_Crke();
                    }

                    else
                    {
                        Kaktusi.Poskusi--;

                        label6.Text = Convert.ToString(Kaktusi.Poskusi);

                        if (Kaktusi.Poskusi == 0)
                        {
                            Igra_2.URL = "wrong.wav";

                            DialogResult dialog = MessageBox.Show("HMMM, ZMANJKALO TI JE POSKUSOV! Bi poskusil/a gibati še enkrat?", "Kaktusi sporočajo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                            if (dialog == DialogResult.Yes)
                            {
                                Razporedi_vse_potrebno();
                            }

                            else
                            {
                                Application.Exit();
                            }
                        }

                        else
                        {
                            Igra_2.URL = "wrong.wav";

                            MessageBox.Show("HMMMM, NE BO DRŽALO! Poskusi še enkrat!", "Kaktus sporoča", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kaktusi.Status_Puscave++;

            if (Kaktusi.Status_Puscave % 2 == 0)
            {
                panel1.BackgroundImage = Properties.Resources.pi;

                button1.Text = "Nočka";
            }

            else
            {
                panel1.BackgroundImage = Properties.Resources.pii;

                button1.Text = "Dan";
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;

            button1.BackColor = Color.SeaGreen;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;

            button1.BackColor = Color.MediumSeaGreen;
        }
    }
}
