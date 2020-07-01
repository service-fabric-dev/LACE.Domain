﻿using LACE.Domain.Model.Abstractions;
using System.Collections.Concurrent;

namespace LACE.Domain.Model.Routines
{
    class RoutineSchedule : IRoutineSchedule
    {
        private readonly ConcurrentQueue<IRoutine> _routines;

        public RoutineSchedule()
        {
            _routines = new ConcurrentQueue<IRoutine>();
        }

        public void Add(IScheduledRoutine schedule)
        {
            if (schedule?.Routine == null)
            {
                return;
            }

            _routines.Enqueue(schedule.Routine);
        }
    }
}
