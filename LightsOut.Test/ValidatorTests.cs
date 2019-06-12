using Moq;
using NUnit.Framework;

namespace LightsOut.Test
{
    public class ValidatorTests
    {
        private IValidator _validator;

        [SetUp]
        public void Setup()
        {
            var loggerMock = new Mock<IConsole>();
            _validator = new Validator(loggerMock.Object);
        }

        [Test]
        public void Given_input_is_q_When_user_enters_value_Then_return_true()
        {
            const string input = "q";

            var result = _validator.IsQuit(input);

            Assert.IsTrue(result);
        }

        [Test]
        public void Given_input_is_null_When_user_enters_value_Then_return_false()
        {
            string input = null;

            var result = _validator.IsValid(input);

            Assert.IsFalse(result);
        }


        [Test]
        public void Given_input_is_1_When_user_enters_value_Then_return_true()
        {
            const string input = "1";

            var result = _validator.IsValid(input);

            Assert.IsTrue(result);
        }

        [Test]
        public void Given_input_is_not_an_int_When_user_enters_value_Then_return_false()
        {
            const string input = "d";

            var result = _validator.IsValid(input);

            Assert.IsFalse(result);
        }
    }
}