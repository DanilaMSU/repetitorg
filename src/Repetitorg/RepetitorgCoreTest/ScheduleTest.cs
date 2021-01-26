using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RepetitorgCore;
using System.Collections.Generic;

namespace RepetitorgCoreTest
{
    [TestClass]
    public class ScheduleTest
    {
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        public void AddLesson(int objCounts)
        {
            var s = GetSchedule();
            for (int i = 0; i < objCounts; ++i)
            {
                s.AddLesson(IDS[i], DATE_TIMES[i], LENGTHES[i], IDS[i]);
                Assert.AreEqual(i + 1, s.LessonsCount);

                Assert.ThrowsException<ArgumentException>(
                    () => s.AddLesson(IDS[i], DATE_TIMES[i], LENGTHES[i], IDS[i])
                );
            }
        }
        [TestMethod]
        public void AddWithIntersect()
        {
            var s = GetSchedule();
            s.AddLesson(IDS[0], INTERSECTIONS_DATE_TIMES[0], LENGTHES[4], IDS[0]);
            Assert.ThrowsException<ArgumentException>(
                () => s.AddLesson(IDS[1], INTERSECTIONS_DATE_TIMES[1], LENGTHES[4], IDS[1])
            );
        }
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        public void GetLesson(int objCounts)
        {
            var s = GetSchedule();
            for (int i = 0; i < objCounts; ++i)
                s.AddLesson(IDS[i], DATE_TIMES[i], LENGTHES[i], IDS[i]);
            for (int i = 0; i < objCounts; ++i)
            {
                Assert.AreEqual(IDS[i], s.GetLesson(IDS[i]).Id);
                Assert.AreEqual(DATE_TIMES[i], s.GetLesson(IDS[i]).DateTime);
                Assert.AreEqual(LENGTHES[i], s.GetLesson(IDS[i]).Length);
                Assert.AreEqual(IDS[i], s.GetLesson(IDS[i]).Order.Id);
                Assert.AreEqual(LessonStatus.InProgress, s.GetLesson(IDS[i]).Status);
            }
        }
        [TestMethod]
        public void CompleteLesson()
        {
            var s = GetSchedule();
            s.AddLesson(IDS[0], DATE_TIMES[0], LENGTHES[0], IDS[0]);
            var lesson = s.GetLesson(IDS[0]);
            List<long> balances = new List<long>();
            foreach (var student in lesson.Order.Students)
                balances.Add(student.Client.Balance);

            s.CompleteLesson(IDS[0]);
            Assert.AreEqual(LessonStatus.Complete, lesson.Status);
            int i = 0;
            foreach (var student in lesson.Order.Students)
            {
                var cost = lesson.Order.GetCostFor(student);
                Assert.AreEqual(balances[i] - cost * lesson.Length / lesson.Order.StandartLength, student.Client.Balance);
                ++i;
            }

        }
        [TestMethod]
        public void CancelLesson()
        {
            var s = GetSchedule();
            s.AddLesson(IDS[0], DATE_TIMES[0], LENGTHES[0], IDS[0]);
            s.AddLesson(IDS[1], DATE_TIMES[1], LENGTHES[1], IDS[1]);
            var lesson0 = s.GetLesson(IDS[0]);
            var lesson1 = s.GetLesson(IDS[1]);

            s.CompleteLesson(IDS[0]);
            Assert.ThrowsException<InvalidOperationException>(
                () => s.CancelLesson(IDS[0])
            );
            s.CancelLesson(IDS[1]);
            Assert.AreEqual(LessonStatus.Canceled, lesson1.Status);
        }
        [TestMethod]
        public void ResumeCompleteLesson()
        {
            var s = GetSchedule();
            s.AddLesson(IDS[0], DATE_TIMES[0], LENGTHES[0], IDS[0]);
            var lesson0 = s.GetLesson(IDS[0]);

            List<long> balances = new List<long>();
            foreach (var student in lesson0.Order.Students)
                balances.Add(student.Client.Balance);

            s.CompleteLesson(IDS[0]);
            s.ResumeLesson(IDS[0]);
            Assert.AreEqual(LessonStatus.InProgress, lesson0.Status);
            int i = 0;
            foreach (var student in lesson0.Order.Students)
            {
                Assert.AreEqual(balances[i], student.Client.Balance);
                ++i;
            }
        }
        [TestMethod]
        public void ResumeCancelLesson()
        {
            var s = GetSchedule();
            s.AddLesson(IDS[1], DATE_TIMES[1], LENGTHES[1], IDS[1]);
            var lesson1 = s.GetLesson(IDS[1]);

            s.CancelLesson(IDS[1]);
            s.ResumeLesson(IDS[1]);
            Assert.AreEqual(LessonStatus.InProgress, lesson1.Status);

        }
        [TestMethod]
        public void RemoveLesson()
        {
            var s = GetSchedule();
            s.AddLesson(IDS[0], DATE_TIMES[0], LENGTHES[0], IDS[0]);
            s.AddLesson(IDS[1], DATE_TIMES[1], LENGTHES[1], IDS[1]);
            s.RemoveLesson(IDS[1]);
            Assert.AreEqual(IDS[1], s.LessonsCount);
            Assert.ThrowsException<ArgumentException>(
                () => s.GetLesson(IDS[1])
            );
            Assert.IsNotNull(s.GetLesson(IDS[0]));
        }
        [TestMethod]
        public void PostponeLesson()
        {
            var s = GetSchedule();
            s.AddLesson(IDS[0], DATE_TIMES[0], LENGTHES[0], 0);
            s.AddLesson(IDS[1], DATE_TIMES[1], LENGTHES[1], 1);
            s.AddLesson(IDS[2], DATE_TIMES[2], LENGTHES[2], 2);

            s.CancelLesson(IDS[1]);
            s.CompleteLesson(IDS[2]);

            Assert.ThrowsException<ArgumentException>(
                () => s.PostponeLesson(IDS[0], IDS[1], DATE_TIMES[1])
            );
            s.PostponeLesson(IDS[0], IDS[4], DATE_TIMES[4]);
            Assert.AreEqual(4, s.LessonsCount);
            Assert.AreEqual(LessonStatus.Postponed, s.GetLesson(IDS[0]).Status);
            Assert.ThrowsException<InvalidOperationException>(
                () => s.PostponeLesson(IDS[1], IDS[5], DATE_TIMES[1])
            );
            Assert.ThrowsException<InvalidOperationException>(
                () => s.PostponeLesson(IDS[2], IDS[6], DATE_TIMES[1])
            );
        }
        [TestMethod]
        public void PostponeIntersectLesson()
        {
            var s = GetSchedule();
            s.AddLesson(IDS[0], DATE_TIMES[0], LENGTHES[4], IDS[0]);
            s.AddLesson(IDS[1], INTERSECTIONS_DATE_TIMES[0], LENGTHES[4], IDS[0]);
            Assert.ThrowsException<ArgumentException>(
                () => s.PostponeLesson(IDS[0], IDS[2], INTERSECTIONS_DATE_TIMES[1])
            );
        }
        [TestMethod]
        public void NoteLesson()
        {
            var s = GetSchedule();
            s.AddLesson(IDS[0], DATE_TIMES[0], LENGTHES[0], IDS[0]);
            s.NoteLesson(IDS[0], NOTES[0]);

            Assert.AreEqual(1, s.LessonsCount);

            Assert.AreEqual(IDS[0], s.GetLesson(IDS[0]).Id);
            Assert.AreEqual(DATE_TIMES[0], s.GetLesson(IDS[0]).DateTime);
            Assert.AreEqual(LENGTHES[0], s.GetLesson(IDS[0]).Length);
            Assert.AreEqual(IDS[0], s.GetLesson(IDS[0]).Order.Id);
            Assert.AreEqual(LessonStatus.InProgress, s.GetLesson(IDS[0]).Status);
        }


