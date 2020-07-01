using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LACE.Domain.Data.Abstractions;
using LACE.Domain.Model.Abstractions;
using LACE.Domain.State;
using LACE.Domain.State.Abstractions;
using LACE.Domain.Validation.Abstractions;

namespace LACE.Domain.Services
{
    class MeterService
    {
        private readonly IRepository<IMeter> _meterRepository;
        private readonly IValidator<IMeter> _meterValidator;

        public MeterService(IRepository<IMeter> meterRepository, IValidator<IMeter> meterValidator)
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
