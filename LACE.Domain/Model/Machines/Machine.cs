using System.Threading;
using System.Threading.Tasks;
using LACE.Domain.Model.Abstractions;
using LACE.Domain.State.Abstractions;

namespace LACE.Domain.Model.Machines
{
    class Machine : IMachine
    {
        public Task WorkAsync(IFacts facts, CancellationToken cancellation)
        {
            throw new System.NotImplementedException();
        }
    }
}
