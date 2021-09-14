namespace CustomExceptionMiddleware
{
    public class CustomErrorResponse
    {
        public CustomError Error { get; set; }
        public string Type { get; set; }
    }

    public class CustomError
    {
        public string Msg { get; set; }
    }
}
