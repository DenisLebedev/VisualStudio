using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicTacToe
{
    class IAEasy
    {

        private int[,] winCombination = new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
        public IAEasy()
        {

        }


        /**
         * This method will have to run all the private
         * methods to make the EasyIA play
         * 
         */ 
        public int Play()
        {
            return 1;
        }



        public int Block(Button [] buttonArray, int[,] winCombination)
        {   
            bool result = false;


            //Loop looking for a POSSIBLE WIN
            for (int i = 0; i < 8 && !result; i++)
            {
                int a = winCombination[i, 0];
                int b = winCombination[i, 1];
                int c = winCombination[i, 2];

                Button but1 = buttonArray[a];
                Button but2 = buttonArray[b];
                Button but3 = buttonArray[c];

                if (but1.Content == "X" && but2.Content == "X" && but3.Content == "") // Look if there is a POSSIBLE WIN
                {
                    Console.WriteLine("Combination X, X, ''\t: " + i);
                    return placeYourCircle(i, buttonArray);    // if they are empty that mean nothing happen this turn
                }

                if (but1.Content == "X" && but2.Content == "" && but3.Content == "X") 
                {
                    Console.WriteLine("Combination X, '', X\t: " + i);
                    return placeYourCircle(i, buttonArray);    // if they are empty that mean nothing happen this turn
                }


                if (but1.Content == "" && but2.Content == "X" && but3.Content == "X")
                {
                    Console.WriteLine("Combination '', X, X\t: " + i);
                    return placeYourCircle(i, buttonArray);     // if they are empty that mean nothing happen this turn
                }

            }
           
            return -1;
        }

        private int placeYourCircle(int index, Button[] buttonArray)
        {
            for (int i = 0; i < winCombination.GetLength(1); i++)
            {
                Console.WriteLine("This one? : " + winCombination[index, i] + "\tL: " + winCombination.GetLength(1));
                if (buttonArray[winCombination[index, i]].Content == "")
                    Console.WriteLine("This one Is EMPTUUU!! : " + winCombination[index, i]);
            }
            return 1;
        }

    }
}
