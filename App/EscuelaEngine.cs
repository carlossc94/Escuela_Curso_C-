using CoreEscuela.Entidades;
namespace CoreEscuela{
    public class EscuelaEngine{
        public Escuela Escuela {get;set;}

        public EscuelaEngine(){
            
        }

        public void Initialize(){
            //Llamado de la clase Escuela  (para instanciar es necesario el new)
            Escuela = new Escuela("Platzi Academy",2015,TipoEscuela.Preparatoria,ciudad:"Valladolid");

            //SI UN METODO QUE TENGA MAS DE 50 LINEAS ESTA MAL DISEÑADA
            CargarCursos();
            CargarAsignaturas();
            /* foreach (var curso in Escuela.Cursos)
            {
                curso.Alumno.AddRange(GenerarAlumnosRandom(50)); 
            } */
            
            CargarEvaluaciones();  
        }

        private void CargarEvaluaciones()
        {
            throw new NotImplementedException();
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos){
                List<Asignatura> listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre="Matemáticas"},
                    new Asignatura{Nombre="Español"},
                    new Asignatura{Nombre="Historia"},
                    new Asignatura{Nombre="Geografía"},
                    new Asignatura{Nombre="Educación Física"},
                    new Asignatura{Nombre="Ética y Valores"},
                    new Asignatura{Nombre="Ciencias Naturales"},
                    new Asignatura{Nombre="Química"},
                };
                curso.Asignatura = new List<Asignatura>();
                curso.Asignatura.AddRange(listaAsignaturas);
            }
        }

        private List<Alumno> GenerarAlumnosRandom(int cantidad)
        {
            string[] nombre1 = {"Alma","Bererenice","Carmen","David","Erick","Alvaro","Donald","Nicolas","Marco","Elena"};
            string[] nombre2 = {"Martin","Noemi","Araceli","Joaquin","Alejandro","Alejandra","Luis","Pedro","Ramon","Beatriz"};
            string[] Apellido1 = {"Ruiz", "Sarmiento","Toledo","Herrera","Soberanis","Eugenio","Maldonado","Perez","Torres","Martinez"};
            string[] Apellido2 = {"Higuain","Polanco","Chan","Cetina","Lopez","Ramirez","Contreras","Fabela","Nuñez","Espadas"};

            //Lenguaje integrado de Consultas (Linq)
            IEnumerable<Alumno> listaAlumnos = from n1 in nombre1 
                            from n2 in nombre2
                            from a1 in Apellido1
                            from a2 in Apellido2 
                            select new Alumno {Nombre=$"{n1} {n2} {a1} {a2}"};
            
            return listaAlumnos.OrderBy((al)=>al.Id).Take(cantidad).ToList();
            
        }

        private void CargarCursos()
        {
            //Se Crea listas
            List<Curso> listaCursos = new List<Curso>(){
                new Curso(){
                    Nombre="201",
                    Jornada = TiposJornada.Tarde
                },
                new Curso(){
                    Nombre="101",
                    Jornada = TiposJornada.Mañana
                },
                new Curso(){
                    Nombre="301",
                    Jornada = TiposJornada.Noche
                },
                new Curso(){
                    Nombre="401",
                    Jornada = TiposJornada.Tarde
                },
                new Curso(){
                    Nombre="501",
                    Jornada = TiposJornada.Mañana
                },
                new Curso(){
                    Nombre="601",
                    Jornada = TiposJornada.Noche
                }
            };

            //Se agrega a la lista en la clase escuela la lista de cursos
            Escuela.Cursos= listaCursos;
            Random rnd = new Random();
            int randomVar = 0;
            foreach (var cursos in Escuela.Cursos)
            {
                randomVar = rnd.Next(10,35);
                cursos.Alumno=GenerarAlumnosRandom(randomVar);
            }

        }
    }
}