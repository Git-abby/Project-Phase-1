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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Project_Part_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string username;

        public MainWindow(string username)
        {
            InitializeComponent();
            this.username = username;
            ShowUserName();
        }

        private void ShowUserName()
        {
            // Display the username in a label or any other UI element
            // For example:
            show_name.Content = "Welcome, " + username + "!";
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