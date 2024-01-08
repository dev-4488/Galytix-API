using GalytixAPI.Models;

namespace GalytixAPI.Services
{
    public interface ICsvReaderService
    {
        List<CsvDataModel> ReadCsvFile();
    }
}