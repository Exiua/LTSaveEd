using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData;

public class BodyCore : BodyComponent
{
    public ValueDisplayPair[] BodyMaterials { get; } =
    [
        new ValueDisplayPair("Flesh", "FLESH"), new ValueDisplayPair("Slime", "SLIME"),
        new ValueDisplayPair("Fire", "FIRE"), new ValueDisplayPair("Water", "WATER"),
        new ValueDisplayPair("Ice", "ICE"), new ValueDisplayPair("Storm-clouds", "AIR"),
        new ValueDisplayPair("Stone", "STONE"), new ValueDisplayPair("Rubber", "RUBBER"),
        new ValueDisplayPair("Energy", "ENERGY")
    ];

    public ValueDisplayPair[] PubicHairTypes => Collections.HairTypes;

    public ValueDisplayPair[] SubspeciesOverrides { get; } =
    [
        new ValueDisplayPair("Human", "HUMAN"), new ValueDisplayPair("Angel", "ANGEL"),
        new ValueDisplayPair("Elder Lilin", "ELDER_LILIN"), new ValueDisplayPair("Lilin", "LILIN"),
        new ValueDisplayPair("Demon", "DEMON"), new ValueDisplayPair("Half Demon", "HALF_DEMON"),
        new ValueDisplayPair("Imp", "IMP"), new ValueDisplayPair("Imp Alpha", "IMP_ALPHA"),
        new ValueDisplayPair("Cow Morph", "COW_MORPH"), new ValueDisplayPair("Dog Morph", "DOG_MORPH"),
        new ValueDisplayPair("Dog Morph Border Collie", "DOG_MORPH_BORDER_COLLIE"),
        new ValueDisplayPair("Dog Morph Dobermann", "DOG_MORPH_DOBERMANN"),
        new ValueDisplayPair("Dog Morph German Shepherd", "DOG_MORPH_GERMAN_SHEPHERD"), new ValueDisplayPair("Dragon Morph", "dsg_dragon_subspecies_dragon"),
        new ValueDisplayPair("Wolf Morph", "WOLF_MORPH"), new ValueDisplayPair("Fox Morph", "FOX_MORPH"),
        new ValueDisplayPair("Fox Morph Arctic", "FOX_MORPH_ARCTIC"),
        new ValueDisplayPair("Fox Morph Fennec", "FOX_MORPH_FENNEC"),
        new ValueDisplayPair("Fox Ascendant", "FOX_ASCENDANT"),
        new ValueDisplayPair("Fox Ascendant Arctic", "FOX_ASCENDANT_ARCTIC"),
        new ValueDisplayPair("Fox Ascendant Fennec", "FOX_ASCENDANT_FENNEC"),
        new ValueDisplayPair("Cat Morph", "CAT_MORPH"),
        new ValueDisplayPair("Cat Morph Lynx", "CAT_MORPH_LYNX"),
        new ValueDisplayPair("Cat Morph Cheetah", "CAT_MORPH_CHEETAH"),
        new ValueDisplayPair("Cat Morph Caracal", "CAT_MORPH_CARACAL"),
        new ValueDisplayPair("Cat Morph Leopard Snow", "CAT_MORPH_LEOPARD_SNOW"),
        new ValueDisplayPair("Cat Morph Leopard", "CAT_MORPH_LEOPARD"),
        new ValueDisplayPair("Cat Morph Lion", "CAT_MORPH_LION"),
        new ValueDisplayPair("Cat Morph Tiger", "CAT_MORPH_TIGER"),
        new ValueDisplayPair("Horse Morph", "HORSE_MORPH"),
        new ValueDisplayPair("Horse Morph Unicorn", "HORSE_MORPH_UNICORN"),
        new ValueDisplayPair("Horse Morph Pegasus", "HORSE_MORPH_PEGASUS"),
        new ValueDisplayPair("Horse Morph Alicorn", "HORSE_MORPH_ALICORN"),
        new ValueDisplayPair("Centaur", "CENTAUR"), new ValueDisplayPair("Pegataur", "PEGATAUR"),
        new ValueDisplayPair("Unitaur", "UNITAUR"), new ValueDisplayPair("Alitaur", "ALITAUR"),
        new ValueDisplayPair("Horse Morph Zebra", "HORSE_MORPH_ZEBRA"),
        new ValueDisplayPair("Reindeer Morph", "REINDEER_MORPH"),
        new ValueDisplayPair("Alligator Morph", "ALLIGATOR_MORPH"), new ValueDisplayPair("Slime", "SLIME"),
        new ValueDisplayPair("Squirrel Morph", "SQUIRREL_MORPH"),
        new ValueDisplayPair("Rat Morph", "RAT_MORPH"), new ValueDisplayPair("Rabbit Morph", "RABBIT_MORPH"),
        new ValueDisplayPair("Rabbit Morph Lop", "RABBIT_MORPH_LOP"),
        new ValueDisplayPair("Bat Morph", "BAT_MORPH"), new ValueDisplayPair("Harpy", "HARPY"),
        new ValueDisplayPair("Harpy Raven", "HARPY_RAVEN"),
        new ValueDisplayPair("Harpy Bald Eagle", "HARPY_BALD_EAGLE"),
        new ValueDisplayPair("Harpy Phoenix", "HARPY_PHOENIX"),
        new ValueDisplayPair("Elemental Fire", "ELEMENTAL_FIRE"),
        new ValueDisplayPair("Elemental Earth", "ELEMENTAL_EARTH"),
        new ValueDisplayPair("Elemental Water", "ELEMENTAL_WATER"),
        new ValueDisplayPair("Elemental Air", "ELEMENTAL_AIR"),
        new ValueDisplayPair("Elemental Arcane", "ELEMENTAL_ARCANE")
    ]; //TODO Check if these are all subspecies in the game
    
    public XmlAttribute<string> BodyMaterial { get; }
    public XmlAttribute<int> BodySize { get; }
    public XmlAttribute<int> Femininity { get; }
    public XmlAttribute<bool> Feral { get; }
    public XmlAttribute<string> GenitalArrangement { get; }
    public XmlAttribute<int> Height { get; }
    public XmlAttribute<int> Muscle { get; }
    public XmlAttribute<bool> PiercedStomach { get; }
    public XmlAttribute<string> PubicHair { get; }
    public XmlAttribute<string> SubspeciesOverride { get; }
    public XmlAttribute<bool> TakesAfterMother { get; }
    

    public BodyCore(XElement bodyCoreNode, Body body) : base(body)
    {
        BodyMaterial = new XmlAttribute<string>(bodyCoreNode.Attribute("bodyMaterial")!);
        BodySize = new XmlAttribute<int>(bodyCoreNode.Attribute("bodySize")!);
        Femininity = new XmlAttribute<int>(bodyCoreNode.Attribute("femininity")!);
        Feral = new XmlAttribute<bool>(bodyCoreNode.Attribute("feral")!);
        GenitalArrangement = new XmlAttribute<string>(bodyCoreNode.Attribute("genitalArrangement")!);
        Height = new XmlAttribute<int>(bodyCoreNode.Attribute("height")!);
        Muscle = new XmlAttribute<int>(bodyCoreNode.Attribute("muscle")!);
        PiercedStomach = new XmlAttribute<bool>(bodyCoreNode.Attribute("piercedStomach")!);
        PubicHair = new XmlAttribute<string>(bodyCoreNode.Attribute("pubicHair")!);
        SubspeciesOverride = new XmlAttribute<string>(bodyCoreNode.Attribute("subspecies")!);
        TakesAfterMother = new XmlAttribute<bool>(bodyCoreNode.Attribute("takesAfterMother")!);
    }
}