using Microsoft.AspNetCore.Mvc;

namespace CustomExceptionMiddleware.WebAppTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int count = 5)
        {
            var result = _customerService.Get(count);
            return Ok(result);
        }

        [HttpGet("domain")]
        public IActionResult GetDomain()
        {
            var result = _customerService.GetDomainException();
            return Ok(result);
        }

        [HttpGet("cannot-access")]
        public IActionResult GetCannotAccess()
        {
            var result = _customerService.GetCannotAccessException();
            return Ok(result);
        }

        [HttpGet("not-found")]
        public IActionResult GetNotFound()
        {
            var result = _customerService.GetNotFoundException();
            return Ok(result);
        }

        [HttpGet("exception")]
        public IActionResult GetException()
        {
            var result = _customerService.GetException();
            return Ok(result);
        }
    }
}

