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
    /// Interaction logic for Difficulty.xaml
    /// </summary>
    public partial class Difficulty : Window
    {
        public Difficulty()
        {
            InitializeComponent();
        }

        private void easy_ButtonClick(object sender, RoutedEventArgs e)
        {
            Window ticTacApp = new TicTacToeApp("Easy", 0, 0, 0);
            ticTacApp.Show();
         

        }

        private void medium_ButtonClick(object sender, RoutedEventArgs e)
        {

            Window ticTacApp = new TicTacToeApp("Medium", 0, 0, 0);
            ticTacApp.Show();
        }

        private void hard_ButtonClick(object sender, RoutedEventArgs e)
        {
            Window ticTacApp = new TicTacToeApp("Hard", 0, 0, 0);
            ticTacApp.Show();


        }
    }
}
