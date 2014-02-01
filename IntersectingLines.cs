using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given two lines in Cartesian plane, determine whether 
// the two lines would intersect

namespace IntersectingLines
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class Line
    {
        double X;
        double Y;

        double margin = 0.00001;

        public double Slope { get; private set; }

        public double YIntercept { get; private set; }

        public Line(double x, double y, double m, double c)
        {
            Slope = m;
            YIntercept = c;
            X = x;
            Y = y;
        }

        // 2 lines intersect if they have differen slopes OR
        // if they have the same y intercept in which case they are 
        // the same line

        // NOTE: For double values, it is better to use a margin instead
        // of the Double.Equals method since we have more options to define how much
        // of a margin is acceptable instead of relying on .Net's precision margin
        bool Intersects(Line other)
        {
            if (Math.Abs(other.Slope - Slope) > margin  || 
                Math.Abs(other.YIntercept - YIntercept) <= margin)
            {
                return true;
            }

            return false;
        }
    }
}
