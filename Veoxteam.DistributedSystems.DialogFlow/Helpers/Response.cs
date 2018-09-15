namespace Veoxteam.DistributedSystems.DialogFlow.Helpers
{
    public class Response<T>
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public string StackTrace { get; set; }
        public T Data { get; set; }

        public Response(T data)
        {
            Message = string.Empty;
            Status = true;
            StackTrace = string.Empty;
            Data = data;
        }

        public Response(string message, string stackTrace)
        {
            Message = string.Empty;
            Status = false;
            StackTrace = stackTrace;
            Data = default(T);
        }
    }
}
