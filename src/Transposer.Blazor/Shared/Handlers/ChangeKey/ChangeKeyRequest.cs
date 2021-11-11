using MediatR;
using Transposer.Blazor.Shared.Models.Enums;

namespace Transposer.Blazor.Shared.Handlers.ChangeKey
{
    public class ChangeKeyRequest : IRequest<ChangeKeyResponse>
    {
        public ChangeKeyRequest(string originalSongText)
        {
            OriginalSongText = originalSongText;
        }

        public ChangeKeyRequest(string originalSongText, Keys originalKey, Keys newKey)
        {
            OriginalSongText = originalSongText;
            OriginalKey = originalKey;
            NewKey = newKey;
        }

        public string OriginalSongText { get; set; }
        public Keys OriginalKey { get; set; }
        public Keys NewKey { get; set; }
    }
}
