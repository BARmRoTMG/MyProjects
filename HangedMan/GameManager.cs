using System;

namespace HangedMan
{
    internal class GameManager
    {
        string _word;
        int _counter = 0;
        int difficultyLevel = 0;

        public int DifficultyLevel { get { return difficultyLevel; } set { difficultyLevel = value; } }
        public string Word { get { return _word; } set { _word = value; } }
        public int Counter { get { return _counter; } set { _counter = value; } }

        public GameManager()
        {
        }

        public string WordGenerator()
        {
            string[] easy = { "chicken", "football", "house", "television", "sugar", "elephant" };
            string[] normal = { "conversation", "strength", "production", "eliminate", "suspect", "character" };
            string[] hard = { "achievement", "violation", "continuous", "exhibition", "pedestrian", "atmosphere" };

            Random rnd = new Random();

            if (difficultyLevel == 0)
                return easy[rnd.Next(easy.Length)];
            else if (difficultyLevel == 1)
                return normal[rnd.Next(normal.Length)];
            else if (difficultyLevel == 2)
                return hard[rnd.Next(hard.Length)];

            return easy[rnd.Next(easy.Length)];
        } //Word generator by difficulty
    }
}
