using System.Threading;
using System.Threading.Tasks;
using LACE.Core.Abstractions.Model;

namespace LACE.Domain.Model.Meters.Moisture
{
    class MoistureMeter : IMeterAdapter<MoistureFact>
    {
        public Task<MoistureFact> ReadConcreteAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IFact> ReadAsync(CancellationToken cancellation)
        {
            return Task.FromResult<IFact>(new MoistureFact(0.23M));
        }
    }
}
