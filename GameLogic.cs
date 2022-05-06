using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Battleship.cs
{
    class GameLogic
    {
        public void PlayGame()
        {
            WriteLine("Welcome to Battleship!\n" +
                "The game is played on a 10x10 grid.\n" +
                "The ship is 5 units long and will be randomly placed within the grid.\n" +
                "You have 8 shots to fire in order to sink the ship.\n" +
                "Guesses should be formatted as 2 numbers with a hyphen in between (e.g. 8-7, 4-10, etc.).\n" +
                "The first number is the x-coordinate (number of spots to the right).\n" +
                "The second number is the y-coordinate (number of spots down).\n" +
                "Good luck!");
            int UserGuesses = 8;
            int ShipRemaining = 5;
            List<string> Misses = new List<string>();
            List<string> Hits = new List<string>();
            string[] RandomShipCoordinates = new string[5];
            RandomShipCoordinates = GenerateRandomShipLocation();

            while (UserGuesses > 0 && ShipRemaining > 0)
            {
                WriteLine("Enter your attack coordinates!");
                string AttackCoordinates = ReadLine();
                if (ValidateFormat(AttackCoordinates) == false)
                {
                    WriteLine("Invalid guess!  Try again!");
                    continue;
                }
                if (Hits.Contains($"{AttackCoordinates}") || Misses.Contains($"{AttackCoordinates}"))
                {
                    WriteLine("You already attacked that location!  Try again!");
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
                        WriteLine("You have destroyed the battleship!  You win!");
                        WriteLine("Type 'y' and hit Enter to start a new game!");
                        string Restart = ReadLine();
                        if (Restart == "y" || Restart == "Y")
                        {
                            Clear();
                            UserGuesses = 8;
                            ShipRemaining = 5;
                            Misses.Clear();
                            Hits.Clear();
                            RandomShipCoordinates = GenerateRandomShipLocation();
                        }
                    }
                    else if (UserGuesses == 0 && ShipRemaining > 0)
                    {
                        WriteLine("HIT! You are out of ammo!  Game Over!");
                        WriteLine("Type 'y' and hit Enter to start a new game!");
                        string Restart = ReadLine();
                        if (Restart == "y" || Restart == "Y")
                        {
                            Clear();
                            UserGuesses = 8;
                            ShipRemaining = 5;
                            Misses.Clear();
                            Hits.Clear();
                            RandomShipCoordinates = GenerateRandomShipLocation();
                        }

                    }
                    else if (UserGuesses > 0 && ShipRemaining > 0)
                    {
                        Clear();
                        WriteLine("HIT!");
                        WriteLine($"Attacks remaining: {UserGuesses}");
                        string HitList = string.Join(", ", Hits);
                        string MissList = string.Join(", ", Misses);
                        WriteLine($"Hits: {HitList}");
                        WriteLine($"Misses: {MissList}");

                    }
                }
                else
                {
                    Misses.Add($"{AttackCoordinates}");
                    if (UserGuesses > 0)
                    {
                        Clear();
                        WriteLine("MISS!");
                        WriteLine($"Attacks remaining: {UserGuesses}");
                        string hitList = string.Join(", ", Hits);
                        string missList = string.Join(", ", Misses);
                        WriteLine($"Hits: {hitList}");
                        WriteLine($"Misses: {missList}");
                    }
                    else if (UserGuesses == 0)
                    {
                        Clear();
                        WriteLine("MISS! You ran out of ammo!  Game over!");
                        WriteLine("Type 'y' and hit Enter to start a new game!");
                        string Restart = ReadLine();
                        if (Restart == "y" || Restart == "Y")
                        {
                            Clear();
                            UserGuesses = 8;
                            ShipRemaining = 5;
                            Misses.Clear();
                            Hits.Clear();
                            RandomShipCoordinates = GenerateRandomShipLocation();
                        }
                    }
                }
            }
        }

        static bool ValidateFormat(string UserGuess)
        {
            bool ContainsHyphen = UserGuess.Contains("-");
            if (ContainsHyphen)
            {
                string[] ParseUserGuess = UserGuess.Split("-");
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


        static string[] GenerateRandomShipLocation()
        {
            string[] ShipCoordinates = new string[5];
            Random RandomNumber = new Random();
            int RandomOrientation = RandomNumber.Next(1, 3);
            int RandomStartPosition = RandomNumber.Next(1, 7);
            if (RandomOrientation == 1)
            {
                //generate row
                string RandomRow = Convert.ToString(RandomNumber.Next(1, 11));
                for (int i = 0; i < 5; i++)
                {
                    ShipCoordinates[i] = ($"{RandomRow}-{RandomStartPosition + i}");
                }
                return ShipCoordinates;
            }
            else
            {
                //generate column
                string RandomColumn = Convert.ToString(RandomNumber.Next(1, 11));
                for (int i = 0; i < 5; i++)
                {
                    ShipCoordinates[i] = ($"{RandomStartPosition + i}-{RandomColumn}");
                }
                return ShipCoordinates;
            }
        }


    }




}
    

