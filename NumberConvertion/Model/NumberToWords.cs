using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberConvertion.Model
{
    class NumberToWords : IConvert
    {
        private const int DEFAULT_NUMBER_SECTION = 1;
        private const int DEFAULT_HUNDREDS_SECTION = 0;
        private const int DEFAULT_CENTS_LENGTH = 3;
        private const int DEFAULT_MAX_MAIN_VALUE_SECTION = 7;
        private const int DEFAULT_MAX_MAIN_VALUE_LENGTH = DEFAULT_MAX_MAIN_VALUE_SECTION * 3;
        /*
            1. hundred
            2. thousand
            3. million
            4. billion
            5. trillion
            6. quadrillion
            7. quintillion
        */



        private string mainValue;
        private string centsValue;

        public delegate void DelegateOnes(string onesSentence);

        private Func<string, string> fixFormatIntoD3 = (i) => Int32.Parse(i).ToString("D3");

        public NumberToWords()
        {
        }

        public string MainValue
        {
            get => this.mainValue;
            set
            {
                if (value.Length > DEFAULT_MAX_MAIN_VALUE_LENGTH)
                    throw new ArgumentOutOfRangeException("The number is too large.");
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
                    decimal parseTemp = Math.Round(decimal.Parse(string.Concat("0.", value)), DEFAULT_CENTS_LENGTH);
                    this.centsValue = parseTemp.ToString().Substring(2);

                }
                else
                    this.centsValue = value;
            }
        }

        private string ConvertNumberGroups(int groupIndex)
        {
            if (groupIndex == 0)
                return "hundred";
            else if (groupIndex == 1)
                return "";
            else if (groupIndex == 2)
                return "thousand";
            else if (groupIndex == 3)
                return "million";
            else if (groupIndex == 4)
                return "billion";
            else if (groupIndex == 5)
                return "trillion";
            else if (groupIndex == 6)
                return "quadrillion";
            else if (groupIndex == 7)
                return "quintillion";
            else
                return "";
        }

        private string ConvertOnes(char ones)
        {
            if (ones == '1')
                return "one";
            else if (ones == '2')
                return "two";
            else if (ones == '3')
                return "three";
            else if (ones == '4')
                return "four";
            else if (ones == '5')
                return "five";
            else if (ones == '6')
                return "six";
            else if (ones == '7')
                return "seven";
            else if (ones == '8')
                return "eight";
            else if (ones == '9')
                return "nine";
            else
                return "";
        }

        private string ConvertTens(string tens)
        {
            /*
                tens is 2 digits number.
             */

            string result = "";

            // the second number of tens:
            char onesOfTens = tens[1];

            // the first number of tens:
            char tensOfTens = tens[0];

            // default value for: 00, 10-19, 20, 30, 40, 50, 60, 70, 80, 90:
            string oneSentence = "";

            if (tens == "00")
                result = "";
            else if (tens == "10")
                result = "ten";
            else if (tens == "11")
                result = "eleven";
            else if (tens == "12")
                result = "twelve";
            else if (tens == "13")
                result = "thirteen";
            else if (tens == "14")
                result = "fourteen";
            else if (tens == "15")
                result = "fifteen";
            else if (tens == "16")
                result = "sixteen";
            else if (tens == "17")
                result = "seventeen";
            else if (tens == "18")
                result = "eighteen";
            else if (tens == "19")
                result = "nineteen";
            else if (tensOfTens == '2')
                result = "twenty";
            else if (tensOfTens == '3')
                result = "thirty";
            else if (tensOfTens == '4')
                result = "forty";
            else if (tensOfTens == '5')
                result = "fifty";
            else if (tensOfTens == '6')
                result = "sixty";
            else if (tensOfTens == '7')
                result = "seventy";
            else if (tensOfTens == '8')
                result = "eighty";
            else if (tensOfTens == '9')
                result = "ninety";

            if (tensOfTens != '1' && onesOfTens != '0')
                oneSentence = "-" + this.ConvertOnes(onesOfTens);

            return result + oneSentence;
        }

        private string ConvertHundreds(string hundreds)
        {
            /*
                hundreds is 3 digits number.
             */

            string hundredsSentence = "";
            string tenSentence = "";

            // fix the format type of numbers into 3 digit numbers:
            hundreds = fixFormatIntoD3(hundreds);

            //the first number of hundreds:
            char hundredsOfHundreds = hundreds[0];

            // the second and third number of hundreds:
            string tensOfHundreds = hundreds.Substring(1, 2);

            // convert tens:
            tenSentence = this.ConvertTens(tensOfHundreds);

            if (hundreds.Equals("000"))
                hundredsSentence = "";
            else if (hundredsOfHundreds == '0')
                hundredsSentence = tenSentence;
            else
                hundredsSentence = this.ConvertOnes(hundredsOfHundreds) + " " + this.ConvertNumberGroups(DEFAULT_HUNDREDS_SECTION) + " " + tenSentence + " ";

            return hundredsSentence;
        }

        private string EachThreeDigitConverter(string eachThreeDigit, int groupIndex)
        {
            return this.ConvertHundreds(eachThreeDigit) + " " + this.ConvertNumberGroups(groupIndex) + " ";
        }

        private List<string> SplitMaxThreeDigits(string mainValue)
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

        public string ConvertNumberIntoWords()
        {
            StringBuilder wordsOfNumber = new StringBuilder("");

            // create mainValue:
            List<string> listMainValue = this.SplitMaxThreeDigits(this.mainValue);
            int remainListCounter = listMainValue.Count();

            foreach (var mainValueTemp in listMainValue)
            {
                wordsOfNumber.Append(this.EachThreeDigitConverter(mainValueTemp, remainListCounter));
                remainListCounter--;

                if (remainListCounter == 0)
                    break;

                wordsOfNumber.Append(" and ");
            }

            if(wordsOfNumber.ToString().Replace(" ", "") != string.Empty)
                wordsOfNumber.Append("dollars ");

            // create cents value:
            string centSentence = this.EachThreeDigitConverter(this.centsValue, DEFAULT_NUMBER_SECTION);

            if(centSentence.Replace(" ", "") != string.Empty)
            {
                wordsOfNumber.Append(centSentence);
                wordsOfNumber.Append("cents");
            }
            
            return wordsOfNumber.ToString().ToUpper();
        }
    }
}
