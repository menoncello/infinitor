using NUnit.Framework;

namespace Infinitor
{
    public partial class InfinityRandomNumbersTests
    {
        public partial class WithNoLimits : InfinityRandomNumbersTests
        {
            [SetUp]
            public void Setup()
            {
                list = new InfinityRandomNumbers();
            }
        }
    }
}