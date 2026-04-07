namespace Phoenix.WebApi.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class TagAttribute : Attribute
{
    public string Tag { get; }

    public TagAttribute(string tag)
    {
        Tag = tag;
    }
}
