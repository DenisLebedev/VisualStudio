using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicTacToe
{
    class IAHard
    {

        private IAHard()
        {

        }

        /**
         * This method will have to run all the private
         * methods to make the EasyIA play
         * 
         */
        public static string[] Play(string[] gameState, int[,] winCombination)
        {
            int actionWin;
            int actionBlock;
            actionWin = Win(gameState, winCombination);
            actionBlock = Block(gameState, winCombination);

            if (actionBlock == -1 && actionWin == -1)
            {
                gameState = normalPlay(gameState);
            }
            if (actionWin != -1)
            {
                gameState = playWin(gameState, actionWin);
            }

            if (actionBlock != -1 && actionWin == -1)
            {
                gameState = playBlock(gameState, actionBlock);
            }

            return gameState;
        }



        private static int Block(string[] buttonArray, int[,] winCombination)
        {
            //Loop looking for a POSSIBLE WIN
            for (int i = 0; i < 8; i++)
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
                    return indexOfEmpty(i, buttonArray, winCombination);    //Will look which index of the button will be EMPTY
                }

                if (but1 == "X" && but2 == "" && but3 == "X")
                {
                    return indexOfEmpty(i, buttonArray, winCombination);    //Will look which index of the button will be EMPTY
                }

                if (but1 == "" && but2 == "X" && but3 == "X")
                {
                    return indexOfEmpty(i, buttonArray, winCombination);     //Will look which index of the button will be EMPTY
                }

            }
            return -1;
        }


        private static int Win(string[] buttonArray, int[,] winCombination)
        {
            //Loop looking for a POSSIBLE WIN
            for (int i = 0; i < 8; i++)
            {
                int a = winCombination[i, 0];
                int b = winCombination[i, 1];
                int c = winCombination[i, 2];

                string but1 = buttonArray[a];
                string but2 = buttonArray[b];
                string but3 = buttonArray[c];

                // Look if there is a POSSIBLE WIN
                if (but1 == "O" && but2 == "O" && but3 == "")
                {
                    return indexOfEmpty(i, buttonArray, winCombination);    //Will look which index of the button will be EMPTY
                }

                if (but1 == "O" && but2 == "" && but3 == "O")
                {
                    return indexOfEmpty(i, buttonArray, winCombination);    //Will look which index of the button will be EMPTY
                }

                if (but1 == "" && but2 == "O" && but3 == "O")
                {
                    return indexOfEmpty(i, buttonArray, winCombination);     //Will look which index of the button will be EMPTY
                }

            }
            return -1;
        }


        /**
         * This method will look the EXACT index of the
         * empty spot and return it.
         * If I do not found it I will return -1 and deal with it 
         * in the Play method.
         */
        private static int indexOfEmpty(int index, string[] buttonArray, int[,] winCombination)
        {
            int foundEmpty = -1;

            for (int i = 0; i < winCombination.GetLength(1); i++)
            {
                if (buttonArray[winCombination[index, i]] == "")
                {
                    foundEmpty = winCombination[index, i];
                }
            }
            return foundEmpty;
        }

        private static string[] playBlock(string[] buttonArray, int index)
        {
                if (buttonArray[index] == "")
                {
                    buttonArray[index] = "O";
                }

            return buttonArray;
        }


        /**
         * If you cannot Block you will just play a random 
         * turn. 
         */
        private static string[] normalPlay(string[] buttonArray)
        {
            if (buttonArray[4] == "")
            {
                buttonArray[4] = "O";
                return buttonArray;
            }

            if ((buttonArray[6] == "X" && buttonArray[2] == "X") && buttonArray[5] == "")
            {
                buttonArray[5] = "O";
                return buttonArray;
            }

            if ((buttonArray[0] == "X" && buttonArray[8] == "X") && buttonArray[3] == "")
            {
                buttonArray[3] = "O";
                return buttonArray;
            }

            if (((buttonArray[7] == "X" && (buttonArray[5] == "X" || buttonArray[3] == "X")) && buttonArray[4] == "") ||
                ((buttonArray[1] == "X" && (buttonArray[3] == "X" || buttonArray[5] == "X")) && buttonArray[4] == ""))
            {
                buttonArray[4] = "O";
                return buttonArray;
            }

            if((buttonArray[1] == "X" || buttonArray[5] == "X") && buttonArray[2] == "")
            {
                buttonArray[2] = "O";
                return buttonArray;
            }

            if ((buttonArray[3] == "X" || buttonArray[7] == "X") && buttonArray[6] == "")
             {
                buttonArray[6] = "O";
                return buttonArray;
            }
            //I created different Strategy and playstyle to make the game unique
            int[,] game = new int[4, 9] { { 2, 6, 4, 7, 5, 8, 0, 1, 3 }, { 6, 8, 4, 0, 2, 3, 5, 1, 7 }, { 0, 2, 6, 1, 3, 8, 4, 7, 5 }, {2,4,6,0,8,1,7,5,3 } };
            Random rnd = new Random();
            int num = rnd.Next(0, 4);
            for(int i=0; i < 8; i++)
                if (buttonArray[game[num,i]] == "")
                {
                    buttonArray[game[num, i]] = "O";
                    //Play ONLY once and leave
                    return buttonArray;
                }
            return buttonArray;
        }


        private static string[] playWin(string[] buttonArray, int index)
        {
            buttonArray[index] = "O";
            return buttonArray;
        }
    }
}
