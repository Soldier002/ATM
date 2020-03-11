using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;

namespace ATM.Tests
{
    public class AutoMockedTests<T>
    {
        private IFixture _fixture;

        protected IFixture Fixture
        {
            get
            {
                if (_fixture != null)
                {
                    return _fixture;
                }

                _fixture = new Fixture().Customize(new AutoMoqCustomization());
                return _fixture;
            }
        }

        protected T ClassUnderTest => Fixture.Create<T>();

        protected Mock<TMock> GetMock<TMock>() where TMock : class 
            => Fixture.Freeze<Mock<TMock>>();
    }
}
