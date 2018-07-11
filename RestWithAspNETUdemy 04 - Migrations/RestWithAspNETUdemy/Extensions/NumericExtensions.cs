using System;

namespace RestWithAspNETUdemy.Extensions
{
    public static class NumericExtensions
    {
        #region commom
        public static bool IsNumeric(this string strValue)
        {
            var temp = 0.0;
            return !string.IsNullOrEmpty(strValue.Trim()) && double.TryParse(strValue, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out temp);
        }
        #endregion

        #region decimal
        public static decimal ConvertToDecimal(this string strValue)
        {
            var decimalValue = 0m;
            if (decimal.TryParse(strValue, out decimalValue))
            {
                return decimalValue;
            }

            throw new ApplicationException($"ConvertToDecimal: Error converting {strValue} to decimal");
        }
        #endregion
    }
}
