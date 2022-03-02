namespace CoreEscuela.Entidades
{
    public class Curso:ObjetoEscuelaBase
    {
         /* Se comentan porque en la clase ObjetoEscuelaBase ya esta heredado estos atributos
        public string Nombre { get; set; }
        public string Id { get; set; }
        public Curso() => Id = Guid.NewGuid().ToString();*/
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignatura{get;set;}
        public List<Alumno> Alumno{get;set;}

       
        
    }
}