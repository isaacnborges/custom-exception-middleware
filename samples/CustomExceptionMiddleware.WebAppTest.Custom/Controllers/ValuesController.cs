using Microsoft.AspNetCore.Mvc;

namespace CustomExceptionMiddleware.WebAppTest.Custom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [IgnoreCustomException]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            throw new CustomDomainException("Some message");
        }
    }
}
