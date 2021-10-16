namespace Infinitor.Factories
{
    public class IntegerFactory : IRandomFactory<int>
    {
        public int Generate(int randomValue) => randomValue;
    }
}