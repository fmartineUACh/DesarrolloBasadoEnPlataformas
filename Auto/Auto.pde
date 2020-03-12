
import android.os.Bundle;  // 1
import android.content.Intent;  // 2

import ketai.net.bluetooth.*;
import ketai.ui.*;
import ketai.net.*;
import ketai.camera.*;
import ketai.sensors.*;
import processing.sound.*;

KetaiSensor sensor;
KetaiCamera camera;
PVector accelerometer;
float light, proximity;
KetaiLocation location; // 1
double longitude, latitude, altitude;
SoundFile beep;

KetaiList connectionList;  // 4
String info = "";  // 5
boolean isConfiguring = true;
String UIText = "";
boolean displayPhoto;
boolean playSound;

ArrayList<String> devices = new ArrayList<String>();
boolean isWatching = false;
boolean hasTakenPhoto = false;

void setup()
{
  orientation(PORTRAIT);
  background(78, 93, 75);
  stroke(255);
    
  sensor = new KetaiSensor(this);
  sensor.start();
  sensor.list();
  accelerometer = new PVector();
  location = new KetaiLocation(this);
  sensor.enableProximity();
  sensor.enableLight();

  
  camera = new KetaiCamera(this, 720, 720, 30);
  camera.start();
  camera.setCameraID(1);
  
  beep = new SoundFile(this, "beep.mp3");
}

void onCameraPreviewEvent() {
  if(!hasTakenPhoto)
    camera.read();
}

void draw()
{
  background(78, 93, 75);
  textSize(40);
  text(UIText, 30, 30, width, height);
   if(displayPhoto && camera.isStarted()) {
      image(camera, 300, 300, 720, 720);
      hasTakenPhoto = true;
      camera.savePhoto();
   }
   else if(!displayPhoto && camera.isStarted()) 
     hasTakenPhoto = false;
   if(playSound) {
     beep.play();
   }
   else if(!playSound) {
     beep.stop();
   }
}
