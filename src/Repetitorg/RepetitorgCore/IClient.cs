using System;
using System.Collections.Generic;
using System.Text;

namespace RepetitorgCore
{
    public interface IClient : IBusinessContact
    {
        IEnumerable<IStudent> Students { get; }
        IEnumerable<IPayment> Payments { get; }
        int StudentsCount { get; }
        int PaymentsCount { get; }

        long Balance { get; }
    }
}
