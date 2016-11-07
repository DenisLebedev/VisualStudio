using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
     

        public TicTacToeApp(string ia, int pointPl1, int pointPl2, int draw)
        {
            InitializeComponent();
            playAgainBut.IsEnabled = false;
            //Initalize ALL 9 buttons from the game
            buttonArray = new Button[9] { but1, but2, but3, but4, but5, but6, but7, but8, but9 };


            //Default new game
            game = new TicTacGame(ia, pointPl1, pointPl2, draw);
           
            //Loading points on the board
            p1scorelabel.Content = game.PointPl1;
            p2scorelabel.Content = game.PointPl2;
            drawLabel.Content = game.Draw;

            displaylabel.Content = "You";

            //redirect ALL buttons in a general method
            for (int i = 0; i < 9; i++)
            {
                buttonArray[i].Click += new RoutedEventHandler(ClickHandler);
            }            
            
        }

        public TicTacToeApp(string ia, int pointPl1, int pointPl2, int draw, int turn, string[] savedBoard, string[] savedOldBoard)
        {

            InitializeComponent();
            buttonArray = new Button[9] { but1, but2, but3, but4, but5, but6, but7, but8, but9 };

            

            game = new TicTacGame(ia, pointPl1, pointPl2, draw, turn, savedBoard,savedOldBoard);
            p1scorelabel.Content = game.PointPl1;
            p2scorelabel.Content = game.PointPl2;
            drawLabel.Content = game.Draw;

            displaylabel.Content = "You";
            buttonArray = game.loadOnButtonState(buttonArray, game.getButtonState());

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

            // if not empty the button has a content already: X or O
            if (tempButton.Content as string != "")    
            {
                MessageBox.Show("Button already has value!", "ERROR", MessageBoxButton.OK);
                return;
            }

            //Keep track of the LAST turn for the undo
            if (game.Turn != 0)
            {
                game.trackOldState(game.getButtonState());
            }

            if (game.IA != "Human")
                playIA(tempButton);
            else
                playHuman(tempButton);

            //9 turn were made and nobody won = tie
            if (game.Turn > 8)
            {
                playAgainBut.IsEnabled = true;
                MessageBox.Show("The game is over and it a Tie!");
                game.addDraw();
                return;
            }
        }

        private void playHuman(Button tempButton)
        {
            if (game.Turn != 9)
            {
                if (game.Turn % 2 == 0)
                {
                    tempButton.Content = "X";
                }

                //Saving state
                game.saveButtonState(buttonArray);

                this.winner = game.checkWinner();

                if (winner)
                {
                    MessageBox.Show("Your are just lucky sir", "LuckyMan", MessageBoxButton.OK);
                    game.addPointPl1();
                    addColor(buttonArray, game.getWinCombination);
                    playAgainBut.IsEnabled = true;

                }
                else
                {

                    if (game.Turn % 2 != 0)
                    {
                        displaylabel.Content = game.IA;
                        tempButton.Content = "O";
                    }

                    game.nextTurn();

                    

                    //Saving state
                    game.saveButtonState(buttonArray);

                    this.winner = game.checkWinner();
                    if (winner)
                    {
                        MessageBox.Show("Only dumb can loose...", "MessageForDumb", MessageBoxButton.OK);
                        game.addPointPl2();
                        addColor(buttonArray, game.getWinCombination);
                        playAgainBut.IsEnabled = true;

                    }else
                    {
                        displaylabel.Content = "You";
                    }
                }
            }
        }

        private void playIA(Button tempButton)
        {
            if (game.Turn != 9)
            {
                //User play
                tempButton.Content = "X";
                game.nextTurn();

                //Saving state
                game.saveButtonState(buttonArray);

                //Look if the User Won
                this.winner = game.checkWinner();

                if (winner)
                {
                    MessageBox.Show("Your are just lucky sir", "LuckyMan", MessageBoxButton.OK);
                    game.addPointPl1();
                    addColor(buttonArray, game.getWinCombination);
                    playAgainBut.IsEnabled = true;

                }

                if (!winner)
                {
                    //If the user did not won then play the IA choosed by the user
                    if (game.IA == "Hard")
                    {
                        displaylabel.Content = game.IA;
                        buttonArray = game.loadOnButtonState(buttonArray, IAHard.Play(game.getButtonState(), game.getWinCombination));
                    }

                    if (game.IA == "Medium")
                    {
                        displaylabel.Content = game.IA;
                        buttonArray = game.loadOnButtonState(buttonArray, IAMedium.Play(game.getButtonState(), game.getWinCombination));
                    }

                    if (game.IA == "Easy")
                    {
                        displaylabel.Content = game.IA;
                        buttonArray = game.loadOnButtonState(buttonArray, IAEasy.Play(game.getButtonState(), game.getWinCombination));
                    }

                    //Saving state
                    game.saveButtonState(buttonArray);
                    game.nextTurn();
                    //Look if the IA won
                    this.winner = game.checkWinner();
                    if (winner)
                    {
                        MessageBox.Show("Only dumb can loose...", "MessageForDumb", MessageBoxButton.OK);
                        game.addPointPl2();
                        addColor(buttonArray, game.getWinCombination);
                        playAgainBut.IsEnabled = true;

                    }
                    else
                    {
                        displaylabel.Content = "You";
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
            if(game.Turn == 0 || winner == true || game.IA == "Human")
            {
                MessageBox.Show("Invalid Undo Sir...","Undo Message", MessageBoxButton.OK);
                return;
            }

            buttonArray = game.loadOnButtonState(buttonArray,game.getOldState());
            game.saveButtonState(buttonArray);
            undobutton.IsEnabled = false;
            game.deleteTurn();
            game.deleteTurn();
        }

        private void playAgainBut_Click(object sender, RoutedEventArgs e)
        {
            playAgainBut.IsEnabled = false;

            removeColor(buttonArray, game.getWinCombination);
            game = new TicTacGame(game.IA,game.PointPl1, game.PointPl2, game.Draw);

            //game.getButtonState() is set to empty by the constructor!
            buttonArray = game.loadOnButtonState(buttonArray, game.getButtonState());

            p1scorelabel.Content = game.PointPl1;
            p2scorelabel.Content = game.PointPl2;
            drawLabel.Content = game.Draw;

            this.winner = false;
            undobutton.IsEnabled = true;
            displaylabel.Content = "You";

        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Serialization seri = new Serialization();
            seri.Serializable(game);
        }

        private void mainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
            
            
          
        }
    }
}
