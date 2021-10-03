using System;

namespace Infinitor
{
    public class ProportionalItem<T>
    {
        public const int ChanceMultiplier = 1000;

        public ProportionalItem(decimal chance, T value)
        {
            Chance = chance;
            Value = value;
        }

        public decimal Chance { get; }
        public T Value { get; }
        public int FullIntChance => Convert.ToInt32(Math.Round(Chance * ChanceMultiplier));
    }
}