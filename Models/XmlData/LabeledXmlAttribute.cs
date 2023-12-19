using System.Xml.Linq;

namespace LTSaveEd.Models.XmlData;

public class LabeledXmlAttribute<T>(XAttribute attribute, Func<T, string> labelGenerator) : XmlAttribute<T>(attribute)
{
    public string Label => labelGenerator(Value);
}