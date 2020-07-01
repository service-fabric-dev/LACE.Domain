using System.Threading.Tasks;

namespace LACE.Domain.Model.Abstractions
{
    interface IRoutine
    {
        public Task<IRoutineReport> ExecuteAsync();
    }
}
