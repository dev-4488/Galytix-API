using GalytixAPI.Controllers;
using GalytixAPI.Models;
using GalytixAPI.Services;
using Moq;

namespace GalytixAPI.Tests.Controllers
{
    [TestClass]
    public class CountryGwpControllerTests
    {
        private CountryGwpController _controller;
        private Mock<IGalytixLogic> _galytixLogicMock;

        [TestInitialize]
        public void Setup()
        {
            _galytixLogicMock = new Mock<IGalytixLogic>();
            _controller = new CountryGwpController(_galytixLogicMock.Object);
        }

        [TestMethod]
        public async Task GetAverageGrossWrittenPremiums_ReturnsDictionary()
        {
            // Arrange
            var request = new GWPRequest();
            var expected = new Dictionary<string, double>();

            _galytixLogicMock.Setup(x => x.GetAverageGrossWrittenPremiums(request)).ReturnsAsync(expected);

            // Act
            var result = await _controller.GetAverageGrossWrittenPremiums(request);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
