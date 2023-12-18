using System.Xml.Linq;

namespace LTSaveEd.Models.XmlData;

public class LabeledXmlAttribute(XAttribute attribute, Func<int, string> labelGenerator) : XmlAttribute<int>(attribute)
{
    public string Label => labelGenerator(Value);
}