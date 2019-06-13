namespace LightsOut
{
    /// <summary>
    /// Wrapper class for Random
    /// </summary>
    public class Random : IRandom
    {
        private readonly System.Random _random;

        public Random()
        {
            _random = new System.Random();
        }

        public int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }

    public interface IRandom
    {
        int Next(int minValue, int maxValue);
    }
}
