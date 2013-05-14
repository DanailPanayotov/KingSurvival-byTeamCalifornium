using System;
using System.Collections.Generic;

namespace KingSurvival
{
    public class Renderer
    {
        private char[,] field;
        private int fieldSize;

        public Renderer(int fieldSize)
        {
            this.fieldSize = fieldSize;
            this.field = new char[this.fieldSize, this.fieldSize];
        }

        public void Render(List<Figure> figures)
        {
            InitField();
            RenderObjects2Field(figures);

            Console.Clear();

            for (int i = 0; i < this.fieldSize; i++)
            {
                for (int j = 0; j < this.fieldSize; j++)
                {
                    Console.Write("{0,2}", this.field[i, j]);
                }

                Console.WriteLine();
            }
        }

        private void InitField()
        {
            for (int i = 0; i < this.fieldSize; i++)
            {
                for (int j = 0; j < this.fieldSize; j++)
                {
                    if (isEven(i + j))
                    {
                        this.field[i, j] = '+';
                    }
                    else
                    {
                        this.field[i, j] = '-';
                    }
                }
            }
        }

        private void RenderObjects2Field(List<Figure> figures)
        {
            foreach (Figure figure in figures)
            {
                this.field[figure.Y, figure.X] = figure.Name;
            }
        }

        private bool isEven(int number)
        {
            bool isEven = false;

            if (number % 2 == 0)
            {
                isEven = true;
            }

            return isEven;
        }
    }
}
