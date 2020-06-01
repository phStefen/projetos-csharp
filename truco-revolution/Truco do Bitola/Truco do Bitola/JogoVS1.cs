using System;
using System.Windows.Forms;
using Truco_do_Bitola.Properties;
using IrrKlang;
using System.Media;

namespace Truco_do_Bitola
{
    public partial class JogoVS1 : Form
    {
        ISoundEngine engine = new ISoundEngine();

        Truco3 objTruco3 = new Truco3();
        Truco6 objTruco6 = new Truco6();
        Truco9 objTruco9 = new Truco9();
        Truco12 objTruco12 = new Truco12();
        Inicio objInicio = new Inicio();
        int cont = 0;
    
        int[,] tabelaImagem = new int[4, 10]{
            {1,5,9,13,17,21,25,29,33,37} ,
            {2,6,10,14,18,22,26,30,34,38} ,
            {3,7,11,15,19,23,27,31,35,39} ,
            {4,8,12,16,20,24,28,32,36,40} ,
        };

        int[,] tabelaOrdem = new int[4, 11] {
            {1,2,3,4,5,6,7,8,9,10,100} ,
            {1,2,3,4,5,6,7,8,9,10,101} ,
            {1,2,3,4,5,6,7,8,9,10,102} ,
            {1,2,3,4,5,6,7,8,9,10,103} ,
        };

        int[] cartas = new int[7] { 0, 0, 0, 0, 0, 0, 0 }, poder = new int[6] { 0, 0, 0, 0, 0, 0 }, coluna = new int[7], linha = new int[7], jogadaD = new int[3] { 0, 0, 0 };

        int jogadaS, rodada = 1, rodadaS = 0, rodadaD = 0, pontosV = 0, pontosE = 0, trucoAceitar, trucoPedir, adicional = 0, imgTruco = 0;

        Boolean esconder = false, eleFez = false, ferro = false;

        Random rnd = new Random();

        public JogoVS1()
        {
            InitializeComponent();
        }

        private void Jogo_Load(object sender, EventArgs e)
        {
        }

        private void pctMenu_Click(object sender, EventArgs e)
        {
            Hide();
            objInicio.ShowDialog();
            Close();
        }

        private void btnEsconder_Click(object sender, EventArgs e)
        {
            pctMao1.Visible = false;
            pctMao2.Visible = false;
            pctMao3.Visible = false;

            btnJogar.Enabled = false;
            btnEsconder.Enabled = false;

            esconder = true;

            moverCartas();
            moverCartasDele();

            quemFez();
            fimRodada();
            verificarFimRodada();
        }

        private void btnCorrer_Click(object sender, EventArgs e)
        {
            rodadaD = 2;
            verificarFimRodada();
        }

        private void btnTruco_Click(object sender, EventArgs e)
        {
            saberTruco();
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            pctMao1.Visible = false;
            pctMao2.Visible = false;
            pctMao3.Visible = false;

            btnJogar.Enabled = false;
            btnEsconder.Enabled = false;

            moverCartas();
            moverCartasDele();

            quemFez();
            fimRodada();
            verificarFimRodada();

            if (rodada > 1)
            {
                btnEsconder.Visible = true;

                if (eleFez == true)
                {
                    moverCartasDele();
                    pctDeleJogada.Visible = true;
                }
            }
        }

        private void btnComecar_Click(object sender, EventArgs e)
        {
            btnComecar.Visible = false;
            carregarJogo();
        }

        private void rdbSua1_CheckedChanged(object sender, EventArgs e)
        {
            btnEsconder.Enabled = true;
            btnJogar.Enabled = true;
            pctMao1.Visible = true;
            pctMao2.Visible = false;
            pctMao3.Visible = false;
            pctSelecionaCarta.Visible = false;
        }

        private void rdbSua2_CheckedChanged(object sender, EventArgs e)
        {
            btnEsconder.Enabled = true;
            btnJogar.Enabled = true;
            pctMao1.Visible = false;
            pctMao2.Visible = true;
            pctMao3.Visible = false;
            pctSelecionaCarta.Visible = false;
        }

        private void rdbSua3_CheckedChanged(object sender, EventArgs e)
        {
            btnEsconder.Enabled = true;
            btnJogar.Enabled = true;
            pctMao1.Visible = false;
            pctMao2.Visible = false;
            pctMao3.Visible = true;
            pctSelecionaCarta.Visible = false;
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            carregarJogo();
        }

        public void carregarJogo()
        {
            pctVira.Visible = false;
            pctCarta0.Visible = false;

            rdbSua1.Visible = false;
            rdbSua2.Visible = false;
            rdbSua3.Visible = false;

            pctCarta4.Visible = false;
            pctCarta5.Visible = false;
            pctCarta6.Visible = false;

            btnJogar.Visible = false;
            btnCorrer.Visible = false;
            btnEsconder.Visible = false;
            btnTruco.Visible = false;

            rdbSua1.Enabled = false;
            rdbSua2.Enabled = false;
            rdbSua3.Enabled = false;

            pctSelecionaCarta.Visible = false;

            pctMao1.Visible = false;
            pctMao2.Visible = false;
            pctMao3.Visible = false;

            for (int i = 0; i < 7; i++)
            {
                cartas[i] = 0;
            }

            for (int i = 0; i < 6; i++)
            {
                poder[i] = 0;
            }

            for (int i = 0; i < 3; i++)
            {
                jogadaD[i] = 0;
            }

            esconder = false;
            eleFez = false;

            pctPontos1.Image = Resources.Normal1;
            pctPontos2.Image = Resources.Normal1;
            pctPontos3.Image = Resources.Normal1;

            rodadaD = 0;
            rodadaS = 0;
            rodada = 1;
            adicional = 0;
            imgTruco = 0;
            cont = 0;

            tabelaCartas();
            darCartas();

            tabelaCartasDele();
            verificarCartasDele();

            tabelaPoder();
            maoDeFerro(ferro);

            tmrCartas.Start();
            mostrarPontos();
        }

        public void tabelaCartas()
        {
            for (int i = 0; i < 7; i++)
            {
                if (cartas[i] == 0)
                {
                    linha[i] = rnd.Next(0, 4);
                    coluna[i] = rnd.Next(0, 10);
                    cartas[i] = tabelaImagem[linha[i], coluna[i]];
                }
            }
            verificarCartas();
        }

        public void comecoDeRodada()
        {
            if (adicional == 0 && rodada < 3 && pontosE<11 && pontosV<11)
            {
                inimigoTruco();
            }
        }

        public void verificarCartas()
        {

            for (int i = 1; i < 7; i++)
            {
                if (cartas[0] == cartas[i])
                {
                    cartas[0] = 0;
                }
            }

            for (int i = 2; i < 7; i++)
            {
                if (cartas[1] == cartas[i])
                {
                    cartas[1] = 0;
                }
            }

            for (int i = 3; i < 7; i++)
            {
                if (cartas[2] == cartas[i])
                {
                    cartas[2] = 0;
                }
            }

            for (int i = 4; i < 7; i++)
            {
                if (cartas[3] == cartas[i])
                {
                    cartas[3] = 0;
                }
            }

            for (int i = 5; i < 7; i++)
            {
                if (cartas[4] == cartas[i])
                {
                    cartas[4] = 0;
                }
            }

            if (cartas[5] == cartas[6])
            {
                cartas[5] = 0;
            }

            for (int i = 0; i < 7; i++)
            {
                if (cartas[i] == 0)
                {
                    tabelaCartas();
                }
            }
        }

        public void tabelaCartasDele()
        {
            for (int i = 0; i < 3; i++)
            {
                jogadaD[i] = rnd.Next(3, 6);
            }

            verificarCartasDele();
        }

