using System;
using System.Security.Cryptography;

namespace Engine
{
    // A more complex, more random version
    public static class RandomNumberGeneratorComplex
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        public static int NumberBetween(int minValue, int maxValue)
        {
            byte[] randomNumber = new byte[1];

            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

            // Using Math.Max and subtracting 0.00000000001 to ensure "multiplier" will always
            // be between 0.0 and .99999999999.
            // Otherwise, it's possible for it to be "1", which causes problems in the rounding.
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001);

            // Add one to the range to allow for the rounding done with Math.Floor
            int range = maxValue - minValue + 1;

            double randomValueInRange = Math.Floor(multiplier * range);

            return (int)(minValue + randomValueInRange);
        }
    }
}
