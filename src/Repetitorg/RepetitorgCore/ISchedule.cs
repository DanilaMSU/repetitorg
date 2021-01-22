using System;
using System.Collections.Generic;
using System.Text;

namespace RepetitorgCore
{
    public interface ISchedule
    {
        IEnumerable<ITask> Tasks                 { get; }
        IEnumerable<ILesson> Lessons             { get; }
        IEnumerable<IScheduleUnit> ScheduleUnits { get; }

        void AddTask(
            long id, 
            string name,
            string description, 
            DateTime dateTime
        );
        ITask GetTask(long id);
        void CompleteTask(long id);
        void CancelTask(long id);
        void PostponeTask(long newTaskId, DateTime dateTime);
        void ResumeTask(long id);
        void RemoveTask(long id);
        void LinkTasks(long parentId, long childId);

        void AddLesson(
            long id,
            string name,
            string description,
            DateTime dateTime,
            long length,
            long orderId
        );
        ILesson GetLesson(long id);
        void CompleteLesson(long id);
        void CancelLesson(long id);
        void PostponeLesson(long newTaskId, DateTime dateTime);
        void ResumeLesson(long id);
        void RemoveLesson(long id);
    }
}
