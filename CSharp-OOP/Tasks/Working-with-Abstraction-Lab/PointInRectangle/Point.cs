﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Point_in_Rectangle
{
    public class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
