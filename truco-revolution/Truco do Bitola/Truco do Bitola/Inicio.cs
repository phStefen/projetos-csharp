using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Truco_do_Bitola
{
    public partial class Inicio : Form
    {
        public SoundPlayer sp = new SoundPlayer(Application.StartupPath + "\\sons\\normal.wav");

        public Inicio()
        {
            InitializeComponent();
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            JogoVS1 obj = new JogoVS1();
            Hide();
            obj.ShowDialog();
            Close();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            sp.PlayLooping();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(".-. .- .--. .... .- . .-.. / ... - . ..-. . -. / .- -- .- / ... .- .-. .- .... / .... . .-.. . -. .-");
        }
    }
}
