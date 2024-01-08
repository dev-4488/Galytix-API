using CsvHelper.Configuration;

namespace GalytixAPI.Models
{
    public sealed class CsvDataModelMap : ClassMap<CsvDataModel>
    {
        public CsvDataModelMap()
        {
            Map(m => m.Country).Name("country");
            Map(m => m.VariableId).Name("variableId");
            Map(m => m.VariableName).Name("variableName");
            Map(m => m.LineOfBusiness).Name("lineOfBusiness");
        }
    }

}
