using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicTacToe
{
    class TicTacGame
    {
        private String ia;
        private int turn;
        private int points;

        public TicTacGame(String ia, int turn, int points)
        {
            this.ia = ia;
            this.turn = turn;
            this.points = points;
        }

        public static bool checkWinner(Button [] buttonArray)
        {
            //2D array that will hold all the win combination
            int[,] winCombination = new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
            bool result = false;

            //Loop looking for a Winner and if I found one !result will leave the loop
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
                    //THIS PART IS FOR DESIGN -- MOVE LATER
                    /*but1.Background = but2.Background = but3.Background = Brushes.Green; //Change the Color of the BackGroung
                    but1.FontFamily = but2.FontFamily = but3.FontFamily = new FontFamily("Arial Black"); //Change the Text of the winner*/

                    result = true;
                }
            }
            return result;
        }











    }
}
