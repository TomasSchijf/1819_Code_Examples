using System.Linq;
using System.Windows;

namespace _1819_12_Example_School
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
         * Controls scherm:
         * 1 DataGrid output -> dgStudents
         * 3 TextBox input-> txtFirstname, txtLastname, txtCourse
         * 1 Button -> btnSave
         * 1 ComboBox -> cbLastname
         */
        dcSchoolDataContext db = new dcSchoolDataContext();
        public MainWindow()
        {
            InitializeComponent();
            SetData();
        }

        void SetData()
        {
            // Datagrid aan data van tabel students koppelen
            dgStudents.ItemsSource = db.students.ToList();
            // Combobox vullen met data uit de tabel students
            cbLastname.ItemsSource = db.students.ToList();
            // De achternaam tonen in de ComboBox, kan ook in xaml met: DisplayMemberPath="lastname"
            cbLastname.DisplayMemberPath = "lastname";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Ingevoerde data ophalen
            string sFirstname = txtFirstname.Text;
            string sLastname = txtLastname.Text;
            string sCourse = txtCourse.Text;

            // Student aanmaken en gegevens zetten
            student myStudent = new student();
            myStudent.firstname = sFirstname;
            myStudent.lastname = sLastname;
            myStudent.course = sCourse;

            // Student klaarzetten om op te slaan in de database
            db.students.InsertOnSubmit(myStudent);
            // Voer de wijzigingen door op de database
            db.SubmitChanges();

            // Data opnieuw ophalen uit de database (de nieuwe student tonen)
            SetData();

            // User feedback en velden legen
            txtFirstname.Text = string.Empty;
            txtLastname.Text = string.Empty;
            txtCourse.Text = string.Empty;
            MessageBox.Show("De nieuwe student " + myStudent.firstname + " " + myStudent.lastname + " is succesvol opgeslagen!");
        }
    }
}
