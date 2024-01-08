using GalytixAPI.Models;
using GalytixAPI.Repositories;

namespace GalytixAPI.Services
{
    public class GalytixLogic : IGalytixLogic
    {
        private readonly ICsvRepository _csvRepository;

        public GalytixLogic(ICsvRepository csvRepository)
        {
            _csvRepository = csvRepository;
        }

        public async Task<Dictionary<string, double>> GetAverageGrossWrittenPremiums(GWPRequest gWPRequest)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();
            var gwpData = await _csvRepository.GetDataFromCsv();

            foreach (var lob in gWPRequest.Lob)
            {
                var filteredData = gwpData.Where(x => x.Country.Equals(gWPRequest.Country, StringComparison.InvariantCultureIgnoreCase) && x.LineOfBusiness.Equals(lob, StringComparison.InvariantCultureIgnoreCase)).ToList();
                //Get Sum Premiums for 2008 to 2015
                foreach (var data in filteredData)
                {
                    var premiumPaid = data.YearlyData.Where(x => x.Key >= 2008 && x.Key <= 2015).Average(x => x.Value);
                    result.Add(lob, premiumPaid);
                }
            }

            return result;
        }
    }
}
