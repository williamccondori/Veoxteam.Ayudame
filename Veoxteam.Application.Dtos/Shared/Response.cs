namespace Veoxteam.Application.Dtos.Shared
{
    public class Response<TData>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public TData Data { get; set; }

        public Response()
        {

        }

        public Response(TData data)
        {
            Status = true;
            Message = string.Empty;
            StackTrace = string.Empty;
            Data = data;
        }

        public Response(string message, string stackTrace)
        {
            Status = false;
            Message = message;
            StackTrace = stackTrace;
            Data = default(TData);
        }
    }
}
