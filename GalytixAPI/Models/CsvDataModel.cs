namespace GalytixAPI.Models
{
    public class CsvDataModel
    {
        public string Country { get; set; }
        public string VariableId { get; set; }
        public string VariableName { get; set; }
        public string LineOfBusiness { get; set; }
        public Dictionary<double, double> YearlyData { get; set; }

        public CsvDataModel()
        {
            YearlyData = new Dictionary<double, double>();
        }
    }

}
