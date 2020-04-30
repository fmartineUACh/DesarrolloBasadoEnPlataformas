import oscP5.*;
import netP5.*;
import P5ireBase.library.*;
P5ireBase fire;

OscP5 oscP5;
NetAddress remoteLocation;

void setup() {
  orientation(PORTRAIT);
  oscP5 = new OscP5(this, 12001);  
  remoteLocation = new NetAddress("192.168.1.68", 12001);  // 1
  fire = new P5ireBase(this, "https://test-37209.firebaseio.com/");
  background(78, 93, 75);
}

void draw() {
    OscMessage myMessage = new OscMessage("AndroidData");  
    myMessage.add((float)mouseY / (float)height);
    fire.setValue("PaddleHeight", String.valueOf((float)mouseY / (float)height));
    oscP5.send(myMessage, remoteLocation);
}
