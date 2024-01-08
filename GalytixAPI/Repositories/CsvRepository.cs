using GalytixAPI.Models;
using GalytixAPI.Services;


namespace GalytixAPI.Repositories
{

    public class CsvRepository : ICsvRepository
    {
        private readonly ICsvReaderService _csvReaderService;

        public CsvRepository( ICsvReaderService csvReaderService)
        {
            _csvReaderService = csvReaderService;
        }

        public async Task<List<CsvDataModel>> GetDataFromCsv()
        {
           return await Task.FromResult(_csvReaderService.ReadCsvFile());
        }
    }

}
