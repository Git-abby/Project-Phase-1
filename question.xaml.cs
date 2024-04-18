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
    /// Interaction logic for question.xaml
    /// </summary>
    public partial class question : Window
    {
        private int currentQuestionIndex = 0;
        private string[] questions;
        private string[][] options;
        private string[] correctAnswers;
        private int score = 0;

        private string connectionString = "Data Source=WEDNESDAY23\\SQLEXPRESS22;Initial Catalog=QuizDb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";


        public question()
        {
            InitializeComponent();
            LoadQuestionsFromDatabase();
            DisplayQuestion();
        }
        private void LoadQuestionsFromDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Question, OptionA, OptionB, OptionC, OptionD, CorrectOption FROM Questions";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    // Initialize arrays based on the number of rows in the database
                    questions = new string[6];
                    options = new string[6][];
                    correctAnswers = new string[6];

                    int index = 0;
                    while (reader.Read() && index < 10)
                    {
                        questions[index] = reader.GetString(0);
                        options[index] = new string[] { reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4) };
                        correctAnswers[index] = reader.GetString(5);
                        index++;
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading questions from database: {ex.Message}");
                // You may want to handle this error gracefully
            }
        }
        private void DisplayQuestion()
        {
            if (currentQuestionIndex < questions.Length)
            {
                question1.Content = questions[currentQuestionIndex];
                op1.Content = options[currentQuestionIndex][0];
                op2.Content = options[currentQuestionIndex][1];
                op3.Content = options[currentQuestionIndex][2];
                op4.Content = options[currentQuestionIndex][3];
            }
            else
            {
                MessageBox.Show($"End of quiz! Your score: {score}/{questions.Length}");
            
            // Optionally, you can close the window or navigate to another page
            // Close();
        }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer();
            currentQuestionIndex++;
            if (currentQuestionIndex < questions.Length)
            {
                DisplayQuestion();
            }
            else
            {
                ScoreQuestions scoreWindow = new ScoreQuestions(score, questions.Length);
                scoreWindow.Show();
                Close(); // Close the current window after showing the score
            }
        }

        private void CheckAnswer()
        {
            string selectedOption = GetSelectedOption();
            if (selectedOption == correctAnswers[currentQuestionIndex])
            {
                score++;
            }
        }
        private string GetSelectedOption()
        {
            if (op1.IsChecked == true)
            {
                return "A";
            }
            else if (op2.IsChecked == true)
            {
                return "B";
            }
            else if (op3.IsChecked == true)
            {
                return "C";
            }
            else if (op4.IsChecked == true)
            {
                return "D";
            }
            else
            {
                return null;
            }
        }

        }
}
