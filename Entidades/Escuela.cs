using CoreEscuela.Util;
namespace CoreEscuela.Entidades{
    public class Escuela:ObjetoEscuelaBase, ILugar
    {
        /* Se comentan porque en la clase ObjetoEscuelaBase ya esta heredado estos atributos
        string nombre ="";
        public string Nombre{
            get{return nombre;}
            set{nombre = value.ToUpper();}
        }*/

        public int AnioDeCreacion {get; set;}
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Direccion{get;set;}
        public List<Curso> Cursos{get;set;}

        public TipoEscuela TipoEscuela{get;set;}

        //Forma Comun de Realizar el llamado del constructor
        /*
        public Escuela (String nombre, int anio){
            this.nombre = nombre;
            AnioDeCreacion = anio;
        }*/

        //Llamada del constructor por asignacion por tuplas
        public Escuela (string nombre,int anio) => (Nombre,AnioDeCreacion) = (nombre,anio);

        public Escuela (string nombre,int anio, TipoEscuela tipo, string pais="",string ciudad=""):base() {
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

        public void LimpiarLugar(){
            Printer.DibujarLinea();
            Console.WriteLine("Limpiando Escuela......");
            Printer.Beep(1000,cantidad:3);
            foreach (Curso curso in Cursos)
            {
                curso.LimpiarLugar();
            }
            Console.WriteLine($"Escuela {Nombre} esta limpio");
        }
    }
}