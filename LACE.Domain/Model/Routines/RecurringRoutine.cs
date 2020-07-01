using System.Threading.Tasks;
using LACE.Domain.Extensions;
using LACE.Domain.Model.Abstractions;

namespace LACE.Domain.Model.Routines
{
    class RecurringRoutine : IRoutine
    {
        public Task<IRoutineReport> ExecuteAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Schedule(IRoutineSchedule schedule)
        {
            var scheduledRoutine = new ScheduledRoutine(this);
            schedule.Add(scheduledRoutine);
        }

        private class ScheduledRoutine : IScheduledRoutine
        {
            public ScheduledRoutine(RecurringRoutine routine)
            {
                Routine = routine.Guard(nameof(routine));
            }

            public IRoutine Routine { get; }
        }
    }
}
