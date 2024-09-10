using Main;

namespace Tests
{
    public class CalculatorTest
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <param name="result"></param>
        [Theory]
        [InlineData(int.MaxValue, 0, int.MaxValue)]
        [InlineData(-int.MaxValue, 0, -int.MaxValue)]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 2)]
        [InlineData(-2, -2, -4)]
        public void Numbers_Are_Summed_Correctly(int val1, int val2, int result)
        {
            //Assign
            var calc = new Calculator();

            //Act
            var value = calc.Sum(val1, val2);

            //Assert
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(1, 2, -1)]
        [InlineData(0, 0, 0)]
        [InlineData(int.MaxValue, 0, int.MaxValue)]
        [InlineData(-int.MaxValue, 0, -int.MaxValue)]
        [InlineData(4, 4, 0)]
        [InlineData(-2, -2, 0)]
        [InlineData(999, 1, 998)]
        public void Numbers_Are_Subtracted_Correctly(int val1, int val2, int result)
        {
            //Assign
            var calc = new Calculator();

            //Act
            var value = calc.Subtract(val1, val2);

            //Assert
            Assert.Equal(value, result);
        }


        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(0, 0, 0)]
        [InlineData(int.MaxValue, 2, -2)]
        [InlineData(-int.MaxValue, 2, 2)]
        [InlineData(4, 4, 16)]
        [InlineData(-2, -2, 4)]
        public void Numbers_Are_Multiplied_Correctly(int val1, int val2, int result)
        {
            //Assign
            var calc = new Calculator();

            //Act
            var value = calc.Multiply(val1, val2);

            //Assert
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(4, 2, 2)]
        [InlineData(4, 4, 1)]
        [InlineData(-2, -2, 1)]
        public void Numbers_Are_Divided_Correctly(int val1, int val2, int result)
        {
            //Assign
            var calc = new Calculator();

            //Act
            var value = calc.Divide(val1, val2);

            //Assert
            Assert.Equal(value, result);
        }

        [Fact]
        public void Divide_By_Zero_Throws_Exception()
        {
            //Assign
            var calc = new Calculator();

            //Act and Assert
            Assert.Throws<DivideByZeroException>(()=>calc.Divide(0, 0));

        }


    }
}