        private ISchedule GetSchedule()
        {
            CoreFacade co = new CoreFacade();
            co.CreateEnvironment(ENVIRONMENT_NAME);
            BuildBusinessBook(co.GetBusinessBook(ENVIRONMENT_NAME));
            return co.GetSchedule(ENVIRONMENT_NAME);
        }
        private void AddLesson(ISchedule s, int index)
        {
            s.AddLesson(
                IDS[index],
                DATE_TIMES[index],
                LENGTHES[index],
                IDS[index]
            );
        }
        private void BuildBusinessBook(IBusinessBook businessBook)
        {
            for (int i = 0; i < ORDER_NAMES.Length; ++i)
            {
                businessBook.AddOrder(
                    IDS[i], ORDER_NAMES[i], ORDER_DESCRIPTIONS[i], DATE_TIMES[5 + i], LENGTHES[0]
                );
            }
        }

        private const string ENVIRONMENT_NAME = "env_1";
        private static long[] IDS = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        private static long[] LENGTHES = 
            { 30 * 60, 45 * 60, 60 * 60, 90 * 60, 120 * 60 };
        private static DateTime[] DATE_TIMES = 
        {
            new DateTime(2020, 1, 10),
            new DateTime(2020, 1, 11),
            new DateTime(2020, 1, 12),
            new DateTime(2020, 1, 13),
            new DateTime(2020, 1, 14),
            new DateTime(2020, 2, 10),
            new DateTime(2020, 2, 11),
            new DateTime(2020, 2, 12),
            new DateTime(2020, 2, 13),
            new DateTime(2020, 2, 14),
            new DateTime(2020, 3, 10),
            new DateTime(2020, 3, 11),
            new DateTime(2020, 3, 12),
            new DateTime(2020, 3, 13),
            new DateTime(2020, 3, 14),
            new DateTime(2020, 4, 10),
            new DateTime(2020, 4, 11),
            new DateTime(2020, 4, 12),
            new DateTime(2020, 4, 13)
        };
        private static DateTime[] INTERSECTIONS_DATE_TIMES =
        {
            new DateTime(2020, 07, 18, 11, 0, 0),
            new DateTime(2020, 07, 18, 12, 0, 0),
            new DateTime(2020, 07, 18, 12, 30, 0),
            new DateTime(2020, 07, 18, 13, 0, 0),
            new DateTime(2020, 07, 18, 13, 10, 0),
            new DateTime(2020, 07, 18, 13, 15, 0),
            new DateTime(2020, 07, 18, 14, 0, 0)
        };
        private static string[] ORDER_NAMES =
        {
            "order_0",
            "order_1",
            "order_2",
            "order_3",
            "order_4"
        };
        private static string[] NOTES =
        {
            "note_0",
            "note_1",
            "note_2",
            "note_3",
            "note_4"
        };
        private static string[] ORDER_DESCRIPTIONS =
        {
            "descr_0",
            "descr_1",
            "descr_2",
            "descr_3",
            "descr_4"
        };
    }
}
