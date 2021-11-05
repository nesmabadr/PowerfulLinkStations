using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace PowerfulLinkStations
{
    public class PowerfulLinkStation
    {
        public static void Main(string[] args)
        {
            bool retryInput;
            string pointCoordinates;

            do
            {
                Console.WriteLine("Please input the point coordinates in the following format: (x,y)");
                pointCoordinates = Console.ReadLine();

                if (!Regex.IsMatch(pointCoordinates, "\\(\\d+.*\\d*,\\d+.*\\d*\\)"))
                {
                    Console.WriteLine($"The input point {pointCoordinates} is not in the correct format. Please make sure to have the point with the following format: (x,y)");
                    Console.WriteLine($"Do you want to enter a new value or exit the program? y or n");

                    var retry = Console.ReadLine();
                    retryInput = retry == "y" ? true : false;

                    if (!retryInput)
                    {
                        Environment.Exit(0);
                    }
                }
                else
                {
                    retryInput = false;
                }

            } while (retryInput);

            var xCoordinate = int.Parse(pointCoordinates.Substring(1, pointCoordinates.IndexOf(',') - 1));
            var yCoordinate = int.Parse(pointCoordinates.Substring(pointCoordinates.IndexOf(',') + 1, pointCoordinates.IndexOf(')') - pointCoordinates.IndexOf(',') - 1)); ;

            var inputPoint = new Point(xCoordinate, yCoordinate);
            var powerAndLinkStation = PowerfulLinkStationHelper.CalculatePower(inputPoint);

            if (powerAndLinkStation.Value == 0)
            {
                Console.WriteLine($"No link station within reach for point {inputPoint.X},{inputPoint.Y}");
            }
            else
            {
                Console.WriteLine($"“Best link station for point {inputPoint.X},{inputPoint.Y} is {powerAndLinkStation.Key.X},{powerAndLinkStation.Key.Y} with power {powerAndLinkStation.Value}");
            }
        }
    }
}
