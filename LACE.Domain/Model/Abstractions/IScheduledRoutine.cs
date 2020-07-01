using System;

namespace LACE.Domain.Model.Abstractions
{
    interface IScheduledRoutine
    {
        IRoutine Routine { get; }
    }
}
