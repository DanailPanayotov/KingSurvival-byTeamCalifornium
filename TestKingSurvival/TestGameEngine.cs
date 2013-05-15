using System;
using KingSurvival;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.IO;

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
        
        [TestMethod]
        public void TestGameEngineWithKingsWinKingReachesRow0()
        {

            char[,] matrix = new char[,]   {
                    {'A','-','B','-','C','-','K','-'},
                    {'-','+','-','+','-','+','-','+'},
                    {'+','-','+','-','+','-','+','-'},
                    {'-','+','-','+','-','+','-','+'},
                    {'+','-','+','-','+','-','+','-'},
                    {'-','+','-','+','-','+','-','+'},
                    {'D','-','+','-','+','-','+','-'},
                    {'-','+','-','+','-','+','-','+'}
                 };

            StringBuilder expectedMatrix = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    expectedMatrix.AppendFormat("{0,2}", matrix[i, j]);
                }
                expectedMatrix.AppendLine();
            }

            StringBuilder commands = new StringBuilder();
            commands.AppendFormat(String.Format("KUR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("DDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("DDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("DDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("DDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("DDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("DDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUL{0}", System.Environment.NewLine));

            StringReader input = new StringReader(commands.ToString());

            Console.SetIn(input);
            GameEngine engine = new GameEngine();
            engine.Run();
            StringWriter result = new StringWriter();
            Console.SetOut(result);

            StringBuilder resultMatrix = new StringBuilder();
            for (int i = 0; i < engine.Renderer.field.GetLength(0); i++)
            {
                for (int j = 0; j < engine.Renderer.field.GetLength(1); j++)
                {
                    resultMatrix.AppendFormat("{0,2}", engine.Renderer.field[i, j]);
                }
                resultMatrix.AppendLine();
            }

            Assert.AreEqual(expectedMatrix.ToString(), resultMatrix.ToString());
        }

        [TestMethod]
        public void TestGameEngineWithKingLosesKingHasNoValidMove()
        {

            char[,] matrix = new char[,]   {
                    {'A','-','+','-','C','-','+','-'},
                    {'-','+','-','+','-','+','-','+'},
                    {'+','-','+','-','+','-','D','-'},
                    {'-','+','-','+','-','+','-','K'},
                    {'+','-','+','-','+','-','B','-'},
                    {'-','+','-','+','-','+','-','+'},
                    {'+','-','+','-','+','-','+','-'},
                    {'-','+','-','+','-','+','-','+'}
                 };

            StringBuilder expectedMatrix = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    expectedMatrix.AppendFormat("{0,2}", matrix[i, j]);
                }
                expectedMatrix.AppendLine();
            }

            StringBuilder commands = new StringBuilder();
            commands.AppendFormat(String.Format("KUR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("DDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("DDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("BDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("BDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("BDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("BDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("BDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("BDR{0}", System.Environment.NewLine));

            StringReader input = new StringReader(commands.ToString());

            Console.SetIn(input);
            GameEngine engine = new GameEngine();
            engine.Run();
            StringWriter result = new StringWriter();
            Console.SetOut(result);

            StringBuilder resultMatrix = new StringBuilder();
            for (int i = 0; i < engine.Renderer.field.GetLength(0); i++)
            {
                for (int j = 0; j < engine.Renderer.field.GetLength(1); j++)
                {
                    resultMatrix.AppendFormat("{0,2}", engine.Renderer.field[i, j]);
                }
                resultMatrix.AppendLine();
            }

            Assert.AreEqual(expectedMatrix.ToString(), resultMatrix.ToString());
        }

        [TestMethod]
        public void TestGameEngineWithKingsWinPawnsHasNoValidMove()
        {

            char[,] matrix = new char[,]   {
                    {'+','-','+','-','+','-','+','-'},
                    {'-','+','-','+','-','+','-','+'},
                    {'+','-','+','-','+','-','+','-'},
                    {'-','+','-','+','-','+','-','+'},
                    {'+','-','+','-','+','-','+','-'},
                    {'-','+','-','+','-','+','-','+'},
                    {'+','-','K','-','+','-','+','-'},
                    {'-','D','-','C','-','B','-','A'}
                 };

            StringBuilder expectedMatrix = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    expectedMatrix.AppendFormat("{0,2}", matrix[i, j]);
                }
                expectedMatrix.AppendLine();
            }

            StringBuilder commands = new StringBuilder();
            commands.AppendFormat(String.Format("KUL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("ADR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("ADR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("ADR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("ADR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("ADR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("ADR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("ADR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("BDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("BDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("BDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("BDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("BDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("BDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("BDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("CDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("CDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("CDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("CDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("CDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("CDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("CDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("CDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("DDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("DDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("DDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("DDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("DDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KUL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("DDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("DDL{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KDR{0}", System.Environment.NewLine));

            StringReader input = new StringReader(commands.ToString());

            Console.SetIn(input);
            GameEngine engine = new GameEngine();
            engine.Run();
            StringWriter result = new StringWriter();
            Console.SetOut(result);

            StringBuilder resultMatrix = new StringBuilder();
            for (int i = 0; i < engine.Renderer.field.GetLength(0); i++)
            {
                for (int j = 0; j < engine.Renderer.field.GetLength(1); j++)
                {
                    resultMatrix.AppendFormat("{0,2}", engine.Renderer.field[i, j]);
                }
                resultMatrix.AppendLine();
            }

            Assert.AreEqual(expectedMatrix.ToString(), resultMatrix.ToString());
        }
    }
}
