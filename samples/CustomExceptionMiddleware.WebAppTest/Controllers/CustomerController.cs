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
        public IActionResult GetDomain([FromQuery] bool returnCustomer = false)
        {
            var result = _customerService.GetDomainException(returnCustomer);
            return Ok(result);
        }

        [HttpGet("cannot-access")]
        public IActionResult GetCannotAccess([FromQuery] bool returnCustomer = false)
        {
            var result = _customerService.GetCannotAccessException(returnCustomer);
            return Ok(result);
        }

        [HttpGet("not-found")]
        public IActionResult GetNotFound([FromQuery] bool returnCustomer = false)
        {
            var result = _customerService.GetNotFoundException(returnCustomer);
            return Ok(result);
        }
        
        [HttpGet("unauthorized")]
        public IActionResult GetUnauthorized([FromQuery] bool returnCustomer = false)
        {
            var result = _customerService.GetUnauthorizedException(returnCustomer);
            return Ok(result);
        }

        [HttpGet("exception")]
        public IActionResult GetException([FromQuery] bool returnCustomer = false)
        {
            var result = _customerService.GetException(returnCustomer);
            return Ok(result);
        }
    }
}