        public void verificarCartasDele()
        {
            for (int i = 1; i < 3; i++)
            {
                if (jogadaD[0] == jogadaD[i])
                {
                    jogadaD[0] = 0;
                }
            }

            if (jogadaD[1] == jogadaD[2])
            {
                jogadaD[1] = 0;
            }

            else if (jogadaD[2] == jogadaD[0])
            {
                jogadaD[2] = 0;
            }

            for (int i = 0; i < 3; i++)
            {
                if (jogadaD[i] == 0)
                {
                    tabelaCartasDele();
                }
            }

        }

        public void darCartas()
        {
            switch (cartas[0])
            {
                case 1:
                    pctCarta0.Image = Resources._4O;
                    break;

                case 2:
                    pctCarta0.Image = Resources._4E;
                    break;

                case 3:
                    pctCarta0.Image = Resources._4C;
                    break;

                case 4:
                    pctCarta0.Image = Resources._4P;
                    break;

                case 5:
                    pctCarta0.Image = Resources._5O;
                    break;

                case 6:
                    pctCarta0.Image = Resources._5E;
                    break;

                case 7:
                    pctCarta0.Image = Resources._5C;
                    break;

                case 8:
                    pctCarta0.Image = Resources._5P;
                    break;

                case 9:
                    pctCarta0.Image = Resources._6O;
                    break;

                case 10:
                    pctCarta0.Image = Resources._6E;
                    break;

                case 11:
                    pctCarta0.Image = Resources._6C;
                    break;

                case 12:
                    pctCarta0.Image = Resources._6P;
                    break;

                case 13:
                    pctCarta0.Image = Resources._7O;
                    break;

                case 14:
                    pctCarta0.Image = Resources._7E;
                    break;

                case 15:
                    pctCarta0.Image = Resources._7C;
                    break;

                case 16:
                    pctCarta0.Image = Resources._7P;
                    break;

                case 17:
                    pctCarta0.Image = Resources.QO;
                    break;

                case 18:
                    pctCarta0.Image = Resources.QE;
                    break;

                case 19:
                    pctCarta0.Image = Resources.QC;
                    break;

                case 20:
                    pctCarta0.Image = Resources.QP;
                    break;

                case 21:
                    pctCarta0.Image = Resources.JO;
                    break;

                case 22:
                    pctCarta0.Image = Resources.JE;
                    break;

                case 23:
                    pctCarta0.Image = Resources.JC;
                    break;

                case 24:
                    pctCarta0.Image = Resources.JP;
                    break;

                case 25:
                    pctCarta0.Image = Resources.KO;
                    break;

                case 26:
                    pctCarta0.Image = Resources.KE;
                    break;

                case 27:
                    pctCarta0.Image = Resources.KC;
                    break;

                case 28:
                    pctCarta0.Image = Resources.KP;
                    break;

                case 29:
                    pctCarta0.Image = Resources.AO;
                    break;

                case 30:
                    pctCarta0.Image = Resources.AE;
                    break;

                case 31:
                    pctCarta0.Image = Resources.AC;
                    break;

                case 32:
                    pctCarta0.Image = Resources.AP;
                    break;

                case 33:
                    pctCarta0.Image = Resources._2O;
                    break;

                case 34:
                    pctCarta0.Image = Resources._2E;
                    break;

                case 35:
                    pctCarta0.Image = Resources._2C;
                    break;

                case 36:
                    pctCarta0.Image = Resources._2P;
                    break;

                case 37:
                    pctCarta0.Image = Resources._3O;
                    break;

                case 38:
                    pctCarta0.Image = Resources._3E;
                    break;

                case 39:
                    pctCarta0.Image = Resources._3C;
                    break;

                case 40:
                    pctCarta0.Image = Resources._3P;
                    break;

            }

            switch (cartas[1])
            {
                case 1:
                    rdbSua1.BackgroundImage = Resources._4O;
                    poder[0] = 1;
                    break;

                case 2:
                    rdbSua1.BackgroundImage = Resources._4E;
                    poder[0] = 1;
                    break;

                case 3:
                    rdbSua1.BackgroundImage = Resources._4C;
                    poder[0] = 1;
                    break;

                case 4:
                    rdbSua1.BackgroundImage = Resources._4P;
                    poder[0] = 1;
                    break;

                case 5:
                    rdbSua1.BackgroundImage = Resources._5O;
                    poder[0] = 2;
                    break;

                case 6:
                    rdbSua1.BackgroundImage = Resources._5E;
                    poder[0] = 2;
                    break;

                case 7:
                    rdbSua1.BackgroundImage = Resources._5C;
                    poder[0] = 2;
                    break;

                case 8:
                    rdbSua1.BackgroundImage = Resources._5P;
                    poder[0] = 2;
                    break;

                case 9:
                    rdbSua1.BackgroundImage = Resources._6O;
                    poder[0] = 3;
                    break;

                case 10:
                    rdbSua1.BackgroundImage = Resources._6E;
                    poder[0] = 3;
                    break;

                case 11:
                    rdbSua1.BackgroundImage = Resources._6C;
                    poder[0] = 3;
                    break;

                case 12:
                    rdbSua1.BackgroundImage = Resources._6P;
                    poder[0] = 3;
                    break;

                case 13:
                    rdbSua1.BackgroundImage = Resources._7O;
                    poder[0] = 4;
                    break;

                case 14:
                    rdbSua1.BackgroundImage = Resources._7E;
                    poder[0] = 4;
                    break;

                case 15:
                    rdbSua1.BackgroundImage = Resources._7C;
                    poder[0] = 4;
                    break;

                case 16:
                    rdbSua1.BackgroundImage = Resources._7P;
                    poder[0] = 4;
                    break;

                case 17:
                    rdbSua1.BackgroundImage = Resources.QO;
                    poder[0] = 5;
                    break;

                case 18:
                    rdbSua1.BackgroundImage = Resources.QE;
                    poder[0] = 5;
                    break;

                case 19:
                    rdbSua1.BackgroundImage = Resources.QC;
                    poder[0] = 5;
                    break;

                case 20:
                    rdbSua1.BackgroundImage = Resources.QP;
                    poder[0] = 5;
                    break;

                case 21:
                    rdbSua1.BackgroundImage = Resources.JO;
                    poder[0] = 6;
                    break;

                case 22:
                    rdbSua1.BackgroundImage = Resources.JE;
                    poder[0] = 6;
                    break;

                case 23:
                    rdbSua1.BackgroundImage = Resources.JC;
                    poder[0] = 6;
                    break;

                case 24:
                    rdbSua1.BackgroundImage = Resources.JP;
                    poder[0] = 6;
                    break;

                case 25:
                    rdbSua1.BackgroundImage = Resources.KO;
                    poder[0] = 7;
                    break;

                case 26:
                    rdbSua1.BackgroundImage = Resources.KE;
                    poder[0] = 7;
                    break;

                case 27:
                    rdbSua1.BackgroundImage = Resources.KC;
                    poder[0] = 7;
                    break;

                case 28:
                    rdbSua1.BackgroundImage = Resources.KP;
                    poder[0] = 7;
                    break;

                case 29:
                    rdbSua1.BackgroundImage = Resources.AO;
                    poder[0] = 8;
                    break;

                case 30:
                    rdbSua1.BackgroundImage = Resources.AE;
                    poder[0] = 8;
                    break;

                case 31:
                    rdbSua1.BackgroundImage = Resources.AC;
                    poder[0] = 8;
                    break;

                case 32:
                    rdbSua1.BackgroundImage = Resources.AP;
                    poder[0] = 8;
                    break;

                case 33:
                    rdbSua1.BackgroundImage = Resources._2O;
                    poder[0] = 9;
                    break;

                case 34:
                    rdbSua1.BackgroundImage = Resources._2E;
                    poder[0] = 9;
                    break;

                case 35:
                    rdbSua1.BackgroundImage = Resources._2C;
                    poder[0] = 9;
                    break;

                case 36:
                    rdbSua1.BackgroundImage = Resources._2P;
                    poder[0] = 9;
                    break;

                case 37:
                    rdbSua1.BackgroundImage = Resources._3O;
                    poder[0] = 10;
                    break;

                case 38:
                    rdbSua1.BackgroundImage = Resources._3E;
                    poder[0] = 10;
                    break;

                case 39:
                    rdbSua1.BackgroundImage = Resources._3C;
                    poder[0] = 10;
                    break;

                case 40:
                    rdbSua1.BackgroundImage = Resources._3P;
                    poder[0] = 10;
                    break;

            }

            switch (cartas[2])
            {
                case 1:
                    rdbSua2.BackgroundImage = Resources._4O;
                    poder[1] = 1;
                    break;

                case 2:
                    rdbSua2.BackgroundImage = Resources._4E;
                    poder[1] = 1;
                    break;

                case 3:
                    rdbSua2.BackgroundImage = Resources._4C;
                    poder[1] = 1;
                    break;

                case 4:
                    rdbSua2.BackgroundImage = Resources._4P;
                    poder[1] = 1;
                    break;

                case 5:
                    rdbSua2.BackgroundImage = Resources._5O;
                    poder[1] = 2;
                    break;

                case 6:
                    rdbSua2.BackgroundImage = Resources._5E;
                    poder[1] = 2;
                    break;

                case 7:
                    rdbSua2.BackgroundImage = Resources._5C;
                    poder[1] = 2;
                    break;

                case 8:
                    rdbSua2.BackgroundImage = Resources._5P;
                    poder[1] = 2;
                    break;

                case 9:
                    rdbSua2.BackgroundImage = Resources._6O;
                    poder[1] = 3;
                    break;

                case 10:
                    rdbSua2.BackgroundImage = Resources._6E;
                    poder[1] = 3;
                    break;

                case 11:
                    rdbSua2.BackgroundImage = Resources._6C;
                    poder[1] = 3;
                    break;

                case 12:
                    rdbSua2.BackgroundImage = Resources._6P;
                    poder[1] = 3;
                    break;

                case 13:
                    rdbSua2.BackgroundImage = Resources._7O;
                    poder[1] = 4;
                    break;

                case 14:
                    rdbSua2.BackgroundImage = Resources._7E;
                    poder[1] = 4;
                    break;

                case 15:
                    rdbSua2.BackgroundImage = Resources._7C;
                    poder[1] = 4;
                    break;

                case 16:
                    rdbSua2.BackgroundImage = Resources._7P;
                    poder[1] = 4;
                    break;

                case 17:
                    rdbSua2.BackgroundImage = Resources.QO;
                    poder[1] = 5;
                    break;

                case 18:
                    rdbSua2.BackgroundImage = Resources.QE;
                    poder[1] = 5;
                    break;

                case 19:
                    rdbSua2.BackgroundImage = Resources.QC;
                    poder[1] = 5;
                    break;

                case 20:
                    rdbSua2.BackgroundImage = Resources.QP;
                    poder[1] = 5;
                    break;

                case 21:
                    rdbSua2.BackgroundImage = Resources.JO;
                    poder[1] = 6;
                    break;

                case 22:
                    rdbSua2.BackgroundImage = Resources.JE;
                    poder[1] = 6;
                    break;

                case 23:
                    rdbSua2.BackgroundImage = Resources.JC;
                    poder[1] = 6;
                    break;

                case 24:
                    rdbSua2.BackgroundImage = Resources.JP;
                    poder[1] = 6;
                    break;

                case 25:
                    rdbSua2.BackgroundImage = Resources.KO;
                    poder[1] = 7;
                    break;

                case 26:
                    rdbSua2.BackgroundImage = Resources.KE;
                    poder[1] = 7;
                    break;

                case 27:
                    rdbSua2.BackgroundImage = Resources.KC;
                    poder[1] = 7;
                    break;

                case 28:
                    rdbSua2.BackgroundImage = Resources.KP;
                    poder[1] = 7;
                    break;

                case 29:
                    rdbSua2.BackgroundImage = Resources.AO;
                    poder[1] = 8;
                    break;

                case 30:
                    rdbSua2.BackgroundImage = Resources.AE;
                    poder[1] = 8;
                    break;

                case 31:
                    rdbSua2.BackgroundImage = Resources.AC;
                    poder[1] = 8;
                    break;

                case 32:
                    rdbSua2.BackgroundImage = Resources.AP;
                    poder[1] = 8;
                    break;

                case 33:
                    rdbSua2.BackgroundImage = Resources._2O;
                    poder[1] = 9;
                    break;

                case 34:
                    rdbSua2.BackgroundImage = Resources._2E;
                    poder[1] = 9;
                    break;

                case 35:
                    rdbSua2.BackgroundImage = Resources._2C;
                    poder[1] = 9;
                    break;

                case 36:
                    rdbSua2.BackgroundImage = Resources._2P;
                    poder[1] = 9;
                    break;

                case 37:
                    rdbSua2.BackgroundImage = Resources._3O;
                    poder[1] = 10;
                    break;

                case 38:
                    rdbSua2.BackgroundImage = Resources._3E;
                    poder[1] = 10;
                    break;

                case 39:
                    rdbSua2.BackgroundImage = Resources._3C;
                    poder[1] = 10;
                    break;

                case 40:
                    rdbSua2.BackgroundImage = Resources._3P;
                    poder[1] = 10;
                    break;

            }

            switch (cartas[3])
            {
                case 1:
                    rdbSua3.BackgroundImage = Resources._4O;
                    poder[2] = 1;
                    break;

                case 2:
                    rdbSua3.BackgroundImage = Resources._4E;
                    poder[2] = 1;
                    break;

                case 3:
                    rdbSua3.BackgroundImage = Resources._4C;
                    poder[2] = 1;
                    break;

                case 4:
                    rdbSua3.BackgroundImage = Resources._4P;
                    poder[2] = 1;
                    break;

                case 5:
                    rdbSua3.BackgroundImage = Resources._5O;
                    poder[2] = 2;
                    break;

                case 6:
                    rdbSua3.BackgroundImage = Resources._5E;
                    poder[2] = 2;
                    break;

                case 7:
                    rdbSua3.BackgroundImage = Resources._5C;
                    poder[2] = 2;
                    break;

                case 8:
                    rdbSua3.BackgroundImage = Resources._5P;
                    poder[2] = 2;
                    break;

                case 9:
                    rdbSua3.BackgroundImage = Resources._6O;
                    poder[2] = 3;
                    break;

                case 10:
                    rdbSua3.BackgroundImage = Resources._6E;
                    poder[2] = 3;
                    break;

                case 11:
                    rdbSua3.BackgroundImage = Resources._6C;
                    poder[2] = 3;
                    break;

                case 12:
                    rdbSua3.BackgroundImage = Resources._6P;
                    poder[2] = 3;
                    break;

                case 13:
                    rdbSua3.BackgroundImage = Resources._7O;
                    poder[2] = 4;
                    break;

                case 14:
                    rdbSua3.BackgroundImage = Resources._7E;
                    poder[2] = 4;
                    break;

                case 15:
                    rdbSua3.BackgroundImage = Resources._7C;
                    poder[2] = 4;
                    break;

                case 16:
                    rdbSua3.BackgroundImage = Resources._7P;
                    poder[2] = 4;
                    break;

                case 17:
                    rdbSua3.BackgroundImage = Resources.QO;
                    poder[2] = 5;
                    break;

                case 18:
                    rdbSua3.BackgroundImage = Resources.QE;
                    poder[2] = 5;
                    break;

                case 19:
                    rdbSua3.BackgroundImage = Resources.QC;
                    poder[2] = 5;
                    break;

                case 20:
                    rdbSua3.BackgroundImage = Resources.QP;
                    poder[2] = 5;
                    break;

                case 21:
                    rdbSua3.BackgroundImage = Resources.JO;
                    poder[2] = 6;
                    break;

                case 22:
                    rdbSua3.BackgroundImage = Resources.JE;
                    poder[2] = 6;
                    break;

                case 23:
                    rdbSua3.BackgroundImage = Resources.JC;
                    poder[2] = 6;
                    break;

                case 24:
                    rdbSua3.BackgroundImage = Resources.JP;
                    poder[2] = 6;
                    break;

                case 25:
                    rdbSua3.BackgroundImage = Resources.KO;
                    poder[2] = 7;
                    break;

                case 26:
                    rdbSua3.BackgroundImage = Resources.KE;
                    poder[2] = 7;
                    break;

                case 27:
                    rdbSua3.BackgroundImage = Resources.KC;
                    poder[2] = 7;
                    break;

                case 28:
                    rdbSua3.BackgroundImage = Resources.KP;
                    poder[2] = 7;
                    break;

                case 29:
                    rdbSua3.BackgroundImage = Resources.AO;
                    poder[2] = 8;
                    break;

                case 30:
                    rdbSua3.BackgroundImage = Resources.AE;
                    poder[2] = 8;
                    break;

                case 31:
                    rdbSua3.BackgroundImage = Resources.AC;
                    poder[2] = 8;
                    break;

                case 32:
                    rdbSua3.BackgroundImage = Resources.AP;
                    poder[2] = 8;
                    break;

                case 33:
                    rdbSua3.BackgroundImage = Resources._2O;
                    poder[2] = 9;
                    break;

                case 34:
                    rdbSua3.BackgroundImage = Resources._2E;
                    poder[2] = 9;
                    break;

                case 35:
                    rdbSua3.BackgroundImage = Resources._2C;
                    poder[2] = 9;
                    break;

                case 36:
                    rdbSua3.BackgroundImage = Resources._2P;
                    poder[2] = 9;
                    break;

                case 37:
                    rdbSua3.BackgroundImage = Resources._3O;
                    poder[2] = 10;
                    break;

                case 38:
                    rdbSua3.BackgroundImage = Resources._3E;
                    poder[2] = 10;
                    break;

                case 39:
                    rdbSua3.BackgroundImage = Resources._3C;
                    poder[2] = 10;
                    break;

                case 40:
                    rdbSua3.BackgroundImage = Resources._3P;
                    poder[2] = 10;
                    break;
            }

            switch (cartas[4])
            {
                case 1:
                    poder[3] = 1;
                    break;

                case 2:
                    poder[3] = 1;
                    break;

                case 3:
                    poder[3] = 1;
                    break;

                case 4:
                    poder[3] = 1;
                    break;

                case 5:
                    poder[3] = 2;
                    break;

                case 6:
                    poder[3] = 2;
                    break;

                case 7:
                    poder[3] = 2;
                    break;

                case 8:
                    poder[3] = 2;
                    break;

                case 9:
                    poder[3] = 3;
                    break;

                case 10:
                    poder[3] = 3;
                    break;

                case 11:
                    poder[3] = 3;
                    break;

                case 12:
                    poder[3] = 3;
                    break;

                case 13:
                    poder[3] = 4;
                    break;

                case 14:
                    poder[3] = 4;
                    break;

                case 15:
                    poder[3] = 4;
                    break;

                case 16:
                    poder[3] = 4;
                    break;

                case 17:
                    poder[3] = 5;
                    break;

                case 18:
                    poder[3] = 5;
                    break;

                case 19:
                    poder[3] = 5;
                    break;

                case 20:
                    poder[3] = 5;
                    break;

                case 21:
                    poder[3] = 6;
                    break;

                case 22:
                    poder[3] = 6;
                    break;

                case 23:
                    poder[3] = 6;
                    break;

                case 24:
                    poder[3] = 6;
                    break;

                case 25:
                    poder[3] = 7;
                    break;

                case 26:
                    poder[3] = 7;
                    break;

                case 27:
                    poder[3] = 7;
                    break;

                case 28:
                    poder[3] = 7;
                    break;

                case 29:
                    poder[3] = 8;
                    break;

                case 30:
                    poder[3] = 8;
                    break;

                case 31:
                    poder[3] = 8;
                    break;

                case 32:
                    poder[3] = 8;
                    break;

                case 33:
                    poder[3] = 9;
                    break;

                case 34:
                    poder[3] = 9;
                    break;

                case 35:
                    poder[3] = 9;
                    break;

                case 36:
                    poder[3] = 9;
                    break;

                case 37:
                    poder[3] = 10;
                    break;

                case 38:
                    poder[3] = 10;
                    break;

                case 39:
                    poder[3] = 10;
                    break;

                case 40:
                    poder[3] = 10;
                    break;
            }

            switch (cartas[5])
            {
                case 1:
                    poder[4] = 1;
                    break;

                case 2:
                    poder[4] = 1;
                    break;

                case 3:
                    poder[4] = 1;
                    break;

                case 4:
                    poder[4] = 1;
                    break;

                case 5:
                    poder[4] = 2;
                    break;

                case 6:
                    poder[4] = 2;
                    break;

                case 7:
                    poder[4] = 2;
                    break;

                case 8:
                    poder[4] = 2;
                    break;

                case 9:
                    poder[4] = 3;
                    break;

                case 10:
                    poder[4] = 3;
                    break;

                case 11:
                    poder[4] = 3;
                    break;

                case 12:
                    poder[4] = 3;
                    break;

                case 13:
                    poder[4] = 4;
                    break;

                case 14:
                    poder[4] = 4;
                    break;

                case 15:
                    poder[4] = 4;
                    break;

                case 16:
                    poder[4] = 4;
                    break;

                case 17:
                    poder[4] = 5;
                    break;

                case 18:
                    poder[4] = 5;
                    break;

                case 19:
                    poder[4] = 5;
                    break;

                case 20:
                    poder[4] = 5;
                    break;

                case 21:
                    poder[4] = 6;
                    break;

                case 22:
                    poder[4] = 6;
                    break;

                case 23:
                    poder[4] = 6;
                    break;

                case 24:
                    poder[4] = 6;
                    break;

                case 25:
                    poder[4] = 7;
                    break;

                case 26:
                    poder[4] = 7;
                    break;

                case 27:
                    poder[4] = 7;
                    break;

                case 28:
                    poder[4] = 7;
                    break;

                case 29:
                    poder[4] = 8;
                    break;

                case 30:
                    poder[4] = 8;
                    break;

                case 31:
                    poder[4] = 8;
                    break;

                case 32:
                    poder[4] = 8;
                    break;

                case 33:
                    poder[4] = 9;
                    break;

                case 34:
                    poder[4] = 9;
                    break;

                case 35:
                    poder[4] = 9;
                    break;

                case 36:
                    poder[4] = 9;
                    break;

                case 37:
                    poder[4] = 10;
                    break;

                case 38:
                    poder[4] = 10;
                    break;

                case 39:
                    poder[4] = 10;
                    break;

                case 40:
                    poder[4] = 10;
                    break;
            }

            switch (cartas[6])
            {
                case 1:
                    poder[5] = 1;
                    break;

                case 2:
                    poder[5] = 1;
                    break;

                case 3:
                    poder[5] = 1;
                    break;

                case 4:
                    poder[5] = 1;
                    break;

                case 5:
                    poder[5] = 2;
                    break;

                case 6:
                    poder[5] = 2;
                    break;

                case 7:
                    poder[5] = 2;
                    break;

                case 8:
                    poder[5] = 2;
                    break;

                case 9:
                    poder[5] = 3;
                    break;

                case 10:
                    poder[5] = 3;
                    break;

                case 11:
                    poder[5] = 3;
                    break;

                case 12:
                    poder[5] = 3;
                    break;

                case 13:
                    poder[5] = 4;
                    break;

                case 14:
                    poder[5] = 4;
                    break;

                case 15:
                    poder[5] = 4;
                    break;

                case 16:
                    poder[5] = 4;
                    break;

                case 17:
                    poder[5] = 5;
                    break;

                case 18:
                    poder[5] = 5;
                    break;

                case 19:
                    poder[5] = 5;
                    break;

                case 20:
                    poder[5] = 5;
                    break;

                case 21:
                    poder[5] = 6;
                    break;

                case 22:
                    poder[5] = 6;
                    break;

                case 23:
                    poder[5] = 6;
                    break;

                case 24:
                    poder[5] = 6;
                    break;

                case 25:
                    poder[5] = 7;
                    break;

                case 26:
                    poder[5] = 7;
                    break;

                case 27:
                    poder[5] = 7;
                    break;

                case 28:
                    poder[5] = 7;
                    break;

                case 29:
                    poder[5] = 8;
                    break;

                case 30:
                    poder[5] = 8;
                    break;

                case 31:
                    poder[5] = 8;
                    break;

                case 32:
                    poder[5] = 8;
                    break;

                case 33:
                    poder[5] = 9;
                    break;

                case 34:
                    poder[5] = 9;
                    break;

                case 35:
                    poder[5] = 9;
                    break;

                case 36:
                    poder[5] = 9;
                    break;

                case 37:
                    poder[5] = 10;
                    break;

                case 38:
                    poder[5] = 10;
                    break;

                case 39:
                    poder[5] = 10;
                    break;

                case 40:
                    poder[5] = 10;
                    break;
            }
        }

