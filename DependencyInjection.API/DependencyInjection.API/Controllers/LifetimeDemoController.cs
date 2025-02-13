using DependencyInjection.API.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LifetimeDemoController : Controller
    {
        private readonly ITimestampService _timestampService;
        private readonly IUserSessionService _userSessionService;
        private readonly IGuidGeneratorService _guidGeneratorService;
        private IRandomNumberService _randomNumberService;


        public LifetimeDemoController(ITimestampService timestampService, IUserSessionService userSessionService, IGuidGeneratorService guidGeneratorService, IRandomNumberService randomNumberService)
        {
            _timestampService = timestampService;
            _userSessionService = userSessionService;
            _guidGeneratorService = guidGeneratorService;
            _randomNumberService = randomNumberService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Timestamp = _timestampService.GetTimeStamp(),
                Session = _userSessionService.GetSessionId(),
                RandNumber = _randomNumberService.GetRandomNumber(),
                Guid = _guidGeneratorService.GenerateGuid(),
            }
                );
        }
    }
}
