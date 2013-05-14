using System;

namespace KingSurvival
{
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