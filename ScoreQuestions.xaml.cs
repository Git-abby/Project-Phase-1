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
using static System.Formats.Asn1.AsnWriter;

namespace Project_Part_1
{
    /// <summary>
    /// Interaction logic for ScoreQuestions.xaml
    /// </summary>
    public partial class ScoreQuestions : Window
    {
        public ScoreQuestions(int score, int totalQuestions)
        {
            InitializeComponent();
            scoreLabel.Content += $"{score}/{totalQuestions}..!";

        }
    }
}
