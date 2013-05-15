// ********************************
// <copyright file="Renderer.cs" company="Team Californium">
// Copyright (c) 2013 Team Californium. All rights reserved.
// </copyright>
//
// ********************************
namespace KingSurvival
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Creates new renderer instance to render game field on the console.
    /// </summary>
    public class Renderer
    {
        /// <summary>
        /// Holds field objects (figures, and empty cells). 
        /// </summary>
        private readonly char[,] field;
        private readonly int fieldSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="Renderer"/> class,
        /// by given size of the field to be rendered.
        /// </summary>
        public Renderer(int fieldSize)
        {
            this.fieldSize = fieldSize;
            this.field = new char[this.fieldSize, this.fieldSize];
        }

        /// <summary>
        /// Renders the field on the console.
        /// </summary>
        /// <param name="figures">List of all figures in the field.</param>
        public void Render(List<Figure> figures)
        {
            this.InitField();
            this.RenderObjects2Field(figures);

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
                    if (this.IsEven(i + j))
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

        private bool IsEven(int number)
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
