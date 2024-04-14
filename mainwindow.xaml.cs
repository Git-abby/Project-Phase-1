using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_Part_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Home(object sender, RoutedEventArgs e)
        {

        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            Student_Login login_form = new Student_Login();
            login_form.Show();
        }

        private void strt_quiz_Click(object sender, RoutedEventArgs e)
        {
        question start_quiz = new question();
            start_quiz.Show();

        }
    }
}