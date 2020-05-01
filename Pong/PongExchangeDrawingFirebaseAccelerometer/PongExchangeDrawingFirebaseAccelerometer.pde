import oscP5.*;
import netP5.*;
import ketai.sensors.*;
import P5ireBase.library.*;

P5ireBase fire;
KetaiSensor sensor;
OscP5 oscP5;
NetAddress remoteLocation;

float position, myAccelerometerY;

void setup() {
  orientation(PORTRAIT);
  oscP5 = new OscP5(this, 12001);  
  remoteLocation = new NetAddress("192.168.1.68", 12001);  // 1
  fire = new P5ireBase(this, "https://test-37209.firebaseio.com/");
  background(78, 93, 75);
  sensor = new KetaiSensor(this);
  sensor.start();
}

void draw() {
    OscMessage myMessage = new OscMessage("AndroidData");  
    position += myAccelerometerY * 0.02;
    if(position > 1) 
      position = 1;
    else if(position < 0) 
      position = 0;
    myMessage.add(position);
    fire.setValue("PaddleHeight", String.valueOf(position));
    oscP5.send(myMessage, remoteLocation);
}

void onAccelerometerEvent(float x, float y, float z)
{
  myAccelerometerY = y;
}
