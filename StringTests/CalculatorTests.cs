using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace StringTests
{
    public class CalculatorTests
    {
        static List<int> singleNumberTestString = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        
        [Test]
        public void GivenIHaveACaculatorWithAnAddMethod_WhenIPassAnEmptyStringItWillReturnZero()
        {
            var calculator = new Calculator();
            calculator.Add(string.Empty).ShouldBe(0);
        }

        [Test]
        [TestCaseSource(nameof(singleNumberTestString))]
        public void GivenIHaveACalculatorWithAnAddMethod_WhenIPassASingleNumberAsAstring_ThenIGetTheValueBack(int testNumber)
        {
            var calculator = new Calculator();
            calculator.Add(testNumber.ToString()).ShouldBe(testNumber);
        }

        [Test]
        public void GivenIHaveACalculatorWithAnAddMethod_WhenIPassATwoNumbersAsACommaSepartedString_ThenIGetTheSumOfTheNumbersBack()
        {
            var calculator = new Calculator();
            calculator.Add("1,1").ShouldBe(2);
        }

        [Test]
        [TestCaseSource(nameof(singleNumberTestString))]
        public void GivenIHaveACalculatorWithAnAddMethod_WhenIPassAnArbitaryNumberOfNumbersAsACommaSepartedString_ThenIGetTheSumOfTheNumbersBack(int numberOfNumbersInTheString)
        {
            var random = new Random();
            var rawNumbers = Enumerable.Range(0, numberOfNumbersInTheString).Select(x => random.Next(100)).ToList();
            var numbers = string.Join(",", rawNumbers);
            var calculator = new Calculator();
            calculator.Add(numbers).ShouldBe(rawNumbers.Sum());
        }

        [Test]
        [TestCaseSource(nameof(singleNumberTestString))]
        public void GivenIHaveACalculatorWithAnAddMethod_WhenIPassAnArbitaryNumberOfNumbersAsASemiColonSepartedString_ThenIGetTheSumOfTheNumbersBack(int numberOfNumbersInTheString)
        {
            var random = new Random();
            var rawNumbers = Enumerable.Range(0, numberOfNumbersInTheString).Select(x => random.Next(100)).ToList();
            var numbers = string.Join(";", rawNumbers);
            var calculator = new Calculator();
            calculator.Add(numbers).ShouldBe(rawNumbers.Sum());
        }

        [Test]
        [TestCaseSource(nameof(singleNumberTestString))]
        public void GivenIHaveACalculatorWithAnAddMethod_WhenIPassAnArbitaryNumberOfNumbersAsANewLineSepartedString_ThenIGetTheSumOfTheNumbersBack(int numberOfNumbersInTheString)
        {
            var random = new Random();
            var rawNumbers = Enumerable.Range(0, numberOfNumbersInTheString).Select(x => random.Next(100)).ToList();
            var numbers = string.Join("\n", rawNumbers);
            var calculator = new Calculator();
            calculator.Add(numbers).ShouldBe(rawNumbers.Sum());
        }

        [Test]
        public void GivenIHaveACalculatorWithAnAddMethod_WhenIPassAnThreeNumbersAsAMixedSeperatorCharactorSepartedString_ThenIGetTheSumOfTheNumbersBack()
        {
            var calculator = new Calculator();
            calculator.Add("1\n2,3").ShouldBe(6);
        }

        [Test]
        public void GivenIHaveACalculatorWithAnAddMethod_WhenIPassAFirstLineWithTwoBackSlashes_ThenTheNextCharacterIsUsedAsTheStringSeperator()
        {
            var calculator = new Calculator();
            calculator.Add("//:\n1:2").ShouldBe(3);
        }

        [Test]
        public void GivenIHaveACalculatorWithAnAddMethod_WhenINegativeNumbers_ThenIGetAnExceptionListingAllTheNegativeNumbers()
        {
            var calculator = new Calculator();
            Should.Throw<ArgumentOutOfRangeException>(() => calculator.Add("-1,-2"));

        }


        [Test]
        public void GivenIHaveACalculatorWithAnAddMethod_WhenPassANumberGreaterThan1000_ThenTheSumIgnoresAllNumbersGreaterThan1000()
        {
            var calculator = new Calculator();
            calculator.Add("2,1001").ShouldBe(2);

        }
    

    }
}
