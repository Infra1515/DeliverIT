using System;

namespace Tests.Mocks
{
    public class DateTimeProvider
    {
        public DateTime Now
        {
            get
            {
                return new DateTime(2018, 2, 13);
            }
        }
    }
}
