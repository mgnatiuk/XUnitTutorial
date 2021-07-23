using System;
using System.Collections;
using System.Collections.Generic;
using XUnitTutorial.Tests.Models;

namespace XUnitTutorial.Tests.MemberDataModels
{
    public class CorrectCalculatorMemberData
    {
        public CorrectCalculatorMemberData()
        {
        }
         
        public static IEnumerable<object[]> GetOperationsFromMemberDataClass()
        {
            yield return new object[]
            {
                new CalcOperation {Expected = 11, OperationNumbers = new List<double>{10,1 } },
                new CalcOperation {Expected = 18, OperationNumbers = new List<double>{10,1,6,1 } }
            };
        }
    }
}
