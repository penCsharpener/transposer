using Transposer.SmartChord.Parser.Annotations;

namespace Transposer.SmartChord.Parser.Models
{
    public enum Note
    {
        Unknown = -1,
        [Alias("A")] A,
        [Alias("Bb")] [Alias("A#")] ASharp,
        [Alias("B")] B,
        [Alias("C")] C,
        [Alias("C#")] [Alias("Db")] CSharp,
        [Alias("D")] D,
        [Alias("Eb")] [Alias("D#")] DSharp,
        [Alias("E")] E,
        [Alias("F")] F,
        [Alias("F#")] [Alias("Gb")] FSharp,
        [Alias("G")] G,
        [Alias("G#")] [Alias("Ab")] GSharp
    }
}
