using System;
namespace Battleship.cs
{
    public class GameLogic
    {
        public GameLogic()
        {

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
                int UserGuesses = 8;
                int ShipRemaining = 5;
                List<string> Misses = new List<string>();
                List<string> Hits = new List<string>();
                string[] RandomShipCoordinates = new string[5];
                RandomShipCoordinates = generateRandomShipLocation();

                while (UserGuesses > 0 && ShipRemaining > 0)
                {
                    Console.WriteLine("Enter your attack coordinates!");
                    string AttackCoordinates = Console.ReadLine();
                    if (validateFormat(AttackCoordinates) == false)
                    {
                        Console.WriteLine("Invalid guess!  Try again!");
                        continue;
                    }
                    if (Hits.Contains($"{AttackCoordinates}") || Misses.Contains($"{AttackCoordinates}"))
                    {
                        Console.WriteLine("You already attacked that location!  Try again!");
                        continue;
                    }
                    UserGuesses -= 1;

                    if (AttackCoordinates == RandomShipCoordinates[0] ||
                        AttackCoordinates == RandomShipCoordinates[1] ||
                        AttackCoordinates == RandomShipCoordinates[2] ||
                        AttackCoordinates == RandomShipCoordinates[3] ||
                        AttackCoordinates == RandomShipCoordinates[4])
                    {
                        ShipRemaining -= 1;
                        Hits.Add($"{AttackCoordinates}");
                        if (UserGuesses > 0 && ShipRemaining == 0)
                        {
                            Console.WriteLine("You have destroyed the battleship!  You win!");
                            Console.WriteLine("Type 'y' and hit Enter to start a new game!");
                            string restart = Console.ReadLine();
                            if (restart == "y" || restart == "Y")
                            {
                                Console.Clear();
                                UserGuesses = 8;
                                ShipRemaining = 5;
                                Misses.Clear();
                                Hits.Clear();
                                RandomShipCoordinates = generateRandomShipLocation();
                            }

                        }
                        else if (UserGuesses == 0 && ShipRemaining > 0)
                        {
                            Console.WriteLine("HIT! You are out of ammo!  Game Over!");
                            Console.WriteLine("Type 'y' and hit Enter to start a new game!");
                            string restart = Console.ReadLine();
                            if (restart == "y" || restart == "Y")
                            {
                                Console.Clear();
                                UserGuesses = 8;
                                ShipRemaining = 5;
                                Misses.Clear();
                                Hits.Clear();
                                RandomShipCoordinates = generateRandomShipLocation();
                            }

                        }
                        else if (UserGuesses > 0 && ShipRemaining > 0)
                        {
                            Console.Clear();
                            Console.WriteLine("HIT!");
                            Console.WriteLine($"Attacks remaining: {UserGuesses}");
                            string HitList = string.Join(", ", Hits);
                            string MissList = string.Join(", ", Misses);
                            Console.WriteLine($"Hits: {HitList}");
                            Console.WriteLine($"Misses: {MissList}");

                        }
                    }
                    else
                    {
                        Misses.Add($"{AttackCoordinates}");
                        if (UserGuesses > 0)
                        {
                            Console.Clear();
                            Console.WriteLine("MISS!");
                            Console.WriteLine($"Attacks remaining: {UserGuesses}");
                            string hitList = string.Join(", ", Hits);
                            string missList = string.Join(", ", Misses);
                            Console.WriteLine($"Hits: {hitList}");
                            Console.WriteLine($"Misses: {missList}");
                        }
                        else if (UserGuesses == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("MISS! You ran out of ammo!  Game over!");
                            Console.WriteLine("Type 'y' and hit Enter to start a new game!");
                            string Restart = Console.ReadLine();
                            if (Restart == "y" || Restart == "Y")
                            {
                                Console.Clear();
                                UserGuesses = 8;
                                ShipRemaining = 5;
                                Misses.Clear();
                                Hits.Clear();
                                RandomShipCoordinates = generateRandomShipLocation();
                            }
                        }
                    }
                }
            }

            static bool validateFormat(string userGuess)
            {
                bool ContainsHyphen = userGuess.Contains("-");
                if (ContainsHyphen)
                {
                    string[] ParseUserGuess = userGuess.Split("-");
                    int XCoord;
                    int YCoord;
                    bool ValidX = int.TryParse((ParseUserGuess[0]), out XCoord);
                    bool ValidY = int.TryParse((ParseUserGuess[1]), out YCoord);
                    if (ValidX == true && ValidY == true && XCoord > 0 && XCoord < 11 && YCoord > 0 && YCoord < 11)
                    {
                        return true;
                    }
                    else return false;

                }
                else return false;
            }


            static string[] generateRandomShipLocation()
            {
                string[] ShipCoordinates = new string[5];
                Random random = new Random();
                int RandomOrientation = random.Next(1, 3);
                int RandomStartPosition = random.Next(1, 7);
                if (RandomOrientation == 1)
                {
                    //generate row
                    string RandomRow = Convert.ToString(random.Next(1, 11));
                    for (int i = 0; i < 5; i++)
                    {
                        ShipCoordinates[i] = ($"{RandomRow}-{RandomStartPosition + i}");
                    }
                    return ShipCoordinates;
                }
                else
                {
                    //generate column
                    string RandomColumn = Convert.ToString(random.Next(1, 11));
                    for (int i = 0; i < 5; i++)
                    {
                        ShipCoordinates[i] = ($"{RandomStartPosition + i}-{RandomColumn}");
                    }
                    return ShipCoordinates;
                }
            }

        }
    }
}
