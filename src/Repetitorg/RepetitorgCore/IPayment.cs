using System;
using System.Collections.Generic;
using System.Text;

namespace RepetitorgCore
{
    public interface IPayment
    {
        long Id { get; }

        long Amount { get; }

        PaymentDocumentType DocumentType { get; }
        string              DocumentId   { get; }

        IClient Client { get; }
    }
}
