using System;
using KingSurvival;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKingSurvival
{
    [TestClass]
    public class TestGameEngine
    {
        [TestMethod]
        public void TestInitialIsKingsMoveOnStart()
        {
            GameEngine engine = new GameEngine();
            Assert.IsTrue(engine.IsKingTurn);
        }

        [TestMethod]
        public void TestInitialIsKingWinnerOnStart()
        {
            GameEngine engine = new GameEngine();
            Assert.IsFalse(engine.IsKingWinner);
        }

        [TestMethod]
        public void TestInitialMovesCountOnStart()
        {
            GameEngine engine = new GameEngine();
            uint movesCount = 0;
            Assert.AreEqual(movesCount, engine.MovesCounter);
        }

        [TestMethod]
        public void TestInitialFiguresCountOnStart()
        {
            GameEngine engine = new GameEngine();
            int figuresCount = 5;
            Assert.AreEqual(figuresCount, engine.Figures.Count);
        }

        [TestMethod]
        public void TestInitialKingsPositionOnStart()
        {
            GameEngine engine = new GameEngine();
            char kingName = 'K';
            int kingX = 3;
            int kingY = 7;
            Assert.AreEqual(kingName, engine.Figures[4].Name);
            Assert.AreEqual(kingX, engine.Figures[4].X);
            Assert.AreEqual(kingY, engine.Figures[4].Y);
        }

        [TestMethod]
        public void TestInitialPawnAPositionOnStart()
        {
            GameEngine engine = new GameEngine();
            char pawnAName = 'A';
            int pawnAX = 0;
            int pawnAY = 0;
            Assert.AreEqual(pawnAName, engine.Figures[0].Name);
            Assert.AreEqual(pawnAX, engine.Figures[0].X);
            Assert.AreEqual(pawnAY, engine.Figures[0].Y);
        }

        [TestMethod]
        public void TestInitialPawnBPositionOnStart()
        {
            GameEngine engine = new GameEngine();
            char pawnBName = 'B';
            int pawnBX = 2;
            int pawnBY = 0;
            Assert.AreEqual(pawnBName, engine.Figures[1].Name);
            Assert.AreEqual(pawnBX, engine.Figures[1].X);
            Assert.AreEqual(pawnBY, engine.Figures[1].Y);
        }

        [TestMethod]
        public void TestInitialPawnDPositionOnStart()
        {
            GameEngine engine = new GameEngine();
            char pawnDName = 'D';
            int pawnDX = 6;
            int pawnDY = 0;
            Assert.AreEqual(pawnDName, engine.Figures[3].Name);
            Assert.AreEqual(pawnDX, engine.Figures[3].X);
            Assert.AreEqual(pawnDY, engine.Figures[3].Y);
        }

        [TestMethod]
        public void TestInitialPawnCPositionOnStart()
        {
            GameEngine engine = new GameEngine();
            char pawnCName = 'C';
            int pawnCX = 4;
            int pawnCY = 0;
            Assert.AreEqual(pawnCName, engine.Figures[2].Name);
            Assert.AreEqual(pawnCX, engine.Figures[2].X);
            Assert.AreEqual(pawnCY, engine.Figures[2].Y);
        }
    }
}
