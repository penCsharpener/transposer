using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Transposer.Blazor.Shared.Handlers.ChangeKey;
using Transposer.Blazor.Shared.Handlers.KeyDetection;
using Transposer.Blazor.Shared.Models.Enums;

namespace Transposer.Blazor.Client.Pages;

public partial class Index
{
    public string SongText { get; set; } = string.Empty;
    public string Chords { get; } = "font-family: \"Courier New\", Courier, monospace !important;";
    public Keys[] DetectedKeyOptions { get; set; } = Enum.GetValues<Keys>();
    public Keys SelectedSourceKey { get; set; }
    public Keys[] TargetKeyOptions { get; set; } = Enum.GetValues<Keys>();
    public Keys SelectedTargetKey { get; set; }

    [Inject]
    public IMediator Mediator { get; set; } = default!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = default!;

    protected override void OnInitialized()
    {
    }

    protected async Task OnSongPastedAsync()
    {
        var response = await Mediator.Send(new KeyDetectionRequest(SongText));

        SelectedSourceKey = response.DetectedKey;

        if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
        {
            Snackbar.Add(response.ErrorMessage, Severity.Error);
        }
    }

    private async Task TransposeSongAsync()
    {
        var response = await Mediator.Send(new ChangeKeyRequest(SongText, SelectedSourceKey, SelectedTargetKey));

        SongText = response.TransposedSongText;

        if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
        {
            Snackbar.Add(response.ErrorMessage, Severity.Error);
        }
    }
}