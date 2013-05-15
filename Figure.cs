// ********************************
// <copyright file="Figure.cs" company="Team Californium">
// Copyright (c) 2013 Team Californium. All rights reserved.
// </copyright>
//
// ********************************
namespace KingSurvival
{
    using System;

    /// <summary>
    /// Creates a game's figures.
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Figure's coordinate by X-axis.
        /// </summary>
        private int x;

        /// <summary>
        /// Figure's coordinate by Y-axis.
        /// </summary>
        private int y;

        private char name;
        private string[] defaultMoves;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Figure"/> class, 
        /// by given coordinate by X-axis and Y-axis and name.
        /// </summary>
        public Figure(int x, int y, char name)
        {
            this.X = x;
            this.Y = y;
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets figure's coordinate by X-axis.
        /// </summary>
        public int X
        {
            get { return this.x; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("coord must be >=0");
                }
                else
                {
                    this.x = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets figure's coordinate by Y-axis.
        /// </summary>
        public int Y
        {
            get { return this.y; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("coord must be >=0");
                }
                else
                {
                    this.y = value;
                }
            }
        }

        public char Name
        {
            get { return this.name; }
            set 
            {
                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets figure's default moves.
        /// </summary>
        public string[] DefaultMoves
        {
            get
            {
                int defaultMovesCount = this.defaultMoves.Length;
                string[] actualMoves = new string[defaultMovesCount];

                for (int i = 0; i < defaultMovesCount; i++)
                {
                    actualMoves[i] = this.name + this.defaultMoves[i];
                }

                return actualMoves;
            }

            protected set { this.defaultMoves = value; }
        }

        /// <summary>
        /// Moves a figure by given X-axis coordinate change,
        /// and X-axis coordinate change.
        /// </summary>
        public void Move(int xChange, int yChange)
        {
            this.X += xChange;
            this.Y += yChange;
        }
    }
}
