using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Services
{
    public class ValidationService : IValidationService
    {
        private Dictionary<char, int> IdNumberValues = new Dictionary<char, int>();
        private const int IdNumberLenght = 9;
        private const int PeselLength = 11;
        // Generates dictionary of letters and their values.
        // The way of generating the values comes from polish id card number.
        private void GenerateIdValues()
        {
            int letterValue = 10;

            for (char letter = 'A'; letter <= 'Z'; letter++, letterValue++)
            {
                IdNumberValues.Add(letter, letterValue);
            }
        }

        public ValidationService()
        {
            GenerateIdValues();
        }
        
        public async Task<bool> ValidateIdNumber(string IdNumber)
        {
            string finalNumber =  IdNumber.Replace(" ", string.Empty);

            if (finalNumber.Length != IdNumberLenght)
            {
                return false;
            }

            int controlNumber = int.Parse(finalNumber[3].ToString());

            // Works, but very ugly - Refactor.
            int sum = IdNumberValues[finalNumber[0]] * 7 + IdNumberValues[finalNumber[1]] * 3
                + IdNumberValues[finalNumber[2]] + int.Parse(finalNumber[4].ToString()) * 7 
                + int.Parse(finalNumber[5].ToString()) * 3 + int.Parse(finalNumber[6].ToString())
                + int.Parse(finalNumber[7].ToString()) * 7 + int.Parse(finalNumber[8].ToString()) * 3;


            if (sum % 10 != controlNumber)
                return false;

            return true;
        }

        public async Task<bool> ValidatePesel(string Pesel)
        {
            // 1 3 7 9 1 3 7 9 1 3
            if (Pesel.Length != PeselLength)
            {
                return false;
            }

            int[] peselDigits = new int[11];
            int index = 0;

            foreach( var digit in Pesel)
            {
                peselDigits[index] = int.Parse(digit.ToString());
                index++;
            }

            int controlSum = peselDigits[0] + peselDigits[1] * 3 + peselDigits[2] * 7 +
                         peselDigits[3] * 9 + peselDigits[4] + peselDigits[5] * 3 +
                         peselDigits[6]*7 + peselDigits[7]*9 + peselDigits[8] + 
                         peselDigits[9] * 3;

            controlSum = controlSum % 10;
            controlSum = (10 - controlSum) % 10;

            if (controlSum != peselDigits[10])
                return false;

            return true;

        }
    }
}
