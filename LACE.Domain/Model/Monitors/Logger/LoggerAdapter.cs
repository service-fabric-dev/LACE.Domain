using System.Drawing;
using LACE.Domain.Extensions;
using LACE.Domain.Model.Monitors.Logger.Abstractions;
using Console = Colorful.Console;

namespace LACE.Domain.Model.Monitors.Logger
{
    class LoggerAdapter : ILoggerAdapter
    {
        private readonly Color _infoColor;
        private readonly Color _warningColor;
        private readonly Color _errorColor;

        public LoggerAdapter(
            Color infoColor,
            Color warningColor,
            Color errorColor)
        {
            _infoColor = infoColor.Guard(nameof(infoColor));
            _warningColor = warningColor.Guard(nameof(warningColor));
            _errorColor = errorColor.Guard(nameof(errorColor));
        }

        public void Info(string message)
        {
            Console.WriteLine(message, _infoColor);
        }
        public void Warning(string message)
        {
            Console.WriteLine(message, _warningColor);
        }
        public void Error(string message)
        {
            Console.WriteLine(message, _errorColor);
        }
    }
}
