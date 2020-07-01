using System.Threading;
using System.Threading.Tasks;
using LACE.Domain.State.Abstractions;

namespace LACE.Domain.Model.Abstractions
{
    public interface IMonitor
    {
        bool IsTriggered(IFacts facts);
        Task WriteAsync(CancellationToken cancellation);
    }
}
