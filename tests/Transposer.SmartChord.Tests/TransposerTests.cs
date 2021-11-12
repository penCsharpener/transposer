using FluentAssertions;
using System;
using System.IO;
using System.Reflection;
using Transposer.SmartChord.Parser;
using Xunit;
using Transpose = Transposer.SmartChord.Transposer;

namespace Transposer.SmartChord.Tests
{
    public class TransposerTests
    {
        private readonly Transpose.Transposer _transposer;
        private readonly string? _assemblyName;

        public TransposerTests()
        {
            _transposer = new Transpose.Transposer();
            _assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        }

        private string GetResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream ?? throw new InvalidOperationException("Cannot find resource.")))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        [Fact]
        public void Changing_without_original_key_specified_works()
        {
            string song = GetResource($"{_assemblyName}.Resources.Input.tears-in-heaven-key-a.txt");

            var result = _transposer.ChangeKey(song, Parser.Models.Note.C);

            string songInKeyOfC = GetResource($"{_assemblyName}.Resources.Output.tears-in-heaven-key-c.txt");

            result.Should().Be(songInKeyOfC);
        }

        [Fact]
        public void Changing_with_original_key_specified_works()
        {
            string song = GetResource($"{_assemblyName}.Resources.Input.tears-in-heaven-key-a.txt");

            var result = _transposer.ChangeKey(new SongParser().ParseSong(song), Parser.Models.Note.C, Parser.Models.Note.A);

            string songInKeyOfC = GetResource($"{_assemblyName}.Resources.Output.tears-in-heaven-key-c.txt");

            result.Should().Be(songInKeyOfC);
        }

        [Fact]
        public void Song_with_ambiguous_elements_works()
        {
            string song = GetResource($"{_assemblyName}.Resources.Input.fake-song-key-a.txt");

            var result = _transposer.ChangeKey(song, Parser.Models.Note.G);

            string songInKeyOfG = GetResource($"{_assemblyName}.Resources.Output.fake-song-key-g.txt");

            result.Should().Be(songInKeyOfG);

        }
    }
}