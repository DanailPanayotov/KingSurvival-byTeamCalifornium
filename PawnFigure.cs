using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSurvival
{
    // this class represents the coordinates of the figure of a Pawn 

    public class PawnFigure
    {
        private MatrixCoords pawnMatrixCoords;

        // the constructor with zero arguments sets the position to origin (0,0)
        public PawnFigure()
            : this(new MatrixCoords())
        {
        }

        public PawnFigure(MatrixCoords matrixCoords)
        {
            this.PawnMatrixCoords.Row = matrixCoords.Row;
            this.PawnMatrixCoords.Col = matrixCoords.Col;
        }

        public MatrixCoords PawnMatrixCoords
        {
            get 
            { 
                return this.pawnMatrixCoords; 
            }
            set 
            {
                this.pawnMatrixCoords = value;
            }
        }
      
    }
}