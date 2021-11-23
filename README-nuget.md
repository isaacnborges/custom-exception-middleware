# Custom Exception Middleware

[![Github actions status](https://github.com/isaacnborges/custom-exception-middleware/actions/workflows/dotnet-workflow.yml/badge.svg)](https://github.com/isaacnborges/custom-exception-middleware/actions/workflows/dotnet-workflow.yml)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=isaacnborges_custom-exception-middleware&metric=alert_status)](https://sonarcloud.io/dashboard?id=isaacnborges_custom-exception-middleware)
[![Nuget](https://img.shields.io/nuget/v/CustomExceptionMiddleware?label=Nuget&style=flat)](https://www.nuget.org/packages/CustomExceptionMiddleware/)

It is a middleware for error handling in [ASP.NET](https://dotnet.microsoft.com/apps/aspnet) projects, the application aims to facilitate and handle when an accidental or custom exception occurs in the project.

## Install

- ### Package Manager Console

```
Install-Package CustomExceptionMiddleware
```

- ### .Net CLI

```
dotnet add package CustomExceptionMiddleware
```

### Minimum requirements to use: [.NET Standard 2.0](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)

### Compilation requirements: [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)

## How to use

It's very simple to use, go to `Startup.cs` on `Configure()` method and add this code:

```c#
app.UseCustomExceptionMiddleware();
```

Example output    
```json
{
    "type": "VALIDATION_ERRORS",
    "error": {
        "msg": "Custom domain exception message"
    }
}
```

### Custom use
- Create object options:
It's possible create a `CustomExceptionOptions` to customize the return middleware object, to view the `StackTrace` like this:

    ```c#
    app.UseCustomExceptionMiddleware(new CustomExceptionOptions
    {
        ViewStackTrace = true
    });
    ```

- Use an action options:
Other options to customize the return object is using an action to create a `CustomErrorModel`
    ```c#
    app.UseCustomExceptionMiddleware(options =>
    {
        options.ViewStackTrace = true;
    });
    ```

In both cases the output will include de stack trace in `detail` object property:    

Example output
```json
{
    "error": {
        "msg": "Custom domain exception message",
        "detail": "at CustomExceptionMiddleware.WebAppTest.Custom.ProductService.GetDomainException(Boolean returnProducts) in C:\\isaacnborges\\projects\\custom-exception-middleware\\tests\\CustomExceptionMiddleware.WebAppTest.Custom\\ProductService.cs:line 18\r\n   at CustomExceptionMiddleware.WebAppTest.Custom.Controllers.ProductController.GetDomain(Boolean returnProduct) in C:\\isaacnborges\\projects\\custom-exception-middleware\\tests\\CustomExceptionMiddleware.WebAppTest.Custom\\Controllers\\ProductController.cs:line 26"
    },
    "type": "VALIDATION_ERRORS"
}
```

### Configure Exceptions
This middleware use some custom exceptions to catch and personalize the response status code.

The custom middleware supports the following **Exceptions**:

```
Exception              Status code description  Status code
---------------------  -----------------------  -----------
DomainException        BadRequest                  400        
CannotAccessException  Forbidden                   403        
NotFoundException      NotFound                    404        
Exception              InternalServerError         500        
```

`DomainException` is an abstract exception, so to use it's necessary create other exception and inherit. The others exceptions only throw an exception

#### Custom exception example
```c#
public class InvalidStateException : DomainException
{
    public InvalidStateException(string message) : base(message)
    { }
}
```

#### Throw exceptions
```c#
throw new InvalidStateException("Custom domain exception message");
throw new CannotAccessException("Custom cannot access exception message");
throw new NotFoundException("Custom not found exception message");
throw new Exception("Custom exception message");
```

### Sample example
Open `docs` folder, inside has a [postman](https://www.postman.com/) collection that could be used for test the sample projects with some requests and validate the middleware in use.

## Logging
This middleware will `Log` some informations that can be used for monitoring and observability, like `TraceIdentifier`, request and exception informations like message type and stack trace:

Example log:

```
Occurred an exception - TraceId: 0HMBO9LGH0JHD:00000002 - ExceptionType: InvalidStateException - Message: Custom domain exception message
CustomExceptionMiddleware.WebAppTest.InvalidStateException: Custom domain exception message
at CustomExceptionMiddleware.WebAppTest.Custom.ProductService.GetDomainException(Boolean returnProducts) in C:\\isaacnborges\\projects\\custom-exception-middleware\\tests\\CustomExceptionMiddleware.WebAppTest.Custom\\ProductService.cs:line 18\r\n   at CustomExceptionMiddleware.WebAppTest.Custom.Controllers.ProductController.GetDomain(Boolean returnProduct) in C:\\isaacnborges\\projects\\custom-exception-middleware\\tests\\CustomExceptionMiddleware.WebAppTest.Custom\\Controllers\\ProductController.cs:line 26
```

## Using custom attribute
In some scenarios the project needs other response object, integrations with 3rd party systems for example, this middleware contains an [attribute](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/) that could be ignore, it's possible use in class or methods

Using the `IgnoreCustomExceptionAttribute` attribute the middleware will ignore your own flow. To use it simply, decorate the class or method with the name.

 - Class example
    ```c#
    [IgnoreCustomException]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            throw new CustomDomainException("Some error ignore class");
        }
    ```

 - Method example
    ```c#
    [IgnoreCustomException]
    [HttpGet("ignore")]
    public IActionResult GetIgnore()
    {
        throw new CustomDomainException("Some error ignore method");
    }
    ```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://opensource.org/licenses/MIT)