        public void tabelaPoder()
        {
            for (int i = 0; i < 6; i++)
            {
                if (coluna[i + 1] == coluna[0] + 1)
                {
                    switch (linha[i + 1])
                    {
                        case 0:
                            poder[i] = 11;
                            break;

                        case 1:
                            poder[i] = 12;
                            break;

                        case 2:
                            poder[i] = 13;
                            break;

                        case 3:
                            poder[i] = 14;
                            break;
                    }
                }

                else if (coluna[0] == 9 && coluna[i + 1] == 0)
                {
                    switch (linha[i + 1])
                    {
                        case 0:
                            poder[i] = 11;
                            break;

                        case 1:
                            poder[i] = 12;
                            break;

                        case 2:
                            poder[i] = 13;
                            break;

                        case 3:
                            poder[i] = 14;
                            break;
                    }
                }
            }
        }

        public void deixarVisivel()
        {
            pctMao1.Visible = true;
            pctMao2.Visible = true;
            pctMao3.Visible = true;

            pctSelecionaCarta.Visible = true;

            btnJogar.Visible = true;
            btnCorrer.Visible = true;
            btnTruco.Visible = true;

            btnTruco.Image = Resources.Truco2;

            btnJogar.Enabled = false;
            btnTruco.Enabled = true;
            btnEsconder.Enabled = false;
            btnEsconder.Visible = false;

            rdbSua1.Enabled = true;
            rdbSua2.Enabled = true;
            rdbSua3.Enabled = true;

            rdbSua1.Checked = false;
            rdbSua2.Checked = false;
            rdbSua3.Checked = false;

            rdbSua1.Visible = true;
            rdbSua2.Visible = true;
            rdbSua3.Visible = true;

            pctCarta4.Visible = true;
            pctCarta5.Visible = true;
            pctCarta6.Visible = true;

            pctDeleJogada.Visible = false;
            pctDeleJogada.Visible = false;

            if (pontosE == 11 || pontosV == 11)
            {
                btnTruco.Enabled = false;
                btnTruco.Visible = false;
            }
        }

