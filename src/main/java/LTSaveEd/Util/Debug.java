package LTSaveEd.Util;

import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;

public class Debug {

    @SuppressWarnings("DuplicatedCode")
    public static void printList(NodeList nodes){
        if(nodes == null){
            System.out.println("null");
            return;
        }
        if(nodes.getLength() == 0){
            System.out.println("List Length = 0");
            return;
        }
        if(nodes.getLength() == 1){
            System.out.println("[" + nodes.item(0).getNodeName() + "]");
            return;
        }
        for(int i = 0; i < nodes.getLength(); i++){
            if(i == 0){
                System.out.print("[" + nodes.item(i).getNodeName() + ", ");
            }
            else if(i == nodes.getLength() - 1){
                System.out.println(nodes.item(i).getNodeName() + "]");
            }
            else {
                System.out.print(nodes.item(i).getNodeName() + ", ");
            }
        }
    }

    public static void printListValue(NodeList nodes, String value){
        if(nodes == null){
            System.out.println("null");
            return;
        }
        if(nodes.getLength() == 0){
            System.out.println("List Length = 0");
            return;
        }
        if(nodes.getLength() == 1){
            System.out.println("[" + nodes.item(0).getAttributes().getNamedItem(value).getTextContent() + "]");
            return;
        }
        for(int i = 0; i < nodes.getLength(); i++){
            if(i == 0){
                if(nodes.item(i).getNodeType() != Node.ELEMENT_NODE){
                    System.out.print("[" + nodes.item(i).getNodeName() + ", ");
                }
                else{
                    System.out.print("[" + nodes.item(i).getAttributes().getNamedItem(value).getTextContent() + ", ");
                }
            }
            else if(i == nodes.getLength() - 1){
                if(nodes.item(i).getNodeType() != Node.ELEMENT_NODE){
                    System.out.print(nodes.item(i).getNodeName() + "]");
                }
                else{
                    System.out.println(nodes.item(i).getAttributes().getNamedItem(value).getTextContent() + "]");
                }
            }
            else {
                if(nodes.item(i).getNodeType() != Node.ELEMENT_NODE){
                    System.out.print(nodes.item(i).getNodeName() + ", ");
                }
                else{
                    System.out.print(nodes.item(i).getAttributes().getNamedItem(value).getTextContent() + ", ");
                }
            }
        }
    }

    @SuppressWarnings("DuplicatedCode")
    public static void printList(NamedNodeMap nodes){
        if(nodes == null){
            System.out.println("null");
            return;
        }
        if(nodes.getLength() == 0){
            System.out.println("List Length = 0");
            return;
        }
        if(nodes.getLength() == 1){
            System.out.println("[" + nodes.item(0).getNodeName() + "]");
            return;
        }
        for(int i = 0; i < nodes.getLength(); i++){
            if(i == 0){
                System.out.print("[" + nodes.item(i).getNodeName() + ", ");
            }
            else if(i == nodes.getLength() - 1){
                System.out.println(nodes.item(i).getNodeName() + "]");
            }
            else {
                System.out.print(nodes.item(i).getNodeName() + ", ");
            }
        }
    }

    public static void printList(ArrayList<?> nodes){
        if(nodes == null){
            System.out.println("null");
            return;
        }
        if(nodes.size() == 0){
            System.out.println("List Length = 0");
            return;
        }
        if(nodes.size() == 1){
            System.out.println("[" + nodes.get(0) + "]");
            return;
        }
        for(int i = 0; i < nodes.size(); i++){
            if(i == 0){
                System.out.print("[" + nodes.get(i) + ", ");
            }
            else if(i == nodes.size() - 1){
                System.out.println(nodes.get(i) + "]");
            }
            else {
                System.out.print(nodes.get(i) + ", ");
            }
        }
    }

    public static void printArr(String[] arr){
        for(int i = 0; i < arr.length; i++){
            if(i == 0){
                System.out.print("[" + arr[i] + ", ");
            }
            else if(i == arr.length - 1){
                System.out.println(arr[i] + "]");
            }
            else {
                System.out.print(arr[i] + ", ");
            }
        }
    }

    public static void main(String[] args) throws IOException {
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
                System.out.println(test);
                break;
            }
        }
        System.out.println("v0.1.0".compareTo(test));
    }
}
