using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalc
{
    public class Triangle : IShape
    {
        #region properties and fields

        private double _sideA;
        private double _sideB;
        private double _sideC;

        public double SideA
        {
            get => _sideA;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Triangle's side must be positive");

                _sideA = value;

                // Смотрим на _isInitialized чтобы не проверять значение пока не присвоили все стороны в конструкторе
                // (поидее можно сразу присваивать приватным полям но тогда на отриц не проверится, мб проверять в конструкторе на отриц, хз как лучше)
                // мб вообще сделать стороны readonly чтобы не менялись
                if (_isInitialized && !Exists())
                    throw new ArgumentException("Triangle with this side does not exist", nameof(value));
            }
        }

        public double SideB
        {
            get => _sideB;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Triangle's side must be positive");

                _sideB = value;

                if (_isInitialized && !Exists())
                    throw new ArgumentException("Triangle with this side does not exist", nameof(value));
            }
        }

        public double SideC
        {
            get => _sideC;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Triangle's side must be positive");

                _sideC = value;

                if (_isInitialized && !Exists())
                    throw new ArgumentException("Triangle with this side does not exist", nameof(value));
            }
        }

        public bool IsRight => CheckIfRight();

        private readonly bool _isInitialized;

        #endregion

        #region ctor

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;

            //проверяем существует ли такой треугольник
            if (!Exists())
                throw new ArgumentException("Triangle with these values does not exist");

            //Устанавливаем флаг что треугольник инициализирован
            _isInitialized = true;
        }

        #endregion

        #region methods 

        /// <summary>
        /// Проверяем существует ли треугольник с такими сторонами 
        /// </summary> 
        /// <returns></returns>
        private bool Exists()
        {
            return SideA + SideB > SideC & SideA + SideC > SideB & SideB + SideC > SideA;
        }

        /// <summary>
        /// Проверяет прямоугольный ли треугольник
        /// </summary>
        /// <returns></returns>
        private bool CheckIfRight()
        {
            var temp = new[] { SideA, SideB, SideC };
            Array.Sort(temp);
            return Math.Round(temp[2] * temp[2], 5) == Math.Round(temp[0] * temp[0] + temp[1] * temp[1], 5);
        }

        /// <summary>
        /// Получает площадь треугольника
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            var p = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        #endregion
    }
}
