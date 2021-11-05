using System;
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

            float xCoordinate = float.Parse(pointCoordinates.Substring(1, pointCoordinates.IndexOf(',') - 1));
            float yCoordinate = float.Parse(pointCoordinates.Substring(pointCoordinates.IndexOf(',') + 1, pointCoordinates.IndexOf(')') - pointCoordinates.IndexOf(',') - 1)); ;
        }
    }
}
