using System;
using System.Windows;

/*
 * Controls scherm:
 * 2 TextBox output -> txtGZL (voor opdracht 1) & txtGML (voor opdracht 2)
 */

namespace _1819_12_CSharpP.H6
{
    /// <summary>
    /// Interaction logic for wOpdracht1.xaml
    /// </summary>
    public partial class wOpdracht1 : Window
    {
        public wOpdracht1()
        {
            InitializeComponent();
            ExOpdracht1();
            ExOpdracht2();
        }

        void ExOpdracht1()
        {
            txtGZL.Text = "50\r\n";
            txtGZL.Text = txtGZL.Text + "51\r\n";
            txtGZL.Text += "52\r\n";
            txtGZL.Text += "53\r\n";
            txtGZL.Text += "54\r\n";
            txtGZL.Text += "55\r\n";
            txtGZL.Text += "56\r\n";
            txtGZL.Text += "57\r\n";
            txtGZL.Text += "58\r\n";
            txtGZL.Text += "59\r\n";
            txtGZL.Text += "60\r\n";
        }

        void ExOpdracht2()
        {
            int iTeller = 50;
            while (iTeller < 250)
            {
                txtGML.Text += iTeller + Environment.NewLine; //OF: + "\r\n"
                iTeller++; //OF: iTeller += 1; //OF: iTeller = iTeller + 1;
            }
        }
    }
}
