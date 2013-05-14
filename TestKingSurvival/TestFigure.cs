using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival;

namespace TestKingSurvival
{
    [TestClass]
    public class TestFigure
    {
        [TestMethod]
        public void TestMove()
        {
            Figure king = new King(2,2,'K');
            king.Move(-1, 1);
            Assert.AreEqual(king.X, 1);
            Assert.AreEqual(king.Y, 3);
        }

        [TestMethod]
        public void TestMove1()
        {
            Figure king = new King(2, 2, 'K');
            king.Move(1, 1);
            Assert.AreEqual(king.X, 3);
            Assert.AreEqual(king.Y, 3);
        }

        [TestMethod]
        public void TestMove2()
        {
            Figure king = new King(2, 2, 'K');
            king.Move(-1, -1);
            Assert.AreEqual(king.X, 1);
            Assert.AreEqual(king.Y, 1);
        }

        [TestMethod]
        public void TestMove3()
        {
            Figure king = new King(2, 2, 'K');
            king.Move(1, -1);
            Assert.AreEqual(king.X, 3);
            Assert.AreEqual(king.Y, 1);
        }
    }
}
