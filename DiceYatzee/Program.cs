using System;
using System.Collections.Generic;

namespace DiceYatzee
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Yatzee!");

            int maxTurns = 5; // Change to 5 for 5 turns

            Console.Write("Enter the number of players: ");
            int numPlayers = int.Parse(Console.ReadLine());

            List<Players> playersList = new List<Players>();

            for (int playerIndex = 0; playerIndex < numPlayers; playerIndex++)
            {
                Console.Write($"\nEnter the name of Player {playerIndex + 1}: ");
                string playerName = Console.ReadLine();
                playersList.Add(new Players(playerName, 5)); // Assuming 5 dice
            }

            for (int turn = 1; turn <= maxTurns; turn++)
            {
                Console.WriteLine($"\n--- Turn {turn} ---");

                foreach (Players player in playersList)
                {
                    Console.WriteLine($"Hello, {player.Name}!");
                    Console.WriteLine($"Current score: {player.CalculateScore()}");
                    Console.WriteLine("Press any key to roll the dice...");
                    Console.ReadKey();

                    Random random = new Random();
                    player.RollDice(random);
                    Console.WriteLine("Dice roll: " + player);

                    Console.WriteLine("Do you want to hold any dice? (y/n)");
                    char choice = char.ToLower(Console.ReadKey().KeyChar);
                    if (choice == 'y')
                    {
                        Console.WriteLine("\nHere are the dice indices and values:");
                        for (int i = 0; i < player.DiceValue.Length; i++)
                        {
                            Console.WriteLine($"[{i + 1}] - {player.DiceValue[i]}");
                        }

                        bool[] holdDice = new bool[player.DiceValue.Length];
                        Console.Write("\nEnter the indices of dice to hold (comma-separated, e.g., 1,3,5): ");
                        string input = Console.ReadLine();
                        string[] indices = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string indexStr in indices)
                        {
                            if (int.TryParse(indexStr, out int index) && index >= 1 && index <= player.DiceValue.Length)
                            {
                                holdDice[index - 1] = true; // Convert to zero-based index
                            }
                            else
                            {
                                Console.WriteLine($"Invalid index: {indexStr}");
                            }
                        }

                        // Reroll only unheld dice
                        player.RollDice(random, holdDice);
                        Console.WriteLine("Dice after holding: " + player);
                    }
                }
            }

            // Determine the winner
            Players winner = DetermineWinner(playersList);
            if (winner != null)
            {
                Console.WriteLine($"\n{winner.Name} has won with a score of {winner.CalculateScore()}!");
            }
            else
            {
                Console.WriteLine("\nNo winner this time. Better luck next time!");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static Players DetermineWinner(List<Players> players)
        {
            Players winner = null;
            int highestScore = -1;

            foreach (Players player in players)
            {
                int score = player.CalculateScore();
                if (score > highestScore)
                {
                    highestScore = score;
                    winner = player;
                }
            }

            return winner;
        }
    }
}
