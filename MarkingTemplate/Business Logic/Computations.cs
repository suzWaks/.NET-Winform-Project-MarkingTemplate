using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkingTemplate
{
    public class Computations
    {
        public double Average(List<int> selectedIntegers)
        {
            return selectedIntegers.Average();
        }

        public double Percentage(List<int> selectedIntegers, string weightValue)
        {
            var stringQuery = weightValue.TrimEnd('%'); //GPT - more efficient
            var value = int.Parse(stringQuery);

            double weight = value/100.0;

            return selectedIntegers.Average()*weight;
        }
    }
}