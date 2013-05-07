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
                if (value > 7 || value < 0)
                {
                    throw new ArgumentOutOfRangeException("The row coord should be between 0-7");
                }
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
                if (value > 7 || value < 0)
                {
                    throw new ArgumentOutOfRangeException("The col coord should be between 0-7");
                }
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
    }
}
