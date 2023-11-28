package LTSaveEd.Util;

import org.jetbrains.annotations.NotNull;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import java.util.Iterator;

public class IterableNodeChildren implements Iterable<Node> {
    private final NodeList nodeList;

    public IterableNodeChildren(Node node) {
        nodeList = node.getChildNodes();
    }

    public IterableNodeChildren(NodeList nodeList) {
        this.nodeList = nodeList;
    }

    @Override
    public @NotNull Iterator<Node> iterator() {
        return new ChildrenIterator(nodeList);
    }
}
