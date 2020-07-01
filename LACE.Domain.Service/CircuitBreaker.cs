using System;
using LACE.Domain.Extensions;
using LACE.Domain.Services.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace LACE.Domain.Service
{
    public class DomainCircuitBreaker : IDomainService
    {
        private readonly Func<IDomainService> _domainServiceFactory;

        public DomainCircuitBreaker(Func<IDomainService> domainServiceFactory)
        {
            _domainServiceFactory = domainServiceFactory.Guard(nameof(domainServiceFactory));
        }

        public async Task RunAsync(CancellationToken cancellation)
        {
            var errors = 0;
            var warnings = 0;

            while (!cancellation.IsCancellationRequested)
            {
                try
                {
                    await _domainServiceFactory().RunAsync(cancellation);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    errors++;
                }
            }
        }
    }
}
