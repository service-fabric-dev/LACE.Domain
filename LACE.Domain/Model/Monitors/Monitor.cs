using System.Threading;
using System.Threading.Tasks;
using LACE.Domain.Extensions;
using LACE.Domain.Model.Abstractions;
using LACE.Domain.Model.Monitors.Logger.Abstractions;
using LACE.Domain.State;
using LACE.Domain.State.Abstractions;

namespace LACE.Domain.Model.Monitors
{
    class Monitor : IMonitor
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
