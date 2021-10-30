﻿using Transposer.SmartChord.Parser;
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

        public async Task<string> ResolveSongKey(string chordsheet)
        {
            var song = _parser.ParseSong(chordsheet);
            return await Task.Run(() => ResolveSongKey(song));
        }

        public async Task<string> ResolveSongKey(Song song)
        {
            var analyzer = new SongAnalyzer();
            var key = await Task.Run(() => analyzer.DiscoverKeyOfSong(song));
            if (key == Note.Unknown)
            {
                throw new InvalidOperationException("Chordsheet does not contain any valid chords.");
            }
            var originalKey = key.GetDisplayName();
            return originalKey;
        }

        public async Task<string> ChangeKey(string chordsheet, string destinationKey, string originalKey = null)
        {
            var song = _parser.ParseSong(chordsheet);

            if (string.IsNullOrWhiteSpace(originalKey))
            {
                originalKey = await ResolveSongKey(song);
            }

            return ChangeKey(song, destinationKey, originalKey);

        }

        public string ChangeKey(Song song, string destinationKey, string originalKey)
        {
            var noteDifference = destinationKey.ToNote() - originalKey.ToNote();

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