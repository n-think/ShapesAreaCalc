using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalc
{
    public class Triangle : IShape
    {
        private double _sideA;
        private double _sideB;
        private double _sideC;

        public double SideA
        {
            get => _sideA;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Triangle's side must be positive", nameof(value));
                _sideA = value;
            }
        }

        public double SideB
        {
            get => _sideB;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Triangle's side must be positive", nameof(value));
                _sideB = value;
            }
        }

        public double SideC
        {
            get => _sideC;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Triangle's side must be positive", nameof(value));
                _sideC = value;
            }
        }

        public bool IsRight => CheckIfRight();

        public Triangle(double sideA, double sideB, double sideC)
        {
            bool triangleExists = sideA + sideB > sideC & sideA + sideC > sideB & sideB + sideC > sideA;
            if (!triangleExists)
                throw new ArgumentException("Triangle does not exist");

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        private bool CheckIfRight()
        {
            var temp = new[] { SideA, SideB, SideC };
            Array.Sort(temp);
            return Math.Round(temp[2] * temp[2], 5) == Math.Round(temp[0] * temp[0] + temp[1] * temp[1], 5);
        }

        public double GetArea()
        {
            var p = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }
    }
}