        public void inimigoTruco()
        {
            trucoPedir = rnd.Next(1,11);

            if (trucoPedir == 1)
            {
                pedir3();
            }
        }

        public void saberTruco()
        {
            if(imgTruco == 0 || imgTruco == 1 || imgTruco == 2)
            {
                trucoAceitar = rnd.Next(1, 4);
            }

            else if(imgTruco == 3)
            {
                trucoAceitar = rnd.Next(1, 3);
            }

            if (imgTruco == 0)
            {
                switch (trucoAceitar)
                {
                    case 1:
                        valendoTruco(3);
                        break;
                    case 2:
                        pedir6();
                        break;
                    case 3:
                        eleCorrerTruco(0);
                        break;
                }
            }
            
            else if(imgTruco == 1)
            {
                switch (trucoAceitar)
                {
                    case 1:
                        valendoTruco(6);
                        break;
                    case 2:
                        pedir9();
                        break;
                    case 3:
                        eleCorrerTruco(3);
                        break;
                }
            }

            else if (imgTruco == 2)
            {
                switch (trucoAceitar)
                {
                    case 1:
                        valendoTruco(9);
                        break;
                    case 2:
                        pedir12();
                        break;
                    case 3:
                        eleCorrerTruco(6);
                        break;
                }
            }

            else if (imgTruco == 3)
            {
                switch (trucoAceitar)
                {
                    case 1:
                        valendoTruco(12);
                        break;
                    case 2:
                        eleCorrerTruco(9);
                        break;
                }
            }
        }

