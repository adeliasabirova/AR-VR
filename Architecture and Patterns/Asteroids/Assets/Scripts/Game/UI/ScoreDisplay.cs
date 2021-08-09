namespace Asteroids
{
    internal sealed class ScoreDisplay
    {
        public string Intepretator(int value)
        {
            return Modification(value);
        }

        private string Modification(int number)
        {
            if (number >= 1000000000) return Modification(number / 1000000000) + "B";
            if (number >= 1000000) return Modification(number / 1000000) + "M";
            if (number >= 1000) return Modification(number / 1000) + "K" ;
            if (number >= 1) return number.ToString();
            return string.Empty;
        }
    }
}