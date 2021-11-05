
using System;
using System.Collections.Generic;
using System.Drawing;

namespace PowerfulLinkStations
{
    public static class PowerfulLinkStationHelper
    {
        private static readonly Dictionary<Point, int> linkStationsReach = new Dictionary<Point, int>
        {
            {new Point(0, 0) , 10},
            {new Point(20, 20) , 5},
            {new Point(10, 0) , 12}
        };

        public static KeyValuePair<Point, double> CalculatePower(Point userPoint)
        {
            double maxPower = 0;
            Point linkStationPoint = new Point();
            foreach (var linkStation in linkStationsReach)
            {
                var distance = Math.Sqrt(Math.Pow(userPoint.X - linkStation.Key.X, 2) + Math.Pow(userPoint.Y - linkStation.Key.Y, 2));
                if (distance > linkStation.Value)
                {
                    continue;
                }

                var power = Math.Pow(linkStation.Value - distance, 2);
                if (power > maxPower)
                {
                    maxPower = power;
                    linkStationPoint = linkStation.Key;
                }
            }

            return new KeyValuePair<Point, double>(linkStationPoint, maxPower);
        }
    }
}
