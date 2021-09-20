using Microsoft.AspNetCore.Mvc;

namespace CustomExceptionMiddleware.WebAppTest.Custom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int count = 5)
        {
            var result = _productService.Get(count);
            return Ok(result);
        }

        [HttpGet("domain")]
        public IActionResult GetDomain([FromQuery] bool returnProduct = false)
        {
            var result = _productService.GetDomainException(returnProduct);
            return Ok(result);
        }

        [IgnoreCustomException]
        [HttpGet("ignore")]
        public IActionResult GetIgnore()
        {
            throw new CustomDomainException("Some error ignore method");
        }
    }
}