using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo18Ghosts
{

    public class Battle
    {

        string player1;
        string player2;

        public void PlayAgain()
        {
            Console.WriteLine("Would you like to play?");
            Console.WriteLine();

            string playerChoice = Console.ReadLine();

            if (playerChoice == "yes" || playerChoice == "y" || playerChoice == "Yes" || playerChoice == "Y")
            {
                StartBattle();
                Winner();
            }

            else if (playerChoice == "no" || playerChoice == "n" || playerChoice == "No" || playerChoice == "N")
            {
                //player does not want to play, ending game
                Console.WriteLine("See ya!");
            }

            else
            {
                //prompting player for another entry.
                Console.WriteLine("Invalid entry.");
                Console.WriteLine("Please try again: ");
                playerChoice = Console.ReadLine();
                StartBattle();
                Winner();
            }
        }


        public void Winner()
        {
            /*if (player1 == player2 || player1 != "Red" || player1 != "Yellow" || player1 != "Blue" || player2 != "Red" || player2 != "Yellow" || player2 != "Blue")
		    {
			    Console.WriteLine("You can't fight that color.");
		    }*/


            if (player1 == "y" && player2 == "r")
            {
                Console.WriteLine("Player1 Wins!");
            }


            else if (player2 == "y" && player1 == "r")
            {
                Console.WriteLine("Player2 Wins!");
            }


            else if (player1 == "b" && player2 == "y")
            {
                Console.WriteLine("Player1 Wins!");
            }


            else if (player2 == "b" && player1 == "y")
            {
                Console.WriteLine("Player2 Wins!");
            }


            else if (player1 == "r" && player2 == "b")
            {
                Console.WriteLine("Player1 Wins!");
            }


            else if (player2 == "r" && player1 == "b")
            {
                Console.WriteLine("Player2 Wins!");
            }

            else
            {
                Console.WriteLine("You can't fight that color.");
            }
        }



        public void StartBattle()
        {
            Console.WriteLine("Red(r), Blue(b), or Yellow(y)?");
            player1 = Console.ReadLine();
            player2 = Console.ReadLine();
        }
    }

}



/*//Defenir variaveis


// Saber se dois fantasmas estao na mesma casa

    public abstract class Players
    {
        public string Name { get; set; }
        public abstract GameAction Act();
    }

//if (BlueVSRed)
    public class PlayerRed : Players
    {
        public override GameAction Act()
        {
            return GameAction.Red;
        }
    }

//if (YellowVSRed)
    public class PlayerYellow : Players
    {
        public override GameAction Act()
        {
            return GameAction.Yellow;
        }
    }

// if (BlueVSYellow)
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

    /*public Players PlayMatchUp()
    {

        int result = WinningHand(_player1.Act(), _player2.Act());

        if (_player1.Act() == result)
        {
            return _player1;
        }

        if (_player2.Act() == result)
        {
            return _player2;
        }

        return null;
    }*/


// Ver qual a cor de cada um e resolfer o comflicto

/*private GameAction? WinningHand(GameAction p1, GameAction p2)
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
}*/
