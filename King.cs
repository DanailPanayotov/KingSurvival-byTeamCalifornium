// ********************************
// <copyright file="King.cs" company="Team Californium">
// Copyright (c) 2013 Team Californium. All rights reserved.
// </copyright>
//
// ********************************
namespace KingSurvival
{
    using System;
    using System.Linq;

    /// <summary>
    /// Class King which creates King objects with X and Y coordinates.
    /// </summary>
    public class King
    {
        /// <summary>
        /// Keeps X coordinate for the Pawn object.
        /// </summary>
        private int x;

        /// <summary>
        /// Keeps Y coordinate for the Pawn object.
        /// </summary>
        private int y;

        /// <summary>
        /// Initializes a new instance of the <see cref="King" /> class 
        /// with coordinates (0, 0).
        /// </summary>
        public King()
        {
            this.x = 0;
            this.y = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="King" /> class 
        /// with coordinates (<paramref name="x"/>, <paramref name="y"/>).
        /// </summary>
        /// <param name="x">X coordinate for King object</param>
        /// <param name="y">Y coordinate for King object</param>
        public King(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Gets or sets X coordinate.
        /// </summary>
        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        /// <summary>
        /// Gets or sets Y coordinate.
        /// </summary>
        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
    }
}
