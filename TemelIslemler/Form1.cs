using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemelIslemler
{
    public partial class Form1 : Form
    {
        Graphics Cizgi;
        Pen klm = new Pen(Color.Red, 2);

        Double[,] EksenX = new double[2, 2] { { -9, 0 }, { 9, 0 } };
        Double[,] EksenY = new double[2, 2] { { 0, 7 }, { 0, -7 } };
        Double[,] ucgen = new double[3, 3] { { 2.0, 3.0, 1.0 }, { 7.0, 3.0, 1.0 }, { 2.0, 6.0, 1.0 } };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cizgi = this.CreateGraphics();
            griCizgiler();
            klm.Color = Color.Red;
            Cizgi.DrawLine(klm, KoordinatHesaplaX(EksenX[0, 0]), KoordinatHesaplaY(EksenX[0, 1]), KoordinatHesaplaX(EksenX[1, 0]), KoordinatHesaplaY(EksenX[1, 1]));
            Cizgi.DrawLine(klm, KoordinatHesaplaX(EksenY[0, 0]), KoordinatHesaplaY(EksenY[0, 1]), KoordinatHesaplaX(EksenY[1, 0]), KoordinatHesaplaY(EksenY[1, 1]));
            Cizgi.Dispose();

        }

        private void Ciz(Double[,] matris)
        {
            Cizgi = this.CreateGraphics();
            Cizgi.DrawPolygon(klm, new Point[3] { new Point(KoordinatHesaplaX(matris[0, 0]), KoordinatHesaplaY(matris[0, 1])), new Point(KoordinatHesaplaX(matris[1, 0]), KoordinatHesaplaY(matris[1, 1])), new Point(KoordinatHesaplaX(matris[2, 0]), KoordinatHesaplaY(matris[2, 1])) });
            Cizgi.Dispose();


        }

        private void griCizgiler()
        {
            klm.Color = Color.LightGray;
            for (int i = 0; i < 10; i++)
            {
                Cizgi.DrawLine(klm, KoordinatHesaplaX(10), KoordinatHesaplaY(i), KoordinatHesaplaX(0), KoordinatHesaplaY(i));
                Cizgi.DrawLine(klm, KoordinatHesaplaX(-10), KoordinatHesaplaY(i), KoordinatHesaplaX(0), KoordinatHesaplaY(i));
                Cizgi.DrawLine(klm, KoordinatHesaplaX(-10), KoordinatHesaplaY(-i), KoordinatHesaplaX(0), KoordinatHesaplaY(-i));
                Cizgi.DrawLine(klm, KoordinatHesaplaX(10), KoordinatHesaplaY(-i), KoordinatHesaplaX(0), KoordinatHesaplaY(-i));
            }

            for (int j = 0; j < 10; j++)
            {
                Cizgi.DrawLine(klm, KoordinatHesaplaX(j), KoordinatHesaplaY(10), KoordinatHesaplaX(j), KoordinatHesaplaY(0));
                Cizgi.DrawLine(klm, KoordinatHesaplaX(j), KoordinatHesaplaY(-10), KoordinatHesaplaX(j), KoordinatHesaplaY(0));
                Cizgi.DrawLine(klm, KoordinatHesaplaX(-j), KoordinatHesaplaY(-10), KoordinatHesaplaX(-j), KoordinatHesaplaY(0));
                Cizgi.DrawLine(klm, KoordinatHesaplaX(-j), KoordinatHesaplaY(10), KoordinatHesaplaX(-j), KoordinatHesaplaY(0));

            }
        }

        private int KoordinatHesaplaX(double geciciX)
        {
            return Convert.ToInt32(400 + 250 + 25 * geciciX);
        }

        private int KoordinatHesaplaY(double geciciY)
        {
            return Convert.ToInt32(250 - 25 * geciciY);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            klm.Color = Color.Green;
            Ciz(ucgen);
        }

        void degerAtama(double[,] degerMatrisi)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    degerMatrisi[i, j] = ucgen[i, j];
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Double[,] Gecici = new double[3, 3];

            degerAtama(Gecici);
            klm.Color = Color.Blue;
            Gecici[0, 1] = -1 * Gecici[0, 1];
            Gecici[1, 1] = -1 * Gecici[1, 1];
            Gecici[2, 1] = -1 * Gecici[2, 1];
            Ciz(Gecici);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Double teta = Convert.ToDouble(textBox1.Text);

            Double a = teta * Math.PI / 180;
            Double b = teta * Math.PI / 180;

            Double[,] dondur = { { Math.Cos(a), -Math.Sin(b), 0 }, { Math.Sin(b), Math.Cos(a), 0 }, { 0, 0, 1 } };

            int i, j, sayac;
            Double[,] Gecici = new double[3, 3];
            double deger;
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    deger = 0;

                    for (sayac = 0; sayac < 3; sayac++)
                    {
                        deger += ucgen[i, sayac] * dondur[sayac, j];
                    }
                    Gecici[i, j] = deger;
                }
            }

            klm.Color = Color.Orange;
            Ciz(Gecici);
        }

    }
}
