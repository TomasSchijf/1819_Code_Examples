using System.Linq;
using System.Windows;

namespace _1819_12_Example_School
{
    /// <summary>
    /// Interaction logic for wShowStudents.xaml
    /// </summary>
    public partial class wShowStudents : Window
    {
        dcSchoolDataContext db = new dcSchoolDataContext();
        public wShowStudents()
        {
            InitializeComponent();
            SetData();
        }

        private void SetData()
        {
            dgStudents.ItemsSource = db.students.ToList();
        }
    }
}
