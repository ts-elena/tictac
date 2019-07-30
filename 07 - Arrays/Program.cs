using System;
using System.Linq;

namespace _07___Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // Тут многомерный массив с полями
            string[,] ticTacToe = new string[3, 3]
            {
                {"1", "2", "3"},
                {"4", "5", "6"},
                {"7", "8", "9"}
            };

            // это отрисовка его в консоли
            void ShowDeck()
            {
                Console.WriteLine("     |     |     ");
                Console.WriteLine("  {0}  |  {1}  |  {2}  ", ticTacToe[0, 0], ticTacToe[0, 1], ticTacToe[0, 2]);
                Console.WriteLine("_____|_____|_____");
                Console.WriteLine("     |     |    ");
                Console.WriteLine("  {0}  |  {1}  |  {2}  ", ticTacToe[1, 0], ticTacToe[1, 1], ticTacToe[1, 2]);
                Console.WriteLine("_____|_____|_____");
                Console.WriteLine("     |     |     ");
                Console.WriteLine("  {0}  |  {1}  |  {2}  ", ticTacToe[2, 0], ticTacToe[2, 1], ticTacToe[2, 2]);
                Console.WriteLine("     |     |     ");
            }


            bool isSquareTaken = false;
            //тут я храню поле, которое выбрал юзер
            int chosenSquare;
            // тут я храню, сколько ходов уже сделанно
            int turnNumber = 0;
            //тут отмечены номера очередей, когда когда должен ходить X
            int[] turnForX = { 1, 3, 5, 7, 9 };


            void CheckForWin()
            {
                string winMessage = "Player '{0}' is the winner!";

                // Diagonal from the left
                if (ticTacToe[0, 0] == ticTacToe[1, 1] && ticTacToe[1, 1] == ticTacToe[2, 2])
                {
                    Console.WriteLine(winMessage, ticTacToe[0, 0]);
                }
                // Diagonal from the right
                else if (ticTacToe[0, 2] == ticTacToe[1, 1] && ticTacToe[1, 1] == ticTacToe[2, 0])
                {
                    Console.WriteLine(winMessage, ticTacToe[0, 2]);
                }
                // Last horizontal
                else if (ticTacToe[2, 0] == ticTacToe[2, 1] && ticTacToe[2, 1] == ticTacToe[2, 2])
                {
                    Console.WriteLine(winMessage, ticTacToe[2, 0]);
                }
                // middle horizontal
                else if (ticTacToe[1, 0] == ticTacToe[1, 1] && ticTacToe[1, 1] == ticTacToe[1, 2])
                {
                    Console.WriteLine(winMessage, ticTacToe[1, 0]);
                }
                // upper horizontal
                else if (ticTacToe[0, 0] == ticTacToe[0, 1] && ticTacToe[0, 1] == ticTacToe[0, 2])
                {
                    Console.WriteLine(winMessage, ticTacToe[0, 0]);
                }
                // Down first
                else if (ticTacToe[0, 0] == ticTacToe[1, 0] && ticTacToe[1, 0] == ticTacToe[2, 0])
                {
                    Console.WriteLine(winMessage, ticTacToe[0, 0]);
                }
                // Down middle
                else if (ticTacToe[0, 1] == ticTacToe[1, 1] && ticTacToe[1, 1] == ticTacToe[2, 1])
                {
                    Console.WriteLine(winMessage, ticTacToe[0, 1]);
                }
                // Down last
                else if (ticTacToe[0, 2] == ticTacToe[1, 2] && ticTacToe[1, 2] == ticTacToe[2, 2])
                {
                    Console.WriteLine(winMessage, ticTacToe[0, 2]);
                }
                else
                {
                    ChooseSquare();
                }
            }

            void SetCrossOrCircle(int value)
            {
                string stringValue = value.ToString();

                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        if (ticTacToe[x, y] == stringValue)
                        {
                            if (turnForX.Contains(turnNumber))
                            {
                                ticTacToe[x, y] = "X";
                                Console.Clear();
                                ShowDeck();
                                CheckForWin();
                            }
                             else
                            {
                                ticTacToe[x, y] = "O";
                                Console.Clear();
                                ShowDeck();
                                CheckForWin();
                            }
                           
                        }
                    }
                }
            }

            bool CheckifSquareIsTaken(int squareNum)
            {
                foreach(string i in ticTacToe)
                {
                    if (i == squareNum.ToString())
                    {
                        isSquareTaken = false;
                        break;
                    }
                    else
                    {
                        isSquareTaken = true;
                    }
                }

                return isSquareTaken;
            }



            void ChooseSquare()
            {
                if (turnNumber < 9)
                {
                    Console.WriteLine("Please, enter square number");
                    bool isItInteger = int.TryParse(Console.ReadLine(), out chosenSquare);

                    string warning = "Ooops, no such square. Choose an empty square from 1 to 9 ;). Go ahead, try again!";

                    if (isItInteger == false)
                    {
                        Console.WriteLine(warning);
                        ChooseSquare();
                    }
                    else if (chosenSquare > 9 || chosenSquare < 0)
                    {
                        Console.WriteLine(warning);
                        ChooseSquare();
                    }
                    else if (CheckifSquareIsTaken(chosenSquare))
                    {
                        Console.WriteLine(warning);
                        ChooseSquare();
                    }
                    else
                    {
                        turnNumber++;
                        SetCrossOrCircle(chosenSquare);
                    }
                }
                else
                {
                    Console.WriteLine("No squares to fill, end of the game :)");
                }
            }

            ShowDeck();
            ChooseSquare();
            Console.ReadKey();
        }
    }
}
