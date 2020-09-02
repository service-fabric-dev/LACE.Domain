using System.Threading;
using System.Threading.Tasks;
using LACE.Core.Abstractions.Model;

namespace LACE.Domain.Services.Abstractions
{
    public interface IMeterService
    {
        Task<IFactReport> GetReportAsync(CancellationToken cancellation);
    }
}