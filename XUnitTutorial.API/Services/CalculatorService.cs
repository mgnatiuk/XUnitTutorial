using System;
using Microsoft.Extensions.Logging;
using XUnitTutorial.API.Interfaces;

namespace XUnitTutorial.API.Services
{
    public class CalculatorService : ICalculatorService
    {
        public ILogger<CalculatorService> _logger { get; set; }

        public double CurrentValue { get; set; }
 
        public CalculatorService(ILogger<CalculatorService> logger)
        {
            _logger = logger;
            CurrentValue = 0;
        }

        public double Add(double value)
        {
            _logger.LogInformation($"{CurrentValue} + {value} = {CurrentValue + value}.");
            return  CurrentValue += value;
        }

        public double Divide(double value)
        {
            if (value == 0)
                throw new ArgumentException($"input parameter: {nameof(value)} = 0. Divide by zero not impossible !");

            _logger.LogInformation($"{CurrentValue} / {value} = {CurrentValue / value}.");
            return CurrentValue /= value;
        }

        public double Multiply(double value)
        {
            _logger.LogInformation($"{CurrentValue} * {value} = {CurrentValue * value}.");
            return CurrentValue *= value;
        }

        public double Subtract(double value)
        {
            _logger.LogInformation($"{CurrentValue} - {value} = {CurrentValue - value}.");
            return CurrentValue -= value;
        }

        public void ClearResult()
        {
            _logger.LogInformation($"Clear current result: {CurrentValue}.");
            CurrentValue = 0;
        }
    }
}
