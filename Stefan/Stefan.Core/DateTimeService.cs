using System;

namespace Stefan.Core
{
    public interface IDateTimeService
    {
        DateTime Get();
    }

    public class DateTimeService : IDateTimeService
    {
        public DateTime Get()
        {
            return DateTime.Now;
        }
    }
}
