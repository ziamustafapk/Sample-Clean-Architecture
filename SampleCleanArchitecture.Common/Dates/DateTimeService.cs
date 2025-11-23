namespace SampleCleanArchitecture.Common.Dates
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetDate()
        {
            return DateTime.UtcNow;
        }
    }
}
