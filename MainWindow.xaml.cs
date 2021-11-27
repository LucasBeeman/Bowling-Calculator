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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bowling_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int answerOne;
        int answerTwo;
        int answerThree;

        public MainWindow()
        {
            InitializeComponent();
        }

        //parses strings from user input to integers
        private void intigerParse()
        {
            try
            {
                answerOne = Int32.Parse(scoreOne.Text);
                answerTwo = Int32.Parse(scoreTwo.Text);
                answerThree = Int32.Parse(scoreThree.Text);
            }
            catch
            {
                answerOne = 0;
                answerTwo = 0;
                answerThree = 0;
            }
        }

        //displays data that the user has inputed in their progile
        private void profileDisplay()
        {
            userNameDisplay.Text = userName.Text;
            if (maleButton.IsChecked == true)
            {
                genderDisplay.Text = "Male";
            }
            else if (femaleButton.IsChecked == true)
            {
                genderDisplay.Text = "Female";
            }
            else
            {
                genderDisplay.Text = "Other";
            }

        }

        //adds and returns all of the scores of the games
        private int gameSum()
        {
            int scoreSum = answerOne + answerTwo + answerThree;
            finalScore.Text = scoreSum.ToString();
            return scoreSum;
        }

        //adds the average of all of the games
        private int gameAverage()
        {
            averageScore.Text = (gameSum() / 3).ToString();
            return gameSum() / 3;
        }

        //finds the highest game of the 3. If 2 games have the same score, it will output "tie"
        private void findHighScore()
        {
            if (answerOne > answerTwo && answerOne > answerThree)
            {
                highGame.Text = "1";
            }
            else if (answerTwo > answerOne && answerTwo > answerThree)
            {
                highGame.Text = "2";
            }
            else if (answerThree > answerOne && answerThree > answerTwo)
            {
                highGame.Text= "3";
            }
            else
            {
                highGame.Text = "Tie";
            }
        }

        //calculates all of the scores to create an average, high game, handicap, and total
        private void calculateBtn_Click(object sender, RoutedEventArgs e)
        {
            profileDisplay();
            intigerParse();
            gameSum();
            gameAverage();
            //finds the handicap using the formula "(200 - [game average]) * .8
            handicap.Text = ((200 - gameAverage()) * .8).ToString();
            findHighScore();
            //clears info that the user typed out
            userName.Text = "";
            maleButton.IsChecked = false;
            femaleButton.IsChecked = false;
            otherButton.IsChecked = false;
            scoreOne.Text = "";
            scoreTwo.Text = "";
            scoreThree.Text = "";
        }

        //clears all modified text & buttons
        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            userNameDisplay.Text = "";
            genderDisplay.Text = "";
            averageScore.Text = "";
            handicap.Text = "";
            highGame.Text = "";
            finalScore.Text = "";
            userName.Text = "";
            maleButton.IsChecked = false;
            femaleButton.IsChecked = false;
            otherButton.IsChecked = false;
            scoreOne.Text = "";
            scoreTwo.Text = "";
            scoreThree.Text = "";
        }

        //exits the program
        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
