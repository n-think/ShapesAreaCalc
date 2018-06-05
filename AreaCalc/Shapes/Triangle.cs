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
        private double _sideA;
        private double _sideB;
        private double _sideC;

        public double SideA
        {
            get => _sideA;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Triangle's side must be positive", nameof(value));

                _sideA = value;

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
                    throw new ArgumentException("Triangle's side must be positive", nameof(value));

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
                    throw new ArgumentException("Triangle's side must be positive", nameof(value));

                _sideC = value;

                if (_isInitialized && !Exists())
                    throw new ArgumentException("Triangle with this side does not exist", nameof(value));
            }
        }

        /// <summary>
        /// Возвращает прямоугольный ли треугольник
        /// </summary>
        public bool IsRight
        {
            get
            {
                var temp = new[] { SideA, SideB, SideC };
                Array.Sort(temp);
                return Math.Round(temp[2] * temp[2], 5) == Math.Round(temp[0] * temp[0] + temp[1] * temp[1], 5);
            }
        }

        /// <summary>
        /// Получаем площадь
        /// </summary>
        public double GetArea
        {
            get
            {
                var p = (SideA + SideB + SideC) / 2;
                return Math.Round(Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC)), 5);
            }
        }

        private readonly bool _isInitialized;

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

        /// <summary>
        /// Проверяем существует ли треугольник с такими сторонами 
        /// </summary> 
        /// <returns></returns>
        private bool Exists()
        {
            return SideA + SideB > SideC & SideA + SideC > SideB & SideB + SideC > SideA;
        }

    }
}
