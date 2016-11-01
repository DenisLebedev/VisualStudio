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
            Window ticTacApp = new TicTacToeApp();
            ticTacApp.Show();
        }
        
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
