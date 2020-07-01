using IronPython.Hosting;
using LACE.Adapters.RaspberryPi.Exceptions;
using Microsoft.Scripting.Hosting;

namespace LACE.Adapters.RaspberryPi.Model
{
    public class GpioPin
    {
        private const string _pinReaderScriptUri = "./PinReader.py";
        private readonly ScriptEngine _scriptEngine;
        private string _scriptUri;

        public GpioPin(int pinPosition, string scriptUri)
        {
            PinPosition = pinPosition;
            _scriptUri = scriptUri;
            _scriptEngine = Python.CreateEngine();
        }

        public int PinPosition { get; }

        public decimal Value => GetPinValue();

        private decimal GetPinValue()
        {
            dynamic pin =_scriptEngine.ExecuteFile(_pinReaderScriptUri);
            dynamic value = pin.Read(PinPosition); // See script for method details

            if (!(value is string))
            {
                throw new PinReadException();
            }

            if(!decimal.TryParse(value, out decimal decimalValue))
            {
                throw new PinReadException();
            }

            return decimalValue;
        }
    }
}
