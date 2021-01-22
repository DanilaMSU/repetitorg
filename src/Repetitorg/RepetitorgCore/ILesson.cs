using System;
using System.Collections.Generic;
using System.Text;

namespace RepetitorgCore
{
    public interface ILesson : IScheduleUnit
    {
        IOrder Order { get; }
    }
}
