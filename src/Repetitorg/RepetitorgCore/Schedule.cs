using System;
using System.Collections.Generic;
using System.Text;

namespace RepetitorgCore
{
    class Schedule : ISchedule
    {
        public IEnumerable<ILesson> Lessons => throw new NotImplementedException();

        public int LessonsCount => throw new NotImplementedException();

        public void AddLesson(long id, DateTime dateTime, long length, long orderId)
        {
            throw new NotImplementedException();
        }

        public void CancelLesson(long id)
        {
            throw new NotImplementedException();
        }

        public void CompleteLesson(long id)
        {
            throw new NotImplementedException();
        }

        public ILesson GetLesson(long id)
        {
            throw new NotImplementedException();
        }

        public void NoteLesson(long id, string note)
        {
            throw new NotImplementedException();
        }

        public void PostponeLesson(long id, long newId, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public void RemoveLesson(long id)
        {
            throw new NotImplementedException();
        }

        public void ResumeLesson(long id)
        {
            throw new NotImplementedException();
        }
    }
}
