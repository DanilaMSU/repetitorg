using System;
using System.Collections.Generic;
using System.Text;

namespace RepetitorgCore
{
    class Schedule : ISchedule
    {
        public IEnumerable<ITask> Tasks => throw new NotImplementedException();

        public IEnumerable<ILesson> Lessons => throw new NotImplementedException();

        public IEnumerable<IScheduleUnit> ScheduleUnits => throw new NotImplementedException();

        public void AddLesson(long id, string name, string description, DateTime dateTime, long length, long orderId)
        {
            throw new NotImplementedException();
        }

        public void AddTask(long id, string name, string description, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public void CancelLesson(long id)
        {
            throw new NotImplementedException();
        }

        public void CancelTask(long id)
        {
            throw new NotImplementedException();
        }

        public void CompleteLesson(long id)
        {
            throw new NotImplementedException();
        }

        public void CompleteTask(long id)
        {
            throw new NotImplementedException();
        }

        public ILesson GetLesson(long id)
        {
            throw new NotImplementedException();
        }

        public ITask GetTask(long id)
        {
            throw new NotImplementedException();
        }

        public void LinkTasks(long parentId, long childId)
        {
            throw new NotImplementedException();
        }

        public void PostponeLesson(long newTaskId, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public void PostponeTask(long newTaskId, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public void RemoveLesson(long id)
        {
            throw new NotImplementedException();
        }

        public void RemoveTask(long id)
        {
            throw new NotImplementedException();
        }

        public void ResumeLesson(long id)
        {
            throw new NotImplementedException();
        }

        public void ResumeTask(long id)
        {
            throw new NotImplementedException();
        }
    }
}
