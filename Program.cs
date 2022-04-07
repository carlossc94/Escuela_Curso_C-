using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;
namespace CoreEscuela
{
    class Program{
        static void Main(string[] args){
            EscuelaEngine escuela= new EscuelaEngine();
            escuela.Initialize();
            //Printer.Beep(32000,5000,1);
            ImprimirCursosEscuela(escuela.Escuela); 
            /*Sobrecarga de objetos*/
            
            var listaObjetos = escuela.GetObjetosEscuela(out int conteoEvaluaciones, out int conteoCursos,out int conteoAsignaturas, out int conteoAlumnos);
            
            /* USO DE LA INTERFACE
            var listaILugar =   from obj in listaObjetos
                                where obj is ILugar
                                select (ILugar)obj; */

            //escuela.Escuela.LimpiarLugar();

            /*Pruebas de Polimorfismo
            Printer.WriteTitle("Pruebas de Polifomrfismo");

            var alumnoTest = new Alumno { Nombre = "Claire UnderWood" };

            Printer.WriteTitle("AlumnoTest");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.Id}");
            WriteLine($"Alumno: {alumnoTest.GetType()}");

            //El objeto padre puede adaptarse para ser un alumno, es decir sin instanciarlo se puede convertir a alumno
            ObjetoEscuelaBase ob = alumnoTest;
            Printer.WriteTitle("ObjetoEscuelaBase");
            WriteLine($"Alumno: {ob.Nombre}");
            WriteLine($"Alumno: {ob.Id}");
            WriteLine($"Alumno: {ob.GetType()}");

            var objDummy = new ObjetoEscuelaBase() { Nombre = "Frank Underwood" };
            Printer.WriteTitle("bjDummy");
            WriteLine($"Alumno: {objDummy.Nombre}");
            WriteLine($"Alumno: {objDummy.Id}");
            WriteLine($"Alumno: {objDummy.GetType()}");

            //Se puede castear para decirle que el ob sera un objeto alumno
            alumnoTest = (Alumno) ob;
            Printer.WriteTitle("AlumnoTest");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.Id}");
            WriteLine($"Alumno: {alumnoTest.GetType()}"); */ //Fin de pruebas de polmorfismo
            
            //GENERA ERROR EN TIEMPO DE EJECUCIÓN, Un objeto instanciado como escuela base no puede castearse a ser alumno
            /* alumnoTest = (Alumno) objDummy;
            Printer.WriteTitle("AlumnoTest");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.Id}");
            WriteLine($"Alumno: {alumnoTest.GetType()}"); */

            /*Pruebas de Polimorfismo
            var evaluacion = new Evaluacion(){Nombre = "Evaluacion 1", Nota=4.5f};
            Printer.WriteTitle("evaluacion");
            WriteLine($"Alumno: {evaluacion.Nombre}");
            WriteLine($"Alumno: {evaluacion.Id}");
            WriteLine($"Alumno: {evaluacion.Nota}");
            WriteLine($"Alumno: {alumnoTest.GetType()}");

            ob = evaluacion;
            Printer.WriteTitle("ObjetoEscuelaBase evaluacion");
            WriteLine($"Alumno: {ob.Nombre}");
            WriteLine($"Alumno: {ob.Id}");
            WriteLine($"Alumno: {ob.GetType()}");

            // GENERA ERROR EN TIEMPO DE EJECUCIÓN
            // alumnoTest = (Alumno)(ObjetoEscuelaBase)evaluacion;

            if(ob is Alumno){
                Alumno AlumnoRecuperado = (Alumno)ob;
            }

            Alumno AlumnoRecuperado2 = ob as Alumno;*/


//Refactorizacion de Codigo separandolos en diferentes clases
/*
            List<Curso> listaCursosNew = new List<Curso>(){
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

            escuela.Cursos.AddRange(listaCursosNew);

            // escuela.Cursos.remove()*/
            /*
            //Se crea un array
            Curso curso2 = new Curso(){
                Nombre="201",
                Jornada = TiposJornada.Tarde
            };*/
            /*
            Curso[] arregloCursos = {
                new Curso(){
                    Nombre="101",
                    Jornada = TiposJornada.Mañana
                },
                curso2,
                new Curso(){
                    Nombre="301",
                    Jornada = TiposJornada.Noche
                }
            };*/
            /*
            escuela.Cursos = new Curso[]{
                new Curso(){
                    Nombre="101",
                    Jornada = TiposJornada.Mañana
                },
                curso2,
                new Curso(){
                    Nombre="301",
                    Jornada = TiposJornada.Noche
                }
            };*/
            
/*
            WriteLine(escuela);
            ImprimirCursosEscuela(escuela);
            //El predicado se usa para que se pueda hacer la busqueda correspondiente devuelve un boleano
            //Predicate<Curso> miAlgoritmo = Predicado;
            //Ingerencia de tipos C# sabe que es la devolucion del boleano y por eso no marca error
            escuela.Cursos.RemoveAll(Predicado);
            //Remove all mediante el uso de delegate
            escuela.Cursos.RemoveAll(delegate (Curso cur){ return cur.Nombre == "301";});
            //Remove all mediante uso de lambda
            escuela.Cursos.RemoveAll((cur) => cur.Nombre == "501" && cur.Jornada==TiposJornada.Mañana);

            ImprimirCursosEscuela(escuela);

            static bool Predicado(Curso curso){
                return curso.Nombre=="301";
            }*/
/*
            static void ImprimirCursosWhile(Curso[] arregloCursos){
                int contador = 0;
                while(contador < arregloCursos.Length){
                    Console.WriteLine($"Id: {arregloCursos[contador].Id},Nombre: {arregloCursos[contador].Nombre}, Jornada: {arregloCursos[contador].Jornada} ");
                    contador ++;
                }
            }

            static void ImprimirCursosDoWhile(Curso[] arregloCursos){
                int contador = 0;
                do{
                    Console.WriteLine($"Id: {arregloCursos[contador].Id},Nombre: {arregloCursos[contador].Nombre}, Jornada: {arregloCursos[contador].Jornada} ");
                    contador ++;
                }while(contador < arregloCursos.Length);
            }

            static void ImprimirCursosFor(Curso[] arregloCursos){
                
                for (int i = 0; i < arregloCursos.Length; i++)
                {
                    Console.WriteLine($"Id: {arregloCursos[i].Id},Nombre: {arregloCursos[i].Nombre}, Jornada: {arregloCursos[i].Jornada} ");
                }
                
            }

            static void ImprimirCursosForEach(Curso[] arregloCursos){
                foreach (var Curso in arregloCursos)
                {
                     Console.WriteLine($"Id: {Curso.Id},Nombre: {Curso.Nombre}, Jornada: {Curso.Jornada} ");
                }
                
            }*/

            static void ImprimirCursosEscuela(Escuela escuela){
                
                /*if(escuela != null && escuela.Cursos != null){
                    foreach (Curso Curso in escuela.Cursos)
                    {
                        Console.WriteLine($"Id: {Curso.Id},Nombre: {Curso.Nombre}, Jornada: {Curso.Jornada} ");
                    }
                }*/
                if(escuela?.Cursos != null){
                    Util.Printer.WriteTitle("Datos de la Escuela");
                    Console.WriteLine(escuela);
                    Util.Printer.WriteTitle("Cursos de la Escuela");
                    foreach (Curso Curso in escuela.Cursos)
                    {
                        Console.WriteLine($"Id: {Curso.Id},Nombre: {Curso.Nombre}, Jornada: {Curso.Jornada} ");
                    }
                }
            }
        }
    }
}
