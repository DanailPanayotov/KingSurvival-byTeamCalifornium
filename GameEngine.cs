using System;
using System.Collections.Generic;

namespace KingSurvival
{
    public class GameEngine
    {
        public const int GAME_FIELD_SIZE = 8;
        public const int USER_COMMAND_LENGTH = 3;

        private struct TurnMove
        {
            public string Command { get; set; }
            public Figure Figure { get; set; }
            public int XChange { get; set; }
            public int YChange { get; set; }
        }

        public List<Figure> Figures { get; set; }
        public Renderer Renderer { get; set; }
        private TurnMove CurrentMove { get; set; }
        public bool IsKingTurn { get; set; }
        public bool IsKingWinner { get; set; }
        public uint MovesCounter { get; set; }
        public bool IsInvalidMove { get; set; }

        public GameEngine()
        {
            this.Renderer = new Renderer(GAME_FIELD_SIZE);
            this.CurrentMove = new TurnMove();
            this.Figures = new List<Figure>();

            this.Figures.Add(new Pawn(0, 0, 'A'));
            this.Figures.Add(new Pawn(2, 0, 'B'));
            this.Figures.Add(new Pawn(4, 0, 'C'));
            this.Figures.Add(new Pawn(6, 0, 'D'));
            this.Figures.Add(new King(3, 7, 'K'));

            this.IsKingTurn = true;
            this.IsKingWinner = false;
            this.MovesCounter = 0;
            this.IsInvalidMove = false;
        }

        public void Run()
        {
            while (true)
            {
                this.Renderer.Render(this.Figures);

                if (GameOverCheck())
                {
                    Console.WriteLine();
                    Console.WriteLine(this.IsKingWinner ? "King wins in " + this.MovesCounter + " moves!" : "King looses!");
                    break;
                }

                Console.WriteLine();

                if (this.IsInvalidMove)
                {
                    Console.WriteLine("Invalid move! Try again.");
                }

                Console.Write("{0}: ", this.IsKingTurn ? "King's turn" : "Pawns turn");
                string command = Console.ReadLine();

                try
                {
                    CommandParse(command);
                }
                catch (Exception e)
                {
                    this.IsInvalidMove = true;
                    continue;
                }

                if (ValidMoveCheck(CurrentMove))
                {
                    this.CurrentMove.Figure.Move(this.CurrentMove.XChange, this.CurrentMove.YChange);
                    this.IsKingTurn = !this.IsKingTurn;
                    this.IsInvalidMove = false;
                    this.MovesCounter++;
                }
                else
                {
                    IsInvalidMove = true;
                }
            }
        }

        private void CommandParse(string command)
        {
            if (command.Length != USER_COMMAND_LENGTH)
            {
                throw new ArgumentException("Invalid command passed! Try again.");
            }

            TurnMove currentMove = new TurnMove();
            currentMove.Command = command;

            char figureName = Char.Parse(command.Substring(0, 1));
            currentMove.Figure = this.GetFigureByName(figureName);

            if (currentMove.Figure.Equals(null))
            {
                throw new ArgumentNullException("Unexisting figure! Try again.");
            }

            char yDirection = Char.Parse(command.Substring(1, 1));
            currentMove.YChange = GetCoordinateChange(yDirection);

            char xDirection = Char.Parse(command.Substring(2, 1));
            currentMove.XChange = GetCoordinateChange(xDirection);

            this.CurrentMove = currentMove;
        }

        private int GetCoordinateChange(char direction)
        {
            switch (direction)
            {
                case 'U':
                case 'L':
                    return -1;
                case 'D':
                case 'R':
                    return 1;
            }

            throw new ArgumentOutOfRangeException("Wrong direction! Try again.");
        }

        private bool GameOverCheck()
        {
            if (this.GetFigureByName('K').Y == 0)
            {
                this.IsKingWinner = true;
                return true;
            }

            bool isOver = true;

            List<Figure> figuresToMove = this.Figures.FindAll(X => { return this.IsKingTurn ? X is King : X is Pawn; });

            foreach (Figure figure in figuresToMove)
            {
                foreach (string direction in figure.DefaultMoves)
                {
                    CommandParse(direction);

                    if (ValidMoveCheck(this.CurrentMove))
                    {
                        isOver = false;
                        break;
                    }
                }

                if (!isOver)
                {
                    break;
                }
            }

            if (isOver)
            {
                this.IsKingWinner = !this.IsKingTurn;
            }

            return isOver;
        }

        private bool ValidMoveCheck(TurnMove move)
        {
            if (IsKingTurn && (move.Figure is Pawn))
            {
                return false;
            }

            if (!IsKingTurn && (move.Figure is King))
            {
                return false;
            }

            bool isValid = false;

            if (MoveInFieldCheck(move) && MoveOnEmptyCheck(move) && PossibleDirectionCheck(move))
            {
                isValid = true;
            }

            return isValid;
        }

        private bool MoveInFieldCheck(TurnMove move)
        {
            bool isInField = false;

            int newX = move.Figure.X + move.XChange;
            int newY = move.Figure.Y + move.YChange;

            if (newX < GAME_FIELD_SIZE && newY < GAME_FIELD_SIZE)
            {
                if (-1 < newX && -1 < newY)
                {
                    isInField = true;
                }
            }

            return isInField;
        }

        private bool MoveOnEmptyCheck(TurnMove move)
        {
            bool isOnEmptySpace = false;

            int newX = move.Figure.X + move.XChange;
            int newY = move.Figure.Y + move.YChange;

            if (null == this.GetFigureByCoordinates(newX, newY))
            {
                isOnEmptySpace = true;
            }

            return isOnEmptySpace;
        }

        private bool PossibleDirectionCheck(TurnMove move)
        {
            bool isPossible = false;

            string[] avaliableDirections = move.Figure.DefaultMoves;

            if (Array.IndexOf(avaliableDirections, move.Command) != -1)
            {
                isPossible = true;
            }

            return isPossible;
        }

        public Figure GetFigureByName(char name)
        {
            return this.Figures.Find(X => { return X.Name == name; });
        }

        public Figure GetFigureByCoordinates(int x, int y)
        {
            return this.Figures.Find(figure =>
            {
                return (figure.X == x && figure.Y == y);
            });
        }
    }
}
