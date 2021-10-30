using MediatR;

namespace Transposer.Blazor.Shared.Handlers.ChangeKey
{
    public class ChangeKeyRequest : IRequest<ChangeKeyResponse>
    {
        public ChangeKeyRequest(string originalSongText)
        {
            OriginalSongText = originalSongText;
        }

        public ChangeKeyRequest(string originalSongText, string? originalKey, string? newKey)
        {
            OriginalSongText = originalSongText;
            OriginalKey = originalKey;
            NewKey = newKey;
        }

        public string OriginalSongText { get; set; }
        public string? OriginalKey { get; set; }
        public string? NewKey { get; set; }
    }
}
