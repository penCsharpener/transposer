using MediatR;
using Microsoft.AspNetCore.Components;
using Transposer.Blazor.Shared.Handlers.ChangeKey;

namespace Transposer.Blazor.Client.Pages
{
    public partial class Index
    {
        public string LyricsAndChords { get; set; } = string.Empty;
        public string Chords { get; } = "font-family: \"Courier New\", Courier, monospace !important;";

        [Inject]
        public IMediator Mediator { get; set; }

        protected async override Task OnInitializedAsync()
        {

        }

        private async Task TransposeSongAsync()
        {
            var response = await Mediator.Send(new ChangeKeyRequest(LyricsAndChords));

            LyricsAndChords = response.TransposedSongText;
        }
    }
}