using Infinitor.Strategies;

namespace Infinitor
{
    public class DummyStrategy : IGenerationStrategy<int>
    {
        public int Generate(int randomNumber)
        {
            return 0;
        }
    }
}