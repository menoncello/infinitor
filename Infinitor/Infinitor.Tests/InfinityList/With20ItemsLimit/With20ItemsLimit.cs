using FluentAssertions;
using NUnit.Framework;

namespace Infinitor
{
    public partial class InfinityRandomNumbersTests
    {
        public class With20ItemsLimit : InfinityRandomNumbersTests
        {
            private const int LimitItems = 20;

            [SetUp]
            public void Setup()
            {
                list = new InfinityRandomNumbers(limitItems: LimitItems);
            }

            [Test]
            public void In1000ItemsNoneMustGreaterThen20()
            {
                for (var i = 0; i < 1000; i++)
                    list[i].Should().BeLessThan(LimitItems);
            }
        }
    }
}