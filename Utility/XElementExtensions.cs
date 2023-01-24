using System.Linq;
using System.Xml.Linq;
using LTSaveEd.Exceptions;

namespace LTSaveEd.Utility;

public static class XElementExtensions
{
    public static XElement GetDescendantByName(this XElement parent, string tagName)
    {
        var tag = (from el in parent.Descendants(tagName) select el).First();
        if (tag is null)
        {
            throw new TagNotFound(tagName);
        }
        return tag;
    }
}