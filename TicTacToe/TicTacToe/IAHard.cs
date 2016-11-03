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

        private int[,] winCombination = new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };


        private IAHard()
        {

        }

        /**
         * This method will have to run all the private
         * methods to make the EasyIA play
         * 
         */
        public static void Play(Button[] buttonArray, int[,] winCombination)
        {
            int action;
            action = Block(buttonArray, winCombination);

            if (action == -1)
            {
                normalPlay(buttonArray);
            }

            if (action != -1)
            {
                playBlock(buttonArray, action);
            }
        }



        private static int Block(Button[] buttonArray, int[,] winCombination)
        {
            //Loop looking for a POSSIBLE WIN
            for (int i = 0; i < 8; i++)
            {
                int a = winCombination[i, 0];
                int b = winCombination[i, 1];
                int c = winCombination[i, 2];

                Button but1 = buttonArray[a];
                Button but2 = buttonArray[b];
                Button but3 = buttonArray[c];

                // Look if there is a POSSIBLE WIN
                if (but1.Content == "X" && but2.Content == "X" && but3.Content == "")
                {
                    return indexOfBlock(i, buttonArray, winCombination);    //Will look which index of the button will be EMPTY
                }

                if (but1.Content == "X" && but2.Content == "" && but3.Content == "X")
                {
                    return indexOfBlock(i, buttonArray, winCombination);    //Will look which index of the button will be EMPTY
                }

                if (but1.Content == "" && but2.Content == "X" && but3.Content == "X")
                {
                    return indexOfBlock(i, buttonArray, winCombination);     //Will look which index of the button will be EMPTY
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
        private static int indexOfBlock(int index, Button[] buttonArray, int[,] winCombination)
        {
            int foundEmpty = -1;

            for (int i = 0; i < winCombination.GetLength(1); i++)
            {
                Console.WriteLine("This one? : " + winCombination[index, i] + "\tL: " + winCombination.GetLength(1));
                if (buttonArray[winCombination[index, i]].Content == "")
                {
                    foundEmpty = winCombination[index, i];
                    Console.WriteLine("\tFoundEmpty: " + foundEmpty);
                }
            }
            return foundEmpty;
        }

        private static void playBlock(Button[] buttonArray, int index)
        {
            Console.WriteLine("Content at Index: " + buttonArray[index].Content + "Index: " + index);
                if (buttonArray[index].Content == "")
                {
                    buttonArray[index].Content = "O";
                    return;
                }
        }


        /**
         * If you cannot Block you will just play a random 
         * turn. 
         */
        private static void normalPlay(Button[] buttonArray)
        {
           
            //Take a corner and I will take the middle
            if ((buttonArray[0].Content == "X" || buttonArray[2].Content == "X" ||
                buttonArray[6].Content == "X" || buttonArray[8].Content == "X") && buttonArray[4].Content == "")
            {
                buttonArray[4].Content = "O";
                return;
            }


            int[,] game = new int[4, 9] { { 2, 6, 4, 7, 5, 8, 0, 1, 3 }, { 6, 8, 4, 0, 2, 3, 5, 1, 7 }, { 0, 2, 6, 1, 3, 8, 4, 7, 5 }, {2,4,6,0,8,1,7,5,3 } };
            Random rnd = new Random();
            int num = rnd.Next(0, 4);
            for(int i=0; i < 8; i++)
                if (buttonArray[game[num,i]].Content == "")
                {
                    buttonArray[game[num, i]].Content = "O";
                    //Play ONLY once and leave
                    return;
                }
            /*//All good player will not focus the middle first!
            if (buttonArray[2].Content == "")
            {
                buttonArray[2].Content = "O";
                //Play ONLY once and leave
                return;
            }
            if (buttonArray[6].Content == "")
            {
                buttonArray[6].Content = "O";
                //Play ONLY once and leave
                return;
            }
            if (buttonArray[8].Content == "")
            {
                buttonArray[8].Content = "O";
                //Play ONLY once and leave
                return;
            }
            if (buttonArray[7].Content == "")
            {
                buttonArray[7].Content = "O";
                //Play ONLY once and leave
                return;
            }
            if (buttonArray[5].Content == "")
            {
                buttonArray[5].Content = "O";
                //Play ONLY once and leave
                return;
            }
            if (buttonArray[0].Content == "")
            {
                buttonArray[0].Content = "O";
                //Play ONLY once and leave
                return;
            }
            if (buttonArray[4].Content == "")
            {
                buttonArray[4].Content = "O";
                //Play ONLY once and leave
                return;
            }
            if (buttonArray[1].Content == "")
            {
                buttonArray[1].Content = "O";
                //Play ONLY once and leave
                return;
            }
            if (buttonArray[3].Content == "")
            {
                buttonArray[3].Content = "O";
                //Play ONLY once and leave
                return;
            }*/
        }
    }
}
