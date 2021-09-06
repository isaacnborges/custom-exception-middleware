# Custom Exception Middleware

This is a custom exception middleware that handling all the exceptions or custom exceptions in your project.

## Dependencies

- [.NET Standard 2.0](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)
- [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)

## How to use

It's very simple to use, go to `Startup.cs` on Configure() method and add this code:

```c#
app.UseCustomExceptionMiddleware();
```

### Custom use
1. Create object options <br/>
It's possible create a `CustomExceptionOptions` to customize the return middleware object, to create this options add this:

    ```c#
    app.UseCustomExceptionMiddleware(new CustomExceptionOptions
    {
        CustomErrorModel = new
        {
            Success = false
            Type = "ErrorType"
        }
    });
    ```

2. Use an action options <br/>
Other options to customize the return object is using an action to create a `CustomErrorModel`
    ```c#
    app.UseCustomExceptionMiddleware(options =>
    {
        options.CustomErrorModel = new
        {
            Success = false
            Type = "ErrorType"
        };
    });
    ```