package LTSaveEd.DataObjects.InventoryElements;

import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

public class MultiColor {
    private static final int MAX_COLOR_COUNT = 7;

    private final Element colorsNode;
    private final String[] colors;
    private final int colorCount;

    public MultiColor(Element node){
        colorsNode = node;
        colors = new String[MAX_COLOR_COUNT];
        NodeList colorList = colorsNode.getChildNodes();
        int index = 0;
        for(int i = 0; i < colorList.getLength(); i++) {
            Node color = colorList.item(i);
            if(color.getNodeType() == Node.ELEMENT_NODE){
                colors[index] = color.getTextContent();
                index++;
            }
        }
        colorCount = index;
    }

    public Element getColorsNode() {
        return colorsNode;
    }

    public String[] getColors() {
        return colors;
    }

    public String getColor(int index){
        if(index >= colorCount){
            throw new ArrayIndexOutOfBoundsException("Index greater than number of valid colors for item");
        }
        return colors[index];
    }

    public void setColor(int index, String value){
        if(index >= colorCount){
            throw new ArrayIndexOutOfBoundsException("Index greater than number of valid colors for item");
        }
        colors[index] = value;
    }

    public int getColorCount() {
        return colorCount;
    }
}
