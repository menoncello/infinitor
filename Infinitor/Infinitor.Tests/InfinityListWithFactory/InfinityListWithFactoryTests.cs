using FluentAssertions;
using NUnit.Framework;

namespace Infinitor
{
    public class InfinityListWithFactoryTests
    {
        private InfinityListWithFactory<FullName> list = null!;
        private SpyFullNameFactory spyFullNameFactory = null!;

        [SetUp]
        public void SetUp()
        {
            spyFullNameFactory = new SpyFullNameFactory();
            list = new InfinityListWithFactory<FullName>(spyFullNameFactory);
        }
        
        [Test]
        public void WhenGetFirstItemResultMustNotBeNull()
        {
            list[0].Should().NotBeNull();
        }
        
        [Test]
        public void ValueMustBeFirstLast()
        {
            list[0].Value.Should().Be("First Last");
        }
        
        [Test]
        public void GenerateOnFactoryShouldBeNeverCalled()
        {
            spyFullNameFactory.GenerateCount.Should().Be(0);
        }
        
        [Test]
        public void GenerateOnFactoryShouldBeCalledOnce()
        {
            _ = list[0];
            spyFullNameFactory.GenerateCount.Should().Be(1);
        }
    }
}