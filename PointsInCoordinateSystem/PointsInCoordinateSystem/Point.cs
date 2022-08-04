using System;

namespace PointsInCoordinateSystem
{
    public class Point
    {
        public Point(string name, double xCoordinate, double yCoordinate)
        {
            Name = name;
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public string Name { get; }
        public double XCoordinate { get; }
        public double YCoordinate { get; }

        public double GetStraightLineDistance()
        {
            return Math.Sqrt(Math.Pow(XCoordinate, 2) + Math.Pow(YCoordinate, 2));
        }

        public string GetLocationOnCoordinateSystem()
        {
            string message = "";

            if (XCoordinate > 0 && YCoordinate > 0)
            {
                message = this.ToString() + " lies in the First quadrant.";
            }
            else if (XCoordinate < 0 && YCoordinate > 0)
            {
                message = this.ToString() + " lies in the Second quadrant.";
            }
            else if (XCoordinate < 0 && YCoordinate < 0)
            {
                message = this.ToString() + " lies in the Third quadrant.";
            }
            else if (XCoordinate > 0 && YCoordinate < 0)
            {
                message = this.ToString() + " lies in the Fourth quadrant.";
            }
            else if (XCoordinate == 0 && YCoordinate == 0)
            {
                message = this.ToString() + " lies at the origin of the coordinate system.";
            }
            else if (XCoordinate == 0 && YCoordinate != 0)
            {
                message = this.ToString() + " lies on the Y-axis";
            }
            else if (XCoordinate != 0 && YCoordinate == 0)
            {
                message = this.ToString() + " lies on the X-axis";
            }

            return message;
        }

        public override string ToString()
        {
            return $"{Name}({XCoordinate}, {YCoordinate})";
        }
    }
}