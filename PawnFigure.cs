using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSurvival
{
    public class PawnFigure:MovingObject
    {
       public PawnFigure(MatrixCoords topLeft,char [,] body, MatrixCoords direction)
            : base(topLeft, body, direction)
        {
        }
    }
}