using System.Threading;
using System.Threading.Tasks;
using LACE.Core.Abstractions.Model;
using LACE.Domain.Extensions;
using LACE.Domain.Model.Monitors.Logger.Abstractions;
using LACE.Domain.State;

namespace LACE.Domain.Model.Monitors
{
    class Monitor : IMonitorAdapter
    {
        private readonly ILoggerAdapter _logger;

        public Monitor(ILoggerAdapter logger)
        {
            _logger = logger.Guard(nameof(logger));
        }

        public bool IsTriggered(IFacts facts)
        {
            var fact = new FactKey();
            return facts.ContainsKey(fact);
        }

        public Task WriteAsync(CancellationToken cancellation)
        {
            _logger.Info("Monitor triggered!");

            return Task.CompletedTask;
        }
    }
}
