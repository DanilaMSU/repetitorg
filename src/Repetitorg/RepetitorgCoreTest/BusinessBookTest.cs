using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RepetitorgCore;
using System.Collections.Generic;

namespace RepetitorgCoreTest
{
    [TestClass]
    public class BusinessBookTest
    {
        [TestMethod]
        public void AddClientTest()
        {
            long id = 1;
            string firstName = "fn";
            string surName = "sn";
            string patronymic = "pa";
            DateTime registrationDateTime = 
                new DateTime(2020, 4, 15, 10, 0, 0);

            var bb = GetBusinessBook();
            Assert.AreEqual(0, bb.ClientsCount);

            bb.AddClient(
                id, firstName, surName, patronymic, registrationDateTime
            );
            Assert.AreEqual(1, bb.ClientsCount);
        }
        [TestMethod]
        public void GetClientTest()
        {
            long id = 1;
            string firstName = "fn";
            string surName = "sn";
            string patronymic = "pa";
            DateTime registrationDateTime =
                new DateTime(2020, 4, 15, 10, 0, 0);

            var bb = GetBusinessBook();
            bb.AddClient(
                id, firstName, surName, patronymic, registrationDateTime
            );
            var client = bb.GetClient(id);
            Assert.AreEqual(id, client.Id);
            Assert.AreEqual(firstName, client.FirstName);
            Assert.AreEqual(surName, client.SurName);
            Assert.AreEqual(patronymic, client.Patronymic);
            Assert.AreEqual(registrationDateTime, client.RegistrationDateTime);
            Assert.AreEqual(0, client.Balance);
            Assert.AreEqual(0, client.StudentsCount);
            Assert.AreEqual(0, client.PaymentsCount);
        }
        [TestMethod]
        public void RemoveClientTest()
        {
            long id = 1;
            string firstName = "fn";
            string surName = "sn";
            string patronymic = "pa";
            DateTime registrationDateTime =
                new DateTime(2020, 4, 15, 10, 0, 0);

            var bb = GetBusinessBook();
            bb.AddClient(
                id, firstName, surName, patronymic, registrationDateTime
            );
            bb.RemoveClient(id);
            Assert.AreEqual(0, bb.ClientsCount);
            Assert.ThrowsException<ArgumentException>(
                () => bb.GetClient(id)
            );
        }
        [TestMethod]
        public void SafeRemoveClientTest()
        {
            long sId = 1;
            string sFirstName = "sfn";
            string sSurName = "ssn";
            string sPatronymic = "spa";
            DateTime sRegistrationDateTime =
                new DateTime(2020, 4, 15, 10, 0, 0);

            long cId = 1;
            string cFirstName = "fn";
            string cSurName = "sn";
            string cPatronymic = "pa";
            DateTime cRegistrationDateTime =
                new DateTime(2020, 3, 15, 10, 0, 0);

            var bb = GetBusinessBook();
            bb.AddClient(
                cId, cFirstName, cSurName, cPatronymic, cRegistrationDateTime
            );
            bb.AddStudent(
                sId,
                sFirstName,
                sSurName,
                sPatronymic,
                sRegistrationDateTime,
                cId
            );
            Assert.ThrowsException<InvalidOperationException>(
                () => bb.RemoveClient(cId)
            );
        }

