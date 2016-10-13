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
        private Button[] buttonArray;

        static private int[,] winCombination = new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };

        public TicTacToeApp()
        {
            InitializeComponent();

            buttonArray = new Button[9] { but1, but2, but3, but4, but5, but6, but7, but8, but9 };

            checkWinner(buttonArray);

            for (int i = 0; i < 9; i++)
                this.buttonArray[i].Click += new System.EventHandler(this.ClickHandler); // if a button is Clicked it will run ClickHandler defined by me. 
                                                                                         //It like a throw in Java, but I have to code the catch

        }

        public static bool checkWinner(Button [] buttonArray)
        {
            bool result = false;

            for (int i = 0; i < 8; i++)
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
                    break;  // you won do not continue.
                }
            }

                return result;
        }

        private void undobutton_Click(object sender, RoutedEventArgs e)
        {

            String message = "Are you sure you want to undo your last move? Warning: You can only undo one move.";
            MessageBox.Show(message, MessageBoxButton.OK);
        }
    }
}
