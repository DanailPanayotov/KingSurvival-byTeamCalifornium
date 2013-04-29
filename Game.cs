// ********************************
// <copyright file="Game.cs" company="Team Californium">
// Copyright (c) 2013 Team Californium. All rights reserved.
// </copyright>
//
// ********************************
namespace KingSurvival
{
    using System;
    using System.Linq;
    //trying something
    
    //trying again
    public class Game
    {
        static int size = 8;
        static King theKing = new King(4, 7);
        static Pawn pawnA = new Pawn(1, 0);        
        static Pawn pawnB = new Pawn(3, 0);        
        static Pawn pawnC = new Pawn(5, 0);        
        static Pawn pawnD = new Pawn(7, 0);
        
        static bool isKingTurn = true;

        static void Print(char[,] matrix)
        {        
            Console.Clear();
            
            for (int i = 0; i < size; i++)           
            {            
                for (int j = 0; j < size; j++)                
                {                
                    Console.Write("{0,2}", matrix[i, j]);
                }
               
                Console.WriteLine("");           
            }
        }

        static void KingMove(int dirX, int dirY, char[,] matrix)
        {
            if (theKing.X + dirX < 0 || theKing.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = true;
                return;
            }

            if (theKing.Y + dirY < 0 || theKing.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = true;
                return;
            }

            if (matrix[theKing.Y + dirY, theKing.X + dirX] == 'A') 
            {
                matrix[theKing.Y + dirY, theKing.X + dirX] = 'K';
                matrix[pawnA.Y, pawnA.X] = '-';
            }

            if (matrix[theKing.Y + dirY, theKing.X + dirX] == 'B')
            {
                matrix[theKing.Y + dirY, theKing.X + dirX] = 'K';
                matrix[pawnB.Y, pawnB.X] = '-';
            }

            if (matrix[theKing.Y + dirY, theKing.X + dirX] == 'C')
            {
                matrix[theKing.Y + dirY, theKing.X + dirX] = 'K';
                matrix[pawnC.Y, pawnC.X] = '-';
            }

            if (matrix[theKing.Y + dirY, theKing.X + dirX] == 'D')
            {
                matrix[theKing.Y + dirY, theKing.X + dirX] = 'K';
                matrix[pawnD.Y, pawnD.X] = '-';
            }

            matrix[theKing.Y, theKing.X] = '-';
            matrix[theKing.Y + dirY, theKing.X + dirX] = 'K';
            theKing.Y += dirY;
            theKing.X += dirX;
            return;
        }

