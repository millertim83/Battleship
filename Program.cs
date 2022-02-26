using System;

namespace Battleship.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            // "-" empty spot
            // "x" hit
            // "o" miss
            // "*" ship location

            

            string[,] gameCanvas = new string[,]
            {
                { "-", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" },
                { "1", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                { "2", "-", "-", "-", "-", "-", "-", "*", "-", "-", "-" },
                { "3", "-", "-", "-", "-", "-", "-", "*", "-", "-", "-" },
                { "4", "-", "-", "-", "-", "-", "-", "*", "-", "-", "-" },
                { "5", "-", "-", "-", "-", "-", "-", "*", "-", "-", "-" },
                { "6", "-", "-", "-", "-", "-", "-", "*", "-", "-", "-" },
                { "7", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                { "8", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                { "9", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                { "10", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" }
            };

            static void playGame()
            {

                int userGuesses = 8;
                int shipRemaining = 5;
                string[] misses = Array.Empty<string>();
                string[] hits = Array.Empty<string>();

                Console.WriteLine("Enter your attack coordinates");
                string attackCoordinates = Console.ReadLine();
                Console.WriteLine($"You attacked {attackCoordinates}");
                userGuesses -= 1;
                Console.WriteLine($"Attacks remaining: {userGuesses}");



            }

            static void parseUserGuess()
            {


            }

            playGame();

            


            





            /*
            Console.WriteLine("A   B   C   D   E   F   G   H   I   J 
                            1  -   -   -   -   -   -   -   -   -   - 
                            2  -   -   -   -   -   -   -   -   -   -
                            3  -   -   -   -   -   -   -   -   -   -
                            4  -   -   -   -   -   -   -   -   -   -
                            5  -   -   -   -   -   -   -   -   -   -
                            6  -   -   -   -   -   -   -   -   -   -
                            7  -   -   -   -   -   -   -   -   -   -
                            8  -   -   -   -   -   -   -   -   -   -
                            9  -   -   -   -   -   -   -   -   -   - 
                            10 -   -   -   -   -   -   -   -   -   -");
            */

        }
    }
}
