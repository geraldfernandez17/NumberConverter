using NumberConvertion.Model.NumberToWords;
using System;
using System.Collections.Generic;

/*
    This is not Mitrais requirement task. I just want to give an example how to implement abstract class, so when this converter program expand to another language or currency, it will be very easy to developed. 
 */

namespace NumberConverter.Model.NumberToWords.Indonesia
{
    public class IndonesiaIDRConverter : Converter
    {
        public override string ConvertNumberIntoWords()
        {
            throw new NotImplementedException();
        }
    }
}
