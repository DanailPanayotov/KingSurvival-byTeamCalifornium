using System;
using System.Linq;

namespace KingSurvival
{
    class GameEngine
    {
        static void Main()
        {
            GameField gameField=new GameField();
            char[,] matrica = gameField.Matrix;
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
            gameField.PrintGameField(matrica);
            bool pobedaPeshki = false;
            bool isKingTurn=true;

            while (car.X > 0 && car.X < matrica.GetLength(0) && !pobedaPeshki)
            {
                isKingTurn = true;
                while (isKingTurn)
                {
                    isKingTurn = false;

                    gameField.PrintGameField(matrica);
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
                                if (gameField.CanMoveFugire(car,-1,-1,matrica))
                                {
                                    gameField.MoveKing(car, -1, -1, matrica);
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
                                if (gameField.CanMoveFugire(car,-1, 1, matrica))
                                {
                                    gameField.MoveKing(car, -1, 1, matrica);
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
                                if (gameField.CanMoveFugire(car , 1, -1, matrica))
                                {
                                    gameField.MoveKing(car, 1, -1, matrica);
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
                                if (gameField.CanMoveFugire(car,1, 1, matrica))
                                {
                                    gameField.MoveKing(car, 1, 1, matrica);
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
                    gameField.PrintGameField(matrica);
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
                                pobedaPeshki = gameField.IsPawnAWinner(peshkaA, 1, 1, matrica);

                                if (gameField.CanMoveFugire(peshkaA,1, 1, matrica))
                                {
                                    gameField.MovePawn(peshkaA, 1, 1, matrica);
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
                                pobedaPeshki = gameField.IsPawnAWinner(peshkaA, 1, -1, matrica);

                                if (gameField.CanMoveFugire(peshkaA , 1, -1, matrica))
                                {
                                    gameField.MovePawn(peshkaA , 1, -1, matrica);
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
                                pobedaPeshki = gameField.IsPawnAWinner(peshkaB, 1, 1, matrica);

                                if (gameField.CanMoveFugire(peshkaB, 1, 1, matrica))
                                {
                                    gameField.MovePawn(peshkaB, 1, 1, matrica);
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
                                pobedaPeshki = gameField.IsPawnAWinner(peshkaB, 1, -1, matrica);

                                if (gameField.CanMoveFugire(peshkaB , 1, -1, matrica))
                                {
                                    gameField.MovePawn(peshkaB, 1, -1, matrica);
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
                                pobedaPeshki = gameField.IsPawnAWinner(peshkaC, 1, 1, matrica);

                                if (gameField.CanMoveFugire(peshkaC, 1, 1, matrica))
                                {
                                    gameField.MovePawn(peshkaC, 1, 1, matrica);
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
                                pobedaPeshki = gameField.IsPawnAWinner(peshkaC, 1, -1, matrica);

                                if (gameField.CanMoveFugire(peshkaC, 1, -1, matrica))
                                {
                                    gameField.MovePawn(peshkaC, 1, -1, matrica);
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
                                pobedaPeshki = gameField.IsPawnAWinner(peshkaD, 1, 1, matrica);

                                if (gameField.CanMoveFugire(peshkaD, 1, 1, matrica))
                                {
                                    gameField.MovePawn(peshkaD, 1, 1, matrica);
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
                                pobedaPeshki = gameField.IsPawnAWinner(peshkaD, 1, -1, matrica);

                                if (gameField.CanMoveFugire(peshkaD, 1, -1, matrica))
                                {
                                    gameField.MovePawn(peshkaD, 1, -1, matrica);
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
                    gameField.PrintGameField(matrica);
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

        