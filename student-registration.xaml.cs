using Microsoft.Data.SqlClient;
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

namespace Project_Part_1
{
    /// <summary>
    /// Interaction logic for student_registration.xaml
    /// </summary>
    public partial class student_registration : Window
    {
        private string connectionString = "Data Source=WEDNESDAY23\\SQLEXPRESS22;Initial Catalog=QuizDb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public student_registration()
        {
            InitializeComponent();
        }

        /*private void login_Click(object sender, RoutedEventArgs e)
        {

        }*/

        private void signup_Click(object sender, RoutedEventArgs e)
        {
            string sid = SidTextBox.Text;
            string name = NameTextBox.Text;
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;

            string query = "INSERT INTO Users (Sid, Name, Username, Password) VALUES (@Sid, @Name, @Username, @Password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Sid", sid);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Signup successful!");
                        MainWindow mainWindow = new MainWindow(username);
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Signup failed. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

       /* private void signup_Click(object sender, object e)
        {

        }*/
    }
}
