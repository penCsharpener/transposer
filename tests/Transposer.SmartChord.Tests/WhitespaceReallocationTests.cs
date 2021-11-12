using FluentAssertions;
using Transposer.SmartChord.Parser;
using Xunit;
using Transpose = Transposer.SmartChord.Transposer;

namespace Transposer.SmartChord.Tests
{
    public class WhitespaceReallocationTests
    {
        private Transpose.Transposer _testObject;

        public WhitespaceReallocationTests()
        {
            _testObject = new Transpose.Transposer();
        }

        [Fact]
        public void Longer_RootNotes_Reduces_Spaces()
        {
            var result = _testObject.ChangeKey(new SongParser().ParseSong(OriginalSong1), Parser.Models.Note.E, Parser.Models.Note.C);

            result.Should().Be(ExpectedSong1);
        }

        [Fact]
        public void Shorter_RootNotes_Lengthen_Spaces()
        {
            var result = _testObject.ChangeKey(new SongParser().ParseSong(ExpectedSong1), Parser.Models.Note.C, Parser.Models.Note.E);

            result.Should().Be(OriginalSong1);
        }

        [Fact]
        public void No_Shortening_For_Single_Spaces()
        {
            var result = _testObject.ChangeKey(new SongParser().ParseSong(OriginalSong2), Parser.Models.Note.CSharp, Parser.Models.Note.C);

            result.Should().Be(ExpectedSong2);
        }

        private const string OriginalSong1 = @"  C                                    F          G
Lorem ipsum dolor sit amet, consetetur sadipscing elitr, 
    C                                     F         G
sed diam nonumy eirmod tempor invidunt ut labore et dolore 
      Am                 F
magna aliquyam erat, sed diam voluptua. 
   C                            G
At vero eos et accusam et justo duo dolores et ea rebum. 
F    G               C
Stet clita kasd gubergren.";

        private const string ExpectedSong1 = @"  E                                    A          B
Lorem ipsum dolor sit amet, consetetur sadipscing elitr, 
    E                                     A         B
sed diam nonumy eirmod tempor invidunt ut labore et dolore 
      C#m                A
magna aliquyam erat, sed diam voluptua. 
   E                            B
At vero eos et accusam et justo duo dolores et ea rebum. 
A    B               E
Stet clita kasd gubergren.";

        private const string OriginalSong2 = @"  C                                    F G
Lorem ipsum dolor sit amet, consetetur sadipscing elitr, 
    C                                     F         G
sed diam nonumy eirmod tempor invidunt ut labore et dolore 
      Am                 F
magna aliquyam erat, sed diam voluptua. 
   C                            G
At vero eos et accusam et justo duo dolores et ea rebum. 
F    G               C
Stet clita kasd gubergren.";

        private const string ExpectedSong2 = @"  C#                                   F# G#
Lorem ipsum dolor sit amet, consetetur sadipscing elitr, 
    C#                                    F#        G#
sed diam nonumy eirmod tempor invidunt ut labore et dolore 
      Bbm                F#
magna aliquyam erat, sed diam voluptua. 
   C#                           G#
At vero eos et accusam et justo duo dolores et ea rebum. 
F#   G#              C#
Stet clita kasd gubergren.";
    }
}
