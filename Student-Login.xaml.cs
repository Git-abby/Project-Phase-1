using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;

namespace Project_Part_1
{
    /// <summary>
    /// Interaction logic for Student_Login.xaml
    /// </summary>
    public partial class Student_Login : Window
    {

        // Connection string using the provided SQL Server instance and database name
        private string connectionString = "Data Source=WEDNESDAY23\\SQLEXPRESS22;Initial Catalog=QuizDb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";


        public Student_Login()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

                 // Retrieve username and password from input fields
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Password;

            if (IsValidUser(username, password))
            {
                // If user is valid, navigate to the quiz window
                MainWindow mainWindow = new MainWindow(username);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                // If user is not valid, show alert box
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private bool IsValidUser(string username, string password)
        {
            bool isValid = false;

            try
            {
                // Open a connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Define SQL query to check if the user exists
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

                    // Create a command with parameters
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // Open the connection
                        connection.Open();

                        // Execute the command and get the result
                        int count = (int)command.ExecuteScalar();

                        // Check if user exists (count > 0)
                        isValid = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors (e.g., database connection error)
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return isValid;
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            student_registration student_Registration = new student_registration();
            student_Registration.Show();
            this.Close();
        }
    }
}
