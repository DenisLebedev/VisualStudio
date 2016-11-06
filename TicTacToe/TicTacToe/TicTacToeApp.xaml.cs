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
        private bool winner = false;

        private TicTacGame game;

        //ALL possible combination to win ... 
        private int[,] winCombination = new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
        private string[] buttonState = new string[9];

        public TicTacToeApp()
        {
            InitializeComponent();
            playAgainBut.Visibility = Visibility.Hidden;
            //Initalize ALL 9 buttons from the game
            buttonArray = new Button[9] { but1, but2, but3, but4, but5, but6, but7, but8, but9 };


            //Default new game
            game = new TicTacGame("Hard",0,0,0);

            //Loading points on the board
            p1scorelabel.Content = game.PointPl1;
            p2scorelabel.Content = game.PointPl2;



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

            if (this.winner)
            {
                MessageBox.Show("Game Over Congratulation","For Dumb Only", MessageBoxButton.OK);
                return;
            }

            //9 turn were made and nobody won = tie
            if (game.Turn > 7)
            {
                playAgainBut.Visibility = Visibility.Visible;
                MessageBox.Show("The game is over and it a Tie!");
                return;
            }

            // if not empty the button has a content already: X or O
            if (tempButton.Content != "")    
            {
                MessageBox.Show("Button already has value!", "ERROR", MessageBoxButton.OK);
                return;
            }

            //IF we clic we increment Turn
            if (game.Turn != 9)
            {
                tempButton.Content = "X";
                game.nextTurn();

                //Saving state
                game.saveButtonState(buttonArray);

                this.winner = game.checkWinner();
                
                if (winner)
                {
                    Console.WriteLine("Human Won!");
                    game.addPointPl1();
                    addColor(buttonArray, game.getWinCombination);
                    playAgainBut.Visibility = Visibility.Visible;

                }
                else
                {

                    buttonArray = game.loadOnButtonState(buttonArray, IAHard.Play(game.getButtonState(), game.getWinCombination));
                    game.nextTurn();
                    //Saving state
                    game.saveButtonState(buttonArray);

                    //this.winner = checkWinner(this.buttonArray, winCombination);
                    this.winner = game.checkWinner();
                    if (winner)
                    {
                        MessageBox.Show("Only dumb can loose...", "MessageForDumb", MessageBoxButton.OK);
                        game.addPointPl2();
                        addColor(buttonArray, game.getWinCombination);
                        playAgainBut.Visibility = Visibility.Visible;

                    }
                }
            }


        }

        private static void addColor(Button [] buttonArray, int [,] winCombination)
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

                if ((but1.Content as string) == "" || (but2.Content as string) == "" || (but3.Content as string) == "") // if one if blank
                    continue;    // if they are empty that mean nothing happen this turn

                if (but1.Content == but2.Content && but2.Content == but3.Content)
                {
                    but1.Background = but2.Background = but3.Background = Brushes.Green; //Change the Color of the BackGroung
                    but1.FontFamily = but2.FontFamily = but3.FontFamily = new FontFamily("Arial Black"); //Change the Text of the winner

                    result = true;
                }
            }
                return;
        }

        private void removeColor(Button[] buttonArray, int[,] winCombination)
        {

            for (int i = 0; i < 8; i++)
            {
                int a = winCombination[i, 0];
                int b = winCombination[i, 1];
                int c = winCombination[i, 2];

                Button but1 = buttonArray[a];
                Button but2 = buttonArray[b];
                Button but3 = buttonArray[c];

                if (but1.Background == Brushes.Green && but2.Background == Brushes.Green && but3.Background == Brushes.Green) // if one if blank
                {
                    but1.Background = but2.Background = but3.Background = Brushes.LightGray;
                    but1.FontFamily = but2.FontFamily = but3.FontFamily = new FontFamily("Sans Serif");
                    return;    // if they are empty that mean nothing happen this turn
                }
            }
        }

        private void undobutton_Click(object sender, RoutedEventArgs e)
        {

          /*  String message = "Are you sure you want to undo your last move? Warning: You can only undo one move.";
            MessageBox.Show(message, "CONFIRMATION" , MessageBoxButton.OK);*/
        }

        private void playAgainBut_Click(object sender, RoutedEventArgs e)
        {
            playAgainBut.Visibility = Visibility.Hidden;

            removeColor(buttonArray, game.getWinCombination);
            game = new TicTacGame(game.IA,0,game.PointPl1, game.PointPl2);

            //game.getButtonState() is set to empty by the constructor!
            buttonArray = game.loadOnButtonState(buttonArray, game.getButtonState());

            p1scorelabel.Content = game.PointPl1;
            p2scorelabel.Content = game.PointPl2;

            this.winner = false;
        }
    }
}
