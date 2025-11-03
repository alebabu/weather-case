using Weather.Integration.Models;

namespace Weather.Integration.Extensions
{
    internal static class SmhiPeriodExtensions
    {
        public static string ToApiValue(this SmhiInputPeriod period) => period switch
        {
            SmhiInputPeriod.LatestHour => "latest-hour",
            SmhiInputPeriod.LatestDay => "latest-day",
            SmhiInputPeriod.LatestMonths => "latest-months",
            SmhiInputPeriod.CorrectedArchive => "corrected-archive",
            _ => throw new ArgumentOutOfRangeException(nameof(period), period, null)
        };
    }
}
