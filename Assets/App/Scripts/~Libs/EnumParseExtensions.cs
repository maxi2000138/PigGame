using System;
using System.Reflection;

public class EnumParseExtensions
{
    public static T EnumParse<T>(string stringValue, bool ignoreCase) where T : struct
    {
        T output = default;
        string enumStringValue = null;
    
        foreach (FieldInfo fi in typeof(T).GetFields())
        {
            var attrs = fi.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
            if (attrs != null && attrs.Length > 0)
            {
                enumStringValue = attrs[0].Value;
            }

            if (string.Compare(enumStringValue, stringValue, ignoreCase) == 0)
            {
                output = Enum.Parse<T>(fi.Name);
                break;
            }
        }
    
        return output;
    }
}

public class StringValueAttribute : Attribute
{
    public string Value { get; private set; }

    public StringValueAttribute(string value)
    {
        Value = value;
    }
}
