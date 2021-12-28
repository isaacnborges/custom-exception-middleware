namespace CustomExceptionMiddleware.Responses
{
    public class CustomErrorResponse
    {
        /// <summary>
        /// Exception type to identificate what error was throw
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// CustomError property
        /// </summary>
        public CustomError Error { get; set; }

        /// <summary>
        /// Create an empty CustomErrorResponse
        /// </summary>
        public CustomErrorResponse()
        { }

        /// <summary>
        /// Create a CustomErrorResponse with type and CustomError
        /// </summary>
        /// <param name="type">Exception type to identificate what error was throw</param>
        /// <param name="error">CustomError property</param>
        public CustomErrorResponse(string type, CustomError error)
        {
            Type = type;
            Error = error;
        }
    }

    public class CustomError
    {
        /// <summary>
        /// Error message
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// Create an empty CustomError
        /// </summary>
        public CustomError()
        { }

        /// <summary>
        /// Create a CustomError with message
        /// </summary>
        /// <param name="msg"></param>
        public CustomError(string msg)
        {
            Msg = msg;
        }
    }
}
