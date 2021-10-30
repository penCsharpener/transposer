using Transposer.SmartChord.Parser.Models;

namespace Transposer.SmartChord.Transposer
{
    public class SongStat
    {
        public Note RootNote { get; set; }
        public Tone Tone { get; set; }
        public int Count { get; set; }
    }
}
