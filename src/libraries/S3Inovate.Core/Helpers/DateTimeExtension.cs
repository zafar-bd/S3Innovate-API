using System;
namespace S3Inovate.Core.Helpers
{
    public static class DateTimeExtension
    {
        public static DateTime ToEndOfTheDate(this DateTime args)
            => new DateTime(args.Year, args.Month, args.Day, 23, 59, 59);


        public static double ToUtcTimestamp(this DateTime date)
        {
            var utc = TimeSpan.FromTicks(date.Ticks).TotalMilliseconds -
            TimeSpan.FromTicks(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks).TotalMilliseconds;
            return utc;
        }
    }
}
