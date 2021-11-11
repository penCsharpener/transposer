using Transposer.Blazor.Shared.Models.Enums;

namespace Transposer.Blazor.Shared.Handlers.KeyDetection
{
    public class KeyDetectionResponse
    {
        public Keys DetectedKey { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
