namespace WeatherService.src.Presentation.Models
{
    public class BaseResponse<TType> : BaseResponse_Error
    {
        public int? ResultCode { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public TType Content { get; set; }
    }

    public class BaseResponse_Error
    {
        private readonly string defaultMessage = "No se pudo completar la operación.";
        public string ErrorCode { get; set; }
        public string ErrorMessageUser { get; set; }
        public string ErrorMessageSystem { get; set; }
        public string ErrorMessageUserDefault => defaultMessage;
    }
}
