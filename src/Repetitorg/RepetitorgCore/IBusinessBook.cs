using System;
using System.Collections.Generic;
using System.Text;

namespace RepetitorgCore
{
    public interface IBusinessBook
    {
        IEnumerable<IOrder>   Orders   { get; }
        IEnumerable<IClient>  Clients  { get; }
        IEnumerable<IStudent> Students { get; }
        IEnumerable<IPayment> Payments { get; }
    }
}
