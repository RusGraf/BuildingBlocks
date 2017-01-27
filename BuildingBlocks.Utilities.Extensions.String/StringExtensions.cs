using System;

namespace BuildingBlocks.Utilities.Extensions.String
{
    public static class StringExtensions
    {
        public static decimal? ToDecimal(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            decimal result;

            if (decimal.TryParse(value, out result))
            {
                return result;
            }
            throw new ArgumentException($"Can not convert {value} to decimal");

        }
        public static double? ToDouble(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            double result;

            if (double.TryParse(value, out result))
            {
                return result;
            }
            throw new ArgumentException($"Can not convert {value} to double");
        }

        public static int? ToInt(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            int result;

            if (int.TryParse(value, out result))
            {
                return result;
            }
            throw new ArgumentException($"Can not convert {value} to integer");
        }

        public static DateTime? ToDateTime(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            DateTime result;

            if (DateTime.TryParse(value, out result))
            {
                return result;
            }
            throw new ArgumentException($"Can not convert {value} to DateTime");
        }
    }
}
