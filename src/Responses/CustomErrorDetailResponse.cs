namespace CustomExceptionMiddleware.Responses
{
    public class CustomErrorDetailResponse
    {
        /// <summary>
        /// Exception type to identificate what error was throw
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// CustomErrorDetail property
        /// </summary>
        public CustomErrorDetail Error { get; set; }

        /// <summary>
        /// Create an empty CustomErrorDetailResponse
        /// </summary>
        public CustomErrorDetailResponse()
        { }

        /// <summary>
        /// Create a CustomErrorDetailResponse with type and CustomErrorDetail
        /// </summary>
        /// <param name="type"></param>
        /// <param name="error"></param>
        public CustomErrorDetailResponse(string type, CustomErrorDetail error)
        {
            Type = type;
            Error = error;
        }
    }

    public class CustomErrorDetail
    {
        /// <summary>
        /// Error message
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// StackTrace error message
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// Create an empty CustomErrorDetail
        /// </summary>
        public CustomErrorDetail()
        { }

        /// <summary>
        /// Create a CustomError with message and detail
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="detail"></param>
        public CustomErrorDetail(string msg, string detail)
        {
            Msg = msg;
            Detail = detail;
        }
    }
}
