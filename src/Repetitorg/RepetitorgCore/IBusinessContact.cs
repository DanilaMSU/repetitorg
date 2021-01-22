using System;
using System.Collections.Generic;
using System.Text;

namespace RepetitorgCore
{
    public interface IBusinessContact
    {
        long Id { get; }

        string FirstName  { get; }
        string SurName    { get; }
        string Patronymic { get; }

        DateTime RegistrationDateTime { get; }
    }
}
