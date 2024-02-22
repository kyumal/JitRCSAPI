using System.Net;

namespace JitRCSAPI.Dtos
{
    public class ServiceResponse<T>
    {
        public ServiceResponse()
        {
            StatusCode = HttpStatusCode.OK;
            Success = true;
            Message = "";
        }

        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public HttpStatusCode StatusCode { get; set; }
    }
}
