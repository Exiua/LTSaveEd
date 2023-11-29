package LTSaveEd.Util;

import javafx.collections.ObservableList;
import javafx.collections.ObservableMap;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.jetbrains.annotations.NotNull;
import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.NodeList;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

public class Debug {
    static Logger log = LogManager.getLogger(Debug.class.getName());

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

    public static void printMap(ObservableMap<?, ?> map){
        if(map == null){
            log.debug("null");
            return;
        }
        if(map.isEmpty()){
            log.debug("Map is empty");
            return;
        }
        if(map.size() == 1){
            var entry = map.entrySet().iterator().next();
            log.debug("{" + entry.getKey() + ": " + entry.getValue() + "}");
            return;
        }

        StringBuilder out = new StringBuilder();
        int i = 0;
        for (var entry : map.entrySet()) {
            if(i == 0){
                out.append("{").append(entry.getKey()).append(": ").append(entry.getValue()).append(",\n");
            }
            else if(i == map.size() - 1){
                out.append(entry.getKey()).append(": ").append(entry.getValue()).append("}");
            }
            else {
                out.append(entry.getKey()).append(": ").append(entry.getValue()).append(",\n");
            }
            i++;
        }

        log.debug(out);
    }

    public static String listToString(ObservableList<?> list, int length){
        if(list == null){
            return "null";
        }
        if(list.isEmpty()){
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
        String jsonStr = getJsonString();
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

    @NotNull
    private static String getJsonString() throws IOException {
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
        return result.toString();
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
}
