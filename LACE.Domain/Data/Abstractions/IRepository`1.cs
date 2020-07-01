using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LACE.Domain.Data.Abstractions
{
    public interface IRepository<TData>
    {
        Task<TData> GetAsync(IDataKey dataKey);
        Task<IEnumerable<TData>> GetAllAsync(CancellationToken cancellation);
    }
}