        [TestMethod]
        public void AddStudentTest()
        {
            long sId = 1;
            string sFirstName = "sfn";
            string sSurName = "ssn";
            string sPatronymic = "spa";
            DateTime sRegistrationDateTime =
                new DateTime(2020, 4, 15, 10, 0, 0);

            long cId = 1;
            string cFirstName = "fn";
            string cSurName = "sn";
            string cPatronymic = "pa";
            DateTime cRegistrationDateTime =
                new DateTime(2020, 3, 15, 10, 0, 0);

            var bb = GetBusinessBook();
            Assert.ThrowsException<ArgumentException>(
                () => bb.AddStudent(
                    sId,
                    sFirstName,
                    sSurName,
                    sPatronymic,
                    sRegistrationDateTime,
                    cId
                )
            );

            bb.AddClient(
                cId, cFirstName, cSurName, cPatronymic, cRegistrationDateTime
            );

            Assert.AreEqual(0, bb.StudentsCount);
            bb.AddStudent(
                sId, 
                sFirstName,
                sSurName,
                sPatronymic,
                sRegistrationDateTime,
                cId
            );
            Assert.AreEqual(1, bb.StudentsCount);
        }
        [TestMethod]
        public void GetStudentTest()
        {
            long sId = 1;
            string sFirstName = "sfn";
            string sSurName = "ssn";
            string sPatronymic = "spa";
            DateTime sRegistrationDateTime =
                new DateTime(2020, 4, 15, 10, 0, 0);

            long cId = 1;
            string cFirstName = "fn";
            string cSurName = "sn";
            string cPatronymic = "pa";
            DateTime cRegistrationDateTime =
                new DateTime(2020, 3, 15, 10, 0, 0);

            var bb = GetBusinessBook();
            bb.AddClient(
                cId, cFirstName, cSurName, cPatronymic, cRegistrationDateTime
            );
            bb.AddStudent(
                sId,
                sFirstName,
                sSurName,
                sPatronymic,
                sRegistrationDateTime,
                cId
            );

            var student = bb.GetStudent(sId);
            Assert.AreEqual(sId, student.Id);
            Assert.AreEqual(sFirstName, student.FirstName);
            Assert.AreEqual(sSurName, student.SurName);
            Assert.AreEqual(sPatronymic, student.Patronymic);
            Assert.AreEqual(sRegistrationDateTime, student.RegistrationDateTime);
            Assert.AreEqual(cId, student.Client.Id);
            Assert.AreSame(bb.GetClient(cId), student.Client);
        }
        [TestMethod]
        public void RemoveStudentTest()
        {
            long sId = 1;
            string sFirstName = "sfn";
            string sSurName = "ssn";
            string sPatronymic = "spa";
            DateTime sRegistrationDateTime =
                new DateTime(2020, 4, 15, 10, 0, 0);

            long cId = 1;
            string cFirstName = "fn";
            string cSurName = "sn";
            string cPatronymic = "pa";
            DateTime cRegistrationDateTime =
                new DateTime(2020, 3, 15, 10, 0, 0);

            var bb = GetBusinessBook();
            bb.AddClient(
                cId, cFirstName, cSurName, cPatronymic, cRegistrationDateTime
            );
            bb.AddStudent(
                sId,
                sFirstName,
                sSurName,
                sPatronymic,
                sRegistrationDateTime,
                cId
            );
            bb.RemoveStudent(sId);
            Assert.AreEqual(0, bb.StudentsCount);
        }

