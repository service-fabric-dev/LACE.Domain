using System.Threading.Tasks;
using LACE.Domain.State.Abstractions;

namespace LACE.Domain.Model.Abstractions
{
    interface IMeter<TMetric> : IMeter
        where TMetric : IFact
    {
        Task<TMetric> ReadConcreteAsync();
    }
}
