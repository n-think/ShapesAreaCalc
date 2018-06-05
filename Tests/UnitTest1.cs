using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AreaCalc;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Triangle_Does_Not_Exist()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var triangle = new Triangle(12, 32, 11);
            },
            "Triangle with this side does not exist");
        }

        [TestMethod]
        public void Circle_Does_Not_Exist()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var circle = new Circle(-1);
            },
            "Radius can't be negative");
        }

        [TestMethod]
        public void Triangle_Assign_Negative_Values_To_SideA()
        {
            var triangle = new Triangle(2, 3, 4);

            Assert.ThrowsException<ArgumentException>(() =>
            {
                triangle.SideA = -2;
            },
            "Triangle's side must be positive");
        }

        [TestMethod]
        public void Triangle_Assign_Negative_Values_To_Side_B()
        {
            var triangle = new Triangle(2, 3, 4);

            Assert.ThrowsException<ArgumentException>(() =>
            {
                triangle.SideB = -3;
            },
            "Triangle's side must be positive");
        }

        [TestMethod]
        public void Triangle_Assign_Negative_Values_To_SideC()
        {
            var triangle = new Triangle(2, 3, 4);

            Assert.ThrowsException<ArgumentException>(() =>
            {
                triangle.SideC = -4;
            },
            "Triangle's side must be positive");
        }

        [TestMethod]
        public void Circle_Assign_Negative_Values()
        {

            Assert.ThrowsException<ArgumentException>(() =>
            {
                new Circle(3) { Radius = -2 };
            },
            "Radius can't be negative");
        }

        [TestMethod]
        public void Circle_Area_Check()
        {
            var circle1 = new Circle(43);
            var circle2 = new Circle(0);

            var calcArea1 = circle1.GetArea; ;
            var area1 = circle1.Radius * circle1.Radius * Math.PI;
            var calcArea2 = circle2.GetArea;
            var area2 = circle2.Radius * circle2.Radius * Math.PI;

            Assert.AreEqual(area1, calcArea1, 0.00001);
            Assert.AreEqual(area2, calcArea2, 0.00001);
        }

        [TestMethod]
        public void Triangle_Area_Check()
        {
            var triangle = new Triangle(3, 4, 5);
            var calcArea = triangle.GetArea;

            double p = (triangle.SideA + triangle.SideB + triangle.SideC) / 2;
            var area = Math.Sqrt(p * (p - triangle.SideA) * (p - triangle.SideB) * (p - triangle.SideC));

            Assert.AreEqual(area, calcArea);
        }

        [TestMethod]
        public void Triangle_Right_Check()
        {
            var triangle = new Triangle(3, 4, 5);

            Assert.AreEqual(true, triangle.IsRight);
        }

        [TestMethod]
        public void Triangle_Assign_Incorrect_Side_After_Init_To_SideA()
        {
            var triangle = new Triangle(2, 3, 4);

            Assert.ThrowsException<ArgumentException>(() =>
            {
                triangle.SideA = 99;
            },
            "Triangle with this side does not exist");
        }

        [TestMethod]
        public void Triangle_Assign_Incorrect_Side_After_Init_To_SideB()
        {
            var triangle = new Triangle(2, 3, 4);

            Assert.ThrowsException<ArgumentException>(() =>
            {
                triangle.SideB = 99;
            },
            "Triangle with this side does not exist");
        }

        [TestMethod]
        public void Triangle_Assign_Incorrect_Side_After_Init_To_SideC()
        {
            var triangle = new Triangle(2, 3, 4);

            Assert.ThrowsException<ArgumentException>(() =>
                {
                    triangle.SideC = 99;
                },
                "Triangle with this side does not exist");
        }
    }
}
