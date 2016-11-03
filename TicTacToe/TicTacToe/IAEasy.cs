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
        public void Play(Button[] buttonArray, int[,] winCombination)
        {
            int action;
            action = Block(buttonArray, winCombination);

            if (action == -1)
            {
                Console.WriteLine("Block Gave -1 Bouuh");
                normalPlay(buttonArray);
            }

            if(action != -1)
            {
                Console.WriteLine("Block did not gave -1");
                playBlock(buttonArray, action);
            }



            //return 1;
        }



        public int Block(Button [] buttonArray, int[,] winCombination)
        {   
            //Loop looking for a POSSIBLE WIN
            for (int i = 0; i < 8 ; i++)
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
                    Console.WriteLine("Combination X, X, ''\t: " + i);
                    return indexOfBlock(i, buttonArray);    //Will look which index of the button will be EMPTY
                }

                if (but1.Content == "X" && but2.Content == "" && but3.Content == "X") 
                {
                    Console.WriteLine("Combination X, '', X\t: " + i);
                    return indexOfBlock(i, buttonArray);    //Will look which index of the button will be EMPTY
                }

                if (but1.Content == "" && but2.Content == "X" && but3.Content == "X")
                {
                    Console.WriteLine("Combination '', X, X\t: " + i);
                    return indexOfBlock(i, buttonArray);     //Will look which index of the button will be EMPTY
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
        private int indexOfBlock(int index, Button[] buttonArray)
        {
            int foundEmpty = -1;

            for (int i = 0; i < winCombination.GetLength(1); i++)
            {
                Console.WriteLine("This one? : " + winCombination[index, i] + "\tL: " + winCombination.GetLength(1));
                if (buttonArray[winCombination[index, i]].Content == "")
                {
                    Console.WriteLine("This one Is EMPTUUU!! : " + winCombination[index, i]);
                    foundEmpty = winCombination[index, i];
                    Console.WriteLine("\tFoundEmpty: " + foundEmpty);
                }
            }
            return foundEmpty;
        }

        private void playBlock(Button[] buttonArray, int index)
        {       

            for(int i = 0; i < buttonArray.Length; i++)
            {

                if (buttonArray[i].Content == "" && i != index)
                {
                    buttonArray[i].Content = "O";
                    return;
                }
            }
        }


        /**
         * If you cannot Block you will just play a random 
         * turn. 
         */
        private void normalPlay(Button[] buttonArray)
        {
  
                //All good player will not focus the middle first!
                if (buttonArray[4].Content == "")
                {
                    buttonArray[4].Content = "O";
                    //Play ONLY once and leave
                    return;
                }
            
                if (buttonArray[5].Content == "")
                {
                    buttonArray[5].Content = "O";
                    return;
                }

                if (buttonArray[3].Content == "")
                {
                    buttonArray[3].Content = "O";
                    return;
                }

                if (buttonArray[8].Content == "")
                {
                    buttonArray[8].Content = "O";
                    return;
                }

                if (buttonArray[2].Content == "")
                {
                    buttonArray[2].Content = "O";
                    return;
                }

                if (buttonArray[0].Content == "")
                {
                    buttonArray[0].Content = "O";
                    return;
                }

                if (buttonArray[1].Content == "")
                {
                    buttonArray[1].Content = "O";
                    return;
                }
                if (buttonArray[6].Content == "")
                {
                    buttonArray[6].Content = "O";
                    return;
                }
                if (buttonArray[7].Content == "")
                {
                    buttonArray[7].Content = "O";
                    return;
                }

            Console.WriteLine("\tMMhh");

        }

    }
}
