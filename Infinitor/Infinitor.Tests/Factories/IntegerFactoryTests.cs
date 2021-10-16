using FluentAssertions;
using NUnit.Framework;

namespace Infinitor.Factories
{
    public class IntegerFactoryTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(500)]
        [TestCase(1000)]
        public void Generate_ResultMustBeTheSameTheNumber(int randomValue) =>
            new IntegerFactory().Generate(randomValue).Should().Be(randomValue);
    }
}