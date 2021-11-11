using MediatR;
using Transposer.SmartChord.Parser.Models;
using TransposerService = Transposer.SmartChord.Transposer.Transposer;

namespace Transposer.Blazor.Shared.Handlers.ChangeKey;

public class ChangeKeyHandler : IRequestHandler<ChangeKeyRequest, ChangeKeyResponse>
{
    private readonly TransposerService _transposer;

    public ChangeKeyHandler(TransposerService transposer)
    {
        _transposer = transposer;
    }

    public async Task<ChangeKeyResponse> Handle(ChangeKeyRequest request, CancellationToken cancellationToken)
    {
        var response = new ChangeKeyResponse();

        try
        {
            response.TransposedSongText = _transposer.ChangeKey(request.OriginalSongText, (Note)request.NewKey);
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
        }

        return response;
    }
}
