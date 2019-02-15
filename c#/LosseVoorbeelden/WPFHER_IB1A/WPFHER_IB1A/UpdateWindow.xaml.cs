using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFHER_IB1A
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        private DatabaseDataContext db;
        public UpdateWindow(DatabaseDataContext db2)
        {
            InitializeComponent();
            this.db = db2;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int iStudentnr = 0;
            if(Int32.TryParse(txtStudentnr.Text, out iStudentnr))
            {
                var stud = (from student in db.students
                           where student.studentnr == iStudentnr
                           select student).Single();
                stud.voornaam = txtVoornaam.Text;
                stud.achternaam = txtAchternaam.Text;
                stud.telefoon = txtTelefoon.Text;

                db.SubmitChanges();
            }
            this.Close();
        }
    }
}
