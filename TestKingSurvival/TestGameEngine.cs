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
        //The Tests for King win and lose SHOULD BE CHANGED,that's why they are commented

        #region Test Initial States
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

        #endregion

        #region Test GetFigureByCoordinates

        [TestMethod]
        public void TestGetFigureByCoordinatesWithPawn()
        {
            GameEngine gameEngine = new GameEngine();
            Figure result = gameEngine.GetFigureByCoordinates(2, 0);
            Figure expected = new Pawn(2, 0, 'B');
            Assert.AreEqual(expected.X, result.X);
            Assert.AreEqual(expected.Y, result.Y);
            Assert.AreEqual(expected.Name, result.Name);
        }

        [TestMethod]
        public void TestGetFigureByCoordinatesWithKing()
        {
            GameEngine gameEngine = new GameEngine();
            Figure result = gameEngine.GetFigureByCoordinates(3, 7);
            Figure expected = new King(3, 7, 'K');
            Assert.AreEqual(expected.X, result.X);
            Assert.AreEqual(expected.Y, result.Y);
            Assert.AreEqual(expected.Name, result.Name);
        }

        [TestMethod]
        public void TestGetFigureByCoordinatesWithNull()
        {
            GameEngine gameEngine = new GameEngine();
            Figure result = gameEngine.GetFigureByCoordinates(3, 3);
            Figure expected = null;
            Assert.AreSame(expected, result);
        }
        #endregion

        #region Test GetFigureByName

        [TestMethod]
        public void TestGetFigureByNameWithKing()
        {
            GameEngine gameEngine = new GameEngine();
            Figure result = gameEngine.GetFigureByName('K');
            Figure expected = new King(3, 7, 'K');
            Assert.AreEqual(expected.X, result.X);
            Assert.AreEqual(expected.Y, result.Y);
            Assert.AreEqual(expected.Name, result.Name);
        }

        [TestMethod]
        public void TestGetFigureByNameWithPawn()
        {
            GameEngine gameEngine = new GameEngine();
            Figure result = gameEngine.GetFigureByName('D');
            Figure expected = new King(6, 0, 'D');
            Assert.AreEqual(expected.X, result.X);
            Assert.AreEqual(expected.Y, result.Y);
            Assert.AreEqual(expected.Name, result.Name);
        }

        [TestMethod]
        public void TestGetFigureByNameWithWithNoSuchName()
        {
            GameEngine gameEngine = new GameEngine();
            Figure result = gameEngine.GetFigureByName('W');
            Figure expected = null;
            Assert.AreSame(expected, result);
        }

        #endregion

        #region Test ValidMoveCheck

        [TestMethod]
        public void TestValidMoveCheckWithPawnAndNotKingTurn()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.IsKingTurn = false;
            Figure pawn = new Pawn(0, 0, 'A');
            GameEngine.TurnMove currentMove = new GameEngine.TurnMove();
            currentMove.Command = "ADR";
            currentMove.Figure = pawn;
            currentMove.XChange = 1;
            currentMove.YChange = 1;
            bool result = gameEngine.ValidMoveCheck(currentMove);
            bool expected = true;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidMoveCheckWithPawnAndKingTurn()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.IsKingTurn = true;
            Figure pawn = new Pawn(2, 0, 'B');
            GameEngine.TurnMove currentMove = new GameEngine.TurnMove();
            currentMove.Command = "BDR";
            currentMove.Figure = pawn;
            currentMove.XChange = 1;
            currentMove.YChange = 1;
            bool result = gameEngine.ValidMoveCheck(currentMove);
            bool expected = false;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidMoveCheckWithKingAndKingTurn()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.IsKingTurn = true;
            Figure king = new King(3, 7, 'K');
            GameEngine.TurnMove currentMove = new GameEngine.TurnMove();
            currentMove.Command = "KUR";
            currentMove.Figure = king;
            currentMove.XChange = 1;
            currentMove.YChange = -1;
            bool result = gameEngine.ValidMoveCheck(currentMove);
            bool expected = true;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidMoveCheckWithKingAndNotKingTurn()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.IsKingTurn = false;
            Figure king = new King(3, 7, 'K');
            GameEngine.TurnMove currentMove = new GameEngine.TurnMove();
            currentMove.Command = "KUL";
            currentMove.Figure = king;
            currentMove.XChange = -1;
            currentMove.YChange = -1;
            bool result = gameEngine.ValidMoveCheck(currentMove);
            bool expected = false;
            Assert.AreEqual(expected, result);
        }

        #region MoveOutOfField

        [TestMethod]
        public void TestValidMoveCheckWithKingAndMoveOutOfFieldDown()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.IsKingTurn = true;
            Figure king = new King(3, 7, 'K');
            GameEngine.TurnMove currentMove = new GameEngine.TurnMove();
            currentMove.Command = "KDL";
            currentMove.Figure = king;
            currentMove.XChange = -1;
            currentMove.YChange = 1;
            bool result = gameEngine.ValidMoveCheck(currentMove);
            bool expected = false;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidMoveCheckWithPawnAndMoveOutOfFieldUp()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.IsKingTurn = false;
            Figure pawn = new Pawn(2, 0, 'B');
            GameEngine.TurnMove currentMove = new GameEngine.TurnMove();
            currentMove.Command = "BUL";
            currentMove.Figure = pawn;
            currentMove.XChange = -1;
            currentMove.YChange = -1;
            bool result = gameEngine.ValidMoveCheck(currentMove);
            bool expected = false;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidMoveCheckWithPawnAndMoveOutOfFieldRight()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.IsKingTurn = false;
            Figure pawn = new Pawn(7, 1, 'D');
            GameEngine.TurnMove currentMove = new GameEngine.TurnMove();
            currentMove.Command = "DDR";
            currentMove.Figure = pawn;
            currentMove.XChange = 1;
            currentMove.YChange = 1;
            bool result = gameEngine.ValidMoveCheck(currentMove);
            bool expected = false;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidMoveCheckWithPawnAndMoveOutOfFieldLeft()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.IsKingTurn = false;
            Figure pawn = new Pawn(0, 0, 'A');
            GameEngine.TurnMove currentMove = new GameEngine.TurnMove();
            currentMove.Command = "ADL";
            currentMove.Figure = pawn;
            currentMove.XChange = -1;
            currentMove.YChange = 1;
            bool result = gameEngine.ValidMoveCheck(currentMove);
            bool expected = false;
            Assert.AreEqual(expected, result);
        }

        #endregion

        #region MoveOnEmptyCheck

        [TestMethod]
        public void TestValidMoveCheckWithPawnAndMoveOnEmptyCheckTrue()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.IsKingTurn = false;
            Figure pawn = new Pawn(0, 0, 'A');
            GameEngine.TurnMove currentMove = new GameEngine.TurnMove();
            currentMove.Command = "ADR";
            currentMove.Figure = pawn;
            currentMove.XChange = 1;
            currentMove.YChange = 1;
            bool result = gameEngine.ValidMoveCheck(currentMove);
            bool expected = true;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidMoveCheckWithTwoPawnsAndMoveOnEmptyCheckFalse()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.IsKingTurn = false;
            //Position B on 1,1
            gameEngine.Figures[1].X = 1;
            gameEngine.Figures[1].Y = 1;
            Figure pawn = new Pawn(0, 0, 'A');
            GameEngine.TurnMove currentMove = new GameEngine.TurnMove();
            //Move A on 1,1
            currentMove.Command = "ADR";
            currentMove.Figure = pawn;
            currentMove.XChange = 1;
            currentMove.YChange = 1;
            bool result = gameEngine.ValidMoveCheck(currentMove);
            bool expected = false;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidMoveCheckWithPawnAndKingMoveOnEmptyCheckFalse()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.IsKingTurn = true;
            //Position A on 2,2
            gameEngine.Figures[0].X = 2;
            gameEngine.Figures[0].Y = 2;
            Figure king = new King(3, 3, 'K');
            GameEngine.TurnMove currentMove = new GameEngine.TurnMove();
            //Move K on 2,2
            currentMove.Command = "KUL";
            currentMove.Figure = king;
            currentMove.XChange = -1;
            currentMove.YChange = -1;
            bool result = gameEngine.ValidMoveCheck(currentMove);
            bool expected = false;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidMoveCheckWithKingAndPawnMoveOnEmptyCheckFalse()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.IsKingTurn = false;
            //Position K on 3,3
            gameEngine.Figures[4].X = 3;
            gameEngine.Figures[4].Y = 3;
            Figure pawn = new Pawn(2, 2, 'A');
            GameEngine.TurnMove currentMove = new GameEngine.TurnMove();
            //Move A on 3,3
            currentMove.Command = "ADR";
            currentMove.Figure = pawn;
            currentMove.XChange = 1;
            currentMove.YChange = 1;
            bool result = gameEngine.ValidMoveCheck(currentMove);
            bool expected = false;
            Assert.AreEqual(expected, result);
        }

        #endregion

        #region PossibleDirectionCheck

        [TestMethod]
        public void TestValidMoveCheckWithPawnAndPossibleDirectionFalseWithUpRight()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.IsKingTurn = false;
            Figure pawn = new Pawn(1, 1, 'A');
            GameEngine.TurnMove currentMove = new GameEngine.TurnMove();
            currentMove.Command = "AUR";
            currentMove.Figure = pawn;
            currentMove.XChange = 1;
            currentMove.YChange = -1;
            bool result = gameEngine.ValidMoveCheck(currentMove);
            bool expected = false;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidMoveCheckWithPawnAndPossibleDirectionFalseWithUpLeft()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.IsKingTurn = false;
            Figure pawn = new Pawn(3, 1, 'B');
            GameEngine.TurnMove currentMove = new GameEngine.TurnMove();
            currentMove.Command = "BUL";
            currentMove.Figure = pawn;
            currentMove.XChange = -1;
            currentMove.YChange = -1;
            bool result = gameEngine.ValidMoveCheck(currentMove);
            bool expected = false;
            Assert.AreEqual(expected, result);
        }
        #endregion

        #endregion

        #region Test GameOverCheck

        [TestMethod]
        public void TestGameOverCheckWithKingReachedZeroRow()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.IsKingTurn = false;
            //Make 2,0 empty
            gameEngine.Figures[1].X = 1;
            gameEngine.Figures[1].Y = 1;
            //Position King on row zero(imitate King has reached row zero)
            gameEngine.Figures[4].X = 2;
            gameEngine.Figures[4].Y = 0;
            bool result = gameEngine.GameOverCheck();
            bool expected = true;
            Assert.AreEqual(expected, result);
        }

        //{'+','-','+','-','+','-','+','-'},
        //{'-','+','-','+','-','+','-','+'},
        //{'+','-','A','-','B','-','+','-'},
        //{'-','+','-','K','-','+','-','+'},
        //{'+','-','C','-','D','-','+','-'},
        //{'-','+','-','+','-','+','-','+'},
        //{'+','-','+','-','+','-','+','-'},
        //{'-','+','-','+','-','+','-','+'}

        [TestMethod]
        public void TestGameOverCheckWithKingHasNoValidMoveSurroundedByAllPawns()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.IsKingTurn = true;
            //Position King on 3,3
            gameEngine.Figures[4].X = 3;
            gameEngine.Figures[4].Y = 3;
            //Suurround King with All Pawns
            gameEngine.Figures[0].X = 2;
            gameEngine.Figures[0].Y = 2;

            gameEngine.Figures[1].X = 4;
            gameEngine.Figures[1].Y = 2;

            gameEngine.Figures[2].X = 2;
            gameEngine.Figures[2].Y = 4;

            gameEngine.Figures[3].X = 4;
            gameEngine.Figures[3].Y = 4;

            bool result = gameEngine.GameOverCheck();
            bool expected = true;
            Assert.AreEqual(expected, result);
        }

        //{'+','-','+','-','C','-','D','-'},
        //{'-','+','-','+','-','+','-','+'},
        //{'+','-','+','-','+','-','+','-'},
        //{'-','+','-','+','-','+','-','+'},
        //{'+','-','+','-','+','-','+','-'},
        //{'-','+','-','+','-','+','-','+'},
        //{'+','-','A','-','B','-','+','-'},
        //{'-','+','-','K','-','+','-','+'}

        [TestMethod]
        public void TestGameOverCheckWithKingHasNoValidMoveSurroundedByTwoPawns()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.IsKingTurn = true;
            //Position King on 3,3
            gameEngine.Figures[4].X = 3;
            gameEngine.Figures[4].Y = 7;
            //Suurround King with Two Pawns
            gameEngine.Figures[0].X = 2;
            gameEngine.Figures[0].Y = 6;

            gameEngine.Figures[1].X = 4;
            gameEngine.Figures[1].Y = 6;

            bool result = gameEngine.GameOverCheck();
            bool expected = true;
            Assert.AreEqual(expected, result);
        }

        //{'+','-','+','-','C','-','D','-'},
        //{'-','+','-','+','-','+','-','+'},
        //{'+','-','+','-','+','-','+','-'},
        //{'-','+','-','+','-','+','-','+'},
        //{'+','-','+','-','+','-','B','-'},
        //{'-','+','-','+','-','+','-','К'},
        //{'+','-','+','-','+','-','A','-'},
        //{'-','+','-','+','-','+','-','+'}

        [TestMethod]
        public void TestGameOverCheckWithKingHasNoValidMoveSurroundedByTwoPawnsAndEndOfField()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.IsKingTurn = true;
            //Position King on 3,3
            gameEngine.Figures[4].X = 7;
            gameEngine.Figures[4].Y = 5;
            //Suurround King with Two Pawns 
            gameEngine.Figures[0].X = 6;
            gameEngine.Figures[0].Y = 6;

            gameEngine.Figures[1].X = 6;
            gameEngine.Figures[1].Y = 4;

            bool result = gameEngine.GameOverCheck();
            bool expected = true;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGameOverCheckFalse()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.IsKingTurn = true;
            //Just Move the figures arround 
            gameEngine.Figures[0].X = 2;
            gameEngine.Figures[0].Y = 2;

            gameEngine.Figures[1].X = 3;
            gameEngine.Figures[1].Y = 1;

            // K and C neighbours
            gameEngine.Figures[2].X = 3;
            gameEngine.Figures[2].Y = 5;

            gameEngine.Figures[4].X = 4;
            gameEngine.Figures[4].Y = 6;

            bool result = gameEngine.GameOverCheck();
            bool expected = false;
            Assert.AreEqual(expected, result);
        }

        #endregion

        #region Test CommandParse
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCommandParse_LongerThanExpectedCommand()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.CommandParse("KURR");           
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCommandParse_ShorterThanExpectedCommand()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.CommandParse("KU");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCommandParse_UnexistingFigure()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.CommandParse("NUR");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCommandParse_WrongYCommand()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.CommandParse("KSR");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCommandParse_WrongXCommand()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.CommandParse("KFR");
        }

        # endregion

        #region Test CounterOfMoves

        [TestMethod]
        public void TestGameEngineMovesCounterWithKingsWinKingReachesZeroRowScenario()
        {
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
            uint expectedMoveCount = 7;
            Assert.IsTrue(engine.IsKingWinner);
            Assert.AreEqual(expectedMoveCount, engine.MovesCounter);
        }

        [TestMethod]
        public void TestGameEngineMovesCounterWithKingsWinPawnsHaveNoValidMoveScenario()
        {
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
            commands.AppendFormat(String.Format("DDR{0}", System.Environment.NewLine));
            commands.AppendFormat(String.Format("KDR{0}", System.Environment.NewLine));

            StringReader input = new StringReader(commands.ToString());

            Console.SetIn(input);
            GameEngine engine = new GameEngine();
            engine.Run();
            StringWriter result = new StringWriter();
            Console.SetOut(result);
            uint expectedMoveCount = 28;

            Assert.IsTrue(engine.IsKingWinner);
            Assert.AreEqual(expectedMoveCount, engine.MovesCounter);
        }
      
        [TestMethod]
        public void TestGameEngineMovesCounterWithKingsLosesKingHasNoValidMoveScenario()
        {
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

            StringReader input = new StringReader(commands.ToString());

            Console.SetIn(input);
            GameEngine engine = new GameEngine();
            engine.Run();
            StringWriter result = new StringWriter();
            Console.SetOut(result);
            uint expectedMoveCount = 6;
            Assert.IsFalse(engine.IsKingWinner);
            Assert.AreEqual(expectedMoveCount, engine.MovesCounter);
        }

        #endregion
    }
}
