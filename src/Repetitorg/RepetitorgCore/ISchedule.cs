using System;
using System.Collections.Generic;
using System.Text;

namespace RepetitorgCore
{
    public interface ISchedule
    {
        IEnumerable<ILesson> Lessons { get; }
        int LessonsCount { get; }

        void AddLesson(
            long id,
            DateTime dateTime,
            long length,
            long orderId
        );
        ILesson GetLesson(long id);

        void CompleteLesson(long id);
        void CancelLesson(long id);
        void PostponeLesson(long id, long newId, DateTime dateTime);
        void ResumeLesson(long id);
        void RemoveLesson(long id);
        void NoteLesson(long id, string note);
    }
}
