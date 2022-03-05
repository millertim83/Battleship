using System;
using System.Collections.Generic;

namespace Battleship.cs
{
    class Program
    {
        static void Main(string[] args)
        {
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
                //Print coordinates
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine(randomShipCoordinates[j]);
                }

                while (userGuesses > 0 && shipRemaining > 0)
                {
                    //bool isHit = true;
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
                    //string convertedCoordinates = convertUserGuess(attackCoordinates);
                    //for (int i = 0; i < 5; i++)
                    //{
                    ///    if (attackCoordinates == randomShipCoordinates[i])
                    //    {
                    //        isHit = true;
                    //    }
                    //}
                    if (attackCoordinates == randomShipCoordinates[0] ||
                        attackCoordinates == randomShipCoordinates[1] ||
                        attackCoordinates == randomShipCoordinates[2] ||
                        attackCoordinates == randomShipCoordinates[3] ||
                        attackCoordinates == randomShipCoordinates[4]
                        )
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
                                //for loop here just to confirm ship location is being re-generated.  delete later
                                for (int j = 0; j < 5; j++)
                                {
                                    Console.WriteLine(randomShipCoordinates[j]);
                                }
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

        }
    }
}
