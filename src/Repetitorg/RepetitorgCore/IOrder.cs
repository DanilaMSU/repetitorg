using System;
using System.Collections.Generic;
using System.Text;

namespace RepetitorgCore
{
    public interface IOrder
    {
        long Id { get; }

        string Name { get; }
        string Description { get; }

        DateTime CreationDateTime { get; }

        long StandartLength { get; }

        IEnumerable<IStudent> Students { get; }

        long GetCostFor(IStudent student);
    }
}
