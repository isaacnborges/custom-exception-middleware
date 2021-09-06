namespace CustomExceptionMiddleware
{
    public class CustomErrorResponse
    {
        public string ErrorMessage { get; set; }

        public CustomErrorResponse(string message)
        {
            ErrorMessage = message;
        }
    }
}
