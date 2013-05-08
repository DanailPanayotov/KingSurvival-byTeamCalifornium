using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSurvival
{
    public class KingFigure : MovingObject
    {
        public KingFigure(MatrixCoords topLeft, MatrixCoords direction)
            : base(topLeft, new char[,] { { 'K' } }, direction)
        {
        }
    }
}
