﻿using System;

namespace KingSurvival
{
    public abstract class Figure
    {
        private int x;
        private int y;
        private char name;
        private string[] defaultMoves;

        public int X
        {
            get { return this.x; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("coord must be >=0");
                }
                else
                {
                    this.x = value;
                }
            }
        }

        public int Y
        {
            get { return this.y; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("coord must be >=0");
                }
                else
                {
                    this.y = value;
                }
            }
        }

        public char Name
        {
            get { return this.name; }
            set 
            {
                if (value==null||value==string.Empty)
                {
                    throw new ArgumentNullException("type in name");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public Figure(int x, int y, char name)
        {
            this.X = x;
            this.Y = y;
            this.Name = name;
        }

        public string[] DefaultMoves
        {
            get
            {
                int defaultMovesCount = this.defaultMoves.Length;
                string[] actualMoves = new string[defaultMovesCount];

                for (int i = 0; i < defaultMovesCount; i++)
                {
                    actualMoves[i] = this.name + this.defaultMoves[i];
                }

                return actualMoves;
            }
            protected set { this.defaultMoves = value; }
        }

        public void Move(int xChange, int yChange)
        {
            this.X += xChange;
            this.Y += yChange;
        }
    }
}
