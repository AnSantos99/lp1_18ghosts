using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo18Ghosts
{
    /// <summary>
    /// this class is used to set the players' info, giving them a list of ghosts
    /// that they have, ghosts they've set free
    /// </summary>
    public class PlayerFix
    {
        public char prefix;
        public List<Ghosts> ghosts = new List<Ghosts>();
        public List<Ghosts> ghostsFree = new List<Ghosts>();

        public PlayerFix(char prefix)
        {
            this.prefix = prefix;
        }

        // getting player position from their input to place each ghost
        public static Position GetPosition(GameBoard board)
        {
            //getting input
            string position = Console.ReadLine();
            //converting input to uppercase to avoid errors
            position = position.ToUpper();

            //calling function to determine which position matches the input
            Position desiredCoordinate = PositionForNumber(position);
            return desiredCoordinate;
        }

        public bool Won()
        {
            uint y = 0, b = 0, r = 0;

            foreach (Ghosts g in ghostsFree)
            {
                if (g is YellowGhost)
                    y++;
                else if (g is BlueGhost)
                    b++;
                else if (g is RedGhost)
                    r++;
            }

            return y > 0 && b > 0 && r > 0;
        }

        /// <summary>
        /// this method receives the input of position the player has given and
        /// returns it on the board so each ghost can be set and rendered
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private static Position PositionForNumber(string position)
        {
            switch (position)
            {
                case "A1": return new Position(0, 0);
                case "A2": return new Position(1, 0);
                case "A3": return new Position(2, 0);
                case "A4": return new Position(3, 0);
                case "A5": return new Position(4, 0);

                case "B1": return new Position(0, 1);
                case "B2": return new Position(1, 1);
                case "B3": return new Position(2, 1);
                case "B4": return new Position(3, 1);
                case "B5": return new Position(4, 1);

                case "C1": return new Position(0, 2);
                case "C2": return new Position(1, 2);
                case "C3": return new Position(2, 2);
                case "C4": return new Position(3, 2);
                case "C5": return new Position(4, 2);

                case "D1": return new Position(0, 3);
                case "D2": return new Position(1, 3);
                case "D3": return new Position(2, 3);
                case "D4": return new Position(3, 3);
                case "D5": return new Position(4, 3);

                case "E1": return new Position(0, 4);
                case "E2": return new Position(1, 4);
                case "E3": return new Position(2, 4);
                case "E4": return new Position(3, 4);
                case "E5": return new Position(4, 4);

                case "Q":

                default: return null;
            }
        }
    }
}
