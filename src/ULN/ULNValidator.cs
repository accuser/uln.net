using System;
using System.Text.RegularExpressions;

namespace ULN
{
    public static class ULNValidator
    {
        private static readonly Regex UlnRegex = new Regex(@"^(?<digits>\d{9})(?<checkDigit>\d{1})$", RegexOptions.Compiled);

        public static string RequireValidULN(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value), "ULN value cannot be null or empty");

            if (!IsValidULN(value))
                throw new ArgumentException("Invalid ULN value", nameof(value));

            return value;
        }

        public static bool IsValidULN(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            Match match = UlnRegex.Match(value);
            if (!match.Success)
                return false;

            string digits = match.Groups["digits"].Value;
            int checkDigit = int.Parse(match.Groups["checkDigit"].Value);

            int remainder = CalculateSum(digits) % 11;

            if (remainder == 0)
                return false;

            return (10 - remainder) == checkDigit;
        }

        private static int CalculateSum(string digits)
        {
            int sum = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                sum += (10 - i) * int.Parse(digits[i].ToString());
            }
            return sum;
        }
    }
}