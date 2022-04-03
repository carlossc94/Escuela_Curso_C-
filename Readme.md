# Curso de C# con .Net Core

Curso realizado en Platzi

## Description

We use this project for learn C# with .Net Core we create a project about school (Students, Exams, Courses, etc)


## Herencia

La herencia en la programación funciona del mismo modo que en la vida real, un padre puede dejar en herencia ciertas características y atributos a sus hijos.

Aprendamos a utilizar la herencia en nuestro código y veamos como una clase hijo puede heredar ciertas características o funciones de la clase padre, también veremos que estas funciones o métodos heredados se pueden sobrescribir.

Al momento de programar nuestras clases padre podemos usar la palabra clave abstract para que dicha clase solamente pueda ser heredada, pero nunca instanciada. Por el contrario, tenemos la palabra clave sealed permite generar instancias de la clase, pero no permite heredarla.

## Polimorfismo
En polimorfismo un objeto hijo que hereda de una clase padre puede ser tratado como un objeto padre, pero al ser convertido en objeto padre ya no se podrá acceder a los atributos del objeto hijo. Por otro lado, un objeto padre no puede tratarse como un objeto hijo a menos que el objeto padre estuviera guardando un objeto hijo.

### Upcasting
Casteo implícito de una clase hija hacia su clase padre, con lo que si se tienen métodos sobrecargados en la clase hija, al hacer esto no se pueden invocar desde tu objeto ya que solo tienes disponibles los de la clase padre.
### Downcasting
Castear explícitamente un objeto de clase padre hacia su clase hija, para poder tener acceso a los métodos de la case hija

## Lista de Objetos polimórfica
Vamos a crear un método que nos regrese todos los objetos Escuela de la escuela a través de un List de ObjetoEscuelaBase.

En C# podemos realizar validaciones sobre el tipo de objeto que estamos manejando, usando las siguientes palabras clave:

is, para verificar si un objeto es de un tipo en específico.
as, para tratar un objeto como un tipo específico, en caso de no poder convertir el objeto entonces va a asignar un valor null.