using System;
using System.Windows;

/*
 * Controls scherm:
 * 2 TextBox input -> txtStart & txtEnd
 * 1 Button -> btnStart
 * 1 TextBox output -> txtOutput (multiline,dus: VerticalScrollBarVisibility="Visible")
 */

namespace _1819_12_CSharpP.H6
{
    /// <summary>
    /// Interaction logic for wOpdracht3.xaml
    /// </summary>
    public partial class wOpdracht3 : Window
    {
        public wOpdracht3()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            int iTeller = 0;
            int iEnd = 0;

            if (int.TryParse(txtStart.Text, out iTeller) &&
                int.TryParse(txtEnd.Text, out iEnd))
            {
                while (iTeller < iEnd)
                {
                    txtOutput.Text += iTeller + Environment.NewLine; //OF: + "\r\n"
                    iTeller++; //OF: iTeller += 1; //OF: iTeller = iTeller + 1;
                }
            }
        }
    }
}
