using System;
using System.Collections.Generic;
using System.Text;

namespace RepetitorgCore
{
    public interface ITask : IScheduleUnit
    {
        ITask ParentTask { get; }
        IEnumerable<ITask> ChildTasks { get; }
    }
}
