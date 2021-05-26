using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberConvertion.Model
{
    class Number : IConvert
    {
        private const int DEFAULT_HUNDREDS_LENGTH = 3;

        private string mainValue;
        private string centsValue;

        private Func<string, string> fixFormatIntoD3 = (i) => Int32.Parse(i).ToString("D3");

        private Func<int, string> convertNumberGroups = (i) =>
        {
            if (i == 3)
                return "hundred";
            else if (i >= 4 && i <= 6)
                return "thousand";
            else if (i >= 7 && i <= 9)
                return "million";
            else if (i >= 10 && i <= 12)
                return "billion";
            else if (i >= 13 && i <= 15)
                return "trillion";
            else if (i >= 16 && i <= 18)
                return "quadrillion";
            else if (i >= 19 && i <= 21)
                return "quintillion";
            else
                return "";
        };

        private Func<char, string> convertOnes = (i) =>
        {
            if (i == '1')
                return "one";
            else if (i == '2')
                return "two";
            else if (i == '3')
                return "three";
            else if (i == '4')
                return "four";
            else if (i == '5')
                return "five";
            else if (i == '6')
                return "six";
            else if (i == '7')
                return "seven";
            else if (i == '8')
                return "eight";
            else if (i == '9')
                return "nine";
            else
                return "";
        };

        private Func<string, Func<char, string>, string> convertTens = (i, convertOnes) =>
        {
            /*
                i must be 2 digits number.
             */

            string result = "";

            // default value for: 00, 10-19, 20, 30, 40, 50, 60, 70, 80, 90:
            string onesSentence = "";
            
            if(i[0] != '1' || i[1] != '0')
                onesSentence = "-" + convertOnes(i[1]);

            if (i == "00")
                result = "";
            else if (i == "10")
                result = "ten";
            else if (i == "11")
                result = "eleven";
            else if (i == "12")
                result = "twelve";
            else if (i == "13")
                result = "thirteen";
            else if (i == "14")
                result = "fourteen";
            else if (i == "15")
                result = "fifteen";
            else if (i == "16")
                result = "sixteen";
            else if (i == "17")
                result = "seventeen";
            else if (i == "18")
                result = "eighteen";
            else if (i == "19")
                result = "nineteen";
            else if (i[0] == '2')
                result = "twenty";
            else if (i[0] == '3')
                result = "thirty";
            else if (i[0] == '4')
                result = "forty";
            else if (i[0] == '5')
                result = "fifty";
            else if (i[0] == '6')
                result = "sixty";
            else if (i[0] == '7')
                result = "seventy";
            else if (i[0] == '8')
                result = "eighty";
            else if (i[0] == '9')
                result = "ninety";

            return result + onesSentence;
        };

        private Func<string, Func<string, Func<char, string>, string>, string> convertHundreds = (i, convertTens) =>
        {
            /*
                i must be 3 digits number.
             */

            string result = "";
            string tensNumber = i.Substring(1);
            //delegate string 
            //string tensSentence = convertTens(tensNumber, delegate()

            //if (i == "000")
            //    return "";
            //else if(i[0])
            //    return convertOnes(i) + " " + convertNumberGroup(DEFAULT_HUNDREDS_LENGTH) + " ";
            return result;
        };
        

        public Number()
        {
        }

        public string MainValue
        {
            get => this.mainValue;
            set
            {
                if (value.Length > 21)
                    throw new ArgumentOutOfRangeException("Value must be under sextillion.");
                else
                    this.mainValue = value;
            }
        }
        public string CentsValue
        {
            get => this.centsValue;
            set
            {
                if (value.Length > 3)
                {
                    decimal parseTemp = Math.Round(decimal.Parse(string.Concat("0.", value)), DEFAULT_HUNDREDS_LENGTH);
                    this.centsValue = parseTemp.ToString().Substring(2);

                }
                else
                    this.centsValue = value;
            }
        }

        public string EachThreeDigitConverter(string eachThreeDigit)
        {
            // fix the format type of numbers into 3 digit numbers:
            eachThreeDigit = Int32.Parse(eachThreeDigit).ToString("D3");

            string numberSentence = "";
            string numberSeparator = "";

            //if (eachThreeDigit[0] != '0')
            //    numberSentence += convertOnes(eachThreeDigit[0]) + " " + convertNumberGroup(DEFAULT_HUNDREDS_LENGTH) + " ";

            //if (eachThreeDigit[2] != '0')
            //{
            //    numberSeparator = "-";
            //    numberSentence += convertTens(eachThreeDigit[2]) + numberSeparator + convertOnes(eachThreeDigit[2]) + " ";
            //}


            return numberSentence;
        }

        public List<string> SplitMaxThreeDigits(string mainValue)
        {
            List<string> listMainValue = new List<string>();
            int remainMainValue = mainValue.Length % 3;

            if (remainMainValue > 0)
            {
                listMainValue.Add(mainValue.Substring(0, remainMainValue));
                mainValue = mainValue.Substring(remainMainValue);
            }

            var splitMainValue = Enumerable.Range(0, mainValue.Length / 3)
                                           .Select(i => mainValue.Substring(i * 3, 3))
                                           .ToList();

            listMainValue.AddRange(splitMainValue);

            return listMainValue;
        }
    }
}
