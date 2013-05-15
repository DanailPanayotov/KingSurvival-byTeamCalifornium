// ********************************
// <copyright file="King.cs" company="Team Californium">
// Copyright (c) 2013 Team Californium. All rights reserved.
// </copyright>
//
// ********************************
namespace KingSurvival
{
    using System;

    public class King
        : Figure
    {
        public King(int x, int y, char name)
            : base(x, y, name)
        {
            this.DefaultMoves = new string[4] { "DL", "DR", "UL", "UR" };
        }
    }
}
