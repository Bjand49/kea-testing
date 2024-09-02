using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class RomanNumeralParser
    {
        private static readonly Dictionary<string, int> RomanMap = new Dictionary<string, int>
        {
            {"I", 1},
            {"V", 5},
            {"X", 10},
            {"L", 50},
            {"C", 100},
            {"D", 500},
            {"M", 1000}
        };

        public int ParseNumeral(string romanNumeral)
        {
            if (romanNumeral.Any(x => !RomanMap.Keys.Contains(x.ToString())))
            {
                throw new ArgumentException("Invalid characters");
            }
            if (romanNumeral.Length == 0)
            {
                throw new ArgumentException("No characters written");
            }

            int fullNumber = 0;

            char currentLetter = romanNumeral[0];
            int timesSeen = 0;
            int highstAllowedNumber = RomanMap["M"];
            for (int i = 0; i < romanNumeral.Length; i++)
            {
                var letter = romanNumeral[i];
                var number = RomanMap[letter.ToString()];
                //If its the last number, its being processed as addition since it would have been caught in the other conditions previously
                if (highstAllowedNumber < number)
                {
                    throw new ArgumentException("Invalid character positioning");
                }
                else if (i + 1 == romanNumeral.Length)
                {
                    fullNumber += number;
                }
                else
                {
                    var nextNumber = RomanMap[romanNumeral[i + 1].ToString()];
                    if (nextNumber <= number)
                    {
                        fullNumber += number;
                        highstAllowedNumber = number;
                    }
                    else if (nextNumber > number && nextNumber <= highstAllowedNumber)
                    {
                        fullNumber += nextNumber - number;
                        highstAllowedNumber = number;
                        i++;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid character positioning");
                    }
                }


                if (letter == currentLetter)
                {
                    timesSeen++;
                }
                else
                {
                    timesSeen = 1;
                    currentLetter = letter;
                }

                if (timesSeen > 3)
                {
                    throw new ArgumentException("Invalid syntax");
                }

            }
            return fullNumber;

        }

        public string ParseNumbers(int number)
        {
            if (number <= 0 || number >= 4000)
            {
                throw new ArgumentException("The number has to be at least 1 or at max 3999");
            }
            var stringNumber = number.ToString();
            var finalString = "";
            for (int i = 0; i < stringNumber.Length; i++)
            {
                var availableNumbers = RomanMap.Where(x => x.Value.ToString().Length >= stringNumber.Length - i).Select(x => x.Key).ToList();
                var digit = stringNumber[i];
                if (digit == '9')
                {
                    finalString += availableNumbers[0] + availableNumbers[2];
                }
                else
                {
                    int actualDigit = int.Parse(digit.ToString());
                    finalString += actualDigit > 5 ? availableNumbers[1] : "";
                    finalString += string.Concat(Enumerable.Repeat(availableNumbers[0], actualDigit % 5));
                }
            }
            return finalString;

        }
    }
}
