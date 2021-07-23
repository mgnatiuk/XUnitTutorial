using Microsoft.Extensions.Logging;
using Xunit;
using XUnitTutorial.API.Services;
using XUnitTutorial.Tests.ClassDataModels;
using XUnitTutorial.Tests.MemberDataModels;
using XUnitTutorial.Tests.Models;

namespace XUnitTutorial.Tests
{
    public class CalculatorServiceTests
    {
        #region Comments
        /*
         *  If you want skip broken test you need use this code: [Fact(Skip="And reason here")]
         *  
         */
        #endregion

        public CalculatorService _calc { get; set; }
        
        public CalculatorServiceTests()
        {
            ILogger<CalculatorService> _logger = new Logger<CalculatorService>(new LoggerFactory());
            _calc = new CalculatorService(_logger);
        }

        [Fact]
        public void ShouldAddNumberToCurrentValueFact()
        {
            _calc.Add(10);
            _calc.Add(19);
            Assert.Equal(29, _calc.CurrentValue);
        }

        [Theory]
        [InlineData(10, 4, 6)]
        [InlineData(19, 14, 5)]
        [InlineData(9, 10, -1)]
        public void ShouldAddNumberToCurrentValueTheory(double expected, double firstNumberToAdd, double secondNumberToAdd)
        {
            _calc.Add(firstNumberToAdd);
            _calc.Add(secondNumberToAdd);
            Assert.Equal(expected, _calc.CurrentValue);
        }

        [Theory]
        [ClassData(typeof(CorrectCalculatorClassData))]
        public void ShouldAddNumberToCurrentValueFromClassDataTheory(double expected, double a, double b, double c, double d)
        {
            _calc.Add(a);
            _calc.Add(b);
            _calc.Add(c);
            _calc.Add(d);
            Assert.Equal(expected, _calc.CurrentValue);
        }

        [Theory]
        [MemberData(nameof(CorrectCalculatorMemberData.GetOperationsFromMemberDataClass),
            MemberType = typeof(CorrectCalculatorMemberData))]
        public void ShouldAddNumberToCurrentValueFromMemberData(CalcOperation operation1, CalcOperation operation2)
        {
            foreach (double number in operation1.OperationNumbers)
            {
                _calc.Add(number);
            }

            Assert.Equal(operation1.Expected, _calc.CurrentValue);

            _calc.ClearResult();
            Assert.Equal(0, _calc.CurrentValue);

            foreach (double number in operation2.OperationNumbers)
            {
                _calc.Add(number);
            }

            Assert.Equal(operation2.Expected, _calc.CurrentValue);
        }

        [Theory]
        [JsonFileDataTest("TestJsonData/CalculatorTestData.json", "CorrectAddData")]
        public void ShouldAddNumbersFromJsonFileCorrectDataTheory(double a, double b, double expected)
        {
            _calc.ClearResult();
            _calc.Add(a);
            _calc.Add(b);
            Assert.Equal(expected, _calc.CurrentValue);
        }

        [Theory]
        [JsonFileDataTest("TestJsonData/CalculatorTestData.json", "IncorrectAddData")]
        public void ShouldAddNumbersFromJsonFileIncorrectDataTheory(double a, double b, double expected)
        {
            _calc.ClearResult();
            _calc.Add(a);
            _calc.Add(b);
            Assert.NotEqual(expected, _calc.CurrentValue);
        }

        [Theory]
        [JsonFileDataTest("TestJsonData/TestData.json")]
        public void ShouldAddNumbersFromJsonFileAllDataTheory(double a, double b, double expected)
        {
            _calc.ClearResult();
            _calc.Add(a);
            _calc.Add(b);
            Assert.NotEqual(expected, _calc.CurrentValue);
        }
    }
}
