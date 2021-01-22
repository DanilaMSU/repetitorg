using System;
using System.Collections.Generic;
using System.Text;

namespace RepetitorgCore
{
    public interface IClient : IBusinessContact
    {
        IEnumerable<IStudent> Students { get; }
        IEnumerable<IPayment> Payments { get; }

        long Balance { get; }
    }
}
