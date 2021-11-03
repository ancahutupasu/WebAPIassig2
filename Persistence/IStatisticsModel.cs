using System.Threading.Tasks;

namespace WebAPI.Persistence
{
    public interface IStatisticsModel
    {
        Task<int> GetAdultAgeGroupAsync(int minimum, int maximum);

        Task<double> GetEyeColorPercentageAsync(string color);
    }
}