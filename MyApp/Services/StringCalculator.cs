using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;

            string[] splitNumbers;

            // check for custom delimiters
            if(numbers.StartsWith("//"))
            {
                var delimiterSectionEnd = numbers.IndexOf('\n');
                string delimiterPart = numbers.Substring(2, delimiterSectionEnd - 2);

                List<string> delimiters = GetDelimiters(delimiterPart);
                splitNumbers = numbers.Substring(delimiterSectionEnd + 1).Split(delimiterPart.ToArray(), StringSplitOptions.None);

            }
            else
            {
                char[] defaultDelimiters = { ',', '\n' };
                splitNumbers = numbers.Split(defaultDelimiters, StringSplitOptions.None);
            }

            var parsedNumbers = splitNumbers.Where(n => !string.IsNullOrWhiteSpace(n))
                                        .Select(int.Parse)
                                        .ToList();
            
            CheckForNegatives(parsedNumbers);
            return parsedNumbers.Where(n => n <= 1000).Sum();

        }

        private List<string> GetDelimiters(string delimiterPart)
        {
            if (delimiterPart.StartsWith("["))
            { 
                return delimiterPart.Trim('[', ']').Split(new[] { "][" }, StringSplitOptions.None).ToList();
            }
            else
            {
                return new List<string> { delimiterPart };
            }
        }

        private void CheckForNegatives(List<int> numbers)
        {
            var negatives = numbers.Where(nameof => nameof < 0).ToList();
            if (negatives.Any())
            {
                throw new ArgumentException($"Negatives not allowed: {string.Join(",", negatives)}");
            }
        }
    }
}
