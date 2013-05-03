using System;
using System.Linq;

namespace KingSurvival
{
    class GameEngine
    {
        static void Main()
        {
            GameField game=new GameField();
            char[,] matrica = game.Matrix;
            Figure car = new King(7,4);
            Figure peshkaA = new Pawn(0, 1);
            Figure peshkaB = new Pawn(0, 3);
            Figure peshkaC = new Pawn(0, 5);
            Figure peshkaD = new Pawn(0, 7);


            matrica[peshkaA.X, peshkaA.Y] = 'A';
            matrica[peshkaB.X, peshkaB.Y] = 'B';
            matrica[peshkaC.X, peshkaC.Y] = 'C';
            matrica[peshkaD.X, peshkaD.Y] = 'D';
            matrica[car.X, car.Y] = 'K';
            game.PrintGameField(matrica);
            bool pobedaPeshki = false;
            bool isKingTurn=true;

            while (car.X > 0 && car.X < matrica.GetLength(0) && !pobedaPeshki)
            {
                isKingTurn = true;
                while (isKingTurn)
                {
                    isKingTurn = false;

                    game.PrintGameField(matrica);
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
                                if (game.CanMoveFugire(car,-1,-1,matrica))
                                {
                                    game.MoveKing(car, -1, -1, matrica);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Move!");
                                    Console.WriteLine("**Press a key to continue**");
                                    Console.ReadKey();
                                    isKingTurn = true;
                                }
                                break;
                            }
                        case "KUR":
                            {
                                if (game.CanMoveFugire(car,-1, 1, matrica))
                                {
                                    game.MoveKing(car, -1, 1, matrica);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Move!");
                                    Console.WriteLine("**Press a key to continue**");
                                    Console.ReadKey();
                                    isKingTurn = true;
                                }
                                
                                break;
                            }
                        case "KDL":
                            {
                                if (game.CanMoveFugire(car , 1, -1, matrica))
                                {
                                    game.MoveKing(car, 1, -1, matrica);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Move!");
                                    Console.WriteLine("**Press a key to continue**");
                                    Console.ReadKey();
                                    isKingTurn = true; 
                                }
                               
                                break;
                            }
                        case "KDR":
                            {
                                if (game.CanMoveFugire(car,1, 1, matrica))
                                {
                                    game.MoveKing(car, 1, 1, matrica);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Move!");
                                    Console.WriteLine("**Press a key to continue**");
                                    Console.ReadKey();
                                    isKingTurn = true;  
                                }
                               
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
                    game.PrintGameField(matrica);
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
                                pobedaPeshki = game.IsPawnAWinner(peshkaA, 1, 1, matrica);

                                if (game.CanMoveFugire(peshkaA,1, 1, matrica))
                                {
                                    game.MovePawn(peshkaA, 1, 1, matrica);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Move!");
                                    Console.WriteLine("**Press a key to continue**");
                                    Console.ReadKey();
                                    isKingTurn = false;
                                }
                                
                                break;
                            }
                        case "ADL":
                            {
                                pobedaPeshki = game.IsPawnAWinner(peshkaA, 1, -1, matrica);

                                if (game.CanMoveFugire(peshkaA , 1, -1, matrica))
                                {
                                    game.MovePawn(peshkaA , 1, -1, matrica);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Move!");
                                    Console.WriteLine("**Press a key to continue**");
                                    Console.ReadKey();
                                    isKingTurn = false;
                                }

                                break;
                            }
                        case "BDR":
                            {
                                pobedaPeshki = game.IsPawnAWinner(peshkaB, 1, 1, matrica);

                                if (game.CanMoveFugire(peshkaB, 1, 1, matrica))
                                {
                                    game.MovePawn(peshkaB, 1, 1, matrica);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Move!");
                                    Console.WriteLine("**Press a key to continue**");
                                    Console.ReadKey();
                                    isKingTurn = false;  
                                }   
                                break;
                            }
                        case "BDL":
                            {
                                pobedaPeshki = game.IsPawnAWinner(peshkaB, 1, -1, matrica);

                                if (game.CanMoveFugire(peshkaB , 1, -1, matrica))
                                {
                                    game.MovePawn(peshkaB, 1, -1, matrica);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Move!");
                                    Console.WriteLine("**Press a key to continue**");
                                    Console.ReadKey();
                                    isKingTurn = false;
                                }   
                                break;
                            }
                        case "CDR":
                            {
                                pobedaPeshki = game.IsPawnAWinner(peshkaC, 1, 1, matrica);

                                if (game.CanMoveFugire(peshkaC, 1, 1, matrica))
                                {
                                    game.MovePawn(peshkaC, 1, 1, matrica);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Move!");
                                    Console.WriteLine("**Press a key to continue**");
                                    Console.ReadKey();
                                    isKingTurn = false;
                                }
                                break;
                            }
                        case "CDL":
                            {
                                pobedaPeshki = game.IsPawnAWinner(peshkaC, 1, -1, matrica);

                                if (game.CanMoveFugire(peshkaC, 1, -1, matrica))
                                {
                                    game.MovePawn(peshkaC, 1, -1, matrica);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Move!");
                                    Console.WriteLine("**Press a key to continue**");
                                    Console.ReadKey();
                                    isKingTurn = false;
                                }
                                break;
                            }
                        case "DDR":
                            {
                                pobedaPeshki = game.IsPawnAWinner(peshkaD, 1, 1, matrica);

                                if (game.CanMoveFugire(peshkaD, 1, 1, matrica))
                                {
                                    game.MovePawn(peshkaD, 1, 1, matrica);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Move!");
                                    Console.WriteLine("**Press a key to continue**");
                                    Console.ReadKey();
                                    isKingTurn = false;
                                }
                                break;
                            }
                        case "DDL":
                            {
                                pobedaPeshki = game.IsPawnAWinner(peshkaD, 1, -1, matrica);

                                if (game.CanMoveFugire(peshkaD, 1, -1, matrica))
                                {
                                    game.MovePawn(peshkaD, 1, -1, matrica);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Move!");
                                    Console.WriteLine("**Press a key to continue**");
                                    Console.ReadKey();
                                    isKingTurn = false;
                                }
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
                    game.PrintGameField(matrica);
                }
            }
            if (pobedaPeshki)
            {
                Console.WriteLine("Pawn`s win!");
            }
            else
            {
                Console.WriteLine("King`s win!");
            }
        }

      
    }
}

        