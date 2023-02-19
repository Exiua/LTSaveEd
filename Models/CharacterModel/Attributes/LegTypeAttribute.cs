using System.Collections.Generic;
using System.Linq;
using LTSaveEd.Exceptions;

namespace LTSaveEd.Models.CharacterModel.Attributes;

public class LegTypeAttribute : Attribute
{
    /**
     * Leg configurations associated with this leg type
     */
    public List<Attribute> legConfiguration { get; }
    
    /**
     * Foot structures associated with this leg type
     */
    public List<Attribute> footStructure { get; }
    
    /**
     * Genital arrangements associated with this leg type
     */
    public List<Attribute> genitalArrangement { get; }

    /**
     * Default leg configuration Attribute
     */
    public Attribute defaultLegConfiguration { get; }
    /**
     * Default foot structure Attribute
     */
    public Attribute defaultFootStructure { get; }
    
    /**
     * Default genital arrangement Attribute
     */
    public Attribute defaultGenitalArrangement { get; }
    


    public LegTypeAttribute(string name, string value, List<Attribute> legConfig, List<Attribute> footStruct, List<Attribute> genitalArrange, string defaultFootStructureName = "") : base(name, value)
    {
        legConfiguration = legConfig;
        footStructure = footStruct;
        genitalArrangement = genitalArrange;
        defaultLegConfiguration = legConfiguration[0];
        defaultGenitalArrangement = genitalArrangement[0];
        if (defaultFootStructureName != "")
        {
            foreach (var attribute in footStructure.Where(attribute => attribute == defaultFootStructureName))
            {
                defaultFootStructure = attribute;
                break;
            }
            if (defaultFootStructure is null)
            {
                throw new SaveEditorException("Default Foot Structure is null");
            }
        }
        else
        {
            defaultFootStructure = footStructure[0];
        }
    }
}