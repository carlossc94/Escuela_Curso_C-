namespace CoreEscuela.Entidades{
    public class Escuela
    {
        string nombre ="";
        public string Nombre{
            get{return nombre;}
            set{nombre = value.ToUpper();}
        }

        public int AnioDeCreacion {get; set;}
        public string Pais { get; set; }
        public string Ciudad { get; set; }

        public List<Curso> Cursos{get;set;}

        public TipoEscuela TipoEscuela{get;set;}

        //Forma Comun de Realizar el llamado del constructor
        /*
        public Escuela (String nombre, int anio){
            this.nombre = nombre;
            AnioDeCreacion = anio;
        }*/

        //Llamada del constructor por asignacion por tuplas
        //public Escuela (string nombre,int anio) => (Nombre,AnioDeCreacion) = (nombre,anio);

        public Escuela (string nombre,int anio, TipoEscuela tipo, string pais="",string ciudad="") {
            (Nombre,AnioDeCreacion) = (nombre,anio);
            Ciudad = ciudad;
            Pais = pais;
        }



        public override string ToString()
        {
            //return $"Nombre: {Nombre},Tipo: {TipoEscuela},\nPais: {Pais}, Ciudad: {Ciudad}";
            //Escribirlo con comillas
            return $"Nombre: \"{Nombre}\",Tipo: {TipoEscuela},{System.Environment.NewLine} Pais: {Pais}, Ciudad: {Ciudad}";
        }
    }
}