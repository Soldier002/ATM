using AutoFixture;
using AutoFixture.AutoMoq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Tests
{
    public class AutoMockedTests<T>
    {
        private IFixture _fixture;
        private T _classUnderTest;

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

        protected T ClassUnderTest
        {
            get
            {
                if (_classUnderTest != null)
                {
                    return _classUnderTest;
                }

                _classUnderTest = Fixture.Create<T>();
                return _classUnderTest;
            }
        }
    }
}
