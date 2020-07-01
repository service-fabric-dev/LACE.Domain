using System;
using System.Collections.Generic;
using System.Text;

namespace LACE.Domain.Model.Abstractions
{
    interface IRoutineSchedule
    {
        void Add(IScheduledRoutine schedule);
    }
}