        private void tmrCartas_Tick(object sender, EventArgs e)
        {
            cont++;
            
            switch (cont)
            {
                case 1:
                    engine.Play2D(Application.StartupPath + "\\sons\\cardSlide1.wav");
                    rdbSua1.Visible = true;
                    break;
                case 2:
                    engine.Play2D(Application.StartupPath + "\\sons\\cardSlide2.wav");
                    rdbSua2.Visible = true;
                    break;
                case 3:
                    engine.Play2D(Application.StartupPath + "\\sons\\cardSlide3.wav");
                    rdbSua3.Visible = true;
                    break;
                case 4:
                    engine.Play2D(Application.StartupPath + "\\sons\\cardSlide4.wav");
                    pctCarta4.Visible = true;
                    break;
                case 5:
                    engine.Play2D(Application.StartupPath + "\\sons\\cardSlide5.wav");
                    pctCarta5 .Visible = true;
                    break;
                case 6:
                    engine.Play2D(Application.StartupPath + "\\sons\\cardSlide6.wav");
                    pctCarta6.Visible = true;
                    break;
                case 7:
                    engine.Play2D(Application.StartupPath + "\\sons\\cardSlide7.wav");
                    pctCarta0.Visible = true;
                    pctVira.Visible = true;
                    break;
                case 8:
                    tmrCartas.Stop();
                    deixarVisivel();
                    comecoDeRodada();

                    if (pontosE == 11 || pontosV == 11)
                    {
                        objInicio.sp.Stop();
                        engine.Play2D(Application.StartupPath + ("\\sons\\mao11.wav"), true);

                        if (pontosE != pontosV)
                        {
                            maoDe11(3);
                        }
                    }
                    break;
            }
        }

