using NUnit.Framework;

namespace Infinitor
{
    public partial class InfinityListRandomNumbersTests
    {
        public partial class WithNoLimits : InfinityListRandomNumbersTests
        {
            [SetUp]
            public void Setup()
            {
                list = new InfinityListRandomNumbers();
            }
        }
    }
}