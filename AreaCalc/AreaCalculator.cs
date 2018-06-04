using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalc
{
    public class AreaCalculator
    {
        /// <summary>
        /// Считает площадь переданной ему фигуры
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        public static double CalculateArea(IShape shape)
        {
            return shape.GetArea();
        }
    }
}