        public void mostrarPontos()
        {
            switch (pontosV)
            {
                case 0:
                    pctPontosV.Image = Resources.V0;
                    break;

                case 1:
                    pctPontosV.Image = Resources.V1;
                    break;

                case 2:
                    pctPontosV.Image = Resources.V2;
                    break;

                case 3:
                    pctPontosV.Image = Resources.V3;
                    break;

                case 4:
                    pctPontosV.Image = Resources.V4;
                    break;

                case 5:
                    pctPontosV.Image = Resources.V5;
                    break;

                case 6:
                    pctPontosV.Image = Resources.V6;
                    break;

                case 7:
                    pctPontosV.Image = Resources.V7;
                    break;

                case 8:
                    pctPontosV.Image = Resources.V8;
                    break;

                case 9:
                    pctPontosV.Image = Resources.V9;
                    break;

                case 10:
                    pctPontosV.Image = Resources.V10;
                    break;

                case 11:
                    pctPontosV.Image = Resources.V11;
                    break;

                case 12:
                    pctPontosV.Image = Resources.V12;
                    break;
            }

            switch (pontosE)
            {
                case 0:
                    pctPontosE.Image = Resources.E0;
                    break;

                case 1:
                    pctPontosE.Image = Resources.E1;
                    break;

                case 2:
                    pctPontosE.Image = Resources.E2;
                    break;

                case 3:
                    pctPontosE.Image = Resources.E3;
                    break;

                case 4:
                    pctPontosE.Image = Resources.E4;
                    break;

                case 5:
                    pctPontosE.Image = Resources.E5;
                    break;

                case 6:
                    pctPontosE.Image = Resources.E6;
                    break;

                case 7:
                    pctPontosE.Image = Resources.E7;
                    break;

                case 8:
                    pctPontosE.Image = Resources.E8;
                    break;

                case 9:
                    pctPontosE.Image = Resources.E9;
                    break;

                case 10:
                    pctPontosE.Image = Resources.E10;
                    break;

                case 11:
                    pctPontosE.Image = Resources.E11;
                    break;

                case 12:
                    pctPontosE.Image = Resources.E12;
                    break;
            }

        }

        public void valendoTruco(int truco)
        {
            MessageBox.Show("Seu Oponente Aceitou o Truco!");
            adicional = truco;
            btnTruco.Enabled = false;
            btnTruco.Visible = false;
        }

        public void maoDeFerro(Boolean maoDeFerro)
        {
            if (maoDeFerro == true)
            {
                rdbSua1.Image = Resources.virada;
                rdbSua2.Image = Resources.virada;
                rdbSua3.Image = Resources.virada;
            }
        }

        public void maoDe11(int truco)
        {
            MessageBox.Show("Mão de 11!");
            adicional = truco;
            btnTruco.Enabled = false;
            btnTruco.Visible = false;
        }
        
        public void pedir3()
        {
            objTruco3.ShowDialog();
            adicional = objTruco3.adicional;

            if(objTruco3.aceitou == true)
            {
                btnTruco.Image = Resources.Pedir_6;
                imgTruco = 1;
                
            }

            else if(objTruco3.aceitou == false)
            {
                rodadaD = 2;
                verificarFimRodada();
            }
        }

        public void pedir6()
        {
            objTruco6.ShowDialog();
            adicional = objTruco6.adicional;

            if (objTruco6.aceitou == true)
            {
                btnTruco.Image = Resources.Pedir_9;
                imgTruco = 2;
            }

            else if (objTruco6.aceitou == false)
            {
                rodadaD = 2;
                verificarFimRodada();
            }
        }

        public void pedir9()
        {
            objTruco9.ShowDialog();
            adicional = objTruco9.adicional;

            if (objTruco9.aceitou == true)
            {
                btnTruco.Image = Resources.Pedir_12;
                imgTruco = 3;
            }

            else if (objTruco9.aceitou == false)
            {
                rodadaD = 2;
                verificarFimRodada();
            }
        }

        public void pedir12()
        {
            objTruco12.ShowDialog();
            btnTruco.Enabled = false;
            btnTruco.Visible = false;
            adicional = objTruco12.adicional;

            if (objTruco12.aceitou == false)
            {
                rodadaD = 2;
                verificarFimRodada();
            }
        }

        public void eleCorrerTruco(int adicionalTruco)
        {
            MessageBox.Show("Ele Correu!");
            rodadaS = 2;
            adicional = adicionalTruco;
            verificarFimRodada();
        }

        public void moverCartas()
        {
            engine.Play2D(Application.StartupPath + "\\sons\\cardSlide8.wav");
            if (rdbSua1.Checked == true)
            {
                if(esconder == true)
                {
                    esconder = false;
                    rdbSua1.Visible = false;
                    rdbSua1.Enabled = false;
                    pctSuaJogada.Image = Resources.virada;
                    jogadaS = 1;
                    poder[0] = 0;
                }

                else
                {
                    rdbSua1.Visible = false;
                    rdbSua1.Enabled = false;
                    pctSuaJogada.Image = rdbSua1.BackgroundImage;
                    jogadaS = 1;
                }
                
            }

            else if (rdbSua2.Checked == true)
            {
                if (esconder == true)
                {
                    esconder = false;
                    rdbSua2.Visible = false;
                    rdbSua2.Enabled = false;
                    pctSuaJogada.Image = Resources.virada;
                    jogadaS = 2;
                    poder[1] = 0;
                }

                else
                {
                    rdbSua2.Visible = false;
                    rdbSua2.Enabled = false;
                    pctSuaJogada.Image = rdbSua2.BackgroundImage;
                    jogadaS = 2;
                }
            }

            else if (rdbSua3.Checked == true)
            {
                if (esconder == true)
                {
                    esconder = false;
                    rdbSua3.Visible = false;
                    rdbSua3.Enabled = false;
                    pctSuaJogada.Image = Resources.virada;
                    jogadaS = 3;
                    poder[2] = 0;
                }

                else
                {
                    rdbSua3.Visible = false;
                    rdbSua3.Enabled = false;
                    pctSuaJogada.Image = rdbSua3.BackgroundImage;
                    jogadaS = 3;
                }
            }


            pctDeleJogada.Visible = true;
            pctSuaJogada.Visible = true;
        }

