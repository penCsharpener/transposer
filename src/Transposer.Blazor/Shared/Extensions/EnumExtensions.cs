using Transposer.Blazor.Shared.Models.Enums;
using Transposer.SmartChord.Parser.Annotations;

namespace Transposer.Blazor.Shared.Extensions;

public static class EnumExtensions
{
    private static Dictionary<Keys, string> _keys;

    static EnumExtensions()
    {
        _keys = Enum.GetValues<Keys>().ToDictionary(k => k, v => v.ToAlias());
    }

    public static string ToStringRepresentation(this Keys key)
    {
        return _keys[key];
    }

    private static string ToAlias<T>(this T key) where T : Enum
    {
        var enumType = typeof(T);
        var memberInfos = enumType.GetMember(key.ToString());
        var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);

        if (enumValueMemberInfo == null)
        {
            return key.ToString();
        }

        var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(AliasAttribute), false);

        if (valueAttributes == null || valueAttributes.Length == 0)
        {
            return key.ToString();
        }

        var description = ((AliasAttribute)valueAttributes[0]).Name;

        return description;
    }

    public static string[] ToKeyAliases()
    {
        return Enum.GetValues<Keys>().Select(x => x.ToAlias()).ToArray();
    }
}
