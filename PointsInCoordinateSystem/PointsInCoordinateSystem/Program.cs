using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace PointsInCoordinateSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var pointsDistanceFromCenterDictionary = new Dictionary<double, List<Point>>();

            using var reader = new StreamReader("Resources/Input.txt");
            
            while (true)
            {
                string line = reader.ReadLine();

                if (line is null)
                {
                    break;
                }

                if (!ValidateInputLine(line))
                {
                    continue;
                }

                char[] separators = { '(', ')' };
                string[] splitedLine = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                string pointName = splitedLine[0];
                string[] pointCoordinates = splitedLine[1].Split(", ");
                double xCoordinate = ParseCoordinate(pointCoordinates[0]);
                double yCoordinate = ParseCoordinate(pointCoordinates[1]);

                Point point = new Point(pointName, xCoordinate, yCoordinate);

                double pointDistanceFromCenter = point.GetStraightLineDistance();

                if (!pointsDistanceFromCenterDictionary.ContainsKey(pointDistanceFromCenter))
                {
                    pointsDistanceFromCenterDictionary[point.GetStraightLineDistance()] = new List<Point>();
                }

                pointsDistanceFromCenterDictionary[point.GetStraightLineDistance()].Add(point);
            }

            double longestDistanceFromCenter = pointsDistanceFromCenterDictionary.Keys.Max();

            using var writer = new StreamWriter("Resources/Output.txt");

            var pointsWithLongestDistanceFromCenter = pointsDistanceFromCenterDictionary[longestDistanceFromCenter].Select(point => point.Name);

            writer.WriteLine($"The point(s) that are farthest from the center (0, 0) in a straight line are: {String.Join(", ", pointsWithLongestDistanceFromCenter)}");

            foreach (var point in pointsDistanceFromCenterDictionary[longestDistanceFromCenter])
            {
                writer.WriteLine(point.GetLocationOnCoordinateSystem());
            }
        }

        public static double ParseCoordinate(string coordinate)
        {
            if (!double.TryParse(coordinate, out _))
            {
                throw new ArgumentException("The coordinate can not be parsed. It must be a number!");
            }

            return double.Parse(coordinate);
        }

        public static bool ValidateInputLine(string inputLine)
        {
            string expression = @"^Point\d+\([-]?\d+(\.\d+)?, [-]?\d+(\.\d+)?\)$";
            return Regex.IsMatch(inputLine, expression);
        }
    }
}
