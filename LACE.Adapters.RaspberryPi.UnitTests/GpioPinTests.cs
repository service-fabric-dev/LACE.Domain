using LACE.Adapters.RaspberryPi.Model;
using Xunit;

namespace LACE.Adapters.RaspberryPi.UnitTests
{
    public class GpioPinTests : EmbeddedTest
    {
        private const string _scriptUri = "";

        [Theory]
        [InlineData(1, 0.3)]
        public void ReadValue_ValueReturned(int pinPosition, decimal result)
        {
            var pin = new GpioPin(pinPosition, _scriptUri);
        }
    }
}
