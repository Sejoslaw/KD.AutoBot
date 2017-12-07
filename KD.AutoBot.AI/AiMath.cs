using System;

namespace KD.AutoBot.AI
{
    /// <summary>
    /// Class which holds mathematic behind AI.
    /// </summary>
    public static class AiMath
    {
        /// <summary>
        /// <see cref="https://en.wikipedia.org/wiki/Sigmoid_function"> Wikipedia </see>
        /// </summary>
        public static double Sigmoid(double value)
        {
            double sig = 1 / (1 + Math.Exp(-value));
            return sig;
        }
    }
}