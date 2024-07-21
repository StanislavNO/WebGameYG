using System;

namespace Assets.Source.Code_base
{
    public class LevelLoadingData
    {
        private const int MinCorrectLevel = 1;

        private int _level;

        public LevelLoadingData(int level = MinCorrectLevel)
        {
            _level = level;
        }

        public int Level
        {
            get { return _level; }
            set
            {
                if (value < MinCorrectLevel)
                    throw new ArgumentOutOfRangeException(nameof(value));

                _level = value;
            }
        }
    }
}