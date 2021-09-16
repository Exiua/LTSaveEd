package LTSaveEd.Util;

import LTSaveEd.Objects.NpcCharacter;
import org.w3c.dom.Document;
import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;

public class Debug {

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

    public static void main(String[] args){
        Document file = loadXml();
        assert file != null;
        NodeList nl = file.getElementsByTagName("NPC");
        if(nl == null){
            System.out.println("Failed to load file");
            return;
        }
        for(int i = 0; i < nl.getLength(); i++){
            NpcCharacter nc = new NpcCharacter(nl.item(i));
            System.out.println(nc.getId());
        }
    }

    public static Document loadXml(){
        //Load XML
        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
        try (InputStream is = new FileInputStream("D:\\Documents\\Games\\Extra\\Lilith's Throne\\Lilith's Throne (exe version)\\data\\saves\\Save Editor Test.xml")){
            DocumentBuilder db = dbf.newDocumentBuilder();
            return db.parse(is);
        }
        catch(ParserConfigurationException | SAXException | IOException e){
            e.printStackTrace();
        }
        return null;
    }
}
