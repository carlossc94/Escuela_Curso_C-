namespace CoreEscuela.Entidades
{
    public class Asignatura
    {
        public string Nombre { get; set; }
        public string Id { get; set; }
        public Asignatura() => Id = Guid.NewGuid().ToString();
    }
}