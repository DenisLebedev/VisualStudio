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
        private int pointPl1;
        private int pointPl2;
        private int[,] winCombination = new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
        private string[] gameState;


        public TicTacGame(String ia, int turn, int pointPl1, int pointPl2)
        {
            this.ia = ia;
            this.turn = turn;
            this.pointPl1 = pointPl1;
            this.pointPl2 = pointPl2;
            //Default Game Board is Empty (For saving to file)
            gameState = new string[] {"","","","","","","","","" };
        }

        public Button[] loadOnButtonState(Button[] buttonArray, string[] gameBoard)
        {
            for (int i = 0; i < gameBoard.Length; i++)
                buttonArray[i].Content = gameBoard[i];

            return buttonArray;
        }


        /**
         * Save the state after every round
         * and return the stae either, but 
         * a deep copy only
         */
        public void saveButtonState(Button[] buttonArray)
        {
            for (int i = 0; i < buttonArray.Length; i++)
                gameState[i] = (buttonArray[i].Content as string);

        }

        /**
         * Return a deep copy of the state of the buttons
         */ 
        public string[] getButtonState()
        {
            string[] copyState = new string[9];
            Array.Copy(gameState, copyState, gameState.Length);        
            return copyState;
        }


        public bool checkWinner()
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

                string but1 = gameState[a];
                string but2 = gameState[b];
                string but3 = gameState[c];

                if (but1 == "" || but2 == "" || but3 == "") // if one if blank
                    continue;    // if they are empty that mean nothing happen this turn

                if (but1 == but2 && but2 == but3)
                {
                    result = true;
                }
            }
            return result;
        }


        /**
         * This property will set a value from this class only 
         * and will get the current turn 
         */
        public int Turn
        {
            get
            {
                return this.turn;
            }
            private set{
                this.turn = value;
            }
        }

        /**
         *This method will call the property Turn  
         * and set a the value for the next turn.
         * The goal is to avoid instantiation of
         * "turn" outside of the class.
         */
        public void nextTurn()
        {
            Turn = turn+=1;
        }


        /**
         * Return the IA that the user choosed
         */ 
        public string IA
        {
            get
            {
                return this.ia.ToString();
            }
        }

        /**
         * return the points, but you cannot set them 
         * only by using the addPoint method
         */ 
        public int PointPl1
        {
            get
            {
                return this.pointPl1;
            }
            private set
            {
                Console.WriteLine("PrivateSetterPl1: " + value);
                this.pointPl1 = value;
            }
        }

        /**
         * return the points, but you cannot set them 
         * only by using the addPoint method
         */
        public int PointPl2
        {
            get
            {
                return this.pointPl2;
            }
            private set
            {
                this.pointPl2 = value;
            }
        }

        /**
         * will use the private setter to add points
         */
        public void addPointPl1()
        {
               
            PointPl1 = pointPl1+= 1;
        }


        /**
         * will use the private setter to add points
         */
        public void addPointPl2()
        {
            PointPl2 = pointPl2+= 1;
        }


        /**
         * return a deep copy of all wins combination because it 
         * is used in all my IA classes
         */
        public int[,] getWinCombination
        {
            get
            {
                return new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
            }
        }
    }
}
