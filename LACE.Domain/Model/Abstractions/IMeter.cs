using System.Threading;
using System.Threading.Tasks;
using LACE.Domain.State.Abstractions;

namespace LACE.Domain.Model.Abstractions
{
    interface IMeter
    {
        Task<IFact> ReadAsync(CancellationToken cancellation);
    }
}
