using Main;
using System.Text;
using System.Text.RegularExpressions;

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
                if(value.Length != 10)
                {
                    throw new Exception("CPR number is not 10 long");
                }
                _cpr = value;
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public Department Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public decimal BaseSalary
        {
            get { return _baseSalary; }
            set { _baseSalary = value; }
        }

        public EducationLevel EducationLevel
        {
            get { return _educationLevel; }
            set { _educationLevel = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public DateTime DateOfEmployment
        {
            get { return _dateOfEmployment; }
            set { _dateOfEmployment = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public Employee(
            string cpr,
            string firstName,
            string lastName,
            string department,
            decimal baseSalary,
            string educationLevel,
            DateTime dateOfBirth,
            DateTime dateOfEmployment,
            string country)
        {
            var errorSB = new StringBuilder();
            //Validate cpr
            _cpr = cpr;
            if (_cpr.Length != 10)
            {
                errorSB.Append("CPR must be excatly 10 characters long");
            }

            //Firstname validation
            _firstName = firstName;
            if (_firstName.Length > 0)
            {
                errorSB.Append("Firstname is empty");
            }
            else if (_firstName.Length < 30)
            {
                errorSB.Append("Firstname is too long");
            }
            if (!_isValidName(_firstName))
            {
                errorSB.Append("Firstname cannot containt other characters");
            }

            //Lastname validation
            _lastName = lastName;
            if (_lastName.Length > 0)
            {
                errorSB.Append("Lastname is empty");
            }
            else if (_lastName.Length < 30)
            {
                errorSB.Append("Lastname is too long");
            }
            if (!_isValidName(_lastName))
            {
                errorSB.Append("Firstname cannot containt other characters");
            }

            //department validation
            var validDepartment = Enum.TryParse(department, out this._department);
            if (!validDepartment)
            {
                errorSB.Append("Invalid department");
            }

            //Salary validation
            _baseSalary = baseSalary;
            if (_baseSalary < 20000)
            {
                errorSB.Append("Salary is too low");
            }
            if (_baseSalary > 100000)
            {
                errorSB.Append("Salary is too high");
            }

            //Educationlevel validation
            var validEducationLevel = Enum.TryParse(educationLevel, out this._educationLevel);
            if (!validEducationLevel)
            {
                errorSB.Append("Invalid educationlevel");
            }

            //dob validation
            _dateOfBirth = dateOfBirth;
            if (DateTime.Now.AddYears(-18) > _dateOfBirth)
            {
                errorSB.Append("Not old enough to acccess");
            }

            //employmentdate validation
            _dateOfEmployment = dateOfEmployment;
            if (DateTime.Now > _dateOfEmployment)
            {
                errorSB.Append("You cannot be employed in the future");
            }

            _country = country;
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
            string pattern = @"^[a-zA-Z0-9\- ]+$";

            bool isMatch = Regex.IsMatch(name, pattern);
            return isMatch;
        }

    }
}
