using System;
using System.Windows;

/*
 * Controls scherm:
 * 2 TextBox input -> txtX & txtY
 * 1 Button -> btnStart
 * 1 TextBox output -> txtOutput (multiline,dus: VerticalScrollBarVisibility="Visible")
 */

namespace _1819_12_CSharpP.H6
{
    /// <summary>
    /// Interaction logic for wOpdracht6.xaml
    /// </summary>
    public partial class wOpdracht6 : Window
    {
        public wOpdracht6()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            // Output legen
            txtOutput.Text = string.Empty; // Of = txtOutput.Text = "";
            // Tekstboxen uitlezen en opslaan in variable
            int iGetalX = 0;
            int iGetalY = 0;
            // Controleren of er getallen ingevoerd zijn en omzetten naar int
            if (int.TryParse(txtX.Text, out iGetalX) &&
                int.TryParse(txtY.Text, out iGetalY))
            {
                // y om aantal loop bij te houden
                // iGetalY om max input van user te onthouden
                // 1ste for -> rijen onder elkaar
                for (int y = 1; y < iGetalY; y++)
                {
                    // iUitkomt aanmaken, gelijk aan het getal wat de gebruiker heeft ingevoerd
                    int iUitkomst = iGetalX;
                    // 2de for -> aantal getallen in rij
                    for (int i = 0; i <= y; i++)
                    {
                        // Controle of het laatste getal is, x of =
                        if (i < y)
                        {
                            // iUitkomst -> zichzelf keer ingevoerde getal
                            iUitkomst = iUitkomst * iGetalX;
                            txtOutput.Text += iGetalX + " x ";
                        }
                        else
                        {
                            // = teken tonen met daarachter onze uitgerekende iUitkomst
                            txtOutput.Text += iGetalX + " = " + iUitkomst;
                        }
                    }
                    txtOutput.Text += Environment.NewLine; // Of txtOutput.Text += "\r\n";
                }
            }
            else
            {
                MessageBox.Show("Vul alleen getallen in!");
            }
        }
    }
}
