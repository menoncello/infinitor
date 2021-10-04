using FluentAssertions;
using NUnit.Framework;

namespace Infinitor
{
    public partial class InfinityListRandomNumbersTests
    {
        public class With20ItemsLimit : InfinityListRandomNumbersTests
        {
            private const int CappedValue = 20;

            [SetUp]
            public void Setup()
            {
                list = new InfinityListRandomNumbers(CappedValue);
            }

            [Test]
            public void In1000ItemsNoneMustGreaterThen20()
            {
                for (var i = 0; i < 1000; i++)
                    list[i].Should().BeLessThan(CappedValue);
            }
        }
    }
}