        [TestMethod]
        public void AddPaymentTest()
        {
            long cId = 1;
            string cFirstName = "fn";
            string cSurName = "sn";
            string cPatronymic = "pa";
            DateTime cRegistrationDateTime =
                new DateTime(2020, 3, 15, 10, 0, 0);

            long pId = 1;
            long pAmount = 100000;
            PaymentDocumentType pDocType = PaymentDocumentType.PaymentOrder;
            string pDocId = "i-12";
            DateTime pDateTime =
                new DateTime(2020, 5, 10, 12, 31, 0);

            var bb = GetBusinessBook();
            Assert.AreEqual(0, bb.PaymentsCount);
            Assert.ThrowsException<ArgumentException>(
                () => bb.AddPayment(pId, pAmount, pDocType, pDocId, cId)
            );

            bb.AddClient(
                cId, cFirstName, cSurName, cPatronymic, cRegistrationDateTime
            );
            bb.AddPayment(pId, pAmount, pDocType, pDocId, cId);
            Assert.AreEqual(1, bb.PaymentsCount);
        }
        [TestMethod]
        public void AddNegativePaymentTest()
        {
            long cId = 1;
            string cFirstName = "fn";
            string cSurName = "sn";
            string cPatronymic = "pa";
            DateTime cRegistrationDateTime =
                new DateTime(2020, 3, 15, 10, 0, 0);

            long pId = 1;
            long pAmount = -100000;
            PaymentDocumentType pDocType = PaymentDocumentType.PaymentOrder;
            string pDocId = "i-12";
            DateTime pDateTime =
                new DateTime(2020, 5, 10, 12, 31, 0);

            var bb = GetBusinessBook();
            bb.AddClient(
                cId, cFirstName, cSurName, cPatronymic, cRegistrationDateTime
            );
            
            Assert.ThrowsException<ArgumentException>(
                () => bb.AddPayment(pId, pAmount, pDocType, pDocId, cId)
            );
        }
        [TestMethod]
        public void GetPaymentTest()
        {
            long cId = 1;
            string cFirstName = "fn";
            string cSurName = "sn";
            string cPatronymic = "pa";
            DateTime cRegistrationDateTime =
                new DateTime(2020, 3, 15, 10, 0, 0);

            long pId = 1;
            long pAmount = 100000;
            PaymentDocumentType pDocType = PaymentDocumentType.PaymentOrder;
            string pDocId = "i-12";
            DateTime pDateTime =
                new DateTime(2020, 5, 10, 12, 31, 0);

            var bb = GetBusinessBook();
            bb.AddClient(
                cId, cFirstName, cSurName, cPatronymic, cRegistrationDateTime
            );
            bb.AddPayment(pId, pAmount, pDocType, pDocId, cId);
            var payment = bb.GetPayment(pId);
            var client = bb.GetClient(cId);
            Assert.AreEqual(pId, payment.Id);
            Assert.AreEqual(pDateTime, payment.DateTime);
            Assert.AreEqual(pAmount, payment.Amount);
            Assert.AreEqual(pDocType, payment.DocumentType);
            Assert.AreEqual(pDocId, payment.DocumentId);
            Assert.AreSame(client, payment.Client);
            Assert.AreEqual(pAmount, client.Balance);
        }
        [TestMethod]
        public void RemovePaymentTest()
        {
            long cId = 1;
            string cFirstName = "fn";
            string cSurName = "sn";
            string cPatronymic = "pa";
            DateTime cRegistrationDateTime =
                new DateTime(2020, 3, 15, 10, 0, 0);

            long pId = 1;
            long pAmount = 100000;
            PaymentDocumentType pDocType = PaymentDocumentType.PaymentOrder;
            string pDocId = "i-12";
            DateTime pDateTime =
                new DateTime(2020, 5, 10, 12, 31, 0);

            var bb = GetBusinessBook();
            bb.AddClient(
                cId, cFirstName, cSurName, cPatronymic, cRegistrationDateTime
            );
            bb.AddPayment(pId, pAmount, pDocType, pDocId, cId);
            bb.RemovePayment(pId);

            var client = bb.GetClient(cId);
            Assert.AreEqual(0, client.Balance);
            Assert.AreEqual(0, bb.PaymentsCount);
            Assert.ThrowsException<ArgumentException>(
                () => bb.GetPayment(pId)
            );
        }

