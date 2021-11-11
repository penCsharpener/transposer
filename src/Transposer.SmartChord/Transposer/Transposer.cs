using Transposer.SmartChord.Parser;
using Transposer.SmartChord.Parser.Models;
using Transposer.SmartChord.Parser.Models.Elements;

namespace Transposer.SmartChord.Transposer
{
    public class Transposer
    {
        private const int NumberOfNotes = 12;
        private readonly SongParser _parser;

        public Transposer() : this(new SongParser())
        {

        }

        public Transposer(SongParser parser)
        {
            _parser = parser;
        }

        public Note ResolveSongKey(string chordsheet)
        {
            var song = _parser.ParseSong(chordsheet);
            return ResolveSongKey(song);
        }

        public Note ResolveSongKey(Song song)
        {
            var analyzer = new SongAnalyzer();
            var key = analyzer.DiscoverKeyOfSong(song);
            if (key == Note.Unknown)
            {
                throw new InvalidOperationException("Chordsheet does not contain any valid chords.");
            }
            return key;
        }

        public string ChangeKey(string chordsheet, Note destinationKey)
        {
            var song = _parser.ParseSong(chordsheet);

            return ChangeKey(song, destinationKey, ResolveSongKey(song));
        }

        public string ChangeKey(Song song, Note destinationKey, Note originalKey)
        {
            var noteDifference = destinationKey - originalKey;

            var chordElements = from line in song.Lines
                                from element in line.Elements.OfType<ChordElement>()
                                select element;

            foreach (var chordElement in chordElements)
            {
                var originalIndex = (int)chordElement.Chord.RawRootNote.ToNote();
                var newIndex = originalIndex + noteDifference;
                if (newIndex < 0)
                {
                    newIndex = NumberOfNotes + newIndex;
                }
                else if (newIndex > NumberOfNotes - 1)
                {
                    newIndex = newIndex - NumberOfNotes;

                }
                var rootNote = ((Note)newIndex).GetDisplayName();

                if (rootNote.Any())
                {
                    chordElement.Chord.SetRootNote(rootNote);
                }
            }

            return song.ToString();
        }
    }
}
