using System.Threading;
using System.Threading.Tasks;

namespace LACE.Domain.Services.Abstractions
{
    public interface IDomainService
    {
        Task RunAsync(CancellationToken cancellation);
    }
}
