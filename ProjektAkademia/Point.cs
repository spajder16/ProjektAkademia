﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektAkademia
{
    public class Point
    {
        public double x { get; set; }
        public double y { get; set; }
        public Point() { }
        public Point(double _x, double _y)
        {
            this.x = _x;
            this.y = _y;
        }
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.x + p2.x, p1.y + p2.y);
        }
        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.x - p2.x, p1.y - p2.y);
        }
        public static Point operator /(Point p1, double p2)
        {
            return new Point(p1.x / p2, p1.y / p2);
        }
    }
}