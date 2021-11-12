namespace Transposer.SmartChord.Parser.Models.Elements
{
    public class WhitespaceElement : BaseElement
    {
        private string _text;

        public int Length => _text.Length;

        public WhitespaceElement(string text)
        {
            _text = text;
        }

        public void AddWhitespaces(int i)
        {
            if (i > 0)
            {
                _text = $"{_text}{new string(' ', i)}";

                return;
            }

            if (Length > 1)
            {
                _text = _text.Substring(0, _text.Length + i);
            }
        }

        public override string GetText()
        {
            return _text;
        }
    }
}
