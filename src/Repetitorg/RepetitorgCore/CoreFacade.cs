using System;
using System.Collections.Generic;
using System.Text;

namespace RepetitorgCore
{
    public class CoreFacade
    {
        public void CreateEnvironment(string environmentId)
        {
            if (schedules.ContainsKey(environmentId) || businessBooks.ContainsKey(environmentId))
                throw new InvalidOperationException("Environment with \"" + environmentId + "\" id already initialized");

            schedules.Add(environmentId, CreateSchedule());
            businessBooks.Add(environmentId, CreateBusinessBook());
        }
        public ISchedule GetSchedule(string environmentId)
        {
            if (!schedules.ContainsKey(environmentId))
                throw new InvalidOperationException("Schedule isn't created. You need call Initialize() with \"" + environmentId + "\" before GetSchedule()");
            return schedules[environmentId];
        }
        public IBusinessBook GetBusinessBook(string environmentId)
        {
            if (!businessBooks.ContainsKey(environmentId))
                throw new InvalidOperationException("BusinessBook isn't created. You need call Initialize() with \"" + environmentId + "\" before GetBusinessBook()");
            return businessBooks[environmentId];
        }


        private ISchedule CreateSchedule()
        {
            return new Schedule();
        }
        private IBusinessBook CreateBusinessBook()
        {
            return new BusinessBook();
        }


        public CoreFacade()
        {
            schedules = new Dictionary<string, ISchedule>();
            businessBooks = new Dictionary<string, IBusinessBook>();
        }


        private Dictionary<string, ISchedule> schedules;
        private Dictionary<string, IBusinessBook> businessBooks;
    }
}
