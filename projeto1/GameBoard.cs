using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo18Ghosts
{
    internal class GameBoard
    {
        private State[,] state;
        public State NextTurn { get; private set; }

        public GameBoard()
        {
            state = new State[5, 5];
            NextTurn = State.P1;
        }

        public State GetState(Position position)
        {
            return state[position.Row, position.Col];
        }

        public bool SetState(Position position, State newState)
        {
            if (newState != NextTurn) return false;
            if (state[position.Row, position.Col] != State.Undecided) return false;

            state[position.Row, position.Col] = newState;
            SwitchNextTurn();
            return true;
        }

        private void SwitchNextTurn()
        {
            if (NextTurn == State.P1) NextTurn = State.P2;
            else NextTurn = State.P1;
        }
     }
 }