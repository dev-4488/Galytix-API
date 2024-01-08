using GalytixAPI.Models;

namespace GalytixAPI.Services
{
    public interface IGalytixLogic
    {
        Task<Dictionary<string, double>> GetAverageGrossWrittenPremiums(GWPRequest gWPRequest);
    }
}
