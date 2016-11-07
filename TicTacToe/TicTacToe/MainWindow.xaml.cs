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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void newGame_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            Serialization seri = new Serialization();
            TicTacGame game;
            game = seri.Deserializable();
            TicTacToeApp tictac = new TicTacToeApp(game.IA, game.PointPl1, game.PointPl2, game.Draw, game.Turn, game.getButtonState(), game.getOldState());
            tictac.Show();
            this.Close();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
    
        }

        private void easyBut_Click(object sender, RoutedEventArgs e)
        {
            Window ticTacApp = new TicTacToeApp("Easy", 0, 0, 0);
            ticTacApp.Show();
            this.Close();
        }

        private void mediumBut_Click(object sender, RoutedEventArgs e)
        {
            Window ticTacApp = new TicTacToeApp("Medium", 0, 0, 0);
            ticTacApp.Show();
            this.Close();
        }

        private void hardBut_Click(object sender, RoutedEventArgs e)
        {
            Window ticTacApp = new TicTacToeApp("Hard", 0, 0, 0);
            ticTacApp.Show();
            this.Close();

        }

        private void two_playBut_Click(object sender, RoutedEventArgs e)
        {
            Window ticTacApp = new TicTacToeApp("Human", 0, 0, 0);
            ticTacApp.Show();
            this.Close();

        }

        private void rulesButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Basic Rule: The object of Tic Tac Toe is to get three in a row. " + 
                            "You play on a three by three game board. The first player is known as X and the second is O. " + 
                            "Players alternate placing Xs and Os on the game board until either oppent has three in a row or all " + 
                            "nine squares are filled.\n\n" +  
                            "Undo Button: When playing against the AI, you can only use the undo button once. The undo button is disabled while playing against another player " +
                            "since it only allows one move to be undoed and that would be unfair!\n\n Have Fun!", " Game Rules: ");
        }


        /* string path;
         path = System.IO.Path.GetDirectoryName( 
                 System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase );
         MessageBox.Show( path );*/



        /*private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedIndex == 1 || comboBox.SelectedIndex == 2)
            {
                Window ticTacApp = new TicTacToeApp();
                ticTacApp.Show();
            }
        }*/
    }
}
