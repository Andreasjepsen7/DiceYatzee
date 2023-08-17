namespace DiceYatzee
{
    public class Dice
    {
        public void Dicer()
        {
            // Create a random number generator
            Random random = new Random();

            // Roll five dice
            for (int i = 0; i <= 5; i++)
            {
                int diceValue = random.Next(1, 7); // Generates a random number between 1 and 6
                Console.WriteLine($"Dice {i} rolled: {diceValue}");
            }
        }
    }
}