        public void moverCartasDele()
        {
            engine.Play2D(Application.StartupPath + "\\sons\\cardSlide8.wav");
            switch (jogadaD[rodada - 1])
            {
                case 3:
                    switch (cartas[4])
                    {
                        case 1:
                            pctDeleJogada.Image = Resources._4O;
                            break;

                        case 2:
                            pctDeleJogada.Image = Resources._4E;
                            break;

                        case 3:
                            pctDeleJogada.Image = Resources._4C;
                            break;

                        case 4:
                            pctDeleJogada.Image = Resources._4P;
                            break;

                        case 5:
                            pctDeleJogada.Image = Resources._5O;
                            break;

                        case 6:
                            pctDeleJogada.Image = Resources._5E;
                            break;

                        case 7:
                            pctDeleJogada.Image = Resources._5C;
                            break;

                        case 8:
                            pctDeleJogada.Image = Resources._5P;
                            break;

                        case 9:
                            pctDeleJogada.Image = Resources._6O;
                            break;

                        case 10:
                            pctDeleJogada.Image = Resources._6E;
                            break;

                        case 11:
                            pctDeleJogada.Image = Resources._6C;
                            break;

                        case 12:
                            pctDeleJogada.Image = Resources._6P;
                            break;

                        case 13:
                            pctDeleJogada.Image = Resources._7O;
                            break;

                        case 14:
                            pctDeleJogada.Image = Resources._7E;
                            break;

                        case 15:
                            pctDeleJogada.Image = Resources._7C;
                            break;

                        case 16:
                            pctDeleJogada.Image = Resources._7P;
                            break;

                        case 17:
                            pctDeleJogada.Image = Resources.QO;
                            break;

                        case 18:
                            pctDeleJogada.Image = Resources.QE;
                            break;

                        case 19:
                            pctDeleJogada.Image = Resources.QC;
                            break;

                        case 20:
                            pctDeleJogada.Image = Resources.QP;
                            break;

                        case 21:
                            pctDeleJogada.Image = Resources.JO;
                            break;

                        case 22:
                            pctDeleJogada.Image = Resources.JE;
                            break;

                        case 23:
                            pctDeleJogada.Image = Resources.JC;
                            break;

                        case 24:
                            pctDeleJogada.Image = Resources.JP;
                            break;

                        case 25:
                            pctDeleJogada.Image = Resources.KO;
                            break;

                        case 26:
                            pctDeleJogada.Image = Resources.KE;
                            break;

                        case 27:
                            pctDeleJogada.Image = Resources.KC;
                            break;

                        case 28:
                            pctDeleJogada.Image = Resources.KP;
                            break;

                        case 29:
                            pctDeleJogada.Image = Resources.AO;
                            break;

                        case 30:
                            pctDeleJogada.Image = Resources.AE;
                            break;

                        case 31:
                            pctDeleJogada.Image = Resources.AC;
                            break;

                        case 32:
                            pctDeleJogada.Image = Resources.AP;
                            break;

                        case 33:
                            pctDeleJogada.Image = Resources._2O;
                            break;

                        case 34:
                            pctDeleJogada.Image = Resources._2E;
                            break;

                        case 35:
                            pctDeleJogada.Image = Resources._2C;
                            break;

                        case 36:
                            pctDeleJogada.Image = Resources._2P;
                            break;

                        case 37:
                            pctDeleJogada.Image = Resources._3O;
                            break;

                        case 38:
                            pctDeleJogada.Image = Resources._3E;
                            break;

                        case 39:
                            pctDeleJogada.Image = Resources._3C;
                            break;

                        case 40:
                            pctDeleJogada.Image = Resources._3P;
                            break;
                    }

                    pctCarta4.Visible = false;
                    break;

                case 4:
                    switch (cartas[5])
                    {
                        case 1:
                            pctDeleJogada.Image = Resources._4O;
                            break;

                        case 2:
                            pctDeleJogada.Image = Resources._4E;
                            break;

                        case 3:
                            pctDeleJogada.Image = Resources._4C;
                            break;

                        case 4:
                            pctDeleJogada.Image = Resources._4P;
                            break;

                        case 5:
                            pctDeleJogada.Image = Resources._5O;
                            break;

                        case 6:
                            pctDeleJogada.Image = Resources._5E;
                            break;

                        case 7:
                            pctDeleJogada.Image = Resources._5C;
                            break;

                        case 8:
                            pctDeleJogada.Image = Resources._5P;
                            break;

                        case 9:
                            pctDeleJogada.Image = Resources._6O;
                            break;

                        case 10:
                            pctDeleJogada.Image = Resources._6E;
                            break;

                        case 11:
                            pctDeleJogada.Image = Resources._6C;
                            break;

                        case 12:
                            pctDeleJogada.Image = Resources._6P;
                            break;

                        case 13:
                            pctDeleJogada.Image = Resources._7O;
                            break;

                        case 14:
                            pctDeleJogada.Image = Resources._7E;
                            break;

                        case 15:
                            pctDeleJogada.Image = Resources._7C;
                            break;

                        case 16:
                            pctDeleJogada.Image = Resources._7P;
                            break;

                        case 17:
                            pctDeleJogada.Image = Resources.QO;
                            break;

                        case 18:
                            pctDeleJogada.Image = Resources.QE;
                            break;

                        case 19:
                            pctDeleJogada.Image = Resources.QC;
                            break;

                        case 20:
                            pctDeleJogada.Image = Resources.QP;
                            break;

                        case 21:
                            pctDeleJogada.Image = Resources.JO;
                            break;

                        case 22:
                            pctDeleJogada.Image = Resources.JE;
                            break;

                        case 23:
                            pctDeleJogada.Image = Resources.JC;
                            break;

                        case 24:
                            pctDeleJogada.Image = Resources.JP;
                            break;

                        case 25:
                            pctDeleJogada.Image = Resources.KO;
                            break;

                        case 26:
                            pctDeleJogada.Image = Resources.KE;
                            break;

                        case 27:
                            pctDeleJogada.Image = Resources.KC;
                            break;

                        case 28:
                            pctDeleJogada.Image = Resources.KP;
                            break;

                        case 29:
                            pctDeleJogada.Image = Resources.AO;
                            break;

                        case 30:
                            pctDeleJogada.Image = Resources.AE;
                            break;

                        case 31:
                            pctDeleJogada.Image = Resources.AC;
                            break;

                        case 32:
                            pctDeleJogada.Image = Resources.AP;
                            break;

                        case 33:
                            pctDeleJogada.Image = Resources._2O;
                            break;

                        case 34:
                            pctDeleJogada.Image = Resources._2E;
                            break;

                        case 35:
                            pctDeleJogada.Image = Resources._2C;
                            break;

                        case 36:
                            pctDeleJogada.Image = Resources._2P;
                            break;

                        case 37:
                            pctDeleJogada.Image = Resources._3O;
                            break;

                        case 38:
                            pctDeleJogada.Image = Resources._3E;
                            break;

                        case 39:
                            pctDeleJogada.Image = Resources._3C;
                            break;

                        case 40:
                            pctDeleJogada.Image = Resources._3P;
                            break;
                    }

                    pctCarta5.Visible = false;
                    break;

                case 5:
                    switch (cartas[6])
                    {
                        case 1:
                            pctDeleJogada.Image = Resources._4O;
                            break;

                        case 2:
                            pctDeleJogada.Image = Resources._4E;
                            break;

                        case 3:
                            pctDeleJogada.Image = Resources._4C;
                            break;

                        case 4:
                            pctDeleJogada.Image = Resources._4P;
                            break;

                        case 5:
                            pctDeleJogada.Image = Resources._5O;
                            break;

                        case 6:
                            pctDeleJogada.Image = Resources._5E;
                            break;

                        case 7:
                            pctDeleJogada.Image = Resources._5C;
                            break;

                        case 8:
                            pctDeleJogada.Image = Resources._5P;
                            break;

                        case 9:
                            pctDeleJogada.Image = Resources._6O;
                            break;

                        case 10:
                            pctDeleJogada.Image = Resources._6E;
                            break;

                        case 11:
                            pctDeleJogada.Image = Resources._6C;
                            break;

                        case 12:
                            pctDeleJogada.Image = Resources._6P;
                            break;

                        case 13:
                            pctDeleJogada.Image = Resources._7O;
                            break;

                        case 14:
                            pctDeleJogada.Image = Resources._7E;
                            break;

                        case 15:
                            pctDeleJogada.Image = Resources._7C;
                            break;

                        case 16:
                            pctDeleJogada.Image = Resources._7P;
                            break;

                        case 17:
                            pctDeleJogada.Image = Resources.QO;
                            break;

                        case 18:
                            pctDeleJogada.Image = Resources.QE;
                            break;

                        case 19:
                            pctDeleJogada.Image = Resources.QC;
                            break;

                        case 20:
                            pctDeleJogada.Image = Resources.QP;
                            break;

                        case 21:
                            pctDeleJogada.Image = Resources.JO;
                            break;

                        case 22:
                            pctDeleJogada.Image = Resources.JE;
                            break;

                        case 23:
                            pctDeleJogada.Image = Resources.JC;
                            break;

                        case 24:
                            pctDeleJogada.Image = Resources.JP;
                            break;

                        case 25:
                            pctDeleJogada.Image = Resources.KO;
                            break;

                        case 26:
                            pctDeleJogada.Image = Resources.KE;
                            break;

                        case 27:
                            pctDeleJogada.Image = Resources.KC;
                            break;

                        case 28:
                            pctDeleJogada.Image = Resources.KP;
                            break;

                        case 29:
                            pctDeleJogada.Image = Resources.AO;
                            break;

                        case 30:
                            pctDeleJogada.Image = Resources.AE;
                            break;

                        case 31:
                            pctDeleJogada.Image = Resources.AC;
                            break;

                        case 32:
                            pctDeleJogada.Image = Resources.AP;
                            break;

                        case 33:
                            pctDeleJogada.Image = Resources._2O;
                            break;

                        case 34:
                            pctDeleJogada.Image = Resources._2E;
                            break;

                        case 35:
                            pctDeleJogada.Image = Resources._2C;
                            break;

                        case 36:
                            pctDeleJogada.Image = Resources._2P;
                            break;

                        case 37:
                            pctDeleJogada.Image = Resources._3O;
                            break;

                        case 38:
                            pctDeleJogada.Image = Resources._3E;
                            break;

                        case 39:
                            pctDeleJogada.Image = Resources._3C;
                            break;

                        case 40:
                            pctDeleJogada.Image = Resources._3P;
                            break;
                    }

                    pctCarta6.Visible = false;
                    break;
            }
        }

