// ********************************
// <copyright file="Pawn.cs" company="Team Californium">
// Copyright (c) 2013 Team Californium. All rights reserved.
// </copyright>
//
// ********************************
namespace KingSurvival
{
    using System;

    public class Pawn
        : Figure
    {
        public Pawn(int x, int y, char name)
            : base(x, y, name)
        {
            this.DefaultMoves = new string[2] { "DR", "DL" };
        }
    }
}