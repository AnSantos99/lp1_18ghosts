using System;
using System.Collections.Generic;

namespace Jogo18Ghosts
{
    /// <summary>
    /// this class creates a 5*5 board and receives different piece types to 
    /// place and render
    /// </summary>
    internal class GameBoard
    {   
        // set the board size
        private uint width = 5, height = 5;

        // initialise the BoardPiece class pieces
        internal BoardPiece[,] pieces;
        
        // create a list for the player's ghosts
        internal List<Ghosts> dungeonGhosts = new List<Ghosts>();

        /// <summary>
        /// this method places all the different pieces on the board
        /// </summary>
        internal GameBoard()
        {
            // initialise variable to convert symbols to string for rendering
            string c;

            // declare the string
            c = Convert.ToString((char)Symbols.Corridor);

            // place pieces on the piece array and set their colour and symbol
            pieces = new BoardPiece[width, height];
            pieces[0, 0] = new BoardPiece(c, ConsoleColor.Blue);
            pieces[0, 1] = new BoardPiece(c, ConsoleColor.Red);
            pieces[0, 2] = new RedPortal(Direction.up);
            pieces[0, 3] = new BoardPiece(c, ConsoleColor.Blue);
            pieces[0, 4] = new BoardPiece(c, ConsoleColor.Red);

            pieces[1, 0] = new BoardPiece(c, ConsoleColor.Yellow);
            pieces[1, 1] = new Mirror();
            pieces[1, 2] = new BoardPiece(c, ConsoleColor.Yellow);
            pieces[1, 3] = new Mirror();
            pieces[1, 4] = new BoardPiece(c, ConsoleColor.Yellow);

            pieces[2, 0] = new BoardPiece(c, ConsoleColor.Red);
            pieces[2, 1] = new BoardPiece(c, ConsoleColor.Blue);
            pieces[2, 2] = new BoardPiece(c, ConsoleColor.Red);
            pieces[2, 3] = new BoardPiece(c, ConsoleColor.Blue);
            pieces[2, 4] = new YellowPortal(Direction.right);

            pieces[3, 0] = new BoardPiece(c, ConsoleColor.Blue);
            pieces[3, 1] = new Mirror();
            pieces[3, 2] = new BoardPiece(c, ConsoleColor.Yellow);
            pieces[3, 3] = new Mirror();
            pieces[3, 4] = new BoardPiece(c, ConsoleColor.Red);

            pieces[4, 0] = new BoardPiece(c, ConsoleColor.Yellow);
            pieces[4, 1] = new BoardPiece(c, ConsoleColor.Red);
            pieces[4, 2] = new BluePortal(Direction.down);
            pieces[4, 3] = new BoardPiece(c, ConsoleColor.Blue);
            pieces[4, 4] = new BoardPiece(c, ConsoleColor.Yellow);

            
        }

