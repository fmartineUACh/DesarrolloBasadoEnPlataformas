import P5ireBase.library.*;
P5ireBase fire;

// importar la librería
// definir una variable del tipo P5ireBase

void setup() {
  size(400, 400);
  fire = new P5ireBase(this, "https://test-37209.firebaseio.com/");
}

// crear instancia de objeto P5ireBase
// la URL debe apuntar hacia la base de datos de firebase

void draw() {
//if(mousePressed) {
// println("was here");
// fire.setValue("Nombre", "Amarito");
//}
}

// podemos esperar por un evento del ratón
// dentro o fuera del método draw()
// por eso aparece comentado

void mousePressed() {
  fire.setValue("Nombre", "Amarito");
  println(fire.getValue("Last"));
}
