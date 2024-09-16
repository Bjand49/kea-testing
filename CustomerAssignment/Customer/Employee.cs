using Main;
using System.Text;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Main
{
    public class Employee
    {
        private string _cpr;
        private string _firstName;
        private string _lastName;
        private Department _department;
        private decimal _baseSalary;
        private EducationLevel _educationLevel;
        private DateTime _dateOfBirth;
        private DateTime _dateOfEmployment;
        private string _country;
        public Employee() { }
        public string Cpr
        {
            get { return _cpr; }
            set
            {
                if (value.Length != 10)
                {
                    throw new Exception("CPR number is not 10 long");
                }
                _cpr = value;
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value.Length == 0)
                {
                    throw new Exception("Firstname is empty");
                }
                else if (value.Length > 30)
                {
                    throw new Exception("Firstname is too long");
                }
                if (!_isValidName(value))
                {
                    throw new Exception("Firstname cannot containt other characters");
                }
                _firstName = value;
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value.Length == 0)
                {
                    throw new Exception("Lastname is empty");
                }
                else if (value.Length > 30)
                {
                    throw new Exception("Lastname is too long");
                }
                if (!_isValidName(value))
                {
                    throw new Exception("Firstname cannot containt other characters");
                }

                _lastName = value;
            }
        }

        public string Department
        {
            get { return _department.ToString(); }
            set
            {
                var validDepartment = Enum.TryParse(value, out this._department);
                if (!validDepartment)
                {
                    throw new Exception("Invalid department");
                }
            }
        }

        public decimal BaseSalary
        {
            get { return _baseSalary; }
            set
            {
                if (value < 20000)
                {
                    throw new Exception("Salary is too low");
                }
                if (value > 100000)
                {
                    throw new Exception("Salary is too high");
                }
                _baseSalary = value;
            }
        }

        public string EducationLevel
        {
            get { return _educationLevel.ToString(); }
            set
            {
                var validEducationLevel = Enum.TryParse(value, out this._educationLevel);
                if (!validEducationLevel)
                {
                    throw new Exception("Invalid educationlevel");
                }
            }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {

                var minimumDate = DateTime.Now.AddYears(-18);
                if (minimumDate < value)
                {
                    throw new Exception("Not old enough to acccess");
                }
                _dateOfBirth = value;
            }
        }

        public DateTime DateOfEmployment
        {
            get { return _dateOfEmployment; }
            set
            {
                if (DateTime.Now > value)
                {
                    throw new Exception("You cannot be employed in the future");
                }

                _dateOfEmployment = value;
            }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }


        public decimal GetSalary()
        {
            return _baseSalary + ((int)_educationLevel * 1220);
        }

        public decimal GetDiscount()
        {
            var datenow = DateTime.Now;
            var timeEmployed = datenow - _dateOfEmployment;
            var years = Math.Floor((float)timeEmployed.Days / 365);
            var discount = (decimal)years * 0.5m;

            return discount;
        }

        public decimal GetShippingCosts()
        {
            var freeCountries = new List<string>() { "Denmark", "Sweden", "Norway" };
            var fiftyCountries = new List<string>() { "Iceland", "Finland" };
            if (freeCountries.Contains(_country))
            {
                return 0;
            }
            else if (fiftyCountries.Contains(_country))
            {
                return 0.5m;
            }
            else
            {
                return 1;
            }
        }

        private bool _isValidName(string name)
        {
            string pattern = @"^[\p{L}\- ]+$";

            bool isMatch = Regex.IsMatch(name, pattern);
            return isMatch;
        }

    }
}
