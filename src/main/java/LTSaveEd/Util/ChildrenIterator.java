package LTSaveEd.Util;

import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import java.util.Iterator;
import java.util.NoSuchElementException;

public class ChildrenIterator implements Iterator<Node> {

    private final NodeList children;
    private int currentChildIndex;
    private final int numChildren;

    public ChildrenIterator(NodeList nodeList){
        children = nodeList;
        currentChildIndex = 0;
        numChildren = children.getLength();
    }

    @Override
    public boolean hasNext() {
        while (currentChildIndex < numChildren) {
            if (children.item(currentChildIndex).getNodeType() == Node.ELEMENT_NODE) {
                return true;
            }
            currentChildIndex++;
        }
        return false;
    }

    @Override
    public Node next() {
        if (!hasNext()) {
            throw new NoSuchElementException();
        }
        return children.item(currentChildIndex++);
    }
}
