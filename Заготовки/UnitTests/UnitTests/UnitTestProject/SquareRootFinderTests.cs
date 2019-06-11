using System;
using NUnit.Framework;
using SquareRootFinder;

namespace UnitTestProject
{
    [TestFixture]
    public class SquareRootFinderTests
    {
        [Test]
        public void NormalBehaviourTest()
        {
            //AAA
            var solver = new SquareRoot();
            var x = 9;

            var result = solver.FindSqrt(x);
            Assert.AreEqual(result, Math.Sqrt(x), 0.0000001);
        }

        [TestCase(2)]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(100)]
        [TestCase(1079)]
        [TestCase(0)]
        public void NormalBehaviourMultiTest(double x)
        {
            //AAA
            var solver = new SquareRoot();

            var result = solver.FindSqrt(x);
            Assert.AreEqual(result, Math.Sqrt(x), 0.0000001);
        }

        [Test]
        public void NegativeValueTest()
        {
            var x = -5;
            var solver = new SquareRoot();

            Assert.Throws<ArgumentOutOfRangeException>(() => solver.FindSqrt(x));
        }
    }
}
