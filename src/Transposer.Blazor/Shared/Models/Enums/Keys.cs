using Transposer.SmartChord.Parser.Annotations;

namespace Transposer.Blazor.Shared.Models.Enums;

public enum Keys
{
    Unknown = -1,
    [Alias("A")] A,
    [Alias("Bb/A#")] ASharpBFlat,
    [Alias("B")] B,
    [Alias("C")] C,
    [Alias("C#/Db")] CSharpDFlat,
    [Alias("D")] D,
    [Alias("Eb/D#")] DSharpEFlat,
    [Alias("E")] E,
    [Alias("F")] F,
    [Alias("F#/Gb")] FSharpGFlat,
    [Alias("G")] G,
    [Alias("G#/Ab")] GSharpAFlat
}
