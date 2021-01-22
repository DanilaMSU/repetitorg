using System;
using System.Collections.Generic;
using System.Text;

namespace RepetitorgCore
{
    class BusinessBook : IBusinessBook
    {
        public IEnumerable<IOrder> Orders => throw new NotImplementedException();

        public IEnumerable<IClient> Clients => throw new NotImplementedException();

        public IEnumerable<IStudent> Students => throw new NotImplementedException();

        public IEnumerable<IPayment> Payments => throw new NotImplementedException();

        public void AddClient(long id, string firstName, string surName, string patronymic, DateTime registrationDateTime)
        {
            throw new NotImplementedException();
        }

        public void AddOrder(long id, string name, string description, DateTime creationDateTime, long standartLength)
        {
            throw new NotImplementedException();
        }

        public void AddPayment(long id, long amount, PaymentDocumentType documentType, string documentId, long clientId)
        {
            throw new NotImplementedException();
        }

        public void AddStudent(long id, string firstName, string surName, string patronymic, DateTime registrationDateTime, long clientId)
        {
            throw new NotImplementedException();
        }

        public void AttachStudentToOrder(long orderId, long studentId, long cost)
        {
            throw new NotImplementedException();
        }

        public void DetachStudentFromOrder(long orderId, long studentId)
        {
            throw new NotImplementedException();
        }

        public IClient GetClient(long id)
        {
            throw new NotImplementedException();
        }

        public IOrder GetOrder(long id)
        {
            throw new NotImplementedException();
        }

        public IPayment GetPayment(long id)
        {
            throw new NotImplementedException();
        }

        public IStudent GetStudent(long id)
        {
            throw new NotImplementedException();
        }
    }
}
