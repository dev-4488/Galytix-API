using GalytixAPI.Models;
using GalytixAPI.Repositories;
using GalytixAPI.Services;
using Moq;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;



namespace GalytixAPI.Tests.Services
{
    [TestClass]
    public class GalytixLogicTests
    {
        [TestMethod]
        public async Task GetAverageGrossWrittenPremiums_WhenCalled_ReturnsExpectedResult()
        {
            // Arrange
            var csvRepositoryMock = new Mock<ICsvRepository>();
            var gwpRequest = new GWPRequest
            {
                Country = "USA",
                Lob = new List<string> { "Auto", "Home" }
            };
            var gwpData = new List<CsvDataModel>
            {
                new CsvDataModel
                {
                    Country = "USA",
                    LineOfBusiness = "Auto",
                    YearlyData = new Dictionary<double, double>
                    {
                        { 2008, 1000 },
                        { 2009, 1500 },
                        { 2010, 2000 },
                        { 2011, 2500 },
                        { 2012, 3000 },
                        { 2013, 3500 },
                        { 2014, 4000 },
                        { 2015, 4500 }
                    }
                },
                new CsvDataModel
                {
                    Country = "USA",
                    LineOfBusiness = "Home",
                    YearlyData = new Dictionary<double, double>
                    {
                        { 2008, 2000 },
                        { 2009, 2500 },
                        { 2010, 3000 },
                        { 2011, 3500 },
                        { 2012, 4000 },
                        { 2013, 4500 },
                        { 2014, 5000 },
                        { 2015, 5500 }
                    }
                }
            };
            csvRepositoryMock.Setup(repo => repo.GetDataFromCsv()).ReturnsAsync(gwpData);
            var galytixLogic = new GalytixLogic(csvRepositoryMock.Object);

            // Act
            var result = await galytixLogic.GetAverageGrossWrittenPremiums(gwpRequest);

            // Assert
            Assert.AreEqual(2750, result["Auto"]);
            Assert.AreEqual(3750, result["Home"]);
        }
    }
}

