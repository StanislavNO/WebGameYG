using System;

namespace Assets.Source.Code_base
{
    public class LevelLoadingData
    {
        private const int MinCorrectLevel = 1;

        public LevelLoadingData(int level)
        {
            Level = level;
        }

        public int Level
        {
            get { return Level; }
            set
            {
                if (value < MinCorrectLevel)
                    throw new ArgumentOutOfRangeException(nameof(value));

                Level = value;
            }
        }
    }
}