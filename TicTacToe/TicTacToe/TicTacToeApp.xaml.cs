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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for TicTacToeApp.xaml
    /// </summary>
    public partial class TicTacToeApp : Window
    {
        //Accessible button in the class ONLY
        private Button[] buttonArray;

        //Keep track of all turns (max 9)
        private short turn =0;
        private bool winner = false;
        private int pointPl1 = 0;
        private int pointPl2 = 0;

        //ALL possible combination to win ... 
        private int[,] winCombination = new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };

        public TicTacToeApp()
        {
            InitializeComponent();

            //Initalize ALL 9 buttons from the game
            buttonArray = new Button[9] { but1, but2, but3, but4, but5, but6, but7, but8, but9 };

            p1scorelabel.Content = pointPl1;
            p2scorelabel.Content = pointPl2;

            //redirect ALL buttons in a general method
            for (int i = 0; i < 9; i++)
            {
                buttonArray[i].Click += new RoutedEventHandler(ClickHandler);
            }
            
            
        }

        /**
         * ClickHanlder will capture all buttons instead of doing 9 iddferent button method
         * Then I will cast the sender to a Button which will represent the clicked button
         * With this information  I will assign an X or an Y depending the situation
         * or nothing.
         */
        private void ClickHandler(object sender, RoutedEventArgs e)
        {
            //the sender is the button that WAS clicked + it a safe cast
            Button tempButton = (Button)sender;

            IAEasy easy = new IAEasy();

            


            if (this.winner)
            {
                MessageBox.Show("Game Over Congratulation","ERROR", MessageBoxButton.OK);
                return;
            }


            //9 turn were made and nobody won = tie
            if (turn == 9)
            {
                MessageBox.Show("The game is over and it a Tie!");
                return;
            }

            // if not empty the button has a content already: X or O
            if (tempButton.Content != "")    
            {
                MessageBox.Show("Button already has value!", "ERROR", MessageBoxButton.OK);
                return;
            }

            //easy.Block(buttonArray, winCombination);

            if (turn % 2 == 0)
                tempButton.Content = "X";
            else
                tempButton.Content = "O";

            easy.Block(buttonArray, winCombination);

            //IF we clic we increment Turn
            if (turn != 9)
                turn++;

            //Console.WriteLine("Turn: " + turn);

            //Look if there is a winner after 5 turn only
            if (turn > 4)
                this.winner = checkWinner(this.buttonArray,winCombination);

        }

        private static bool checkWinner(Button [] buttonArray, int [,] winCombination)
        {
            bool result = false;

            //Loop looking for a Winner
            for (int i = 0; i < 8 && !result; i++)
            {
                int a = winCombination[i, 0];
                int b = winCombination[i, 1];
                int c = winCombination[i, 2];

                Button but1 = buttonArray[a];
                Button but2 = buttonArray[b];
                Button but3 = buttonArray[c];

                if (but1.Content == "" || but2.Content == "" || but3.Content == "") // if one if blank
                    continue;    // if they are empty that mean nothing happen this turn

                if (but1.Content == but2.Content && but2.Content == but3.Content)
                {
                    but1.Background = but2.Background = but3.Background = Brushes.Green; //Change the Color of the BackGroung
                    but1.FontFamily = but2.FontFamily = but3.FontFamily = new FontFamily("Arial Black"); //Change the Text of the winner

                    result = true;
                    //break;  // you won do not continue.
                }
            }
                return result;
        }

        private void undobutton_Click(object sender, RoutedEventArgs e)
        {

          /*  String message = "Are you sure you want to undo your last move? Warning: You can only undo one move.";
            MessageBox.Show(message, "CONFIRMATION" , MessageBoxButton.OK);*/
        }
    }
}
