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
        private string[] questions = {
    "1. Which of the following is a fundamental principle of object-oriented programming?",
    "2. What is the capital of France?",
    "3. What is the largest mammal?",
    "4. Who wrote 'To Kill a Mockingbird'?",
    "5. What does C# stand for?",
    "6. Which keyword is used to declare a method that does not return a value in C#?",
    "7. What is the base class for all WPF controls?",
    "8. What markup language is used to create user interfaces in WPF?",
    "9. What event is fired when a button is clicked in WPF?",
    "10. Which layout panel automatically arranges its children in a single line?",
};

        private string[][] options = {
    new string[] { "A) Encapsulation", "B) Procedural programming", "C) Functional programming", "D) Imperative programming" },
    new string[] { "A) London", "B) Paris", "C) Berlin", "D) Madrid" },
    new string[] { "A) Elephant", "B) Blue whale", "C) Giraffe", "D) Lion" },
    new string[] { "A) Harper Lee", "B) J.K. Rowling", "C) George Orwell", "D) Charles Dickens" },
    new string[] { "A) C Sharp", "B) Computer Sharp", "C) C Syntax", "D) None of the above" },
    new string[] { "A) void", "B) null", "C) return", "D) int" },
    new string[] { "A) Control", "B) FrameworkElement", "C) UIElement", "D) DependencyObject" },
    new string[] { "A) HTML", "B) XAML", "C) XML", "D) CSS" },
    new string[] { "A) Clicked", "B) Pressed", "C) MouseDown", "D) MouseClick" },
    new string[] { "A) StackPanel", "B) WrapPanel", "C) Grid", "D) DockPanel" },
};
        private string[] correctAnswers = { "A", "B", "B", "A", "A", "A", "B", "B", "A", "A" };
        private int score = 0;

        public question()
        {
            InitializeComponent();
            DisplayQuestion();
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
