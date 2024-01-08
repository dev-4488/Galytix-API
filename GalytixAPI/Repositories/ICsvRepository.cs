using GalytixAPI.Models;

namespace GalytixAPI.Repositories
{
    public interface ICsvRepository
    {
        Task<List<CsvDataModel>> GetDataFromCsv();
    }
}
