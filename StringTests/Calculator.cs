using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTests
{
    public class Calculator
    {
        public int Add(string input)
        {
            if(input == string.Empty)
            {
                return 0;
            }

            var deliminators = new List<char>{ ',', ';', '\n' };

            if(input.StartsWith("//"))
            {
                //Take 1 character after the escape sequence
                deliminators.Add(input.Substring(2, 1).ToCharArray().First());
                var sequenceStart = input.IndexOf('\n') + 1;
                input = input.Substring(sequenceStart);
            }

            var inputNumbers = input.Split(deliminators.ToArray()).Select(x => int.Parse(x)).Where(x => x <= 1000);

            var negativeNumbers = inputNumbers.Where(x => x < 0);

            if(negativeNumbers.Any())
            {
                throw new ArgumentOutOfRangeException(nameof(input), $"negatives not allowed: {string.Join(",", negativeNumbers)}");
            }

            return inputNumbers.Sum();
        }
    }
}
