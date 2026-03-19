using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTPM_PR4;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int res = 2 + 2;
            Assert.AreEqual(res, 4);
            Assert.AreNotEqual(res, 5);
            Assert.IsFalse(res > 5);
            Assert.IsTrue(res < 5);
        }

        /// <summary>
        /// Тест функции из Page1
        /// </summary>
        [TestMethod]
        public void CalculateExpression_ValidInput_ReturnsCorrectResult()
        {
            double x = 1;
            double y = 2;
            double z = 3;

            double result = MathFunctions.CalculateExpression(x, y, z);

            Assert.IsFalse(double.IsNaN(result));
        }

        /// <summary>
        /// Тест функции sinh(x)
        /// </summary>
        [TestMethod]
        public void CalculateFx_Sinh_ReturnsCorrectValue()
        {
            double x = 1;

            double result = MathFunctions.CalculateFx(x, 1);

            Assert.AreEqual(Math.Sinh(x), result, 0.0001);
        }

        /// <summary>
        /// Тест основной логики Page2
        /// </summary>
        [TestMethod]
        public void CalculateResult_ValidInput_ReturnsCorrectResult()
        {
            double x = 2;
            double i = 3;
            double fx = 4;

            double result = MathFunctions.CalculateResult(x, i, fx);

            Assert.AreEqual(i * Math.Sqrt(fx), result, 0.0001);
        }
    }
}
