using System;
using System.Text;

namespace Jogo18Ghosts
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            /*//Asks Player Names
            Console.WriteLine("Tell me your names Player 1, Player 2.");

            var player1 = new PlayerYellow()
            {
                Name = Console.ReadLine()


            /*//Asks Player Names
           Console.WriteLine("Tell me your names Player 1, Player 2.");
           var player1 = new PlayerYellow()
           {
               Name = Console.ReadLine()
           };
           var player2 = new PlayerBlue()
           {
               Name = Console.ReadLine()
           };
           //Prints who Won and who can interact with who 
           var winner = new Battle(player1, player2).PlayMatchUp();
           if (winner == null)
           {
               Console.WriteLine("You cannot fight him.");
           }
           else
           {
               Console.WriteLine("The Winner of this battle is {0}", winner.Name);
           }
           Console.ReadKey();
           Console.OutputEncoding = Encoding.UTF8;
           GameBoard board;
           board = new GameBoard();
           board.Board();*/



            //allowing the use of UNICODE on the console
            Console.OutputEncoding = Encoding.UTF8;

            //initialising variables related to each class needed
            GameBoard board;
            WinChecker winChecker;
            Renderer renderer;
            PlayerFix player1;
            PlayerFix player2;
           

            //declaring the variables
            board = new GameBoard();
            winChecker = new WinChecker();
            renderer = new Renderer();





            player1 = new PlayerFix();
            player2 = new PlayerFix();

            //initializing the game cycle until a player has won or quit the game
            do
            {
                //draw the board on the console
                renderer.Render(board);


                //get current player's next move
                Position nextMove;

                //change the current player's choice
                if (board.NextTurn == State.P1)
                    nextMove = player1.GetPosition(board);
                else
                    nextMove = player2.GetPosition(board);

                if (!board.SetState(nextMove, board.NextTurn))
                    Console.WriteLine("There's already a ghost there!!");

            board.Board();*/


            }
            //run while noone has won nor tied
            while ((!winChecker.IsDraw(board) && winChecker.Check(board) == State.Undecided));

            //final render of the board and results
            renderer.Render(board);
            renderer.RenderResults(winChecker.Check(board));

            //play again?
        }

    }
}
