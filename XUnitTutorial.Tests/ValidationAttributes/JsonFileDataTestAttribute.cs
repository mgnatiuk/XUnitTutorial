using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit.Sdk;

namespace XUnitTutorial.Tests
{
    public class JsonFileDataTest : DataAttribute
    {
        private string _filePath { get; set; }

        private string _propertyName { get; set; }

        public JsonFileDataTest(string filePath) : this(filePath, null){}

        public JsonFileDataTest(string filePath, string propertyName)
        {
            _filePath = filePath;
            _propertyName = propertyName;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null) { throw new ArgumentNullException(nameof(testMethod)); }

            var path = Path.IsPathRooted(_filePath)
                ? _filePath
                : Path.GetRelativePath(Directory.GetCurrentDirectory(), _filePath);

            if (!File.Exists(path))
                throw new ArgumentException($"Could not find file at path: {path}");

            var fileData = File.ReadAllText(_filePath);

            // If property name is empty then get all records in file
            if (string.IsNullOrEmpty(_propertyName))
                return JsonConvert.DeserializeObject<List<object[]>>(fileData);

            // Else use data by property name
            var allData = JObject.Parse(fileData);
            var data = allData[_propertyName];
            return data.ToObject<List<object[]>>();

        }
    }
}
