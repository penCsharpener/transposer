using MediatR;

namespace Transposer.Blazor.Shared.Handlers.KeyDetection;

public class KeyDetectionRequest : IRequest<KeyDetectionResponse>
{
    public string OriginalSongText { get; set; }

    public KeyDetectionRequest(string originalSongText)
    {
        OriginalSongText = originalSongText;
    }
}
