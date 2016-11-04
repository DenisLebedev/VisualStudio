﻿using System;
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


        public TicTacGame(String ia, int turn, int pointPl1, int pointPl2)
        {
            this.ia = ia;
            this.turn = turn;
            this.pointPl1 = pointPl1;
            this.pointPl2 = pointPl2;
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

        public string IA
        {
            get
            {
                return this.ia.ToString();
            }
        }

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

        public void addPointPl1()
        {
               
            PointPl1 = pointPl1+= 1;
        }

        public void addPointPl2()
        {
            PointPl2 = pointPl2+= 1;
        }

        public int[,] getWinCombination
        {
            get
            {
                return new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
            }
        }
    }
}
