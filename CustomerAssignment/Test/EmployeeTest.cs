using Main;


namespace Test
{
    public class EmployeeTest
    {
        #region validation
        #region positive tests
        [Fact]
        public void CPR_Returns_No_Error_When_Length_Is_Ten()
        {
            //Arrange
            var sut = new Employee();

            //Act
            sut.Cpr = "1234567890";

            //Assert
            Assert.True(sut.Cpr.Length == 10);
        }

        [Theory]
        [InlineData("Bjørn")]
        [InlineData("Bo")]
        [InlineData("Floccinaucinihilipilification")]
        public void FirstName_Sets_Valid_name(string name)
        {
            //Arrange
            var sut = new Employee();

            //Act
            sut.FirstName = name;

            //Assert
            Assert.True(sut.FirstName == name);
        }
        [Theory]
        [InlineData("Andersen")]
        [InlineData("Bo")]
        [InlineData("Floccinaucinihilipilification")]
        public void LastName_Sets_Valid_name(string name)
        {
            //Arrange
            var sut = new Employee();

            //Act
            sut.LastName = name;

            //Assert
            Assert.True(sut.LastName == name);
        }

        [Theory]
        [InlineData("HR")]
        [InlineData("Finance")]
        [InlineData("IT")]
        [InlineData("Sales")]
        [InlineData("GeneralServices")]
        public void Valid_Departments_Are_Set_Correctly(string departmentName)
        {
            //Arrange
            var sut = new Employee();

            //Act
            sut.Department = departmentName;

            //Assert
            Assert.True(sut.Department == departmentName);
        }

        [Theory]
        [InlineData(20000)]
        [InlineData(20001)]
        [InlineData(70000)]
        [InlineData(99999)]
        [InlineData(100000)]
        public void Valid_Salaries_Are_Set_Correctly(decimal number)
        {
            //Arrange
            var sut = new Employee();

            //Act
            sut.BaseSalary = number;

            //Assert
            Assert.True(sut.BaseSalary == number);
        }

        [Theory]
        [InlineData(-18, 0, -1)]
        [InlineData(-80, 0, 1)]
        [InlineData(-190, 0, 1)]
        public void Valid_DateOfBirth_Are_Set_Correctly(int year, int month, int day)
        {
            //Arrange
            var date = DateTime.Now;
            date = date.AddYears(year);
            date = date.AddMonths(month);
            date = date.AddDays(day);

            var sut = new Employee();

            //Act
            sut.DateOfBirth = date;

            //Assert
            Assert.True(sut.DateOfBirth == date);

        }

        [Theory]
        [InlineData(0, 0, 1)]
        [InlineData(0, 0, 2)]
        [InlineData(150, 0, 0)]
        public void Valid_Date_Of_Employment_Are_Set_Correctly(int year, int month, int day)
        {
            //Arrange
            var date = DateTime.Now;
            date = date.AddYears(year);
            date = date.AddMonths(month);
            date = date.AddDays(day);

            var sut = new Employee();

            //Act
            sut.DateOfEmployment = date;

            //Assert
            Assert.True(sut.DateOfEmployment == date);
        }

        #endregion

        #region negative tests
        [Theory]
        [InlineData("12345678901")]  //11
        [InlineData("123456789012")] //12
        public void CPR_Returns_Error_When_Length_Is_More_Than_Ten(string cpr)
        {
            //Arrange
            var sut = new Employee();

            //Act & Assert
            Assert.Throws<Exception>(() => sut.Cpr = cpr);
        }
        
        [Theory]
        [InlineData("")]   //0
        [InlineData("1")]   //1
        [InlineData("12")]   //2
        [InlineData("12345678")]   //8
        [InlineData("123456789")]  //9
        public void CPR_Returns_Error_When_Length_Is_Less_Than_Ten(string cpr)
        {
            //Arrange
            var sut = new Employee();

            //Act & Assert
            Assert.Throws<Exception>(() => sut.Cpr = cpr);
        }


