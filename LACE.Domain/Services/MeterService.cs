using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LACE.Core.Abstractions.Model;
using LACE.Domain.Data.Abstractions;
using LACE.Domain.State;
using LACE.Domain.Validation.Abstractions;

namespace LACE.Domain.Services
{
    class MeterService
    {
        private readonly IRepository<IMeterAdapter> _meterRepository;
        private readonly IValidator<IMeterAdapter> _meterValidator;

        public MeterService(IRepository<IMeterAdapter> meterRepository, IValidator<IMeterAdapter> meterValidator)
        {
            _meterRepository = meterRepository;
            _meterValidator = meterValidator;
        }

        async Task<IFactReport> GetReportAsync(CancellationToken cancellation)
        {
            cancellation.ThrowIfCancellationRequested();

            var report = new FactReport();

            var meters = await _meterRepository
                .GetAllAsync(cancellation)
                .ConfigureAwait(false);
            if (meters == null)
            {
                report.IsSuccessful = false;
                return report;
            }

            foreach (var meter in meters.Where(m => _meterValidator.Validate(m)))
            {
                var metric = await meter.ReadAsync(cancellation).ConfigureAwait(false);
                if (metric != null)
                {
                    report.AddFact(metric);
                }

                cancellation.ThrowIfCancellationRequested();
            }

            report.IsSuccessful = true;
            return report;
        }
    }
}
