using System;
using System.Linq;

namespace KingSurvival
{
    public class GameField
    {
        private const int MATRIX_SIZE = 8;
        private char[,] matrix;
        public bool isKingTurn = false;

        public char[,] Matrix
        {
            get
            {
                return new char[,]   {
                    {'+','-','+','-','+','-','+','-'},
                    {'-','+','-','+','-','+','-','+'},
                    {'+','-','+','-','+','-','+','-'},
                    {'-','+','-','+','-','+','-','+'},
                    {'+','-','+','-','+','-','+','-'},
                    {'-','+','-','+','-','+','-','+'},
                    {'+','-','+','-','+','-','+','-'},
                    {'-','+','-','+','-','+','-','+'}
                 };
            }
        }

        public void PrintGameField(char[,] matrix)
        {
            Console.Clear();
            for (int i = 0; i < MATRIX_SIZE; i++)
            {
                for (int j = 0; j < MATRIX_SIZE; j++)
                {

                    Console.Write("{0,2}", matrix[i, j]);
                }
                Console.WriteLine("");
            }
        }

        private bool IsMoveCoordinatesProper(Figure figure, int nextX, int nextY, char[,] matrix)
        {
            if (figure.X + nextX < 0 || figure.X + nextX > MATRIX_SIZE - 1)
            {
                return false;
            }

            if (figure.Y + nextY < 0 || figure.Y + nextY > MATRIX_SIZE - 1)
            {
                return false;
            }
            return true;
        }

        private bool IsCoordinatesAvailable(Figure figure, int nextX, int nextY, char[,] matrix)
        {
            if (matrix[figure.X + nextX, figure.Y + nextY] != '+' && matrix[figure.X + nextX, figure.Y + nextY] != '-')
            {
                return false;
            }
            return true;
        }

        public void MoveKing(Figure figure, int nextX, int nextY, char[,] matrix)
        {
            matrix[figure.X, figure.Y] = '-';
            matrix[figure.X + nextX, figure.Y + nextY] = 'K';
            figure.MoveFigure(nextX, nextY);
        }

        public void MovePawn(Figure figure, int nextX, int nextY, char[,] matrix)
        {
            char pawnLetter=' ';
            if (matrix[figure.X, figure.Y] == 'A')
            {
                pawnLetter = 'A';
            }
            else if (matrix[figure.X, figure.Y] == 'B')
            {
                pawnLetter = 'B';
            }
            else if (matrix[figure.X, figure.Y] == 'C')
            {
                pawnLetter = 'C';
            }
            else 
            {
                pawnLetter = 'D';
            }

            matrix[figure.X, figure.Y] = '-';
            matrix[figure.X + nextX, figure.Y + nextY] = pawnLetter;
            figure.MoveFigure(nextX, nextY);
            
        }

        public bool CanMoveFugire(Figure figure, int nextX, int nextY, char[,] matrix)
        {

            if ((IsMoveCoordinatesProper(figure, nextX, nextY, matrix)) && (IsCoordinatesAvailable(figure, nextX, nextY, matrix)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsNextPawnPositionKing(Figure figure, int nextX, int nextY, char[,] matrix)
        {
            if (IsMoveCoordinatesProper(figure, nextX, nextY, matrix))
            {
                if (matrix[figure.X + nextX, figure.Y + nextY] == 'K')
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsPawnAWinner(Figure figure, int nextX, int nextY, char[,] matrix)
        {
            if (this.IsNextPawnPositionKing(figure, nextX, nextY, matrix))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}   