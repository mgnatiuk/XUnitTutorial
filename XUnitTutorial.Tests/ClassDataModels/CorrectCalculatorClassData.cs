using System;
using System.Collections;
using System.Collections.Generic;

namespace XUnitTutorial.Tests.ClassDataModels
{
    public class CorrectCalculatorClassData : IEnumerable<object[]>
    {
        public CorrectCalculatorClassData(){}

        #region Comments
        /*
         *  _data - has to be an object, otherwise xUnit will throws an error.
         */
        #endregion

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {17,2,6,8,1},
            new object[] {20,3,7,2,8},
            new object[] {20,7,9,1,3}
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
