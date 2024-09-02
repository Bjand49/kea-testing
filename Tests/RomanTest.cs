using Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Tests
{
    public class RomanTest
    {
        [Theory]
        [InlineData("VII", 7)]
        [InlineData("CCC", 300)]
        [InlineData("MMMDCCCLXXXVIII", 3888)]
        [InlineData("IX", 9)]
        [InlineData("I", 1)]

        public void Parse_Roman_Nummerals_To_Numbers_Are_Correct(string romanNumber, int expectedResult)
        {
            //Assign
            var roman = new RomanNumeralParser();

            //Act
            var value = roman.ParseNumeral(romanNumber);

            //Assert
            Assert.Equal(value, expectedResult);
        }
        [Theory]
        [InlineData("", "No characters written")]
        [InlineData("DCMII", "Invalid character positioning")]
        [InlineData("VIIII", "Invalid syntax")]
        public void Parse_Roman_Nummerals_To_Numbers_Are_Incorrect(string romanNumber, string errorExpectedMessage)
        {
            var errorMessage = "";
            try
            {
                //Assign
                var roman = new RomanNumeralParser();

                //Act
                roman.ParseNumeral(romanNumber);
            }
            catch (Exception e)
            {
                //Assert
                errorMessage = e.Message;
                return;
            }
            Assert.Equal(errorExpectedMessage, errorMessage);
        }


        [Theory]
        [InlineData(7, "VII")]
        [InlineData(300, "CCC")]
        [InlineData(3888, "MMMDCCCLXXXVIII")]
        [InlineData(9, "IX")]
        [InlineData(1, "I")]

        public void Parse_Numbers_To_Roman_Numerals_Are_Correct(int number, string expectedResult)
        {
            //Assign
            var roman = new RomanNumeralParser();

            //Act
            var value = roman.ParseNumbers(number);

            //Assert
            Assert.Equal(value, expectedResult);
        }
        [Theory]
        [InlineData(0, "The number has to be at least 1 or at max 3999")]
        [InlineData(50000, "The number has to be at least 1 or at max 3999")]
        [InlineData(-200, "The number has to be at least 1 or at max 3999")]
        public void Parse_Numbers_To_Roman_Numerals_Are_Incorrect(int number, string expectedResult)
        {
            var errorMessage = "";
            try
            {
                //Assign
                var roman = new RomanNumeralParser();

                //Act
                roman.ParseNumbers(number);
            }
            catch (Exception e)
            {
                //Assert
                errorMessage = e.Message;
                return;
            }
            Assert.Equal(expectedResult, errorMessage);
        }
    }
}
