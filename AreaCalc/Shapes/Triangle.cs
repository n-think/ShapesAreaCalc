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
                    throw new ArgumentOutOfRangeException("Triangle's side must be positive", nameof(value));

                // Смотрим на _isInitialized чтобы не проверять значение пока не присвоили все стороны в конструкторе
                // (поидее можно сразу присваивать приватным полям но тогда на отриц не проверится, мб проверять в конструкторе на отриц, хз как лучше)
                if (_isInitialized && !Exists(value))
                    throw new ArgumentException("Triangle with this value does not exist", nameof(value));
                _sideA = value;
            }
        }

        public double SideB
        {
            get => _sideB;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Triangle's side must be positive", nameof(value));
                if (_isInitialized && !Exists(value))
                    throw new ArgumentException("Triangle with this value does not exist", nameof(value));
                _sideB = value;
            }
        }

        public double SideC
        {
            get => _sideC;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Triangle's side must be positive", nameof(value));
                if (_isInitialized && !Exists(value))
                    throw new ArgumentException("Triangle with this value does not exist", nameof(value));
                _sideC = value;
            }
        }

        public bool IsRight => CheckIfRight();

        private readonly bool _isInitialized;

        #endregion

        #region ctor

        public Triangle(double sideA, double sideB, double sideC)
        {
            //проверяем существует ли такой треугольник
            if (!Exists(sideA, sideB, sideC))
                throw new ArgumentException("Triangle with these values does not exist");

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;

            //Устанавливаем флаг что треугольник инициализирован
            _isInitialized = true;
        }

        #endregion

        #region methods 

        /// <summary>
        /// Проверяет будет ли существовать треугольник перед тем как присвоить свойству стороны значение
        /// </summary>
        /// <param name="sideValue">Значение стороны</param>
        /// <param name="side">Сторона</param>
        /// <returns></returns>
        private bool Exists(double sideValue, [CallerMemberName] string side = "")
        {
            if (side == "SideA")
                return sideValue + SideB > SideC & sideValue + SideC > SideB & SideB + SideC > sideValue;
            else
            if (side == "SideB")
                return SideA + sideValue > SideC & SideA + SideC > sideValue & sideValue + SideC > SideA;
            else
            if (side == "SideC")
                return SideA + SideB > sideValue & SideA + sideValue > SideB & SideB + sideValue > SideA;
            else
                return false;
        }

        /// <summary>
        /// Проверяет существует ли треугольник с такими сторонами
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="sideC"></param>
        /// <returns></returns>
        private bool Exists(double sideA, double sideB, double sideC)
        {
            return sideA + sideB > sideC & sideA + sideC > sideB & sideB + sideC > sideA;
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
