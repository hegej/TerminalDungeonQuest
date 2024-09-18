

namespace DungeonGameLogic.Utilities
{
    public static class RandomStatsProvider
    {
        private static readonly Random _random = new Random();

        public static Random GetRandom()
        {
            return _random;
        }
    }
}
