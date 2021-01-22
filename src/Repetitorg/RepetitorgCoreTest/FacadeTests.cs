using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RepetitorgCore;

namespace RepetitorgCoreTest
{
    [TestClass]
    public class FacadeTests
    {
        [TestMethod]
        public void GetFromEmpty_Create_GetAgain()
        {
            const string TEST_ENVIRONMENT_ID = "env_1";
            CoreFacade cf = new CoreFacade();

            Assert.ThrowsException<InvalidOperationException>(
                () => cf.GetSchedule(TEST_ENVIRONMENT_ID)
            );
            Assert.ThrowsException<InvalidOperationException>(
                () => cf.GetBusinessBook(TEST_ENVIRONMENT_ID)
            );

            cf.CreateEnvironment(TEST_ENVIRONMENT_ID);

            Assert.IsNotNull(
                cf.GetSchedule(TEST_ENVIRONMENT_ID)
            );
            Assert.IsNotNull(
                cf.GetBusinessBook(TEST_ENVIRONMENT_ID)
            );
        }

        [TestMethod]
        public void GetFromEmptyTwoDifferent_CreateOne_GetTwoAgain()
        {
            const string TEST_ENVIRONMENT_ID = "env_1";
            const string TEST_ENVIRONMENT_OTHER_ID = "env_2";
            CoreFacade cf = new CoreFacade();

            Assert.ThrowsException<InvalidOperationException>(
                () => cf.GetSchedule(TEST_ENVIRONMENT_ID)
            );
            Assert.ThrowsException<InvalidOperationException>(
                () => cf.GetBusinessBook(TEST_ENVIRONMENT_ID)
            );
            Assert.ThrowsException<InvalidOperationException>(
                () => cf.GetSchedule(TEST_ENVIRONMENT_OTHER_ID)
            );
            Assert.ThrowsException<InvalidOperationException>(
                () => cf.GetBusinessBook(TEST_ENVIRONMENT_OTHER_ID)
            );

            cf.CreateEnvironment(TEST_ENVIRONMENT_ID);

            Assert.IsNotNull(
                cf.GetSchedule(TEST_ENVIRONMENT_ID)
            );
            Assert.IsNotNull(
                cf.GetBusinessBook(TEST_ENVIRONMENT_ID)
            );

            Assert.ThrowsException<InvalidOperationException>(
                () => cf.GetSchedule(TEST_ENVIRONMENT_OTHER_ID)
            );
            Assert.ThrowsException<InvalidOperationException>(
                () => cf.GetBusinessBook(TEST_ENVIRONMENT_OTHER_ID)
            );
        }

        [TestMethod]
        public void CreateTwoDifferent_Get_TestDifference()
        {
            const string TEST_ENVIRONMENT_ID = "env_1";
            const string TEST_ENVIRONMENT_OTHER_ID = "env_2";
            CoreFacade cf = new CoreFacade();

            cf.CreateEnvironment(TEST_ENVIRONMENT_ID);
            cf.CreateEnvironment(TEST_ENVIRONMENT_OTHER_ID);

            Assert.IsNotNull(
                cf.GetSchedule(TEST_ENVIRONMENT_ID)
            );
            Assert.IsNotNull(
                cf.GetBusinessBook(TEST_ENVIRONMENT_ID)
            );

            Assert.IsNotNull(
                cf.GetSchedule(TEST_ENVIRONMENT_OTHER_ID)
            );
            Assert.IsNotNull(
                cf.GetBusinessBook(TEST_ENVIRONMENT_OTHER_ID)
            );

            Assert.AreNotEqual(
                cf.GetSchedule(TEST_ENVIRONMENT_ID),
                cf.GetSchedule(TEST_ENVIRONMENT_OTHER_ID)
            );
            Assert.AreNotEqual(
                cf.GetBusinessBook(TEST_ENVIRONMENT_ID),
                cf.GetBusinessBook(TEST_ENVIRONMENT_OTHER_ID)
            );
        }
    }
}
