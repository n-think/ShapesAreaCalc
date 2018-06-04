using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalc
{
    public class Circle : IShape
    {
        private double _radius;
        public double Radius
        {
            get => _radius;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Radius can't be negative", nameof(value));
                _radius = value;
            }
        }

        public Circle(double r)
        {
            Radius = r;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
