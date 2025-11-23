namespace SampleCleanArchitecture.Dto.Responses
{
    public abstract class ApiBaseResponse 
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        protected ApiBaseResponse(bool success) => Success = success;
        public List<string>? ValidationErrors { get; set; }
    }
}
