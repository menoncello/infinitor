using System;

namespace Infinitor.Tools
{
    public static class RandomTool
    {
        public static int GetInteger(int seed)
        {
            var rnd = new Random(seed);
            return rnd.Next();
        }
    }
}