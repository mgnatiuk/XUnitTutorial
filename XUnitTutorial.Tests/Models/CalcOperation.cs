using System.Collections.Generic;

namespace XUnitTutorial.Tests.Models
{
    public class CalcOperation
    {
        public CalcOperation()
        {
            OperationNumbers = new List<double>();
        }

        public double Expected { get; set; }

        public List<double> OperationNumbers { get; set; }
    }
}
