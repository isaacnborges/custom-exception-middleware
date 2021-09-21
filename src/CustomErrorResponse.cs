namespace CustomExceptionMiddleware
{
    public class CustomErrorResponse
    {
        public string Type { get; set; }
        public CustomError Error { get; set; }

        public CustomErrorResponse()
        { }

        public CustomErrorResponse(string type, CustomError error)
        {
            Type = type;
            Error = error;
        }
    }

    public class CustomError
    {
        public string Msg { get; set; }

        public CustomError()
        { }

        public CustomError(string msg)
        {
            Msg = msg;
        }
    }
}
