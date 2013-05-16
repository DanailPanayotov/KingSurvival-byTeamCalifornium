// ********************************
// <copyright file="GameEngine.cs" company="Team Californium">
// Copyright (c) 2013 Team Californium. All rights reserved.
// </copyright>
//
// ********************************
namespace KingSurvival
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Holds the Run() method for the game.
    /// </summary>
    public class GameEngine
    {        
        public const int GAME_FIELD_SIZE = 8;
        public const int USER_COMMAND_LENGTH = 3;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEngine"/> class.
        /// </summary>
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

        public List<Figure> Figures { get; set; }
        public Renderer Renderer { get; set; }
        public bool IsKingTurn { get; set; }
        public bool IsKingWinner { get; set; }
        public uint MovesCounter { get; set; }
        public bool IsInvalidMove { get; set; }
        private TurnMove CurrentMove { get; set; }

        /// <summary>
        /// Provides logic of the game.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                this.Renderer.Render(this.Figures);

                if (this.GameOverCheck())
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
                    this.CommandParse(command);
                }
                catch (Exception e)
                {
                    this.IsInvalidMove = true;
                    continue;
                }

                if (this.ValidMoveCheck(this.CurrentMove))
                {
                    this.CurrentMove.Figure.Move(this.CurrentMove.XChange, this.CurrentMove.YChange);

                    if (this.IsKingTurn)
                    {
                        this.MovesCounter++;
                    }

                    this.IsKingTurn = !this.IsKingTurn;
                    this.IsInvalidMove = false;
                }
                else
                {
                    this.IsInvalidMove = true;
                }
            }
        }

        /// <summary>
        /// Gets figure by given character, if figure with such name exists in the list of figures.
        /// </summary>
        public Figure GetFigureByName(char name)
        {
            return this.Figures.Find(X => { return X.Name == name; });
        }

        /// <summary>
        /// Gets figure by given coodinates, if figure with such coordinates exists in the list of figures.
        /// </summary>
        public Figure GetFigureByCoordinates(int x, int y)
        {
            return this.Figures.Find(figure =>
            {
                return (figure.X == x && figure.Y == y);
            });
        }

        /// <summary>
        /// Checks if the game is over in these conditions:
        /// -king has reached row zero;
        /// -figures has no valid moves e.g. pawsn have surrounded the king;
        /// </summary>
        public bool GameOverCheck()
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
                    this.CommandParse(direction);

                    if (this.ValidMoveCheck(this.CurrentMove))
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

        /// <summary>
        /// Checks if current move is valid.A move is valid when:
        /// -the coordinates of the position to move are inside the field;
        /// -the the coordinates of the position to move are empty/free;
        /// -the direction of the move of current figure is allowed;
        /// </summary>
        public bool ValidMoveCheck(TurnMove move)
        {
            if (this.IsKingTurn && (move.Figure is Pawn))
            {
                return false;
            }

            if (!this.IsKingTurn && (move.Figure is King))
            {
                return false;
            }

            bool isValid = false;

            if (this.MoveInFieldCheck(move) && this.MoveOnEmptyCheck(move) && this.PossibleDirectionCheck(move))
            {
                isValid = true;
            }

            return isValid;
        }

        /// <summary>
        /// Parses current command.A command is correct when:
        /// -it's length is equal to 3 (e.g. KUL,ADR...);
        /// -the first letter of the command is valid character for figure;
        /// </summary>
        public void CommandParse(string command)
        {
            if (command.Length != USER_COMMAND_LENGTH)
            {
                throw new ArgumentException("Invalid command passed! Try again.");
            }

            TurnMove currentMove = new TurnMove();
            currentMove.Command = command;

            char figureName = char.Parse(command.Substring(0, 1));
            currentMove.Figure = this.GetFigureByName(figureName);

            if (currentMove.Figure==null)
            {
                throw new ArgumentNullException("Unexisting figure! Try again.");
            }

            char yDirection = char.Parse(command.Substring(1, 1));
            currentMove.YChange = this.GetCoordinateChange(yDirection);

            char xDirection = char.Parse(command.Substring(2, 1));
            currentMove.XChange = this.GetCoordinateChange(xDirection);

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

        /// <summary>
        /// Hold all information needed for the move.
        /// </summary>
        public struct TurnMove
        {
            public string Command { get; set; }
            public Figure Figure { get; set; }
            public int XChange { get; set; }
            public int YChange { get; set; }
        }
    }
}
