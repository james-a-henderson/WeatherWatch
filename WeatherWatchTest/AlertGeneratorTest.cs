using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WeatherWatch;

namespace WeatherWatchTest
{
    [TestClass]
    public class AlertGeneratorTest
    {
        [TestMethod]
        public void NoAlerts_ReturnsEmptyList()
        {
            List<string> expected = new List<string>();

            DateTime date = new DateTime(2018, 3, 10);

            var result = AlertGenerator.generateAlerts(new Forcast(date, 40, 50, "Nothing"));
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LowTempLessThan32_GeneratesFreezingTempAlert()
        {
            List<string> expected = new List<string> { "Freezing Temperature Alert for Saturday, March 10" };

            DateTime date = new DateTime(2018, 3, 10);

            var result1 = AlertGenerator.generateAlerts(new Forcast(date, 0, 50, "Nothing"));
            CollectionAssert.AreEqual(expected, result1);

            var result2 = AlertGenerator.generateAlerts(new Forcast(date, 20, 70, "Nothing"));
            CollectionAssert.AreEqual(expected, result2);

            var result3 = AlertGenerator.generateAlerts(new Forcast(date, -60, -40, "Nothing"));
            CollectionAssert.AreEqual(expected, result2);
        }

        [TestMethod]
        public void LowTempAt32_GeneratesFreezingTempAlert()
        {
            List<string> expected = new List<string> { "Freezing Temperature Alert for Saturday, March 10" };

            DateTime date = new DateTime(2018, 3, 10);

            var result = AlertGenerator.generateAlerts(new Forcast(date, 32, 50, "Nothing"));
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void HighTempAbove85_GeneratesHighHeatAlert()
        {
            List<string> expected = new List<string> { "High Heat Alert for Saturday, March 10" };

            DateTime date = new DateTime(2018, 3, 10);

            var result1 = AlertGenerator.generateAlerts(new Forcast(date, 50, 90, "Nothing"));
            CollectionAssert.AreEqual(expected, result1);

            var result2 = AlertGenerator.generateAlerts(new Forcast(date, 70, 120, "Nothing"));
            CollectionAssert.AreEqual(expected, result2);

            var result3 = AlertGenerator.generateAlerts(new Forcast(date, 90, 150, "Nothing"));
            CollectionAssert.AreEqual(expected, result2);
        }

        [TestMethod]
        public void HighTempAt85_GeneratesHighHeatAlert()
        {
            List<string> expected = new List<string> { "High Heat Alert for Saturday, March 10" };

            DateTime date = new DateTime(2018, 3, 10);

            var result = AlertGenerator.generateAlerts(new Forcast(date, 50, 85, "Nothing"));
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LowTempBelow32_And_HighTempAbove85_GeneratesTwoAlerts()
        {
            List<string> expected = new List<string> { "Freezing Temperature Alert for Saturday, March 10",
                                                        "High Heat Alert for Saturday, March 10"};

            DateTime date = new DateTime(2018, 3, 10);

            var result = AlertGenerator.generateAlerts(new Forcast(date, 30, 90, "Nothing"));
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The Low Temperature cannot be higher than the high temperature")]
        public void LowTemp_AboveHighTemp_ThrowsException()
        {
            DateTime date = new DateTime(2018, 3, 10);

            var result = AlertGenerator.generateAlerts(new Forcast(date, 70, 60, "Nothing"));
        }

        [TestMethod]
        public void ForcastContainsRain_GeneratesRainAlert()
        {
            List<string> expected = new List<string> { "Rain Alert for Saturday, March 10" };

            DateTime date = new DateTime(2018, 3, 10);

            var result1 = AlertGenerator.generateAlerts(new Forcast(date, 50, 70, "Rain"));
            CollectionAssert.AreEqual(expected, result1);

            var result2 = AlertGenerator.generateAlerts(new Forcast(date, 50, 70, "light rain"));
            CollectionAssert.AreEqual(expected, result2);

            var result3 = AlertGenerator.generateAlerts(new Forcast(date, 50, 70, "Heavy Rain"));
            CollectionAssert.AreEqual(expected, result2);
        }

        [TestMethod]
        public void ForcastContainsThunderstorm_GeneratesThunderstormAlert()
        {
            List<string> expected = new List<string> { "Thunderstorm Alert for Saturday, March 10" };

            DateTime date = new DateTime(2018, 3, 10);

            var result1 = AlertGenerator.generateAlerts(new Forcast(date, 50, 70, "Thunderstorms"));
            CollectionAssert.AreEqual(expected, result1);

            var result2 = AlertGenerator.generateAlerts(new Forcast(date, 50, 70, "Scattered Thunderstorms"));
            CollectionAssert.AreEqual(expected, result2);

            var result3 = AlertGenerator.generateAlerts(new Forcast(date, 50, 70, "Heavy Thunderstorm"));
            CollectionAssert.AreEqual(expected, result2);
        }

        [TestMethod]
        public void ForcastContainsSnow_GeneratesSnowAlert()
        {
            List<string> expected = new List<string> { "Snow Alert for Saturday, March 10" };

            DateTime date = new DateTime(2018, 3, 10);

            var result1 = AlertGenerator.generateAlerts(new Forcast(date, 50, 70, "Snow"));
            CollectionAssert.AreEqual(expected, result1);

            var result2 = AlertGenerator.generateAlerts(new Forcast(date, 50, 70, "light snow"));
            CollectionAssert.AreEqual(expected, result2);

            var result3 = AlertGenerator.generateAlerts(new Forcast(date, 50, 70, "Scattered Snow"));
            CollectionAssert.AreEqual(expected, result2);
        }

        [TestMethod]
        public void ForcastContainsIce_GeneratesIceAlert()
        {
            List<string> expected = new List<string> { "Ice Alert for Saturday, March 10" };

            DateTime date = new DateTime(2018, 3, 10);

            var result1 = AlertGenerator.generateAlerts(new Forcast(date, 50, 70, "Ice"));
            CollectionAssert.AreEqual(expected, result1);

            var result2 = AlertGenerator.generateAlerts(new Forcast(date, 50, 70, "black ice"));
            CollectionAssert.AreEqual(expected, result2);

            var result3 = AlertGenerator.generateAlerts(new Forcast(date, 50, 70, "some more ice"));
            CollectionAssert.AreEqual(expected, result2);
        }

        [TestMethod]
        public void MultipleForcastAlerts()
        {
            List<string> expected = new List<string> { "Snow Alert for Saturday, March 10",
                                                        "Ice Alert for Saturday, March 10"};

            DateTime date = new DateTime(2018, 3, 10);
            var result = AlertGenerator.generateAlerts(new Forcast(date, 50, 70, "ice and snow"));
        }

        [TestMethod]
        public void ForcastAndTemp_GeneratesTwoAlerts()
        {
            List<string> expected = new List<string> { "Freezing Temperature Alert for Saturday, March 10",
                                                        "Ice Alert for Saturday, March 10"};

            DateTime date = new DateTime(2018, 3, 10);
            var result = AlertGenerator.generateAlerts(new Forcast(date, -40, 70, "ice"));
        }
    }
}
