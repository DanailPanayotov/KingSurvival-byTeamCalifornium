using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSurvival
{
    public class MatrixCoords
    {
        private int row;
        private int col;
        
        public int Row 
        {
            get
            {
                return this.row;
            }
            set
            {
                this.row = value;
            }
        }
        public int Col 
        {
            get
            {
                return this.col;
            }
            set
            {
                this.col = value;
            }
        }

        public MatrixCoords()
            : this(0, 0)
        {
        }

        public MatrixCoords(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public static MatrixCoords operator +(MatrixCoords a, MatrixCoords b)
        {
            return new MatrixCoords(a.Row + b.Row, a.Col + b.Col);
        }

        public static MatrixCoords operator -(MatrixCoords a, MatrixCoords b)
        {
            return new MatrixCoords(a.Row - b.Row, a.Col - b.Col);
        }

        public override bool Equals(object obj)
        {
            MatrixCoords objAsMatrixCoords = obj as MatrixCoords;

            return objAsMatrixCoords.Row == this.Row && objAsMatrixCoords.Col == this.Col;
        }
    }
}
