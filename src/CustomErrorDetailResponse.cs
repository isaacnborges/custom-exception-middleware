namespace CustomExceptionMiddleware
{
    public class CustomErrorDetailResponse
    {
        public string Type { get; set; }
        public CustomErrorDetail Error { get; set; }

        public CustomErrorDetailResponse()
        { }

        public CustomErrorDetailResponse(string type, CustomErrorDetail error)
        {
            Type = type;
            Error = error;
        }
    }

    public class CustomErrorDetail
    {
        public string Msg { get; set; }
        public string Detail { get; set; }

        public CustomErrorDetail()
        { }

        public CustomErrorDetail(string msg, string detail)
        {
            Msg = msg;
            Detail = detail;
        }
    }
}
