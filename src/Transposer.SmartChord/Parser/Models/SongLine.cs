using Transposer.SmartChord.Parser.Models.Elements;

namespace Transposer.SmartChord.Parser.Models
{
    public class SongLine
    {
        public SongLine PreviousLine { get; set; }
        public SongLine NextLine { get; set; }
        public List<BaseElement> Elements { get; set; } = new List<BaseElement>();

    }
}
