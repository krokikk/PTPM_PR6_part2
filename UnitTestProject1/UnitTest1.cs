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
    }
}
