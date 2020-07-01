using LACE.Domain.Extensions;
using LACE.Domain.Model.Abstractions;
using LACE.Domain.State.Abstractions;
using LACE.Domain.Validation.Abstractions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LACE.Domain.Data.Abstractions;
using LACE.Domain.Services.Abstractions;

namespace LACE.Domain.Services
{
    public class DomainService : IDomainService
    {
        private readonly IDomainState _domainState;
        private readonly IMeterService _meterService;
        private readonly IRepository<IMachine> _machineRepository;
        private readonly IRepository<IMonitor> _monitorRepository;
        private readonly IValidator<IMachine> _machineValidator;
        private readonly IValidator<IMonitor> _monitorValidator;

        public DomainService(
            IDomainState domainState,
            IMeterService meterService,
            IRepository<IMachine> machineRepository,
            IRepository<IMonitor> monitorRepository,
            IValidator<IMachine> machineValidator,
            IValidator<IMonitor> monitorValidator)
        {
            _domainState = domainState.Guard(nameof(domainState));
            _meterService = meterService.Guard(nameof(meterService));
            _machineRepository = machineRepository.Guard(nameof(machineRepository));
            _monitorRepository = monitorRepository.Guard(nameof(monitorRepository));
            _machineValidator = machineValidator.Guard(nameof(machineValidator));
            _monitorValidator = monitorValidator.Guard(nameof(monitorValidator));
        }

        public async Task RunAsync(CancellationToken cancellation)
        {
            cancellation.ThrowIfCancellationRequested();

            var meterReport = await _meterService
                .GetReportAsync(cancellation)
                .ConfigureAwait(false);
            if (!meterReport.IsSuccessful)
            {
                // TODO: log
            }

            var facts = _domainState.GetFacts();
            var monitors = await _monitorRepository
                .GetAllAsync(cancellation)
                .ConfigureAwait(false);
            if (monitors != null)
            {
                foreach (var monitor in monitors.Where(m => _monitorValidator.Validate(m)))
                {
                    cancellation.ThrowIfCancellationRequested();

                    if (!monitor.IsTriggered(facts))
                    {
                        continue;
                    }

                    await monitor.WriteAsync(cancellation).ConfigureAwait(false);
                }
            }

            var machines = await _machineRepository
                .GetAllAsync(cancellation)
                .ConfigureAwait(false);
            if (machines != null)
            {
                foreach (var machine in machines.Where(m => _machineValidator.Validate(m)))
                {
                    cancellation.ThrowIfCancellationRequested();

                    await machine.WorkAsync(facts, cancellation).ConfigureAwait(false);
                }
            }
        }
    }
}