        [TestMethod]
        public void AddOrderTest()
        {
            long oId = 1;
            string oName = "oName";
            string oDescr = "oDescr";
            DateTime oCreation = new DateTime(2020, 10, 15, 10, 0, 0);
            long oStandartLength = 90;

            var bb = GetBusinessBook();

            Assert.AreEqual(0, bb.OrdersCount);
            Assert.ThrowsException<ArgumentException>(
                () => bb.GetOrder(oId)
            );
            bb.AddOrder(oId, oName, oDescr, oCreation, oStandartLength);
            Assert.AreEqual(1, bb.OrdersCount);
        }
        [TestMethod]
        public void AddOrderNegativeLengthTest()
        {
            long oId = 1;
            string oName = "oName";
            string oDescr = "oDescr";
            DateTime oCreation = new DateTime(2020, 10, 15, 10, 0, 0);
            long oStandartLength = -90;

            var bb = GetBusinessBook();

            Assert.ThrowsException<ArgumentException>(
                () => bb.AddOrder(oId, oName, oDescr, oCreation, oStandartLength)
            );
        }
        [TestMethod]
        public void GetOrderTest()
        {
            long oId = 1;
            string oName = "oName";
            string oDescr = "oDescr";
            DateTime oCreation = new DateTime(2020, 10, 15, 10, 0, 0);
            long oStandartLength = 90;

            var bb = GetBusinessBook();
            bb.AddOrder(oId, oName, oDescr, oCreation, oStandartLength);

            var order = bb.GetOrder(oId);
            Assert.AreEqual(oId, order.Id);
            Assert.AreEqual(oName, order.Name);
            Assert.AreEqual(oDescr, order.Description);
            Assert.AreEqual(oCreation, order.CreationDateTime);
            Assert.AreEqual(oStandartLength, order.StandartLength);
            Assert.AreEqual(0, order.StudentsCount);
        }
        [TestMethod]
        public void RemoveOrderTest()
        {
            long oId = 1;
            string oName = "oName";
            string oDescr = "oDescr";
            DateTime oCreation = new DateTime(2020, 10, 15, 10, 0, 0);
            long oStandartLength = 90;

            var bb = GetBusinessBook();
            bb.AddOrder(oId, oName, oDescr, oCreation, oStandartLength);
            bb.RemoveOrder(oId);

            Assert.ThrowsException<ArgumentException>(
                () => bb.GetOrder(oId)
            );
            Assert.AreEqual(0, bb.OrdersCount);
        }
        [TestMethod]
        public void SafeRemoveOrderTest()
        {
            long oId = 1;
            string oName = "oName";
            string oDescr = "oDescr";
            DateTime oCreation = new DateTime(2020, 10, 15, 10, 0, 0);
            long oStandartLength = 90;

            long lId = 1;
            DateTime lDateTime = new DateTime(2020, 10, 16, 10, 0, 0);
            long lLength = 90;

            const string ENVIRONMENT_NAME = "env_1";
            CoreFacade co = new CoreFacade();
            co.CreateEnvironment(ENVIRONMENT_NAME);
            var bb = co.GetBusinessBook(ENVIRONMENT_NAME);
            var s = co.GetSchedule(ENVIRONMENT_NAME);

            bb.AddOrder(oId, oName, oDescr, oCreation, oStandartLength);
            s.AddLesson(lId, lDateTime, lLength, oId);
            Assert.ThrowsException<InvalidOperationException>(
                () => bb.RemoveOrder(oId)
            );
            s.RemoveLesson(lId);
            bb.RemoveOrder(oId);
            Assert.AreEqual(0, bb.OrdersCount);
        }
        [TestMethod]
        public void AttachStudentToOrderTest()
        {
            long oId = 1;
            string oName = "oName";
            string oDescr = "oDescr";
            DateTime oCreation = new DateTime(2020, 10, 15, 10, 0, 0);
            long oStandartLength = 90;

            long cId = 1;
            string cFirstName = "fn";
            string cSurName = "sn";
            string cPatronymic = "pa";
            DateTime cRegistrationDateTime =
                new DateTime(2020, 3, 15, 10, 0, 0);

            long sId = 1;
            string sFirstName = "sfn";
            string sSurName = "ssn";
            string sPatronymic = "spa";
            DateTime sRegistrationDateTime =
                new DateTime(2020, 11, 15, 10, 0, 0);

            long cost = 100000;

            var bb = GetBusinessBook();
            bb.AddOrder(oId, oName, oDescr, oCreation, oStandartLength);
            bb.AddClient(
                cId, cFirstName, cSurName, cPatronymic, cRegistrationDateTime
            );
            bb.AddStudent(
                sId,
                sFirstName,
                sSurName,
                sPatronymic,
                sRegistrationDateTime,
                cId
            );

            var order = bb.GetOrder(oId);
            var student = bb.GetStudent(sId);
            Assert.AreEqual(0, order.StudentsCount);
            bb.AttachStudentToOrder(oId, sId, cost);
            Assert.AreEqual(1, order.StudentsCount);
            int i = 0;
            foreach(var st in order.Students)
            {
                Assert.AreSame(student, st);
                ++i;
            }
            Assert.AreEqual(1, i);
        }
        [TestMethod]
        public void DetachStudentFromTest()
        {
            long oId = 1;
            string oName = "oName";
            string oDescr = "oDescr";
            DateTime oCreation = new DateTime(2020, 10, 15, 10, 0, 0);
            long oStandartLength = 90;

            long cId = 1;
            string cFirstName = "fn";
            string cSurName = "sn";
            string cPatronymic = "pa";
            DateTime cRegistrationDateTime =
                new DateTime(2020, 3, 15, 10, 0, 0);

            long sId = 1;
            string sFirstName = "sfn";
            string sSurName = "ssn";
            string sPatronymic = "spa";
            DateTime sRegistrationDateTime =
                new DateTime(2020, 11, 15, 10, 0, 0);

            long cost = 100000;

            var bb = GetBusinessBook();
            bb.AddOrder(oId, oName, oDescr, oCreation, oStandartLength);
            bb.AddClient(
                cId, cFirstName, cSurName, cPatronymic, cRegistrationDateTime
            );
            bb.AddStudent(
                sId,
                sFirstName,
                sSurName,
                sPatronymic,
                sRegistrationDateTime,
                cId
            );

            var order = bb.GetOrder(oId);
            var student = bb.GetStudent(sId);
            bb.AttachStudentToOrder(oId, sId, cost);
            bb.DetachStudentFromOrder(oId, sId);
            Assert.AreEqual(0, order.StudentsCount);
            int i = 0;
            foreach (var st in order.Students) ++i;

            Assert.AreEqual(0, i);
        }
        [TestMethod]
        public void GetCostForTest()
        {
            long oId = 1;
            string oName = "oName";
            string oDescr = "oDescr";
            DateTime oCreation = new DateTime(2020, 10, 15, 10, 0, 0);
            long oStandartLength = 90;

            long cId = 1;
            string cFirstName = "fn";
            string cSurName = "sn";
            string cPatronymic = "pa";
            DateTime cRegistrationDateTime =
                new DateTime(2020, 3, 15, 10, 0, 0);

            long sId = 1;
            string sFirstName = "sfn";
            string sSurName = "ssn";
            string sPatronymic = "spa";
            DateTime sRegistrationDateTime =
                new DateTime(2020, 11, 15, 10, 0, 0);

            long cost = 100000;

            var bb = GetBusinessBook();
            bb.AddOrder(oId, oName, oDescr, oCreation, oStandartLength);
            bb.AddClient(
                cId, cFirstName, cSurName, cPatronymic, cRegistrationDateTime
            );
            bb.AddStudent(
                sId,
                sFirstName,
                sSurName,
                sPatronymic,
                sRegistrationDateTime,
                cId
            );

            bb.AttachStudentToOrder(oId, sId, cost);
            Assert.AreEqual(cost, bb.GetCostFor(oId, sId));
            bb.DetachStudentFromOrder(oId, sId);
            Assert.ThrowsException<ArgumentException>(
                () => bb.GetCostFor(oId, sId)
            );
        }

        private IBusinessBook GetBusinessBook()
        {
            const string ENVIRONMENT_NAME = "env_1";
            CoreFacade co = new CoreFacade();
            co.CreateEnvironment(ENVIRONMENT_NAME);
            return co.GetBusinessBook(ENVIRONMENT_NAME);
        }
    }
}
