using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSurvival
{

    // this class represents the coordinates of the figure of the king 

    public class KingFigure
    {
        private MatrixCoords kingMatrixCoords;

        // the constructor with zero arguments sets the position to origin (0,0)
        public KingFigure()
            : this(new MatrixCoords())
        {
        }

        public KingFigure(MatrixCoords matrixCoords)
        {
            this.KingMatrixCoords.Row = matrixCoords.Row;
            this.KingMatrixCoords.Col = matrixCoords.Col;
        }

        public MatrixCoords KingMatrixCoords
        {
            get 
            { 
                return this.kingMatrixCoords; 
            }
            set 
            {
                this.kingMatrixCoords = value;
            }
        }
      
    }
}
