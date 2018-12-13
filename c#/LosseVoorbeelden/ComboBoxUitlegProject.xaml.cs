using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace _1819_12_Example_School
{
    /// <summary>
    /// Interaction logic for wGroups.xaml
    /// </summary>
    public partial class wGroups : Window
    {
        /*
         * Controls scherm:
         * 2 DataGrid output -> dgGroups, dgStudents
         * 1 ComboBox filter -> cbGroupFilter
         * 1 ComboBox -> cbStudents
         * 2 TextBox input(add) -> txtFirstname, txtLastname
         * 1 ComboBox input(add) -> cbGroupStudentAdd
         * 1 Button save(add) -> btnAdd
         */
        dcSchoolDataContext db = new dcSchoolDataContext();
        public wGroups()
        {
            InitializeComponent();
            SetData();
        }

        private void SetData()
        {
            // DataGrid met overzicht van groepen vullen
            dgGroups.ItemsSource = db.groups.ToList();
            // DataGrid en ComboBox voor overzicht studenten vullen
            cbGroupFilter.ItemsSource = db.groups.ToList();
            cbGroupFilter.DisplayMemberPath = "name";
            dgStudents.ItemsSource = db.students.ToList();
            cbStudents.ItemsSource = db.students.ToList();
            cbStudents.DisplayMemberPath = "firstname";
            // ComboBox voor toevoegen van studenten vullen
            cbGroupStudentAdd.ItemsSource = db.groups.ToList();
            cbGroupStudentAdd.DisplayMemberPath = "name";
        }

        private void cbGroupFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Controle of er een groep is geselecteerd
            if (cbGroupFilter.SelectedItem != null)
            {
                // Geselecteerde groep uit ComboBox halen en opslaan in veriable
                group selGroup = (group)cbGroupFilter.SelectedItem;
                // Studenten filteren aan de hand van de geselecteerde groep
                List<student> myStudents = (
                    from s in db.students
                    where s.groupId == selGroup.id
                    select s).ToList();
                // ItemsSource van de DataGrid en ComboBox zetten aan de hand van de zojuist gemaakte lijst
                dgStudents.ItemsSource = myStudents;
                cbStudents.ItemsSource = myStudents;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Controle of er een groep is geselecteerd
            if (cbGroupStudentAdd.SelectedItem != null)
            {
                // Velden uitlezen en opslaan in variable
                string sFirstname = txtFirstname.Text;
                string sLastname = txtLastname.Text;
                group selGroup = (group) cbGroupStudentAdd.SelectedItem;

                // Nieuwe student aanmaken en vullen met de data uit de variable
                // LET OP: De foreign key (groupId)
                student myStudent = new student();
                myStudent.firstname = sFirstname;
                myStudent.lastname = sLastname;
                myStudent.groupId = selGroup.id;

                // Nieuwe student klaarzetten om op te slaan en opslaan
                db.students.InsertOnSubmit(myStudent);
                db.SubmitChanges();

                // Data in formulier refreshen
                SetData();

                // Velden legen
                txtFirstname.Text = string.Empty;
                txtLastname.Text = string.Empty;
                cbGroupStudentAdd.SelectedItem = null;
            }
        }
    }
}
