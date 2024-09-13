using MyApp.Services;

namespace MyApp.Tests.Services
{
    public class StringCalculatorTests
    {
        private readonly IStringCalculator _calculator;

        public StringCalculatorTests() => _calculator = new StringCalculator();

        [Fact]
        public void Add_EmptyString_ReturnsZero()
        {
            Assert.Equal(0, _calculator.Add(""));
        }

        [Fact]
        public void Add_SingleNumber_ReturnsTheNumber()
        {
            Assert.Equal(1, _calculator.Add("1"));
        }

        [Fact]
        public void Add_TwoNumbers_CommaSeparated_ReturnsTheirSum()
        {
            Assert.Equal(3, _calculator.Add("1,2"));
        }

        [Fact]
        public void Add_MultipleNumbersWithNewLinesAndCommas_ReturnsTheirSum()
        {
            Assert.Equal(6, _calculator.Add("1\n2,3"));
        }

        [Fact]
        public void Add_CustomDelimiter_SingleCharacter()
        {
            Assert.Equal(3, _calculator.Add("//;\n1;2"));
        }

        [Fact]
        public void Add_CustomDelimiter_MultipleCharacters()
        {
            Assert.Equal(6, _calculator.Add("//[***]\n1***2***3"));
        }

        [Fact]
        public void Add_CustomDelimiters_MultipleDelimiters()
        {
            Assert.Equal(6, _calculator.Add("//[*][%]\n1*2%3"));
        }

        [Fact]
        public void Add_NegativeNumber_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentException>(() => _calculator.Add("1,-2,3"));
            Assert.Contains("Negatives not allowed", exception.Message);
            Assert.Contains("-2", exception.Message);
        }

        [Fact]
        public void Add_NumbersGreaterThan1000_Ignored()
        {
            Assert.Equal(2, _calculator.Add("2,1001"));
        }
    }
}