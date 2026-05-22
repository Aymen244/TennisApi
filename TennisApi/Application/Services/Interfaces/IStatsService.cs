namespace TennisApi.Application.Services.Interfaces
{
    public interface IStatsService
    {
        string BestCountryByWinRatio();
        double AverageBMI();
        double MedianHeight();
    }
}
