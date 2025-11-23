using System.Text.Json;

namespace SampleCleanArchitecture.Common.Exceptions
{
    public class ErrorModelDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
        public Dictionary<string, string>? ValidationErrors { get; set; }
        public override string ToString() =>
            JsonSerializer.Serialize(this);
    }
}
