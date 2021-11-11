using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Transposer.Blazor.Shared.Handlers.ChangeKey;
using Transposer.Blazor.Shared.Handlers.KeyDetection;
using Transposer.Blazor.Shared.Models.Enums;

namespace Transposer.Blazor.Client.Pages
{
    public partial class Index
    {
        public string SongText { get; set; } = string.Empty;
        public string Chords { get; } = "font-family: \"Courier New\", Courier, monospace !important;";
        public Keys[] DetectedKeyOptions { get; set; } = Enum.GetValues<Keys>();
        public Keys SelectedSourceKeys { get; set; }
        public Keys[] TargetKeyOptions { get; set; } = Enum.GetValues<Keys>();
        public Keys SelectedTargetKeys { get; set; }

        [Inject]
        public IMediator Mediator { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        protected async override Task OnInitializedAsync()
        {
        }

        protected async Task OnSongPastedAsync()
        {
            var response = await Mediator.Send(new KeyDetectionRequest(SongText));

            SelectedSourceKeys = response.DetectedKey;

            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                Snackbar.Add(response.ErrorMessage, Severity.Error);
            }
        }

        private async Task TransposeSongAsync()
        {
            var response = await Mediator.Send(new ChangeKeyRequest(SongText));

            SongText = response.TransposedSongText;

            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                Snackbar.Add(response.ErrorMessage, Severity.Error);
            }
        }
    }
}