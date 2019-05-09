﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo18Ghosts
{
    /// <summary>
    /// 
    /// </summary>
    public class GameBoard
    {    
        private uint width = 5, height = 5;
        public BoardPiece[,] pieces;
        public List<Ghosts> lostSouls = new List<Ghosts>();

        public GameBoard()
        {
            pieces = new BoardPiece[width, height];
            pieces[0, 0] = new BoardPiece("b", ConsoleColor.Blue);
            pieces[0, 1] = new BoardPiece("r", ConsoleColor.Red);
            pieces[0, 2] = new RedPortal(Portals.Direction.up);
            pieces[0, 3] = new BoardPiece("b", ConsoleColor.Blue);
            pieces[0, 4] = new BoardPiece("r", ConsoleColor.Red);

            pieces[1, 0] = new BoardPiece("y", ConsoleColor.Yellow);
            pieces[1, 1] = new Mirror();
            pieces[1, 2] = new BoardPiece("y", ConsoleColor.Yellow);
            pieces[1, 3] = new Mirror();
            pieces[1, 4] = new BoardPiece("y", ConsoleColor.Yellow);

            pieces[2, 0] = new BoardPiece("r", ConsoleColor.Red);
            pieces[2, 1] = new BoardPiece("b", ConsoleColor.Blue);
            pieces[2, 2] = new BoardPiece("r", ConsoleColor.Red);
            pieces[2, 3] = new BoardPiece("b", ConsoleColor.Blue);
            pieces[2, 4] = new YellowPortal(Portals.Direction.right);

            pieces[3, 0] = new BoardPiece("b", ConsoleColor.Blue);
            pieces[3, 1] = new Mirror();
            pieces[3, 2] = new BoardPiece("y", ConsoleColor.Yellow);
            pieces[3, 3] = new Mirror();
            pieces[3, 4] = new BoardPiece("r", ConsoleColor.Red);

            pieces[4, 0] = new BoardPiece("y", ConsoleColor.Yellow);
            pieces[4, 1] = new BoardPiece("r", ConsoleColor.Red);
            pieces[4, 2] = new BluePortal(Portals.Direction.down);
            pieces[4, 3] = new BoardPiece("b", ConsoleColor.Blue);
            pieces[4, 4] = new BoardPiece("y", ConsoleColor.Yellow);

            
        }

        public static BoardPiece GetBoardSettings(Position pos)
        {
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
                            return new RedPortal(Portals.Direction.up);
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
                            return new YellowPortal(Portals.Direction.right);
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
                            return new BluePortal(Portals.Direction.down);
                        case 3:
                            return new BoardPiece("b", ConsoleColor.Blue);
                        case 4:
                            return new BoardPiece("y", ConsoleColor.Yellow);
                    }
                    break;
            }
            return null;
        }

        

        public void SetGhost(Ghosts ghost, Position pos)
        {
            ghost.pos = pos;
            pieces[pos.Row, pos.Col] = ghost;
        }

        public Ghosts GetLostSoul(string position)
        {
            switch (position.ToUpper())
            {
                case "A6": return lostSouls[0];
                case "A7": return lostSouls[5];
                case "A8": return lostSouls[10];
                case "A9": return lostSouls[15];

                case "B6": return lostSouls[1];
                case "B7": return lostSouls[6];
                case "B8": return lostSouls[11];
                case "B9": return lostSouls[16];

                case "C6": return lostSouls[2];
                case "C7": return lostSouls[7];
                case "C8": return lostSouls[12];
                case "C9": return lostSouls[17];

                case "D6": return lostSouls[3];
                case "D7": return lostSouls[8];
                case "D8": return lostSouls[13];
                case "D9": return lostSouls[18];

                case "E6": return lostSouls[4];
                case "E7": return lostSouls[9];
                case "E8": return lostSouls[14];
            }

            return null;
        }

        public uint CountLostSoulsForPlayer(PlayerFix player)
        {
            uint counter = 0;
            foreach (Ghosts ghost in lostSouls)
                if (ghost.player == player)
                    counter++;

            return counter;
        }

        
        public BoardPiece GetPiece(Position pos)
        {
            return pieces[pos.Row, pos.Col];

        }

        public void render()
        {
            Console.WriteLine("  __[A]_|_[B]_|_[C]_|_[D]_|_[E]__");

            for (uint y = 0; y < height; y++)
            {
                Console.WriteLine("  |     |     |     |     |     |");
                Console.Write($"[{y + 1}] ");
                for (uint x = 0; x < width; x++)
                {
                    if (pieces[y, x] != null)
                        pieces[y, x].Render();
                }

                Console.WriteLine();
                Console.WriteLine("  |__ __|__ __|__ __|__ __|__ __|");
            }

            Console.WriteLine("  |                             |");
            Console.Write("6 |");
            uint counter = 0,
                 uCounter = 6;
            foreach (Ghosts soul in lostSouls)
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
            Console.WriteLine();
            Console.WriteLine("  |_____________________________|");
        }

        public void OnPieceLost(BoardPiece piece)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (pieces[i, j] is Portals portal && portal.color == piece.color)
                    {
                        portal.Turn();
                        UpdatePortal(portal.color);
                        break;
                    }
                }
            }

            if (piece is Ghosts ghost)
                lostSouls.Add(ghost);
        }

        public uint CountMirrors()
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

        private void CheckPortalNeighbour(Portals portal, int x, int y)
        {
            if (pieces[y, x] is Ghosts ghost && ghost.color == portal.color)
            {
                ghost.player.ghostsFree.Add((Ghosts)pieces[y, x]);
                pieces[y, x] = GetBoardSettings(new Position(y, x));
            }
        }

        public void UpdatePortal(ConsoleColor color)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (pieces[i, j] is Portals portal && portal.color == color)
                    {

                        switch (portal.dir)
                        {
                            case Portals.Direction.up:
                                if (i > 0)
                                    CheckPortalNeighbour(portal, j, i - 1);
                                break;
                            case Portals.Direction.down:
                                if (i < height - 1)
                                    CheckPortalNeighbour(portal, j, i + 1);
                                break;
                            case Portals.Direction.left:
                                if (j > 0)
                                    CheckPortalNeighbour(portal, j - 1, i);
                                break;
                            case Portals.Direction.right:
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