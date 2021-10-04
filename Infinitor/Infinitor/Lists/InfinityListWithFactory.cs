namespace Infinitor
{
    public class InfinityListWithFactory<T> : InfinityList<T>
        where T: class
    {
        private readonly IRandomFactory<T> randomFactory;

        public InfinityListWithFactory(IRandomFactory<T> randomFactory)
        {
            this.randomFactory = randomFactory;
        }

        protected override T GetGeneratedCustomItem(int randomValue)
        {
            return randomFactory.Generate(randomValue);
        }
    }
}