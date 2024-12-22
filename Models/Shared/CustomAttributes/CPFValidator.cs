using System.ComponentModel.DataAnnotations;

namespace TravelManagement.Models.Shared.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CPFValidator : ValidationAttribute
    {
        private readonly int BASE_FIRST_DIGIT = 10;
        private readonly int INDEX_FIRST_DIGIT = 9;
        private readonly int BASE_SECOND_DIGIT = 11;
        private readonly int INDEX_SECOND_DIGIT = 10;

        public override bool IsValid(object? value)
        {
            if (value is null || !TypeIsValid(value))
                return false;

            value = RemoveFormatting((string)value);

            if (!LengthIsValid((string)value))
                return false;

            if (!ValidatorIfDigitsAreValid((string)value))
                return false;

            return true;
        }

        private bool TypeIsValid(object value)
        {
            return value is string;
        }

        private string RemoveFormatting(string cpf)
        {
            return cpf.Replace(".", "").Replace("-", "");
        }

        private bool LengthIsValid(string cpf)
        {
            return cpf.Length == 11; // No formatting
        }

        private bool ValidatorIfDigitsAreValid(string cpf)
        {
            int totalForTheFirstDigit = GetSumForDigit(cpf, BASE_FIRST_DIGIT);
            if (cpf[INDEX_FIRST_DIGIT] != GetDigit(totalForTheFirstDigit))
                return false;

            int totalForTheSecondDigit = GetSumForDigit(cpf, BASE_SECOND_DIGIT);
            if (cpf[INDEX_SECOND_DIGIT] != GetDigit(totalForTheSecondDigit))
                return false;

            return true;
        }

        private int GetSumForDigit(string cpf, int baseCalc)
        {
            int total = 0;
            for (int i = 0; i < baseCalc; i++)
            {
                var digit = cpf[i];
                total += SumPerDigit(baseCalc, digit, i);
            }

            return total;
        }

        private int SumPerDigit(int baseCalc, int digit, int index)
        {
            return digit * (baseCalc - index);
        }

        private int GetDigit(int total)
        {
            if (total >= 10)
                return 0;

            int resto = total % 11;
            return 11 - resto;
        }
    }
}
