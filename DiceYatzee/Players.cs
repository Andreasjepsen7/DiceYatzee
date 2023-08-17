using System;

namespace DiceYatzee
{
    public class Players
    {
        public string Name { get; set; }
        public int[] DiceValue { get; set; }

        public Players(string name, int numDice)
        {
            Name = name;
            DiceValue = new int[numDice];
        }

        public void RollDice(Random random)
        {
            for (int i = 0; i < DiceValue.Length; i++)
            {
                DiceValue[i] = random.Next(1, 7);
            }
        }

        public void RollDice(Random random, bool[] hold)
        {
            for (int i = 0; i < DiceValue.Length; i++)
            {
                if (!hold[i])
                {
                    DiceValue[i] = random.Next(1, 7);
                }
            }
        }

        public void HoldDice(bool[] hold)
        {
            for (int i = 0; i < DiceValue.Length; i++)
            {
                if (!hold[i])
                {
                    DiceValue[i] = 0;
                }
            }
        }

        public int CalculateScore()
        {
            // Implement your scoring logic here
            int score = 0;

            // Calculate the sum of all dice showing the number 1
            score += DiceValue[0]; // Assuming first element is for ones
            // Continue adding scores for twos, threes, ..., sixes

            // Implement the scoring rules for lower section as well

            return score;
        }

        public override string ToString()
        {
            string diceStr = string.Join(", ", DiceValue);
            return $"Player: {Name}, Dice: [{diceStr}]";
        }
    }
}
