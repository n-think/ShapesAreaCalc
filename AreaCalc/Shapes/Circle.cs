using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalc
{
    public class Circle : IShape
    {
        /// <summary>
        /// Радиус круга
        /// </summary>
        private double _radius;
        public double Radius
        {
            get => _radius;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Radius can't be negative", nameof(value));
                _radius = value;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="r"></param>
        public Circle(double r)
        {
            Radius = r;
        }

        /// <summary>
        /// Получаем площадь круга
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
