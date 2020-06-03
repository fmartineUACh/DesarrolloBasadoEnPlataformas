# Importante
Al iniciar la ejecucion en la escena de unity es necesiario esperar unos 7 segundos en lo que se realiza la conexión con Firebase.  

Para cambiar la forma de controlar la cámara entre teclado y GPS se presionan las teclas 1 y 2.   

# Scripts mas importantes  
## Unity  

FirebaseStart Notifica a todos los demas scripts cuando se ha inicializado la conexion con Firebase  

SetFanFromFirebaseTemperature Escucha cambios en la temperatura y pone el abanico en marcha si esta es de mas de 25 grados  

SetTVFromFirebase Prende y apaga la television acorde a su estado en firebase  

UpdatePositionFromFirebase Escucha cambios en las coordenadas longitud y latitud de firebase y ajusta la posicion de la camara si el script se encuentra activo  

## Android (Xamarin)

MainActivity Escucha los cambios en la temperatura y actualiza a Firebase acorde a esta, si no se tiene acceso a un sensor de temperatura la cantidad predeterminada es de 25 grados   

MainPageViewModel Se encarga de obtener continuamente la posicion GPS, ademas tambien muestra un boton para poder prender o apagar el televisor    
 
# Screenshots
![image](https://user-images.githubusercontent.com/26514646/83587713-f5c8f580-a50c-11ea-818d-c217d96af95c.png)
![image](https://user-images.githubusercontent.com/26514646/83587755-1002d380-a50d-11ea-9205-1165809e36a7.png)
![smarttime](https://user-images.githubusercontent.com/26514646/83586905-e779da00-a50a-11ea-9675-92328ad44cac.jpg)
