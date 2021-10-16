using Infinitor.Factories;

namespace Infinitor
{
    public class DummyFactory : IRandomFactory<int>
    {
        public int Generate(int randomValue)
        {
            return 0;
        }
    }
}