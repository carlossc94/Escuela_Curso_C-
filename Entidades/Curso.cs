namespace CoreEscuela.Entidades
{
    public class Curso
    {
        public string Nombre { get; set; }
        public string Id { get; set; }
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignatura{get;set;}
        public List<Alumno> Alumno{get;set;}

        public Curso() => Id = Guid.NewGuid().ToString();
        
    }
}