        public void quemFez()
        {
            switch (jogadaS)
            {
                case 1:
                    if (poder[0] > poder[jogadaD[rodada - 1]])
                    {
                        MessageBox.Show("Você Ganhou!");

                        eleFez = false;

                        if (rodada == 1)
                        {
                            pctPontos1.Image = Resources.Você1;
                        }

                        else if (rodada == 2)
                        {
                            pctPontos2.Image = Resources.Você1;
                        }

                        else if (rodada == 3)
                        {
                            pctPontos3.Image = Resources.Você1;
                        }
                        rodadaS++;
                    }

                    else if (poder[0] < poder[jogadaD[rodada - 1]])
                    {
                        MessageBox.Show("Você Perdeu!");

                        eleFez = true;

                        if (rodada == 1)
                        {
                            pctPontos1.Image = Resources.Ele1;
                        }

                        else if (rodada == 2)
                        {
                            pctPontos2.Image = Resources.Ele1;
                        }

                        else if (rodada == 3)
                        {
                            pctPontos3.Image = Resources.Ele1;
                        }

                        rodadaD++;
                    }

                    else if (poder[0] == poder[jogadaD[rodada - 1]])
                    {
                        MessageBox.Show("Empatou!");

                        if (rodada == 1)
                        {
                            pctPontos1.Image = Resources.Empaixou;
                        }

                        else if (rodada == 2)
                        {
                            pctPontos2.Image = Resources.Empaixou;
                        }

                        else if (rodada == 3)
                        {
                            pctPontos3.Image = Resources.Empaixou;
                        }

                        if (rodadaS > rodadaD)
                        {
                            rodadaS++;
                        }

                        else if (rodadaS < rodadaD)
                        {
                            rodadaS++;
                        }
                        
                        else if(rodadaS == rodadaD)
                        {
                            if(pctPontos1.Image == Resources.Você1)
                            {
                                rodadaS++;
                            }

                            else if(pctPontos1.Image == Resources.Ele1)
                            {
                                rodadaD++;
                            }

                            else
                            {
                                rodadaD++;
                                rodadaS++;
                            }
                        }
                    }
                    break;

                case 2:
                    if (poder[1] > poder[jogadaD[rodada - 1]])
                    {
                        MessageBox.Show("Você Ganhou!");

                        eleFez = false;

                        if (rodada == 1)
                        {
                            pctPontos1.Image = Resources.Você1;
                        }

                        else if (rodada == 2)
                        {
                            pctPontos2.Image = Resources.Você1;
                        }

                        else if (rodada == 3)
                        {
                            pctPontos3.Image = Resources.Você1;
                        }

                        rodadaS++;
                    }

                    else if (poder[1] < poder[jogadaD[rodada - 1]])
                    {
                        MessageBox.Show("Você Perdeu!");

                        eleFez = true;

                        if (rodada == 1)
                        {
                            pctPontos1.Image = Resources.Ele1;
                        }

                        else if (rodada == 2)
                        {
                            pctPontos2.Image = Resources.Ele1;
                        }

                        else if (rodada == 3)
                        {
                            pctPontos3.Image = Resources.Ele1;
                        }

                        rodadaD++;
                    }

                    else if (poder[1] == poder[jogadaD[rodada - 1]])
                    {
                        MessageBox.Show("Empatou!");

                        if (rodada == 1)
                        {
                            pctPontos1.Image = Resources.Empaixou;
                        }

                        else if (rodada == 2)
                        {
                            pctPontos2.Image = Resources.Empaixou;
                        }

                        else if (rodada == 3)
                        {
                            pctPontos3.Image = Resources.Empaixou;
                        }

                        rodadaS++;
                        rodadaD++;
                    }
                    break;

                case 3:
                    if (poder[2] > poder[jogadaD[rodada - 1]])
                    {
                        MessageBox.Show("Você Ganhou!");

                        eleFez = false;

                        if (rodada == 1)
                        {
                            pctPontos1.Image = Resources.Você1;
                        }

                        else if (rodada == 2)
                        {
                            pctPontos2.Image = Resources.Você1;
                        }

                        else if (rodada == 3)
                        {
                            pctPontos3.Image = Resources.Você1;
                        }

                        rodadaS++;

                    }

                    else if (poder[2] < poder[jogadaD[rodada - 1]])
                    {
                        MessageBox.Show("Você Perdeu!");

                        eleFez = true;

                        if (rodada == 1)
                        {
                            pctPontos1.Image = Resources.Ele1;
                        }

                        else if (rodada == 2)
                        {
                            pctPontos2.Image = Resources.Ele1;
                        }

                        else if (rodada == 3)
                        {
                            pctPontos3.Image = Resources.Ele1;
                        }

                        rodadaD++;
                    }

                    else if (poder[2] == poder[jogadaD[rodada - 1]])
                    {
                        MessageBox.Show("Empatou!");

                        if (rodada == 1)
                        {
                            pctPontos1.Image = Resources.Empaixou;
                        }

                        else if (rodada == 2)
                        {
                            pctPontos2.Image = Resources.Empaixou;
                        }

                        else if (rodada == 3)
                        {
                            pctPontos3.Image = Resources.Empaixou;
                        }

                        rodadaS++;
                        rodadaD++;
                    }
                    break;
            }
        }

        public void fimRodada()
        {
            rdbSua1.Checked = false;
            rdbSua2.Checked = false;
            rdbSua3.Checked = false;
            pctMao1.Visible = false;
            pctMao2.Visible = false;
            pctMao3.Visible = false;

            btnJogar.Enabled = false;
            btnEsconder.Enabled = false;

            pctSuaJogada.Visible = false;
            pctDeleJogada.Visible = false;
            rodada++;

            mostrarPontos();

            verificarFimJogo();
        }

        public void verificarFimRodada()
        {
            rdbSua1.Checked = false;
            rdbSua2.Checked = false;
            rdbSua3.Checked = false;
            pctMao1.Visible = false;
            pctMao2.Visible = false;
            pctMao3.Visible = false;

            btnJogar.Enabled = false;
            btnEsconder.Enabled = false;

            pctSuaJogada.Visible = false;
            pctDeleJogada.Visible = false;

            
                if (rodadaS == 2)
                {
                    MessageBox.Show("Você Ganhou esta Rodada!");

                     if (adicional > 0)
                     {
                        pontosV += adicional;
                        verificarFimJogo();
                        carregarJogo();
                     }

                    else
                    {
                        pontosV++;
                        verificarFimJogo();
                        carregarJogo();
                    }
                }

                else if (rodadaD == 2)
                {
                    MessageBox.Show("Você Perdeu esta Rodada!");
                    if (adicional > 0)
                    {
                        pontosE += adicional;
                        verificarFimJogo();
                        carregarJogo();
                    }

                    else
                    {
                        pontosE++;
                        verificarFimJogo();
                        carregarJogo();
                    }
                }

                 else
                {
                    comecoDeRodada();
                }
        }

        public void verificarFimJogo()
        {
            mostrarPontos();
            
            if(pontosE == 11 && pontosV == 11)
            {
                ferro = true;
            }

            if (pontosV >= 12)
            {
                MessageBox.Show("Você Ganhou o Jogo!\nObrigado por Jogar! - Feito por: Raphael Stefen Barreto");
                Hide();
                objInicio.ShowDialog();
                Close();
            }

            else if (pontosE >= 12)
            {
                MessageBox.Show("Você Perdeu o Jogo!\nObrigado por Jogar! - Feito por: Raphael Stefen Barreto");
                Hide();
                objInicio.ShowDialog();
                Close();
            }
        }
    }
}