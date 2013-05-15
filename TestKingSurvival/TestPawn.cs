using System;
using KingSurvival;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKingSurvival
{
    [TestClass]
    public class TestPawn
    {
        //[TestMethod]
        //[ExpectedException(typeof(IndexOutOfRangeException))]
        //public void TestPawnAMoveDLFromItsStartPosition()
        //{
        //    GameEngine engine = new GameEngine();
        //    engine.Figures[0].Move(-1, 1);
        //    Assert.AreEqual(0, engine.Figures[0].X);
        //    Assert.AreEqual(1, engine.Figures[0].Y);
        //}

        [TestMethod]
        public void TestPawnAMoveDRFromItsStartPosition()
        {
            GameEngine engine = new GameEngine();
            engine.Figures[0].Move(1, 1);
            Assert.AreEqual(1, engine.Figures[0].X);
            Assert.AreEqual(1, engine.Figures[0].Y);
        }

        [TestMethod]
        public void TestPawnBMoveDLFromItsStartPosition()
        {
            GameEngine engine = new GameEngine();
            engine.Figures[1].Move(-1, 1);
            Assert.AreEqual(1, engine.Figures[1].X);
            Assert.AreEqual(1, engine.Figures[1].Y);
        }

        [TestMethod]
        public void TestPawnBMoveDRFromItsStartPosition()
        {
            GameEngine engine = new GameEngine();
            engine.Figures[1].Move(1, 1);
            Assert.AreEqual(3, engine.Figures[1].X);
            Assert.AreEqual(1, engine.Figures[1].Y);
        }

        [TestMethod]
        public void TestPawnCMoveDLFromItsStartPosition()
        {
            GameEngine engine = new GameEngine();
            engine.Figures[2].Move(-1, 1);
            Assert.AreEqual(3, engine.Figures[2].X);
            Assert.AreEqual(1, engine.Figures[2].Y);
        }

        [TestMethod]
        public void TestPawnCMoveDRFromItsStartPosition()
        {
            GameEngine engine = new GameEngine();
            engine.Figures[2].Move(1, 1);
            Assert.AreEqual(5, engine.Figures[2].X);
            Assert.AreEqual(1, engine.Figures[2].Y);
        }

        [TestMethod]
        public void TestPawnDMoveDLFromItsStartPosition()
        {
            GameEngine engine = new GameEngine();
            engine.Figures[3].Move(-1, 1);
            Assert.AreEqual(5, engine.Figures[3].X);
            Assert.AreEqual(1, engine.Figures[3].Y);
        }

        [TestMethod]
        public void TestPawnDMoveDRFromItsStartPosition()
        {
            GameEngine engine = new GameEngine();
            engine.Figures[3].Move(1, 1);
            Assert.AreEqual(7, engine.Figures[3].X);
            Assert.AreEqual(1, engine.Figures[3].Y);
        }
    }
}
