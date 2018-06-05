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

        /// <summary>
        /// Радиус круга
        /// </summary>
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

        /// <summary>
        /// Получаем площадь круга
        /// </summary>
        public double GetArea
        {
            get { return Math.Round(Math.PI * Radius * Radius, 5); }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="r"></param>
        public Circle(double r)
        {
            Radius = r;
        }
    }
}
