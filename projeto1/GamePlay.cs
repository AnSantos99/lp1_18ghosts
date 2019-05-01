using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo18Ghosts
{
    //Defenir variaveis


    // Saber se dois fantasmas estao na mesma casa


    // Ver qual a cor de cada um 
    public abstract class Players
    {
        public string Name { get; set; }
        public abstract GameAction Act();
    }

    public class PlayerRed : Players
    {
        public override GameAction Act()
        {
            return GameAction.Red;
        }
    }

    public class PlayerYellow : Players
    {
        public override GameAction Act()
        {
            return GameAction.Yellow;
        }
    }

    public class PlayerBlue : Players
    {
        public override GameAction Act()
        {
            return GameAction.Blue;
        }
    }

    public enum GameAction
    {
        Blue,
        Yellow,
        Red
    }


    // Saber os resultados

    public class Battle
    {
        private readonly Players _player1;
        private readonly Players _player2;

        public Battle(Players player1, Players player2)
        {
            this._player1 = player1;
            this._player2 = player2;
        }

        public Players PlayMatchUp()
        {

            var result = WinningHand(_player1.Act(), _player2.Act());

            if (_player1.Act() == result)
            {
                return _player1;
            }

            if (_player2.Act() == result)
            {
                return _player2;
            }

            return null;
        }


        // Resolfer o comflicto

        private GameAction? WinningHand(GameAction p1, GameAction p2)
        {
            //P1 wins with yellow
            if (p1 == GameAction.Yellow && p2 == GameAction.Red)
            {
                return GameAction.Yellow;
            }

            //P2 wins with blue
            if (p1 == GameAction.Yellow && p2 == GameAction.Blue)
            {
                return GameAction.Blue;
            }

            //P1 wins with blue
            if (p1 == GameAction.Blue && p2 == GameAction.Yellow)
            {
                return GameAction.Blue;
            }

            //P2 wins with red
            if (p1 == GameAction.Blue && p2 == GameAction.Red)
            {
                return GameAction.Red;
            }

            //P2 wins with yellow
            if (p1 == GameAction.Red && p2 == GameAction.Yellow)
            {
                return GameAction.Yellow;
            }

            //P1 wins with Red
            if (p1 == GameAction.Red && p2 == GameAction.Blue)
            {
                return GameAction.Red;
            }

            return null;
        }


    }
}
