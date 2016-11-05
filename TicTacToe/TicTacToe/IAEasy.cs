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

        private IAEasy()
        {

        }


        /**
         * This method will have to run all the private
         * methods to make the EasyIA play
         * 
         */ 
        public static string[] Play(string[] gameState, int[,] winCombination)
        {
            int action;
            action = Block(gameState, winCombination);

            if (action == -1)
            {
                gameState = normalPlay(gameState);
            }

            if(action != -1)
            {
                gameState = playBlock(gameState, action);
            }
            return gameState;

        }



        private static int Block(string[] buttonArray, int[,] winCombination)
        {   
            //Loop looking for a POSSIBLE WIN
            for (int i = 0; i < 8 ; i++)
            {
                int a = winCombination[i, 0];
                int b = winCombination[i, 1];
                int c = winCombination[i, 2];

                string but1 = buttonArray[a];
                string but2 = buttonArray[b];
                string but3 = buttonArray[c];

                // Look if there is a POSSIBLE WIN
                if (but1 == "X" && but2 == "X" && but3 == "") 
                {
                    return indexOfBlock(i, buttonArray, winCombination);    //Will look which index of the button will be EMPTY
                }

                if (but1 == "X" && but2 == "" && but3 == "X") 
                {
                    return indexOfBlock(i, buttonArray, winCombination);    //Will look which index of the button will be EMPTY
                }

                if (but1 == "" && but2 == "X" && but3 == "X")
                {
                    return indexOfBlock(i, buttonArray, winCombination);     //Will look which index of the button will be EMPTY
                }

            }

            Console.WriteLine("Return -1!");
            return -1;
        }


        /**
         * This method will look the EXACT index of the
         * empty spot and return it.
         * If I do not found it I will return -1 and deal with it 
         * in the Play method.
         */ 
        private static int indexOfBlock(int index, string[] buttonArray, int[,] winCombination)
        {
            int foundEmpty = -1;

            for (int i = 0; i < winCombination.GetLength(1); i++)
            {
                if (buttonArray[winCombination[index, i]] == "")
                {
                    foundEmpty = winCombination[index, i];
                    Console.WriteLine("\tFoundEmpty: " + foundEmpty);
                }
            }
            return foundEmpty;
        }

        private static string[] playBlock(string[] buttonArray, int index)
        {       

            for(int i = 0; i < buttonArray.Length; i++)
            {

                if (buttonArray[i] == "" && i != index)
                {
                    buttonArray[i] = "O";
                    return buttonArray;
                }
            }
            return buttonArray;
        }


        /**
         * If you cannot Block you will just play a random 
         * turn. 
         */
        private static string[] normalPlay(string[] buttonArray)
        {
            int[,] game = new int[4, 9] { { 2, 6, 4, 7, 5, 8, 0, 1, 3 }, { 6, 8, 4, 0, 2, 3, 5, 1, 7 }, { 0, 2, 6, 1, 3, 8, 4, 7, 5 }, { 2, 4, 6, 0, 8, 1, 7, 5, 3 } };
            Random rnd = new Random();
            int num = rnd.Next(0, 4);
            for (int i = 0; i < 8; i++)
                if (buttonArray[game[num, i]] == "")
                {
                    buttonArray[game[num, i]] = "O";
                    //Play ONLY once and leave
                    return buttonArray;
                }
            return buttonArray;
        }
    }
}