        [Theory]
        [InlineData("Floccinaucinihilipilificationer")]
        [InlineData("Floccinaucinihilipilificationer skibidi toilet")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer et tincidunt risus. Sed ut semper lorem. Cras volutpat odio in arcu hendrerit aliquam. Nullam a efficitur est. Proin eu ex eget tellus dapibus dapibus. Suspendisse potenti. Aliquam erat volutpat. Duis congue tortor quis libero condimentum, vitae eleifend sem vehicula. Nulla iaculis dui cursus, rutrum dolor a, placerat justo. Ut iaculis dui et mollis faucibus. Suspendisse potenti. Cras sed quam felis.\r\n\r\n")]
        public void Firstname_Too_Long_Throws_Exception(string name)
        {
            //Arrange
            var sut = new Employee();

            //Act & Assert
            Assert.Throws<Exception>(() => sut.FirstName = name);
        }

        [Theory]
        [InlineData("B@nan@")]
        [InlineData("B4nan4")]
        [InlineData("Ban_ana")]
        public void FirstName_with_invalid_characters_throws_error(string name)
        {
            //Arrange
            var sut = new Employee();

            //Act & Assert
            Assert.Throws<Exception>(() => sut.FirstName = name);
        }

        [Fact]
        public void FirstName_empty_throws_error()
        {
            //Arrange
            var sut = new Employee();

            //Act & Assert
            Assert.Throws<Exception>(() => sut.FirstName = "");
        }


        [Theory]
        [InlineData("Floccinaucinihilipilificationer")]
        [InlineData("Floccinaucinihilipilificationer skibidi toilet")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer et tincidunt risus. Sed ut semper lorem. Cras volutpat odio in arcu hendrerit aliquam. Nullam a efficitur est. Proin eu ex eget tellus dapibus dapibus. Suspendisse potenti. Aliquam erat volutpat. Duis congue tortor quis libero condimentum, vitae eleifend sem vehicula. Nulla iaculis dui cursus, rutrum dolor a, placerat justo. Ut iaculis dui et mollis faucibus. Suspendisse potenti. Cras sed quam felis.\r\n\r\n")]
        public void LastName_too_long_throws_error(string name)
        {
            //Arrange
            var sut = new Employee();

            //Act & Assert
            Assert.Throws<Exception>(() => sut.LastName = name);
        }
        [Theory]
        [InlineData("B@nan@")]
        [InlineData("B4nan4")]
        [InlineData("Ban_ana")]
        public void LastName_with_invalid_characters_throws_error(string name)
        {
            //Arrange
            var sut = new Employee();

            //Act & Assert
            Assert.Throws<Exception>(() => sut.LastName = name);
        }
        [Fact]
        public void LastName_empty_throws_error()
        {
            //Arrange
            var sut = new Employee();

            //Act & Assert
            Assert.Throws<Exception>(() => sut.LastName = "");
        }
        [Theory]
        [InlineData("HAR")]
        [InlineData("")]
        [InlineData("General_Services")]
        [InlineData("sales")]
        public void Invalid_Departments_Throws_Exceptions(string departmentName)
        {
            //Arrange
            var sut = new Employee();

            //Act & Assert
            Assert.Throws<Exception>(() => sut.Department = departmentName);
        }

        [Theory]
        [InlineData(19999)]
        [InlineData(19998)]
        [InlineData(0)]
        [InlineData(-19999)]
        [InlineData(-20000)]
        [InlineData(-20001)]
        public void Salaries_Too_Low_Throws_Exception(decimal number)
        {
            //Arrange
            var sut = new Employee();

            //Act & Assert
            Assert.Throws<Exception>(() => sut.BaseSalary = number);
        }

        [Theory]
        [InlineData(100001)]
        [InlineData(100002)]
        [InlineData(10000002)]
        public void Salaries_Too_High_Throws_Exception(decimal number)
        {
            //Arrange   
            var sut = new Employee();

            //Act & Assert
            Assert.Throws<Exception>(() => sut.BaseSalary = number);
        }

        [Theory]
        [InlineData(-18, 0, 1)]
        [InlineData(0, 0, 0)]
        [InlineData(18, 0, 0)]
        public void Invalid_DateOfBirth_Throws_Exception(int year, int month, int day)
        {
            //Arrange
            var date = DateTime.Now;
            date = date.AddYears(year);
            date = date.AddMonths(month);
            date = date.AddDays(day);
            var sut = new Employee();

            //Act & Assert
            Assert.Throws<Exception>(() => sut.DateOfBirth = date);

        }
        [Theory]
        [InlineData(0, 0, -1)]
        [InlineData(0, 0, -2)]
        [InlineData(-150, 0, 0)]
        public void Invalid_Date_Of_Employment_Are_Set_Correctly(int year, int month, int day)
        {
            //Arrange
            var date = DateTime.Now;
            date = date.AddYears(year);
            date = date.AddMonths(month);
            date = date.AddDays(day);

            var sut = new Employee();

            //Act & Assert
            Assert.Throws<Exception>(() => sut.DateOfEmployment = date);
        }

        #endregion
        #endregion

        #region methods

        [Theory]
        [InlineData(EducationLevel.None, 20000, 20000)]
        [InlineData(EducationLevel.Primary, 20000, 21220)]
        [InlineData(EducationLevel.Secondary, 20000, 22440)]
        [InlineData(EducationLevel.Tertiary, 20000, 23660)]
        [InlineData(EducationLevel.None, 20001, 20001)]
        [InlineData(EducationLevel.Primary, 20001, 21221)]
        [InlineData(EducationLevel.Secondary, 20001, 22441)]
        [InlineData(EducationLevel.Tertiary, 20001, 23661)]
        [InlineData(EducationLevel.None, 60000, 60000)]
        [InlineData(EducationLevel.Primary, 60000, 61220)]
        [InlineData(EducationLevel.Secondary, 60000, 62440)]
        [InlineData(EducationLevel.Tertiary, 60000, 63660)]
        [InlineData(EducationLevel.None, 99999, 99999)]
        [InlineData(EducationLevel.Primary, 99999, 101219)]
        [InlineData(EducationLevel.Secondary, 99999, 102439)]
        [InlineData(EducationLevel.Tertiary, 99999, 103659)]
        [InlineData(EducationLevel.None, 100000, 100000)]
        [InlineData(EducationLevel.Primary, 100000, 101220)]
        [InlineData(EducationLevel.Secondary, 100000, 102440)]
        [InlineData(EducationLevel.Tertiary, 100000, 103660)]
        public void Education_Level_Affects_Salary(EducationLevel education, decimal baseSalary, decimal expectedValue)
        {
            //Arrange
            var sut = new Employee();
            sut.EducationLevel = education.ToString();
            sut.BaseSalary = baseSalary;

            //Act & Assert
            Assert.True(sut.GetSalary() == expectedValue);

        }

        [Theory]
        [InlineData("Denmark", 0)]
        [InlineData("Sweden", 0)]
        [InlineData("Norway", 0)]
        [InlineData("Iceland", 0.5)]
        [InlineData("Finland", 0.5)]
        [InlineData("Germany", 1)]
        [InlineData("", 1)]
        public void Get_Shipping_Returns_Correct_Amount_From_County(string country, decimal expectedValue)
        {
            //Arrange
            var sut = new Employee();
            sut.Country = country;

            //Act & Assert
            Assert.True(sut.GetShippingCosts() == expectedValue);

        }
        #endregion
    }
}