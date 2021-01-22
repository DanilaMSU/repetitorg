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

        void AddOrder(
            long id,
            string name,
            string description,
            DateTime creationDateTime,
            long standartLength
        );
        IOrder GetOrder(long id);
        void AttachStudentToOrder(
            long orderId,
            long studentId,
            long cost
        );
        void DetachStudentFromOrder(
             long orderId,
             long studentId
        );

        void AddClient(
            long id,
            string firstName,
            string surName,
            string patronymic,
            DateTime registrationDateTime
        );
        IClient GetClient(long id);

        void AddStudent(
            long id,
            string firstName,
            string surName,
            string patronymic,
            DateTime registrationDateTime,
            long clientId
        );
        IStudent GetStudent(long id);

        void AddPayment(
            long id,
            long amount,
            PaymentDocumentType documentType,
            string documentId,
            long clientId
        );
        IPayment GetPayment(long id);
    }
}
