using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RepetitorgCore;

namespace RepetitorgCoreTest
{
    [TestClass]
    public class ScheduleTest
    {
        [TestMethod]
        public void CreationTest()
        {
            const string ENVIRONMENT_ID = "env_1";
            CoreFacade cf = new CoreFacade();
            cf.CreateEnvironment(ENVIRONMENT_ID);

            Assert.IsNotNull(cf.GetSchedule(ENVIRONMENT_ID));
        }

        [TestMethod]
        public void AddTask_Enumerable()
        { }
        [TestMethod]
        public void AddTask_Get()
        { }
        [TestMethod]
        public void AddTask_Remove_Enumerable()
        { }
        [TestMethod]
        public void AddTask_Remove_Get()
        { }
    }
}
