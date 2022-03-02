namespace CoreEscuela.Entidades
{
    public class Evaluacion:ObjetoEscuelaBase
    {
        /* Se comentan porque en la clase ObjetoEscuelaBase ya esta heredado estos atributos
        public string Id { get; set; }
        public string Nombre { get; set; }
        public Evaluacion() => Id = Guid.NewGuid().ToString();
        */

        public Asignatura Asignatura { get; set; }
        public float Nota { get; set; }
        public Alumno Alumno{get;set;}
        
        public override string ToString()
        {
            return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
        }
    }
}