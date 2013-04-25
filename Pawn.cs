// ********************************
// <copyright file="Pawn.cs" company="Team Californium">
// Copyright (c) 2013 Team Californium. All rights reserved.
// </copyright>
//
// ********************************
namespace KingSurvival
{
    using System;
    using System.Linq;

    /// <summary>
    /// Class Pawn which creates Pawn objects with X and Y coordinates.
    /// </summary>
    public class Pawn
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
        /// Initializes a new instance of the <see cref="Pawn" /> class 
        /// with coordinates (0, 0).
        /// </summary>
        public Pawn()
        {
            this.x = 0;
            this.y = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pawn" /> class 
        /// with coordinates (<paramref name="x"/>, <paramref name="y"/>).
        /// </summary>
        /// <param name="x">X coordinate for Pawn object</param>
        /// <param name="y">Y coordinate for Pawn object</param>
        public Pawn(int x, int y)
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
