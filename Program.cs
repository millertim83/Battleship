using System;
using System.Collections.Generic;

namespace Battleship.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] gameCanvas = new string[,]
               {
                    { " -", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" },
                    { " 1", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                    { " 2", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                    { " 3", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                    { " 4", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                    { " 5", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                    { " 6", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                    { " 7", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                    { " 8", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                    { " 9", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                    { "10", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" }
               };
            //code below prints array to console
            for (int i = 0; i < gameCanvas.GetLength(0); i++)
            {
                for (int j = 0; j < gameCanvas.GetLength(1); j++)
                {
                    Console.Write("{0} ", gameCanvas[i, j]);
                }
                Console.WriteLine();            }

            playGame();
        
            static void playGame()
            {
                Console.WriteLine("Welcome to Battleship!\n" +
                    "The game is played on a 10x10 grid.\n" +
                    "The ship is 5 units long and will be randomly placed within the grid.\n" +
                    "You have 8 shots to fire in order to sink the ship.\n" +
                    "Guesses should be formatted as 2 numbers with a hyphen (e.g. 8-7, 4-10, etc.) in between.\n" +
                    "The first number is the x-coordinate (number of spots to the right).\n" +
                    "The second number is the y-coordinate (number of spots down).\n" +
                    "Good luck!");
                int userGuesses = 8;
                int shipRemaining = 5;
                List<string> misses = new List<string>();
                List<string> hits = new List<string>();
                string[] randomShipCoordinates = new string[5];
                randomShipCoordinates = generateRandomShipLocation();

                for (int i = 0; i < 5; i ++)
                {
                    Console.WriteLine(randomShipCoordinates[i]);
                }
            
                while (userGuesses > 0 && shipRemaining > 0)
                {
                    Console.WriteLine("Enter your attack coordinates!");
                    string attackCoordinates = Console.ReadLine();
                    if (validateFormat(attackCoordinates) == false)
                    {
                        Console.WriteLine("Invalid guess!  Try again!");
                        continue;
                    }
                    if (hits.Contains($"{attackCoordinates}") || misses.Contains($"{attackCoordinates}"))
                    {
                        Console.WriteLine("You already attacked that location!  Try again!");
                        continue;
                    }
                    userGuesses -= 1;

                    if (attackCoordinates == randomShipCoordinates[0] ||
                        attackCoordinates == randomShipCoordinates[1] ||
                        attackCoordinates == randomShipCoordinates[2] ||
                        attackCoordinates == randomShipCoordinates[3] ||
                        attackCoordinates == randomShipCoordinates[4])
                    {
                        shipRemaining -= 1;
                        hits.Add($"{attackCoordinates}");
                        if (userGuesses > 0 && shipRemaining == 0)
                        {
                            
                           
                            Console.WriteLine("You have destroyed the battleship!  You win!");
                            Console.WriteLine("Type 'y' and hit Enter to start a new game!");
                            string restart = Console.ReadLine();
                            if (restart == "y" || restart == "Y")
                            {
                                Console.Clear();
                                userGuesses = 8;
                                shipRemaining = 5;
                                misses.Clear();
                                hits.Clear();
                                randomShipCoordinates = generateRandomShipLocation();
                            }

                        }
                        else if (userGuesses == 0 && shipRemaining > 0)
                        {
                            Console.WriteLine("HIT! You are out of ammo!  Game Over!");
                            Console.WriteLine("Type 'y' and hit Enter to start a new game!");
                            string restart = Console.ReadLine();
                            if (restart == "y" || restart == "Y")
                            {
                                Console.Clear();
                                userGuesses = 8;
                                shipRemaining = 5;
                                misses.Clear();
                                hits.Clear();
                                randomShipCoordinates = generateRandomShipLocation();
                            }

                        }
                        else if (userGuesses > 0 && shipRemaining > 0)
                        {
                            Console.Clear();
                            Console.WriteLine("HIT!");
                            Console.WriteLine($"Attacks remaining: {userGuesses}");
                            string hitList = string.Join(", ", hits);
                            string missList = string.Join(", ", misses);
                            Console.WriteLine($"Hits: {hitList}");
                            Console.WriteLine($"Misses: {missList}");

                        }
                    }
                    else
                    {
                        misses.Add($"{attackCoordinates}");
                        if (userGuesses > 0)
                        {
                            Console.Clear();
                            Console.WriteLine("MISS!");
                            Console.WriteLine($"Attacks remaining: {userGuesses}");
                            string hitList = string.Join(", ", hits);
                            string missList = string.Join(", ", misses);
                            Console.WriteLine($"Hits: {hitList}");
                            Console.WriteLine($"Misses: {missList}");
                        }
                        else if (userGuesses == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("MISS! You ran out of ammo!  Game over!");
                            Console.WriteLine("Type 'y' and hit Enter to start a new game!");
                            string restart = Console.ReadLine();
                            if (restart == "y" || restart == "Y")
                            {
                                Console.Clear();
                                userGuesses = 8;
                                shipRemaining = 5;
                                misses.Clear();
                                hits.Clear();
                                randomShipCoordinates = generateRandomShipLocation();
                            }
                        }
                    }
                }
            }

            static bool validateFormat(string userGuess)
            {
                bool containsHyphen = userGuess.Contains("-");
                if (containsHyphen)
                {
                    string[] parseUserGuess = userGuess.Split("-");
                    int xCoord;
                    int yCoord;
                    bool validX = int.TryParse((parseUserGuess[0]), out xCoord);
                    bool validY = int.TryParse((parseUserGuess[1]), out yCoord);
                    if (validX == true && validY == true && xCoord > 0 && xCoord < 11 && yCoord > 0 && yCoord < 11)
                    {
                        return true;
                    }
                    else return false;

                }
                else return false;
            }


            static string[] generateRandomShipLocation()
            {
                string[] shipCoordinates = new string[5];
                Random random = new Random();
                int randomOrientation = random.Next(1, 3);
                int randomStartPosition = random.Next(1, 7);
                if (randomOrientation == 1)
                {
                    //generate row
                    string randomRow = Convert.ToString(random.Next(1, 11));
                    for (int i = 0; i < 5; i++)
                    {
                        shipCoordinates[i] = ($"{randomRow}-{randomStartPosition + i}");
                    }
                    return shipCoordinates;
                }
                else
                {
                    //generate column
                    string randomColumn = Convert.ToString(random.Next(1, 11));
                    for (int i = 0; i < 5; i++)
                    {
                        shipCoordinates[i] = ($"{randomStartPosition + i}-{randomColumn}");
                    }
                    return shipCoordinates;
                }
            }

            static int[] convertUserGuess(string guess)
            {

                // Examples of user guess - gameCanvas => 1-8 - [8,1]; 4-5 - [5,4]
                string[] convertedAttackLocation = guess.Split("-");
                int[] convertedCoordinates = new int[2];
                int yCoordinate = int.Parse(convertedAttackLocation[1]);
                string xCoordinate = convertedAttackLocation[0];
                int convertedX = 1;
                //Need to use implement loop for if statements - went with what I knew would work
                if (xCoordinate == "a" || xCoordinate =="A")
                {
                    convertedX = 1;   
                } else if (xCoordinate == "b" || xCoordinate == "B")
                {
                    convertedX = 2;
                } else if (xCoordinate == "c" || xCoordinate == "C")
                {
                    convertedX = 3;
                } else if (xCoordinate == "d" || xCoordinate == "D")
                {
                    convertedX = 4;
                } else if (xCoordinate == "e" || xCoordinate == "E")
                {
                    convertedX = 5;
                } else if (xCoordinate == "f" || xCoordinate == "F")
                {
                    convertedX = 6;
                } else if (xCoordinate == "g" || xCoordinate == "G")
                {
                    convertedX = 7;
                } else if (xCoordinate == "h" || xCoordinate == "H")
                {
                    convertedX = 8;
                } else if (xCoordinate == "i" || xCoordinate == "I")
                {
                    convertedX = 9;
                } else if (xCoordinate == "j" || xCoordinate == "J")
                {
                    convertedX = 10;
                }
                convertedCoordinates[0] = yCoordinate;
                convertedCoordinates[1] = convertedX;
                return convertedCoordinates;
                //string modifiedUserGuess = ($"{yCoordinate}-{xCoordinate}");
                //return modifiedUserGuess;

            }


        }
    }
}
