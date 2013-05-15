using System;
using KingSurvival;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKingSurvival
{
    [TestClass]
    public class TestKing
    {
        [TestMethod]
        public void TestKingMoveURFromItsStartPosition()
        {
            GameEngine engine = new GameEngine();            
            engine.Figures[4].Move(1, -1);
            Assert.AreEqual(4, engine.Figures[4].X);
            Assert.AreEqual(6, engine.Figures[4].Y);
        }

        [TestMethod]
        public void TestKingMoveULFromItsStartPosition()
        {
            GameEngine engine = new GameEngine();
            engine.Figures[4].Move(-1, -1);
            Assert.AreEqual(2, engine.Figures[4].X);
            Assert.AreEqual(6, engine.Figures[4].Y);
        }

        [TestMethod]
        public void TestKingMoveDLFromItsStartPosition()
        {
            GameEngine engine = new GameEngine();
            engine.Figures[4].Move(-1, 1);
        }

        [TestMethod]
        public void TestKingMoveDRFromItsStartPosition()
        {
            GameEngine engine = new GameEngine();
            engine.Figures[4].Move(-1, 1);
        }
    }
}
