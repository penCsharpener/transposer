namespace Transposer.SmartChord.Parser.Annotations
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class AliasAttribute : Attribute
    {
        public string Name { get; }

        public AliasAttribute(string name)
        {
            Name = name;
        }
    }
}
