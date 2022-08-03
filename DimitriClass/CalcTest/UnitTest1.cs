using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalcTest
{
    [TestClass]
    public class UnitTest1
    {
        readonly Calc calc = new Calc();

        [TestMethod]
        public void GetRootSquareStringErrorTest()
        {
            //Assert.IsFalse(TestRootSqEqualsTwo("abc"));

            //Action act = GetRootSquareString;
            //Assert.ThrowsException<Exception>(act);

            //Cntr + D = Line Copy
            Assert.ThrowsException<Exception>(GetRootSquareString);
        }

        private void GetRootSquareString() => calc.GetSquareRoot("abc");

        [TestMethod]
        public void GetRootSquareMinusTest()
        {
            //anonymous delegate
            Assert.ThrowsException<Exception>(() => calc.GetSquareRoot("-81"));
        }

        [TestMethod]
        public void GetRootSquareValidTest()
        {
            //if (calc.GetRootSquare("4") == 2)
            //    Console.WriteLine("OK");

            Assert.IsTrue(TestRootSqEqualsTwo("4"));
        }

        [TestMethod]
        public void GetRootSquareValidDoubleTest()
        {
            //if (calc.GetRootSquare("4") == 2)
            //    Console.WriteLine("OK");

            Assert.IsTrue(calc.GetSquareRoot("0.25") == 0.5);
        }

        [TestMethod]
        public void GetRootSquareInvalidTest()
        {
            Assert.IsFalse(TestRootSqEqualsTwo("16"));
        }

        private bool TestRootSqEqualsTwo(string str) => calc.GetSquareRoot(str) == 2;
        public void GetRootSquareNotForTest()
        {
            Assert.IsTrue(calc.GetSquareRoot("4") == Support.PI);
        }
    }
}
