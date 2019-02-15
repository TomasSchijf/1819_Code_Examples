using System;
using System.Collections.Generic;
using System.Data.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFHER_IB1A
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatabaseDataContext db = new DatabaseDataContext();
        public MainWindow()
        {
            InitializeComponent();

            setData();
           

        }
        public void setData()
        {
            dgStudenten.ItemsSource = db.students.ToList();
            cmbKlas.ItemsSource = db.klas.ToList();
        }

        private void BtnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            student deStudent = new student();
            deStudent.voornaam = txtVoornaam.Text;
            deStudent.achternaam = txtAchternaam.Text;
            deStudent.telefoon = txtTelefoon.Text;
            deStudent.klasId = ( (kla)cmbKlas.SelectedItem).Id;

            db.students.InsertOnSubmit(deStudent);
            db.SubmitChanges();

            setData();
        }

        private void DgStudenten_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           

            
            
        }

        private void HetRaam_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("gesloten");
            setData();
            
        }

        private void BtnWijzig_Click(object sender, RoutedEventArgs e)
        {
            UpdateWindow hetRaam = new UpdateWindow(db);
            var deStudent = (student)dgStudenten.SelectedItem;
            hetRaam.txtStudentnr.Text = deStudent.studentnr.ToString();
            hetRaam.txtVoornaam.Text = deStudent.voornaam;
            hetRaam.txtAchternaam.Text = deStudent.achternaam;
            hetRaam.txtTelefoon.Text = deStudent.telefoon;
            hetRaam.Closed += HetRaam_Closed;
            hetRaam.Show();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var r = MessageBox.Show("Weet u het zeker?", "Melding", MessageBoxButton.OKCancel);
            if (MessageBoxResult.OK == r)
            {
                //Selecteren van de student uit de datagrid
                var student = (student)dgStudenten.SelectedItem;
                //In de wachtrij zetten om verwijderd te worden
                db.students.DeleteOnSubmit(student);
                //De wachtrij afwerken en doorvoeren naar de database
                db.SubmitChanges();
                setData();
            }
        }
    }
}
