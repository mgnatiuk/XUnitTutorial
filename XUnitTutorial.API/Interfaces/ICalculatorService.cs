using System;
namespace XUnitTutorial.API.Interfaces
{
    public interface ICalculatorService
    {
        public double CurrentValue { get; set; }

        double Add(double value);
        double Subtract(double value);
        double Divide(double value);
        double Multiply(double value);
        void ClearResult();
    }
}
