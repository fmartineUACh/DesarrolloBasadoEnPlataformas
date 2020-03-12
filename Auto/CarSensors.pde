  void onAccelerometerEvent(float x, float y, float z){
  accelerometer.set(x, y, z);
  testSensorEvent();
}
 
void onLightEvent(float v){
  light = v;
  testSensorEvent();
}
 
void onProximityEvent(float v) {
  proximity = v;
  testSensorEvent();
 }
 
void onLocationEvent(double _latitude, double _longitude, double _altitude) {
  longitude = _longitude;
  latitude = _latitude;
  altitude = _altitude;
  testSensorEvent();
}
 
void eventInTheCar(int event){
  if(event < 0 || event > 4) return;
  String alerta = ""; // Compiler cries otherwise
  switch(event){ 
    case Eventos.PROXIMITY_EVENT:
      alerta = "POSIBLE INTRUSO HUSMEANDO";
      displayPhoto = false;  
      playSound = true;
      break;
    case Eventos.TOUCH_EVENT:
      alerta = "ALGUIEN INTENTA ABRIR O HA ROTO LOS CRISTALES";
      displayPhoto = true;  
      playSound = false;
      break;
    case Eventos.CAR_DISTURBANCE_EVENT:  
      alerta = "PROBABLE IMPACTO O ROBO DE AUTOPARTES EXTERNAS";
      displayPhoto = true;  
      playSound = true;
      break;
    case Eventos.INTRUDER_EVENT:
      alerta = "INTRUSO EN EL AUTO";
      displayPhoto = false;  
      playSound = false;
      break;
    case Eventos.GPS_EVENT:
      alerta = "EL AUTOMOVIL ESTA EN MOVIMIENTO. POSIBLE ROBO";
      displayPhoto = false;  
      playSound = false;
      break;
  }
  
  UIText = alerta;
  //println("Se ha levantado la siguiente alerta: " + alerta + "\n Pero no hay dispositivo que nos escuche.");

}
 
class Eventos{
  static final int PROXIMITY_EVENT = 0;
  static final int TOUCH_EVENT = 1;
  static final int CAR_DISTURBANCE_EVENT = 2;
  static final int INTRUDER_EVENT = 3;
  static final int GPS_EVENT = 4;
}
   
 
void testSensorEvent(){
  if (touchIsStarted){
      eventInTheCar(Eventos.TOUCH_EVENT);
  } else if(accelerometer.x > 3.00 && accelerometer.z > 2.00){
     eventInTheCar(Eventos.CAR_DISTURBANCE_EVENT);
  } else if (light > 40.0){
      eventInTheCar(Eventos.INTRUDER_EVENT);
  } else if(proximity == 0){
    eventInTheCar(Eventos.PROXIMITY_EVENT);
  } else if(latitude != 0 && longitude != 0 && altitude!=0 && accelerometer.x > 3 && accelerometer.z > 2){
    eventInTheCar(Eventos.GPS_EVENT);
  }
}
