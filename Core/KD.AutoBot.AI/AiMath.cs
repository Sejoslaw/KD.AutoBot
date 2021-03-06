﻿using System;

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
            if (value == 0)
            {
                return 0;
            }

            double sig = 1.0D / (1.0D + Math.Exp(-value));
            return sig;
        }
    }
}