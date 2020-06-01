using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrrKlang;

namespace Truco_do_Bitola
{
    public partial class Truco12 : Form
    {
        ISoundEngine engine = new ISoundEngine();

        public int adicional;

        int timer = 0;

        public Boolean aceitou;

        public Truco12()
        {
            InitializeComponent();
        }

        private void btnAceitar_Click(object sender, EventArgs e)
        {
            adicional = 12;
            aceitou = true;
            Close();
        }

        private void btnRecusar_Click(object sender, EventArgs e)
        {

            adicional = 9;
            aceitou = false;
            Close();
        }

        private void tmrVibracao_Tick_1(object sender, EventArgs e)
        {
            timer++;

            switch (timer)
            {
                case 1:
                    pctTruco.Left = 10;
                    pctTruco.Top = 22;
                    break;
                case 2:
                    pctTruco.Left = 15;
                    pctTruco.Top = 32;
                    break;
                case 3:
                    pctTruco.Left = 20;
                    pctTruco.Top = 20;
                    break;
                case 4:
                    pctTruco.Left = 18;
                    pctTruco.Top = 23;
                    break;
                case 5:
                    pctTruco.Left = 2;
                    pctTruco.Top = 30;
                    break;
                case 6:
                    pctTruco.Left = 12;
                    pctTruco.Top = 12;
                    timer = 0;
                    tmrVibracao.Stop();
                    break;
            }
        }

        private void pctDesce_MouseEnter(object sender, EventArgs e)
        {
            pctMaoDesce.Visible = true;
            pctMaoCorre.Visible = false;
        }

        private void pctDesce_MouseLeave(object sender, EventArgs e)
        {
            pctMaoDesce.Visible = false;
        }

        private void pctCorro_MouseEnter(object sender, EventArgs e)
        {
            pctMaoDesce.Visible = false;
            pctMaoCorre.Visible = true;
        }

        private void Truco12_Load(object sender, EventArgs e)
        {
            timer = 0;
            tmrVibracao.Start();
            engine.Play2D(Application.StartupPath + "\\sons\\bater.wav");
        }

        private void pctCorro_MouseLeave(object sender, EventArgs e)
        {
            pctMaoCorre.Visible = false;
        }
    }
}