        /// <summary>
        /// this method turns each piece into it's colour and gives it the
        /// necessary "settings" from their class in order to work
        /// </summary>
        /// <param name="pos">piece position</param>
        /// <returns>a BoardPiece with the correct colour and symbol
        /// or null if the position doesn't exist</returns>
        internal static BoardPiece GetBoardSettings(Position pos)
        {
            // switch case to define each position properly according to it's
            // row and column 
            switch (pos.Row)
            {
                case 0:
                    switch (pos.Col)
                    {
                        case 0:
                            return new BoardPiece("b", ConsoleColor.Blue);
                        case 1:
                            return new BoardPiece("r", ConsoleColor.Red);
                        case 2:
                            return new RedPortal(Direction.up);
                        case 3:
                            return new BoardPiece("b", ConsoleColor.Blue);
                        case 4:
                            return new BoardPiece("r", ConsoleColor.Red);
                    }
                    break;
                case 1:
                    switch (pos.Col)
                    {
                        case 0:
                            return new BoardPiece("y", ConsoleColor.Yellow);
                        case 1:
                            return new Mirror();
                        case 2:
                            return new BoardPiece("y", ConsoleColor.Yellow);
                        case 3:
                            return new Mirror();
                        case 4:
                            return new BoardPiece("y", ConsoleColor.Yellow);
                    }
                    break;
                case 2:
                    switch (pos.Col)
                    {
                        case 0:
                            return new BoardPiece("r", ConsoleColor.Red);
                        case 1:
                            return new BoardPiece("b", ConsoleColor.Blue);
                        case 2:
                            return new BoardPiece("r", ConsoleColor.Red);
                        case 3:
                            return new BoardPiece("b", ConsoleColor.Blue);
                        case 4:
                            return new YellowPortal(Direction.right);
                    }
                    break;
                case 3:
                    switch (pos.Col)
                    {
                        case 0:
                            return new BoardPiece("b", ConsoleColor.Blue);
                        case 1:
                            return new Mirror();
                        case 2:
                            return new BoardPiece("y", ConsoleColor.Yellow);
                        case 3:
                            return new Mirror();
                        case 4:
                            return new BoardPiece("r", ConsoleColor.Red);
                    }
                    break;
                case 4:
                    switch (pos.Col)
                    {
                        case 0:
                            return new BoardPiece("y", ConsoleColor.Yellow);
                        case 1:
                            return new BoardPiece("r", ConsoleColor.Red);
                        case 2:
                            return new BluePortal(Direction.down);
                        case 3:
                            return new BoardPiece("b", ConsoleColor.Blue);
                        case 4:
                            return new BoardPiece("y", ConsoleColor.Yellow);
                    }
                    break;
            }
            return null;
        }

        /// <summary>
        /// this method sets the ghosts on the board according to player input
        /// </summary>
        /// <param name="ghost">chosen ghost</param>
        /// <param name="pos">wanted position</param>
        internal void SetGhost(Ghosts ghost, Position pos)
        {

            // set the ghost in that position
            ghost.pos = pos;
            // assign that position as a ghost 
            pieces[pos.Row, pos.Col] = ghost;
        }

        /// <summary>
        /// this method places the ghosts inside a dungeon that creates new
        /// positions on the board's dungeon
        /// </summary>
        /// <param name="position">get the position of the ghost</param>
        /// <returns>the ghost now in the dungeon</returns>
        internal Ghosts GetDungeonGhost(string position)
        {
            // convert to upper to avoid errors
            switch (position.ToUpper())
            {
                // get ghost from the dungeon so it can be placed back on board
                case "A6": return dungeonGhosts[0];
                case "A7": return dungeonGhosts[5];
                case "A8": return dungeonGhosts[10];
                case "A9": return dungeonGhosts[15];

                case "B6": return dungeonGhosts[1];
                case "B7": return dungeonGhosts[6];
                case "B8": return dungeonGhosts[11];
                case "B9": return dungeonGhosts[16];

                case "C6": return dungeonGhosts[2];
                case "C7": return dungeonGhosts[7];
                case "C8": return dungeonGhosts[12];
                case "C9": return dungeonGhosts[17];

                case "D6": return dungeonGhosts[3];
                case "D7": return dungeonGhosts[8];
                case "D8": return dungeonGhosts[13];
                case "D9": return dungeonGhosts[18];

                case "E6": return dungeonGhosts[4];
                case "E7": return dungeonGhosts[9];
                case "E8": return dungeonGhosts[14];
            }

            return null;
        }

        /// <summary>
        /// this method serves as a counter for how many ghosts a player has in
        /// the dungeon in order to ask them if they want to take them out
        /// </summary>
        /// <param name="player">check which player's ghost got sent</param>
        /// <returns>the updated counter</returns>
        internal uint CountdungeonGhostsForPlayer(Player player)
        {
            // starting a counter for the ghosts in the dungeon
            uint counter = 0;
            // going through every ghost in the dungeon to count it
            foreach (Ghosts ghost in dungeonGhosts)
                if (ghost.player == player)
                    counter++;

            return counter;
        }

        /// <summary>
        /// this method uses GetPiece from the BoardPiece class and returns its
        /// position by row and column on the board
        /// </summary>
        /// <param name="pos">piece's position</param>
        /// <returns>piece's position on the board by row and column</returns>
        internal BoardPiece GetPiece(Position pos)
        {
            return pieces[pos.Row, pos.Col];
        }

