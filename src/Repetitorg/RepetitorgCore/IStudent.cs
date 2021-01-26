using System;
using System.Collections.Generic;
using System.Text;

namespace RepetitorgCore
{
    public interface IStudent : IBusinessContact
    {
        IClient Client { get; }
    }
}
