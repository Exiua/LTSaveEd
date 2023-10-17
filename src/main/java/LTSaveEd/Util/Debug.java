package LTSaveEd.Util;

import LTSaveEd.DataObjects.InventoryElements.InventoryClothing;
import javafx.collections.ObservableList;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.NodeList;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

public class Debug {
    static Logger log = LogManager.getLogger(InventoryClothing.class.getName());

    public static void printList(NodeList nodes){
        if(nodes == null){
            log.debug("null");
            return;
        }
        if(nodes.getLength() == 0){
            log.debug("List Length = 0");
            return;
        }
        if(nodes.getLength() == 1){
            log.debug("[" + nodes.item(0).getNodeName() + "]");
            return;
        }

        StringBuilder out = new StringBuilder();
        for(int i = 0; i < nodes.getLength(); i++){
            if(i == 0){
                out.append("[").append(nodes.item(i).getNodeName()).append(", ");
            }
            else if(i == nodes.getLength() - 1){
                out.append(nodes.item(i).getNodeName()).append("]");
            }
            else {
                out.append(nodes.item(i).getNodeName()).append(", ");
            }
        }

        log.debug(out);
    }

    public static void printList(NamedNodeMap nodes){
        if(nodes == null){
            log.debug("null");
            return;
        }
        if(nodes.getLength() == 0){
            log.debug("List Length = 0");
            return;
        }
        if(nodes.getLength() == 1){
            log.debug("[" + nodes.item(0).getNodeName() + "]");
            return;
        }

        StringBuilder out = new StringBuilder();
        for(int i = 0; i < nodes.getLength(); i++){
            if(i == 0){
                out.append("[").append(nodes.item(i).getNodeName()).append(", ");
            }
            else if(i == nodes.getLength() - 1){
                out.append(nodes.item(i).getNodeName()).append("]");
            }
            else {
                out.append(nodes.item(i).getNodeName()).append(", ");
            }
        }

        log.debug(out);
    }

    public static String listToString(ObservableList<?> list, int length){
        if(list == null){
            return "null";
        }
        if(list.size() == 0){
            return "[]";
        }
        if(list.size() == 1){
            return "[" + list.get(0) + "]";
        }

        StringBuilder out = new StringBuilder("[");
        for(int i = 0; i < length; i++){
            if(i == length - 1){
                out.append(list.get(i)).append("]");
            }
            else {
                out.append(list.get(i)).append(", ");
            }
        }
        return out.toString();
    }

    public static void versionCompare() throws IOException{
        StringBuilder result = new StringBuilder();
        URL url = new URL("https://api.github.com/repos/Exiua/LTSaveEd/releases/latest");
        HttpURLConnection conn = (HttpURLConnection) url.openConnection();
        conn.setRequestMethod("GET");
        conn.setRequestProperty("Accept", "application/vnd.github.v3+json");
        try (BufferedReader reader = new BufferedReader(new InputStreamReader(conn.getInputStream()))) {
            for (String line; (line = reader.readLine()) != null; ) {
                result.append(line);
            }
        }
        String jsonStr = result.toString();
        String[] jsonArr = jsonStr.replace("{", "").replace("}", "").split(",");
        String test = "";
        for(String s : jsonArr) {
            if(s.startsWith("\"tag_name\"")) {
                test = s.split(":")[1].replace("\"", "");
                log.debug(test);
                break;
            }
        }
        log.debug("v0.1.0".compareTo(test));
        log.debug(compareVersions("v1.10.0", "v1.9.0"));
    }

    public static int compareVersions(String version1, String version2){
        String[] v1Arr = version1.replace("v", "").split("\\.");
        String[] v2Arr = version2.replace("v", "").split("\\.");
        int v1Int;
        int v2Int;
        for(int i = 0; i < 3; i++){
            v1Int = Integer.parseInt(v1Arr[i]);
            v2Int = Integer.parseInt(v2Arr[i]);
            if(v1Int > v2Int){
                return 1;
            }
            else if(v1Int < v2Int){
                return -1;
            }
        }
        return 0; //Version strings must be equal at this point
    }

    public static void main(String[] args) throws IOException {
        versionCompare();
    }
}