        /// <summary>
        /// this method renders the board on the console, it uses a for cycle
        /// to go through each row and column of the board and place the
        /// pieces correctly
        /// </summary>
        internal void Render()
        {
            // print the top row
            Console.WriteLine("  __[A]_|_[B]_|_[C]_|_[D]_|_[E]__");

            // begin cycle to set all the rows right
            for (uint y = 0; y < height; y++)
            {
                
                Console.WriteLine("  |     |     |     |     |     |");
                Console.Write($"[{y + 1}] ");

                // check if there are pieces and place them
                for (uint x = 0; x < width; x++)
                {
                    if (pieces[y, x] != null)
                        pieces[y, x].Render();
                }
                
                // new line to render bottom of row
                Console.WriteLine();
                Console.WriteLine("  |__ __|__ __|__ __|__ __|__ __|");
            }
           
            // print the dungeon
            Console.WriteLine("  |                             |");
            Console.Write("6 |");

            // simulating coordinates outside of normal board for
            uint counter = 0, uCounter = 6;
            
            // checking ghosts inside dungeon and rendering it
            foreach (Ghosts soul in dungeonGhosts)
            {
                soul.Render();
                counter++;
                if (counter == 5)
                {
                    counter = 0;
                    uCounter++;
                    Console.WriteLine();
                    Console.Write(uCounter + " |");
                }
            }

            // printing bottom of dungeon
            Console.WriteLine();
            Console.WriteLine("  |_____________________________|");
        }

        /// <summary>
        /// this method checks what ghost lost a fight and calls the portal
        /// update function in the Portal class in order to turn it, sends
        /// the ghost to the dungeon
        /// </summary>
        /// <param name="piece">checks the ghost that lost</param>
        internal void OnPieceLost(BoardPiece piece)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    // finds the portal with the colour that matches the ghost
                    if (pieces[i, j] is Portals portal && 
                        portal.color == piece.color)
                    {
                        // rotates the portal
                        portal.Turn();
                        UpdatePortal(portal.color);
                        break;
                    }
                }
            }

            // checks the ghost that lost and sends it to the dungeon
            if (piece is Ghosts ghost)
                dungeonGhosts.Add(ghost);
        }

        /// <summary>
        /// this method counts the mirrors on the board
        /// </summary>
        /// <returns>returns number of mirrors</returns>
        internal uint CountMirrors()
        {
            uint count = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (pieces[i, j] is Mirror)
                        count++;
                }
            }

            return count;
        }

        /// <summary>
        /// this method checks to see if a ghost is next to and facing 
        /// an open portal so it can escape
        /// </summary>
        /// <param name="portal">portal on the board position</param>
        /// <param name="x">the x axis from board</param>
        /// <param name="y">the y axis from board</param>
        private void CheckPortalNeighbour(Portals portal, int x, int y)
        {
            // checks if piece is a ghost matching the portal colour
            if (pieces[y, x] is Ghosts ghost && ghost.color == portal.color)
            {
                // adds ghost to the free ghost list
                ghost.player.ghostsFree.Add((Ghosts)pieces[y, x]);
                // returns corridor back to its original empty colour state
                pieces[y, x] = GetBoardSettings(new Position(y, x));
            }
        }

        /// <summary>
        /// this method updates the portals by checking what ghosts are near
        /// them to see if they are facing them
        /// </summary>
        /// <param name="color"></param>
        internal void UpdatePortal(ConsoleColor color)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    // checks if the piece is a portal and it matches the color
                    if (pieces[i, j] is Portals portal && portal.color == color)
                    {
                        // checking the neighbours according to the facing dir
                        switch (portal.dir)
                        {
                            case Direction.up:
                                if (i > 0)
                                    CheckPortalNeighbour(portal, j, i - 1);
                                break;
                            case Direction.down:
                                if (i < height - 1)
                                    CheckPortalNeighbour(portal, j, i + 1);
                                break;
                            case Direction.left:
                                if (j > 0)
                                    CheckPortalNeighbour(portal, j - 1, i);
                                break;
                            case Direction.right:
                                if (j < width - 1)
                                    CheckPortalNeighbour(portal, j + 1, i);
                                break;
                        }

                    }
                }
            }
        } 
    }
}
