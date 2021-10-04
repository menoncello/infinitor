namespace Infinitor
{
    public class SpyFullNameFactory : IRandomFactory<FullName>
    {
        public FullName Generate(int randomValue)
        {
            GenerateCount++;
            return new FullName("First Last");
        }

        public int GenerateCount { get; private set; }
    }
}