using System.Collections.Generic;

namespace NumberConvertion.Model.NumberToWords
{
    public abstract class Converter : IConvert
    {
        protected const string DEFAULT_MAIN_VALUE = "000";
        protected const string DEFAULT_CENTS_VALUE = "00";

        private string mainValue;
        private string centsValue;

        public virtual string MainValue { get => mainValue; set => mainValue = value; }
        public virtual string CentsValue { get => centsValue; set => centsValue = value; }

        public Converter()
        {
            this.MainValue = DEFAULT_MAIN_VALUE;
            this.CentsValue = DEFAULT_CENTS_VALUE;
        }

        public abstract string ConvertNumberIntoWords();
    }
}
