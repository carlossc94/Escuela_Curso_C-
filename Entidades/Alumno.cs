namespace CoreEscuela.Entidades
{
    public class Alumno
    {
        public string Nombre { get; set; }
        public string Id { get; set; }

        public Alumno() => Id = Guid.NewGuid().ToString();
    }
}