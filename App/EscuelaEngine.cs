using CoreEscuela.Entidades;
namespace CoreEscuela{
    public class EscuelaEngine{
        public Escuela Escuela {get;set;}

        public EscuelaEngine(){
            
        }

        public void Initialize(){
            //Llamado de la clase Escuela  (para instanciar es necesario el new)
            Escuela = new Escuela("Platzi Academy",2015,TipoEscuela.Preparatoria,ciudad:"Valladolid");

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
        }
    }
}