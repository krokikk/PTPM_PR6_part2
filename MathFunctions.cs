using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPM_PR4
{
    /// <summary>
    /// математические функции приложения.
    /// </summary>
    public static class MathFunctions
    {
        /// <summary>
        /// Вычисляет выражение из Page1.
        /// </summary>
        public static double CalculateExpression(double x, double y, double z)
        {
            return Math.Log(Math.Pow(y, -Math.Sqrt(Math.Abs(x)))) *
                   (x - y / 2) +
                   Math.Pow(Math.Sin(Math.Atan(z)), 2);
        }

        /// <summary>
        /// Вычисляет значение функции (sinh, x^2, exp).
        /// </summary>
        public static double CalculateFx(double x, int functionType)
        {
            switch (functionType)
            {
                case 1:
                    return Math.Sinh(x);

                case 2:
                    return Math.Pow(x, 2);

                case 3:
                    return Math.Exp(x);

                default:
                    throw new ArgumentException("Неизвестная функция");
            }
        }

        /// <summary>
        /// Вычисляет результат из Page2.
        /// </summary>
        public static double CalculateResult(double x, double i, double fx)
        {
            if (i % 2 != 0 && x > 0)
                return i * Math.Sqrt(fx);

            if (i % 2 == 0 && x < 0)
                return (i / 2.0) * Math.Sqrt(Math.Abs(fx));

            return Math.Sqrt(Math.Abs(i * fx));
        }
    }

}