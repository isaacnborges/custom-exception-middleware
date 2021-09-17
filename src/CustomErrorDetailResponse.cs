namespace CustomExceptionMiddleware
{
    public class CustomErrorDetailResponse
    {
        public string Type { get; set; }
        public CustomErrorDetail Error { get; set; }
    }

    public class CustomErrorDetail
    {
        public string Msg { get; set; }
        public string Detail { get; set; }

        public CustomErrorDetail(string msg, string detail)
        {
            Msg = msg;
            Detail = detail;
        }
    }
}
