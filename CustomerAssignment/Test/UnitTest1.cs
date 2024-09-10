using Main;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void CPR_Returns_no_error_when_length_is_10()
        {
            //Arrange
            var sut = new Employee();

            //Act
            sut.Cpr = "1234567890";

            //Assert
            Assert.True(sut.Cpr.Length == 10);
        }

        [Fact]
        public void CPR_Returns_error_when_length_is_11()
        {
            //Arrange
            var sut = new Employee();

            //act & Assert
            Assert.Throws<Exception>(()=> sut.Cpr = "12345678901");
        }

        [Theory]
        [InlineData(1,2)]
        [InlineData(2,4)]
        [InlineData(4,8)]
        public void Test2(int a, int b)
        {
            Assert.Equal(a*2, b);

        }

    }
}