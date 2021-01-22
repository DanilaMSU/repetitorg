using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RepetitorgCore;

namespace RepetitorgCoreTest
{
    [TestClass]
    public class ScheduleTest
    {
        const string ENVIRONMENT_ID = "env_1";
        string[] TASK_NAMES = { "task_1", "task_2" };
        string[] TASK_DESCRIPTIONS = { "deskr_1", "deskr_2" };
        long[] IDS = { 1, 2 };
        static DateTime[] DATE_TIMES = {
            new DateTime(2020, 12, 7, 1, 2, 3),
            new DateTime(2019, 11, 9, 3, 2, 1) 
        };

        private ISchedule GetEmptySchedule()
        {            
            CoreFacade cf = new CoreFacade();
            cf.CreateEnvironment(ENVIRONMENT_ID);
            return cf.GetSchedule(ENVIRONMENT_ID);
        }
        private void AddTask(ISchedule s, int index)
        {
            s.AddTask(
                IDS[index],
                TASK_NAMES[index],
                TASK_DESCRIPTIONS[index],
                DATE_TIMES[index]
            );
        }

        [TestMethod]
        public void CreationTest()
        {
            Assert.IsNotNull(GetEmptySchedule());
        }

        [TestMethod]
        public void AddTask_Enumerable()
        {
            var s = GetEmptySchedule();
            AddTask(s, 0);
            int i = 0;
            foreach(var task in s.Tasks)
            {
                Assert.AreEqual(IDS[i], task.Id);
                Assert.AreEqual(TASK_NAMES[i], task.Name);
                Assert.AreEqual(TASK_DESCRIPTIONS[i], task.Description);
                Assert.AreEqual(DATE_TIMES[i], task.DateTime);

                ++i;
            }
        }
        [TestMethod]
        public void AddTasks_Enumerable()
        {
            var s = GetEmptySchedule();
            AddTask(s, 0);
            AddTask(s, 1);
            int i = 0;
            foreach (var task in s.Tasks)
            {
                Assert.AreEqual(IDS[i], task.Id);
                Assert.AreEqual(TASK_NAMES[i], task.Name);
                Assert.AreEqual(TASK_DESCRIPTIONS[i], task.Description);
                Assert.AreEqual(DATE_TIMES[i], task.DateTime);

                ++i;
            }
        }
        [TestMethod]
        public void AddTask_Get()
        {
            var s = GetEmptySchedule();
            AddTask(s, 0);

            var task = s.GetTask(0);

            Assert.AreEqual(IDS[0], task.Id);
            Assert.AreEqual(TASK_NAMES[0], task.Name);
            Assert.AreEqual(TASK_DESCRIPTIONS[0], task.Description);
            Assert.AreEqual(DATE_TIMES[0], task.DateTime);
        }
        [TestMethod]
        public void AddTasks_Get()
        {
            var s = GetEmptySchedule();
            AddTask(s, 0);

            var task0 = s.GetTask(0);
            var task1 = s.GetTask(1);

            Assert.AreEqual(IDS[0], task0.Id);
            Assert.AreEqual(TASK_NAMES[0], task0.Name);
            Assert.AreEqual(TASK_DESCRIPTIONS[0], task0.Description);
            Assert.AreEqual(DATE_TIMES[0], task0.DateTime);

            Assert.AreEqual(IDS[1], task1.Id);
            Assert.AreEqual(TASK_NAMES[1], task1.Name);
            Assert.AreEqual(TASK_DESCRIPTIONS[1], task1.Description);
            Assert.AreEqual(DATE_TIMES[1], task1.DateTime);
        }
        [TestMethod]
        public void AddTask_GetStatus()
        {
            var s = GetEmptySchedule();
            AddTask(s, 0);

            var task0 = s.GetTask(0);
            Assert.AreEqual(task0.Status, ScheduleUnitStatus.InProgress);
        }
        [TestMethod]
        public void GetNotExist()
        {
            var s = GetEmptySchedule();
            Assert.ThrowsException<ArgumentException>(() => s.GetTask(0));
            AddTask(s, 0);
            Assert.ThrowsException<ArgumentException>(() => s.GetTask(1));

            var task = s.GetTask(0);
            Assert.AreEqual(IDS[0], task.Id);
            Assert.AreEqual(TASK_NAMES[0], task.Name);
            Assert.AreEqual(TASK_DESCRIPTIONS[0], task.Description);
            Assert.AreEqual(DATE_TIMES[0], task.DateTime);
        }
        [TestMethod]
        public void AddTask_Remove_Enumerable()
        {
            var s = GetEmptySchedule();
            AddTask(s, 0);

            s.RemoveTask(0);

            int cnt = 0;
            foreach (var task in s.Tasks) ++cnt;

            Assert.AreEqual(cnt, 0);
        }
        [TestMethod]
        public void AddTasks_Remove_Enumerable()
        {
            var s = GetEmptySchedule();
            AddTask(s, 0);
            AddTask(s, 1);

            s.RemoveTask(0);

            int cnt = 0;
            foreach (var task in s.Tasks) // 1 times
            {
                Assert.AreEqual(IDS[1], task.Id);
                Assert.AreEqual(TASK_NAMES[1], task.Name);
                Assert.AreEqual(TASK_DESCRIPTIONS[1], task.Description);
                Assert.AreEqual(DATE_TIMES[1], task.DateTime);

                ++cnt; 
            }

            Assert.AreEqual(cnt, 1);
        }
        [TestMethod]
        public void AddTask_Remove_Get()
        { }
        [TestMethod]
        public void AddTasks_Link()
        { }
        [TestMethod]
        public void AddTask_Cancel_GetStatus()
        { }
        [TestMethod]
        public void AddTasks_Link_Cancel_GetStatus()
        { }
        [TestMethod]
        public void AddTask_Cancel_Resume_GetStatus()
        { }
        [TestMethod]
        public void AddTasks_Link_Cancel_Resume_GetStatus()
        { }
        [TestMethod]
        public void AddTask_Complete_GetStatus()
        { }
        [TestMethod]
        public void AddTasks_Link_Complete_GetStatus()
        { }
        [TestMethod]
        public void AddTask_Complete_Resume_GetStatus()
        { }
        [TestMethod]
        public void AddTasks_Link_Complete_Resume_GetStatus()
        { }
        [TestMethod]
        public void AddTask_Postpone_GetStatus()
        { }
    }
}
