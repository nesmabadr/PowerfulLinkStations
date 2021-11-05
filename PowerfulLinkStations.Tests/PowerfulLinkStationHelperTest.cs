using System;
using System.Collections.Generic;
using System.Drawing;
using Xunit;

namespace PowerfulLinkStations.Tests
{
    public class PowerfulLinkStationTest
    {
        public static TheoryData CalculatePowerTestData()
        {
            return new TheoryData<Point, KeyValuePair<Point, double>>
            {
                // Happy scenario with a point having a powerful station
                {
                    new Point(0,0),
                    new KeyValuePair<Point, double>(new Point(0,0), 100)
                },

                // No powerful link station
                {
                    new Point(100,100),
                    new KeyValuePair<Point, double>(new Point(), 0)
                }
            };
        }

        [Theory]
        [MemberData(nameof(CalculatePowerTestData))]
        public void TestPowerCalculation(
            Point inputPoint,
            KeyValuePair<Point, double> expected)
        {
            var actualResult = PowerfulLinkStationHelper.CalculatePower(inputPoint);

            Assert.Equal(expected, actualResult);
        }
    }
}
