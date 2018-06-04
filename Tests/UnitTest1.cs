using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AreaCalc;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateCorrectShapeInstance()
        {
            var triangle = new Triangle(2, 3, 4);
            var circle = new Circle(7);
        }

        [TestMethod]
        public void TriangleDoesNotExist()
        {
            Action action = () =>
            {
                var triangle = new Triangle(12, 32, 11);
            };
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void CircleDoesNotExist()
        {
            Action action = () =>
            {
                var circle = new Circle(-1);
            };
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void AssignNegativeValuesToTriangle()
        {
            Action action = () =>
            {
                new Triangle(2, 3, 4) {SideA = -2};
            };
            Assert.ThrowsException<ArgumentException>(action);

            action = () =>
            {
                new Triangle(2, 3, 4) {SideB = -2};
            };
            Assert.ThrowsException<ArgumentException>(action);

            action = () =>
            {
                new Triangle(2, 3, 4) {SideC = -2};
            };
            Assert.ThrowsException<ArgumentException>(action);

        }

        [TestMethod]
        public void AssignNegativeValuesToCircle()
        {
            Action action = () =>
            {
                new Circle(3) {Radius = -2};
            };
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void CircleAreaCheck()
        {
            var circle = new Circle(43);
            var calcArea = AreaCalculator.CalculateArea(circle);
            var area = circle.Radius * circle.Radius * Math.PI;
            Assert.AreEqual(area, calcArea, 0.00001);

            circle = new Circle(0);
            calcArea = AreaCalculator.CalculateArea(circle);
            area = circle.Radius * circle.Radius * Math.PI;
            Assert.AreEqual(area, calcArea, 0.00001);
        }

        [TestMethod]
        public void TriangleAreaCheck()
        {
            //var triangle = new Triangle(12,32,11);
            var triangle = new Triangle(3, 4, 5);
            var calcArea = AreaCalculator.CalculateArea(triangle);
            double p = (triangle.SideA + triangle.SideB + triangle.SideC) / 2;
            var area = Math.Sqrt(p * (p - triangle.SideA) * (p - triangle.SideB) * (p - triangle.SideC));
            Assert.AreEqual(area, calcArea, 0.00001);
        }

        [TestMethod]
        public void TriangleRightCheck()
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.AreEqual(true, triangle.IsRight);
        }
    }
}
