



import java.applet.*;
import java.awt.*;

public class HelloApplet extends Applet{
    String mes;
    public HelloApplet(){
        this("Standart inform");
    }

    public HelloApplet(String inform){
        mes = inform;
    }

    public String getAppletInfo(){
        return "Name: HelloApplet\r\n" + 
            "Created with JBuilder";
    }

    public void init(){
        resize(320, 240);
    }

    public void destroy(){
        mes = "";
    }

    public void paint(Graphics g){
        g.drawString("Created with JBuilder", 10, 20);
    }

    public void start(){
        mes = "Standart inform";
    }

    public void stop(){
        mes = "Applet stoped";
    }
}
