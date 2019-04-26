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
        private char ghost;

        // ----------> Constructors <---------- //
        public Player(int actionOne, int actionTwo, int actionThree)
        {
            this.actionOne = actionOne;
            this.actionTwo = actionTwo;
            this.actionThree = actionThree;
        }

        public Player(char ghost)
        {
            this.ghost = ghost;
        }

        // ----------> Functions <---------- //

        public void ForwardGhostMovement()
        {
            /*
                You can either move one of your ghosts 1 space
                orthogonally (not diagonally), or from one mirror
                chamber to another mirror chamber. With the singlestep movement, you may either move into a mirror
                chamber, or into a carpeted chamber, but the color of
                the carpet doesn't matter. 
            */
            string userMoveChoice = Console.ReadLine();
            string userMoveChoiceLowCase = userMoveChoice.ToLower();
            string moveUp, moveDown, moveLeft, moveRight;

            if (userMoveChoiceLowCase == "up")
            {
                
            }           
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
