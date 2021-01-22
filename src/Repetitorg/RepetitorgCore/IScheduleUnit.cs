using System;
using System.Collections.Generic;
using System.Text;

namespace RepetitorgCore
{
    public interface IScheduleUnit
    {
        long                Id              { get; }

        string              Name            { get; }
        string              Description     { get; }
        string              Notes           { get; }

        DateTime            DateTime        { get; }
        ScheduleUnitStatus  Status          { get; }

        IScheduleUnit       PostponedUnit   { get; }

        void Complete();
        void Cancel();
        void Postpone(DateTime to);
    }
}
