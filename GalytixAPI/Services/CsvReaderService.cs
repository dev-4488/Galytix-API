using System.Globalization;
using CsvHelper;
using GalytixAPI.Models;


namespace GalytixAPI.Services
{

    public class CsvReaderService : ICsvReaderService
    {
        private readonly IConfiguration _configuration;
        public CsvReaderService(IConfiguration configuration)
        {
             _configuration = configuration;
        }

        public List<CsvDataModel> ReadCsvFile()
        {
            List<CsvDataModel> records = new List<CsvDataModel>();

            try
            {
                using (var reader = new StreamReader(_configuration.GetValue<string>("CSVFilePath"))) // Change the path to the CSV file
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<CsvDataModelMap>();
                    csv.Context.Configuration.HasHeaderRecord = true;

                    while (csv.Read())
                    {
                        var record = csv.GetRecord<CsvDataModel>();
                        ProcessYearlyData(csv, record); // Process yearly data columns
                        records.Add(record);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred while reading the CSV file: {ex.Message}");
                // Log the exception or perform appropriate error handling
            }

            return records;
        }

        private void ProcessYearlyData(CsvReader csv, CsvDataModel record)
        {
            for (int i = 4; i < csv.HeaderRecord.Length; i++) // Starting from the 5th column
            {
                string yearIdentifier = csv.HeaderRecord[i];
                double year = double.Parse(yearIdentifier[1..]); // Extract the year from the column header
                if (double.TryParse(csv.GetField(yearIdentifier), out double value))
                {
                    record.YearlyData[year] = value;
                }
                else
                {
                    record.YearlyData[year] = 0;
                }
            }
        }
    }

}
