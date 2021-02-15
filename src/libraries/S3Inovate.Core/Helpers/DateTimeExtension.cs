using System;
namespace S3Inovate.Core.Helpers
{
    public static class DateTimeExtension
    {
        public static DateTime ToEndOfTheDate(this DateTime args)
            => new DateTime(args.Year, args.Month, args.Day, 23, 59, 59);
    }
}
