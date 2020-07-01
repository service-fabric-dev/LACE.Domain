using LACE.Domain.State.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace LACE.Domain.Services.Abstractions
{
    public interface IMeterService
    {
        Task<IFactReport> GetReportAsync(CancellationToken cancellation);
    }
}