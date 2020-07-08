using System;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverUnitTest
{
    [TestClass]
    public class MainUnitTest
    {
        [TestMethod]
        public void Rover1()
        {
            // Arrange
            Rover rover = new Rover();
            rover.X = 1;
            rover.Y = 2;
            rover.Header = "N";
            // Act
            var output = rover.Run("LMLMLMLMM");
            // Assert
            Assert.AreEqual("1 3 N", output);
        }
        [TestMethod]
        public void Rover2()
        {
            // Arrange
            Rover rover = new Rover();
            rover.X = 1;
            rover.Y = 2;
            rover.Header = "N";
            // Act
            var output = rover.Run("LLLLM");
            // Assert
            Assert.AreEqual("1 3 N", output);
        }
    }
}
