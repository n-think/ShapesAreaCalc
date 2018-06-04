using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AreaCalc;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Create_Correct_Shape_Instance()
        {
            bool gotException = false;

            try
            {
                var triangle = new Triangle(2, 3, 4);
                var circle = new Circle(7);
            }
            catch (Exception e)
            {
                gotException = true;
            }

            Assert.AreEqual(gotException, false);

        }

        [TestMethod]
        public void Triangle_Does_Not_Exist()
        {
            Action action = () =>
            {
                var triangle = new Triangle(12, 32, 11);
            };

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Circle_Does_Not_Exist()
        {
            Action action = () =>
            {
                var circle = new Circle(-1);
            };

            Assert.ThrowsException<ArgumentOutOfRangeException>(action);
        }

        [TestMethod]
        public void Assign_Negative_Values_To_Triangle_SideA()
        {
            var triangle = new Triangle(2, 3, 4);

            Action action = () => { triangle.SideA = -2; };

            Assert.ThrowsException<ArgumentOutOfRangeException>(action);
        }

        [TestMethod]
        public void Assign_Negative_Values_To_Triangle_Side_B()
        {
            var triangle = new Triangle(2, 3, 4);

            Action action = () => { triangle.SideB = -2; };

            Assert.ThrowsException<ArgumentOutOfRangeException>(action);
        }

        [TestMethod]
        public void Assign_Negative_Values_To_Triangle_SideC()
        {
            var triangle = new Triangle(2, 3, 4);

            Action action = () => { triangle.SideC = -2; };

            Assert.ThrowsException<ArgumentOutOfRangeException>(action);
        }

        [TestMethod]
        public void Assign_Negative_Values_To_Circle()
        {
            Action action = () =>
            {
                new Circle(3) { Radius = -2 };
            };

            Assert.ThrowsException<ArgumentOutOfRangeException>(action);
        }

        [TestMethod]
        public void Circle_Area_Check()
        {
            var circle1 = new Circle(43);
            var circle2 = new Circle(0);

            var calcArea1 = AreaCalculator.CalculateArea(circle1);
            var area1 = circle1.Radius * circle1.Radius * Math.PI;
            var calcArea2 = AreaCalculator.CalculateArea(circle2);
            var area2 = circle2.Radius * circle2.Radius * Math.PI;

            Assert.AreEqual(area1, calcArea1, 0.00001);
            Assert.AreEqual(area2, calcArea2, 0.00001);
        }

        [TestMethod]
        public void Triangle_Area_Check()
        {
            //var triangle = new Triangle(12,32,11);
            var triangle = new Triangle(3, 4, 5);
            var calcArea = AreaCalculator.CalculateArea(triangle);
            double p = (triangle.SideA + triangle.SideB + triangle.SideC) / 2;
            var area = Math.Sqrt(p * (p - triangle.SideA) * (p - triangle.SideB) * (p - triangle.SideC));
            Assert.AreEqual(area, calcArea, 0.00001);
        }

        [TestMethod]
        public void Triangle_Right_Check()
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.AreEqual(true, triangle.IsRight);
        }

        [TestMethod]
        public void Assign_Incorrect_Triangle_Side_After_Init_To_SideA()
        {
            var triangle = new Triangle(2, 3, 4);

            Action action = () => { triangle.SideA = 99; };

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Assign_Incorrect_Triangle_Side_After_Init_To_SideB()
        {
            var triangle = new Triangle(2, 3, 4);

            Action action = () => { triangle.SideB = 99; };

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Assign_Incorrect_Triangle_Side_After_Init_To_SideC()
        {
            var triangle = new Triangle(2, 3, 4);

            Action action = () => { triangle.SideB = 99; };

            Assert.ThrowsException<ArgumentException>(action);
        }
    }
}
