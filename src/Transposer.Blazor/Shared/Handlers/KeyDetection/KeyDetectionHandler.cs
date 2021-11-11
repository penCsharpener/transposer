using MediatR;
using Transposer.Blazor.Shared.Models.Enums;
using TransposerService = Transposer.SmartChord.Transposer.Transposer;

namespace Transposer.Blazor.Shared.Handlers.KeyDetection;

public class KeyDetectionHandler : IRequestHandler<KeyDetectionRequest, KeyDetectionResponse>
{
    private readonly TransposerService _transposer;

    public KeyDetectionHandler(TransposerService transposer)
    {
        _transposer = transposer;
    }

    public async Task<KeyDetectionResponse> Handle(KeyDetectionRequest request, CancellationToken cancellationToken)
    {
        var response = new KeyDetectionResponse();

        try
        {
            response.DetectedKey = (Keys)_transposer.ResolveSongKey(request.OriginalSongText);
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
        }

        return response;
    }
}
