namespace TDD
{
    using FluentAssertions;
    using NSubstitute;
    using StringCalculator.Implementations;
    using Xunit;

    public class StringCalculatorTests
    {
        private IValidator validator;
        private StringCalculator sut;
        private IReplacer replacer;

        public StringCalculatorTests()
        {
            this.validator = Substitute.For<IValidator>();
            this.validator.IsValid(Arg.Any<string>()).Returns(x => true);
            this.replacer = Substitute.For<IReplacer>();
            this.sut = new StringCalculator(this.validator, this.replacer);
        }

        ~ StringCalculatorTests()
        {
            this.validator = null;
            this.replacer = null;
            this.sut = null;
        }
        
        [Fact]
        public void Sum_Input_1_2()
        {
            string values = "1 2";

            this.replacer.Replace(values).Returns(values);

            float result = sut.Add(values);

            result.Should().Be(3);

            this.replacer.Received(1).Replace(values);
            this.validator.Received(1).IsValid(values);
        }

        [Fact]
        public void Sum_Input_4_4_5()
        {
            string values = "4 4 5";

            this.replacer.Replace(values).Returns(values);

            float result = sut.Add(values);

            result.Should().Be(13);

            this.replacer.Received(1).Replace(values);
            this.validator.Received(1).IsValid(values);
        }

        [Fact]
        public void Subtract_Input_1_2()
        {
            string values = "1 2";

            this.replacer.Replace(values).Returns(values);

            float result = sut.Subtract(values);

            result.Should().Be(-1);

            this.replacer.Received(1).Replace(values);
            this.validator.Received(1).IsValid(values);
        }

        [Fact]
        public void Subtract_Input_4_4_5()
        {
            string values = "4 4 5";

            this.replacer.Replace(values).Returns(values);

            float result = sut.Subtract(values);

            result.Should().Be(-5);

            this.replacer.Received(1).Replace(values);
            this.validator.Received(1).IsValid(values);
        }

        [Fact]
        public void Subtract_Input_4_4_negative_5()
        {
            string values = "4 4 -5";

            this.replacer.Replace(values).Returns(values);

            float result = sut.Subtract(values);

            result.Should().Be(5);

            this.replacer.Received(1).Replace(values);
            this.validator.Received(1).IsValid(values);
        }

        [Fact]
        public void Sum_4_dot_1_4_5()
        {

            string values = "4.1 4 5";

            this.replacer.Replace(values).Returns(values);

            float result = sut.Add(values);

            result.Should().Be(13.1f);

            this.replacer.Received(1).Replace(values);
            this.validator.Received(1).IsValid(values);
        }

        [Fact]
        public void Sum_negative_4_5()
        {
            string values = "-4 5";

            this.replacer.Replace(values).Returns(values);

            float result = sut.Add(values);

            result.Should().Be(1);

            this.replacer.Received(1).Replace(values);
            this.validator.Received(1).IsValid(values);
        }
    }
}
