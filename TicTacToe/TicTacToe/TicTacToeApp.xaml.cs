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
        Button[] buttonArray;
        public TicTacToeApp()
        {
            InitializeComponent();

            buttonArray = new Button[9] { but1, but2, but3, but4, but5, but6, but7, but8, but9 };
        }


    }
}
