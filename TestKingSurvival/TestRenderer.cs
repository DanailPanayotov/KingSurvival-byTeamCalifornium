using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using KingSurvival;
using System.Collections.Generic;
using System.IO;

namespace TestKingSurvival
{
    [TestClass]
    public class TestRenderer
    {
        [TestMethod]
        public void TestRenderWithInitialState()
        {
            char[,] matrix = new char[,]   {
                    {'A','-','B','-','C','-','D','-'},
                    {'-','+','-','+','-','+','-','+'},
                    {'+','-','+','-','+','-','+','-'},
                    {'-','+','-','+','-','+','-','+'},
                    {'+','-','+','-','+','-','+','-'},
                    {'-','+','-','+','-','+','-','+'},
                    {'+','-','+','-','+','-','+','-'},
                    {'-','+','-','K','-','+','-','+'}
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

            Renderer render = new Renderer(8);
            List<Figure> figures = new List<Figure>();

            figures.Add(new Pawn(0, 0, 'A'));
            figures.Add(new Pawn(2, 0, 'B'));
            figures.Add(new Pawn(4, 0, 'C'));
            figures.Add(new Pawn(6, 0, 'D'));
            figures.Add(new King(3, 7, 'K'));

            StringWriter result = new StringWriter();
            Console.SetOut(result);

            render.Render(figures);
            Assert.AreEqual(expectedMatrix.ToString(), result.ToString());
        }

        [TestMethod]
        public void TestRenderAfterMovingFiguresOnBoard()
        {

            char[,] matrix = new char[,]   {
                    {'+','-','+','-','C','-','+','-'},
                    {'-','A','-','B','-','D','-','+'},
                    {'+','-','+','-','+','-','+','-'},
                    {'-','+','-','+','-','+','-','+'},
                    {'+','-','+','-','+','-','+','-'},
                    {'-','+','-','+','-','+','-','+'},
                    {'+','-','+','-','K','-','+','-'},
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

            Renderer render = new Renderer(8);
            List<Figure> figures = new List<Figure>();

            figures.Add(new Pawn(0, 0, 'A'));
            figures.Add(new Pawn(2, 0, 'B'));
            figures.Add(new Pawn(4, 0, 'C'));
            figures.Add(new Pawn(6, 0, 'D'));
            figures.Add(new King(3, 7, 'K'));

            figures[0].Move(1, 1);
            figures[1].Move(1, 1);
            figures[3].Move(-1, 1);
            figures[4].Move(1, -1);

            StringWriter result = new StringWriter();
            Console.SetOut(result);

            render.Render(figures);
            Assert.AreEqual(expectedMatrix.ToString(), result.ToString());

        }
    }
}
