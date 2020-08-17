using Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FundsApi.Tests
{
    public class ApiTests
    {
        private readonly ILogger<FundsController> _mockLogger;
        private FundsController _fundsController;

        public ApiTests()
        {
            // Arrange
            _mockLogger = new Logger<FundsController>(new NullLoggerFactory());
            _fundsController = new FundsController(_mockLogger);
        }

        // GetAllFunds

        [Fact]
        public void GetAllFunds_Success()
        {
            // Act
            var result = _fundsController.GetAllFunds() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        // GetFundByMarketCode

        [Fact]
        public void GetFundByMarketCode_Success()
        {
            // Act
            var result = _fundsController.GetFundByMarketCode("SUNT") as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetFundByMarketCode_Fail_NoMarketCodeMatch()
        {
            // Act
            var result = _fundsController.GetFundByMarketCode("SUTT") as StatusCodeResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void GetFundByMarketCode_Fail_NoMarketCode()
        {
            // Act
            var result = _fundsController.GetFundByMarketCode(null) as StatusCodeResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        // GetFundByFundManager

        [Fact]
        public void GetFundByFundManager_Success()
        {
            // Act
            var result = _fundsController.GetFundsByFundManager("Zolarex") as OkObjectResult;

            // Assert
            Assert.NotNull(result.Value);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetFundByFundManager_Fail_NoManager()
        {
            // Act
            var result = _fundsController.GetFundsByFundManager(null) as StatusCodeResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

    }
}
