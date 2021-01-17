

using MarsRover.Business.Concrete;
using MarsRover.Business.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestLab
{
    [TestClass]
    public class MarsRoversTest
    {
        [TestMethod]
        public void TestMehtod()
        {
            // First Test Case 
            //5 5
            //1 2 N
            //LMLMLMLMM
            // Expected Output:
            //1 3 N
            var orientationService = new OrientationService();
            var coordinatesBoundaries = new List<int> { 5, 5 };
            var currnetPosition = "1 2 N";
            var movesSet = "LMLMLMLMM";
            var movementModel = new MovementModel()
            {
                CurrnetPosition = currnetPosition,
                CoordinatesBoundaries = coordinatesBoundaries,
                MovesSet = movesSet
            };

            var actualOutput = orientationService.StartMovement(movementModel);
            var expectedOutput = "1 3 N";
            Assert.AreEqual(expectedOutput, actualOutput);


            // Second Test Case
            //5 5
            // 3 3 E
            // MMRMMRMRRM
            // Expected Output:
            //5 1 E
            currnetPosition = "3 3 E";
            movesSet = "MMRMMRMRRM";

            actualOutput = orientationService.StartMovement(movementModel);
            expectedOutput = "5 1 E";
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
