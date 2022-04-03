namespace CoreEscuela.Entidades
{
    //Abstract es una idea y no se puede acceder a ella para crear objetos
            /*
        Si queremos que nuestra clase sea INSTANCIADA pero que no fuera posible **HEREDAR de ella ** debemos utilizar el tipo de clase SEALED (Clase sellada).

        Si queremos que nuestra clase sea HEREDADA pero que no fuera posible INSTANCIARLA debemos utilizar el tipo de clase ABSTRACT (clase abstracta)
        */
    //public abstract class ObjetoEscuelaBase
    public class ObjetoEscuelaBase
    {
        public string Nombre { get; set; } 
        public string Id { get; set; } 

        public ObjetoEscuelaBase(){
            Id = Guid.NewGuid().ToString();
        }
    }
}