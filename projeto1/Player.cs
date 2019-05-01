using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo18Ghosts
{
    class Player
    {
        // ----------> Instances <---------- // 
        private int actionOne;
        private int actionTwo;
        private int actionThree;
        public int[] ghosts;
        private string playerChoices;

        //public string nameOfPlayer { get; set; }
        //public int numbOfGhosts { get; set; }

        private int[,] testBoard = new int [5,5];


        // ----------> Constructors <---------- //
        public Player() { string playerActions = playerChoices; } 


        // ----------> Functions <---------- //

        public void PlayerActions(int actionOne, int actionTwo, int actionThree)
        {
            this.actionOne = actionOne;
            this.actionTwo = actionTwo;
            this.actionThree = actionThree;
        }

        /*
        public void player(int playerGhosts)
        {
            playerGhosts = ghosts;
        }
        */

        public void Act1GhostMovement(string userInput)
        {
            /*
                You can either move one of your ghosts 1 space
                orthogonally (not diagonally), or from one mirror
                chamber to another mirror chamber. 
                With the singlestep movement, you may either move into a mirror
                chamber, or into a carpeted chamber, but the color of
                the carpet doesn't matter. 
            */
            int moveUp, moveDown, moveLeft, moveRight;
            int mirrorUpLeft, mirrorUpRight, mirrorDownLeft, mirrorDownRight;

            userInput.ToLower();

            if (userInput == "normal move")
            {
                string normMoveChoice;
                Console.WriteLine("Where do you wanna go? up/down left/right");
                normMoveChoice = Console.ReadLine();
                normMoveChoice.ToLower();

                if (normMoveChoice == "up")
                {
                    moveUp = testBoard[0, 1];
                    Console.WriteLine($"You");
                    // - 1;
                    // Ghost position = new position
                }

                if (normMoveChoice == "down")
                {
                    moveUp = testBoard[0, 1]; // - 1;
                                              // Ghost position = new position
                }

                if (normMoveChoice == "left")
                {
                    moveUp = testBoard[0, 1]; // - 1;
                                              // Ghost position = new position
                }

                if (normMoveChoice == "right")
                {
                    moveUp = testBoard[0, 1]; // - 1;
                                              // Ghost position = new position
                }
            }

            else if (userInput == "mirror chamber")
            {
                string normMoveChoice;
                Console.WriteLine("What mirror chamber do you want to go?");
                normMoveChoice = Console.ReadLine();
                normMoveChoice.ToLower();

                // Player Mirror Movements
                if (userInput == "mirror up left")
                {
                    mirrorUpLeft = testBoard[1, 1];
                    Console.WriteLine("HEHEHEani");
                    // Ghost position = new position
                }

                if (userInput == "mirror up right")
                {
                    mirrorUpRight = testBoard[1, 3];
                    // Ghost position = new position
                }

                if (userInput == "mirror down left")
                {
                    mirrorDownLeft = testBoard[3, 1];
                    // Ghost position = new position
                }

                if (userInput == "mirror down right")
                {
                    mirrorDownRight = testBoard[3, 3];
                    // Ghost position = new position
                }
            }

            else
            {
                Console.WriteLine("Invalid Choice");
                
            }
        }


        public int GetGhostsPosition()
        {
            return ghosts;
        }

        public void FightGhost()
        {

            /*
             *  Fight a ghost in an adjacent chamber
                
                Red ghosts beat blue ones.
                Blue ghosts beat yellow ones
                Yellow ghosts beat red ones.

                You are welcome to beat up your own ghosts, and
                you are equally welcome to pick a fight that your
                ghost will lose.
             */

            // Defeat ghost
            

        }

        public void ReleaseGhost()
        {
            // Release ghost

        }
    }
}
