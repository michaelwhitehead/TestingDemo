using System;
using TestingDemo.Services.Interfaces;

namespace TestingDemo.Demo_2
{
    public class ComplexNumberService
    {
        private readonly IBaseServices _baseServices;

        public ComplexNumberService(IBaseServices baseServices)
        {
            _baseServices = baseServices;
        }

        public bool CheckForPositiveNumber(string number)
        {
            try
            {
                var actualValue = int.Parse(number);
                return actualValue > 0;
            }
            catch (Exception ex)
            {
                _baseServices.Logger.LogError(ex);
            }

            return false;
        }
    }
}
