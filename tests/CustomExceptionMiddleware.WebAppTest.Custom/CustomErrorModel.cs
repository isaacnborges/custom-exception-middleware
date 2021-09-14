namespace CustomExceptionMiddleware.WebAppTest.Custom
{
    public class CustomErrorModel
    {
        public CustomError Error { get; set; }
        public string Type { get; set; }
        public string CustomValue { get; set; }
        public bool Success { get; set; }
    }

    public class CustomError
    {
        public string Msg { get; set; }
    }
}
