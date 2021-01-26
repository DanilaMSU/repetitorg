using System;
using System.Collections.Generic;
using System.Text;

namespace RepetitorgCore
{
    public interface ILesson
    {
        long         Id              { get; }
        string       Notes           { get; }
        DateTime     DateTime        { get; }
        LessonStatus Status          { get; }
        ILesson      PostponedLesson { get; }
        IOrder       Order           { get; }
        long         Length          { get; }
    }
}
