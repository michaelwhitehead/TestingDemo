using System;
using TestingDemo.Services.Interfaces;

namespace TestingDemo.Demo_2
{
    public class SimpleNumberService
    {
        private readonly ILogger _logger;

        public SimpleNumberService(ILogger logger)
        {
            _logger = logger;
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
                _logger.LogError(ex);
            }

            return false;
        }
    }
}
