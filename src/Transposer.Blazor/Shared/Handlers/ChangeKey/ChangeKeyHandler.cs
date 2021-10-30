using MediatR;
using TransposerService = Transposer.SmartChord.Transposer.Transposer;

namespace Transposer.Blazor.Shared.Handlers.ChangeKey
{
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

            response.TransposedSongText = await _transposer.ChangeKey(request.OriginalSongText, "E");

            return response;
        }
    }
}
