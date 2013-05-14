using System;

namespace KingSurvival
{
    class King
        : Figure
    {
        public King(int x, int y, char name)
            : base(x, y, name)
        {
            this.DefaultMoves = new string[4] { "DL", "DR", "UL", "UR" };
        }
    }
}
