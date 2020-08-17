namespace Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System.IO;
    using Api.DataFiles;
    using Microsoft.Extensions.Logging;
    using System.Runtime.CompilerServices;

    [ApiController]
    public class FundsController : ControllerBase
    {
        private readonly ILogger<FundsController> _log;
        public FundsController(ILogger<FundsController> Logger)
        {
            _log = Logger;
        }


        [HttpGet("api/GetFundByMarketCode")]
        public IActionResult GetFundByMarketCode(string MarketCode)
        {
            _log.LogInformation($"[API Request] GetFundByMarketCode");

            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            var funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);

            if (!string.IsNullOrEmpty(MarketCode))
            {
                _log.LogInformation($"[API Request] GetFundByMarketCode with MarketCode == {MarketCode}");
                try
                {
                    return this.Ok(funds.Single(x => x.MarketCode == MarketCode));
                }
                catch (Exception)
                {
                    _log.LogInformation($"[API Request] GetFundByMarketCode - INVALID MARKET CODE");
                    return this.StatusCode(400);
                }
            }

            _log.LogInformation($"[API Request] GetFundByMarketCode - MISSING MARKET CODE INPUT");
            return this.StatusCode(400);
        }


        [HttpGet("api/GetFundsByFundManager")]
        public IActionResult GetFundsByFundManager(string Manager)
        {
            _log.LogInformation($"[API Request] GetFundsByFundManager ");
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            var funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);


            if (!string.IsNullOrEmpty(Manager))
            {
                _log.LogInformation($"[API Request] GetFundsByFundManager - Manager == {Manager}");
                return this.Ok(funds.Where(x => x.FundManager == Manager));
            }

            _log.LogInformation($"[API Request] GetFundsByFundManager - MISSING MANAGER INPUT");
            return this.StatusCode(400);
        }


        [HttpGet("api/GetAllFunds")]
        public IActionResult GetAllFunds()
        {
            _log.LogInformation("[API Request] GetAllFunds");
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;
            var funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);

            return this.Ok(funds);
        }

    }
}