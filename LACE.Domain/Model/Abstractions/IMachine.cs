using System.Threading;
using System.Threading.Tasks;
using LACE.Domain.State.Abstractions;

namespace LACE.Domain.Model.Abstractions
{
    public interface IMachine
    {
        Task WorkAsync(IFacts facts, CancellationToken cancellation);
    }
}