        // TODO - One method for Pown move called with current pawn (A, B, C or D)
        static bool PawnAMove(int dirX, int dirY, char[,] matrix)
        {
            //sledvat mnogo proverki
            if (pawnA.X + dirX < 0 || pawnA.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
                
            }

            if (pawnA.Y + dirY < 0 || pawnA.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            if (matrix[pawnA.Y + dirY, pawnA.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }

            if (matrix[pawnA.Y + dirY, pawnA.X + dirX] == 'D' ||
                matrix[pawnA.Y + dirY, pawnA.X + dirX] == 'B' || 
                matrix[pawnA.Y + dirY, pawnA.X + dirX] == 'C')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            //ako ne grymne do momenta znachi e validen hoda
           
            matrix[pawnA.Y, pawnA.X] = '-';
            matrix[pawnA.Y + dirY, pawnA.X + dirX] = 'A';
            pawnA.Y += dirY;
            pawnA.X += dirX;
            return false;
        }

        static bool PawnBMove(int dirX, int dirY, char[,] matrix)
        {//za dokumentaciq pregledai PawnAMove
            if (pawnB.X + dirX < 0 || pawnB.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            if (pawnB.Y + dirY < 0 || pawnB.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }
            if (matrix[pawnB.Y + dirY, pawnB.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }

            if (matrix[pawnB.Y + dirY, pawnB.X + dirX] == 'A' || matrix[pawnB.Y + dirY, pawnB.X + dirX] == 'C' 
                || matrix[pawnB.Y + dirY, pawnB.X + dirX] == 'D')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }
            matrix[pawnB.Y, pawnB.X] = '-';
            matrix[pawnB.Y + dirY, pawnB.X + dirX] = 'B';
            pawnB.Y += dirY;
            pawnB.X += dirX;
            return false;
        }
        static bool PawnCMove(int dirX, int dirY, char[,] matrix)
        {//za dokumentaciq pregledai PawnAMove
            if (pawnC.X + dirX < 0 || pawnC.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }
            if (pawnC.Y + dirY < 0 || pawnC.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }
            if (matrix[pawnC.Y + dirY, pawnC.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }
            if (matrix[pawnC.Y + dirY, pawnC.X + dirX] == 'A' || matrix[pawnC.Y + dirY, pawnC.X + dirX] == 'B'
                || matrix[pawnC.Y + dirY, pawnC.X + dirX] == 'D')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            matrix[pawnC.Y, pawnC.X] = '-';
            matrix[pawnC.Y + dirY, pawnC.X + dirX] = 'C';
            pawnC.Y += dirY;
            pawnC.X += dirX;
            return false;
        }
        static bool PawnDMove(int dirX, int dirY, char[,] matrix)
        {//za dokumentaciq pregledai PawnAMove
            if (pawnD.Y + dirY < 0 || pawnD.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            if (pawnD.X + dirX < 0 || pawnD.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }
            if (matrix[pawnD.Y + dirY, pawnD.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }
            if (matrix[pawnD.Y + dirY, pawnD.X + dirX] == 'A' || matrix[pawnD.Y + dirY, pawnD.X + dirX] == 'B'
                                                             || matrix[pawnD.Y + dirY, pawnD.X + dirX] == 'C')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
                return false;
            }

            matrix[pawnD.Y, pawnD.X] = '-';
            matrix[pawnD.Y + dirY, pawnD.X + dirX] = 'D';
            pawnD.Y += dirY;
            pawnD.X += dirX;
            return false;
        }

                
        static void Main()
        {
            char[,] gameField = new char[,] 
            {
                {'+','-','+','-','+','-','+','-'},
                {'-','+','-','+','-','+','-','+'},
                {'+','-','+','-','+','-','+','-'},
                {'-','+','-','+','-','+','-','+'},
                {'+','-','+','-','+','-','+','-'},
                {'-','+','-','+','-','+','-','+'},
                {'+','-','+','-','+','-','+','-'},
                {'-','+','-','+','-','+','-','+'}
            };
                        
            gameField[pawnA.Y, pawnA.X] = 'A';
            gameField[pawnB.Y, pawnB.X] = 'B';
            gameField[pawnC.Y, pawnC.X] = 'C';
            gameField[pawnD.Y, pawnD.X] = 'D';
            gameField[theKing.Y, theKing.X] = 'K';

            Print(gameField);

            int movesCounter = 0;
            bool pobedaPeshki = false;

            while (theKing.Y > 0 && theKing.Y < size && !pobedaPeshki)
            {
                movesCounter++;
                isKingTurn = true;
                while (isKingTurn)
                {
                    isKingTurn = false;

                    Print(gameField);
                    Console.Write("King`s Turn:");
                    string direction = Console.ReadLine();
                    if (direction == "")
                    {
                        isKingTurn = true;
                        continue;
                    }

                    direction = direction.ToUpper();

                    switch (direction)
                    {
                        case "KUL":
                            {
                                KingMove(-1, -1, gameField);
                                break;
                            }
                        case "KUR":
                            {
                                KingMove(1, -1, gameField);
                                break;
                            }
                        case "KDL":
                            {
                                KingMove(-1, 1, gameField);
                                break;
                            }
                        case "KDR":
                            {
                                KingMove(1, 1, gameField);
                                break;
                            }
                        default:
                            {
                                isKingTurn = true;
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine("**Press a key to continue**");
                                Console.ReadKey();
                                break;
                            }

                    }
                }
                while (!isKingTurn)
                {
                    isKingTurn = true;
                    Print(gameField);
                    Console.Write("Pawn`s Turn:");
                    string direction = Console.ReadLine();
                    if (direction == "")
                    {
                        isKingTurn = false;
                        continue;
                    }

                    direction = direction.ToUpper();

                    switch (direction)
                    {
                        case "ADR":
                            {
                                pobedaPeshki= PawnAMove(1, 1, gameField);
                                break;
                            }
                        case "ADL":
                            {
                                pobedaPeshki = PawnAMove(-1, 1, gameField);
                                break;
                            }
                        case "BDL":
                            {
                                pobedaPeshki = PawnBMove(-1, 1, gameField);
                                break;
                            }
                        case "BDR":
                            {
                                pobedaPeshki = PawnBMove(1, 1, gameField);
                                break;
                            }
                        case "CDL":
                            {
                                pobedaPeshki = PawnCMove(-1, 1, gameField);
                                break;
                            }
                        case "CDR":
                            {
                                pobedaPeshki = PawnCMove(1, 1, gameField);
                                break;
                            }
                        case "DDR":
                            {
                              pobedaPeshki =   PawnDMove(1, 1, gameField);
                                break;
                            }
                        case "DDL":
                            {
                              pobedaPeshki = PawnDMove(-1, 1, gameField);
                                break;
                            }
                        default:
                            {
                                isKingTurn = false;
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine("**Press a key to continue**");
                                Console.ReadKey();
                                break;
                            }
                    }

                    Print(gameField);
                }
            }

            if (pobedaPeshki)
            {
                Console.WriteLine("Pawn`s win!");
            }

            else
            {
                Console.WriteLine("King wins in {0} turns!", movesCounter);
            }
        }
    }
}     
