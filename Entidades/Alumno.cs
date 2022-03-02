namespace CoreEscuela.Entidades
{
    public class Alumno: ObjetoEscuelaBase
    {
        /* Se comentan porque en la clase ObjetoEscuelaBase ya esta heredado estos atributos
        public string Nombre { get; set; }
        public string Id { get; set; }
        public Alumno() => Id = Guid.NewGuid().ToString();
        */
        public List<Evaluacion> Evaluaciones{get;set;} = new List<Evaluacion>();

        
    }
}