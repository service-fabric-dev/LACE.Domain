using System.Threading;
using System.Threading.Tasks;
using LACE.Core.Abstractions.Model;

namespace LACE.Domain.Model.Machines
{
    public class Machine : IMachineAdapter
    {
        public Task WorkAsync(IFacts facts, CancellationToken cancellation)
        {
            throw new System.NotImplementedException();
        }
    }
}
