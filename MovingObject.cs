using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSurvival
{
    public class MovingObject : GameObject
    {
        public MatrixCoords Direction { get; protected set; }

        public MovingObject(MatrixCoords topLeft, char[,] body, MatrixCoords direction)
            : base(topLeft, body)
        {
            this.Direction = direction;
        }

        protected virtual void UpdatePosition()
        {
            this.TopLeft += this.Direction;
        }

        public override void Update()
        {
            this.UpdatePosition();
        }
    }
}
