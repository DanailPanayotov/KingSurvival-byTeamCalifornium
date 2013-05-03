using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSurvival
{
    public abstract class Figure
    {
       private int x;
       private int y;
       
        public Figure(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public virtual void MoveFigure(int nextX, int nextY)
        {
            this.X += nextX;
            this.Y += nextY;
        }
    }
}
