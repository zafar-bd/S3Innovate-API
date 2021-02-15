namespace S3Inovate.Console
{
    using System;
    class Program
    {
        static readonly ushort _pulse = 20; //sec;
        static readonly ushort _offPeakRate = 20;
        static readonly ushort _peakRate = 30;
        static void Main(string[] args)
        {
            var inputStartTime = new DateTime(2019, 8, 31, 8, 59, 13);
            var inputEndTime = new DateTime(2019, 8, 31, 9, 0, 39);

            decimal billAtPaisa = CalculateBill(inputStartTime, inputEndTime);

            Console.WriteLine("=========");
            Console.WriteLine($"Total Bill: {billAtPaisa / 100} Taka");
            Console.ReadLine();
        }

        private static decimal CalculateBill(DateTime inputStartTime, DateTime inputEndTime)
        {
            Console.WriteLine("=========");
            Console.WriteLine("Break Downs");
            decimal billAtPaisa = 0;
            while (inputStartTime <= inputEndTime)
            {
                ushort callRate = CalculateCallRate(inputStartTime);
                billAtPaisa += callRate;
                Console.WriteLine($"{inputStartTime:HH:mm:ss} - {inputStartTime.AddSeconds(_pulse):HH:mm:ss} = {callRate}");
                inputStartTime = inputStartTime.AddSeconds(_pulse + 1);
            }
            return billAtPaisa;
        }

        private static ushort CalculateCallRate(DateTime duration)
        {
            var durationAddedPulse = duration.AddSeconds(_pulse);
            var pickStart = new DateTime(duration.Year, duration.Month, duration.Day, 9, 0, 0);
            var pickEnd = new DateTime(duration.Year, duration.Month, duration.Day, 22, 59, 59);
            ushort callRate;
            if ((duration >= pickStart && duration <= pickEnd)
                || (durationAddedPulse >= pickStart && durationAddedPulse <= pickEnd))
            {
                callRate = _peakRate;
            }

            callRate = _offPeakRate;
            return callRate;
        }
    }
}
