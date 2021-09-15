namespace CustomExceptionMiddleware
{
    public class CustomErrorResponse
    {
        public string Type { get; set; }
        public CustomError Error { get; set; }
    }

    public class CustomError
    {
        public string Msg { get; set; }

        public CustomError(string msg)
        {
            Msg = msg;
        }
    }
}
