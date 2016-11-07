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
            Window difficulty = new Difficulty();
            difficulty.Show();
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            Serialization seri = new Serialization();
            TicTacGame game;
            game = seri.Deserializable();
            TicTacToeApp tictac = new TicTacToeApp(game.IA, game.PointPl1, game.PointPl2, game.Draw, game.Turn, game.getButtonState(), game.getOldState());
            tictac.Show();
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
