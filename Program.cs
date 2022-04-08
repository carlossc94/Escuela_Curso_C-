using System;
using System.Collections.Generic;
using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;
namespace CoreEscuela
{
    class Program{
        static void Main(string[] args){
            //Evantos puede tener varios delegados 
                //Se agrega primer delegado
            AppDomain.CurrentDomain.ProcessExit += AccionEventoExit;
                //Otro metodo de agregar delegado
            AppDomain.CurrentDomain.ProcessExit += (o,s)=> Printer.Beep(2000,1000,1);
                //Quitar delegados ya implementados
            AppDomain.CurrentDomain.ProcessExit -= AccionEventoExit;

            EscuelaEngine escuela= new EscuelaEngine();
            escuela.Initialize();
            //Printer.Beep(32000,5000,1);
            Printer.WriteTitle("Bienvenidos a la Escuela");
            var Reporteador = new Reporteador(escuela.GetDiccionarioObjetos());
            var evalList = Reporteador.GetListaEvaluaciones();
            var asigList = Reporteador.GetListaAsignatura();
            var listaEvalXAsig = Reporteador.GetDiccionarioEvaluaxAsignatura();
            var listaPromedioAlumnoXAsignatura= Reporteador.GetPromedioAlumnoXAsignatura();
            var listaMejoresPromedioAlumnoXAsignatura= Reporteador.GetBestAverageStudentXAssesment(15);
            ImprimirCursosEscuela(escuela.Escuela); 
            Printer.WriteTitle("Captura de una evaluacion por Consola");
            var newEval = new Evaluacion();
            string nombre;
            string notaString;

            WriteLine("Ingrese el nombre de la evaluacion");
            Printer.PresioneEnter();
            nombre= Console.ReadLine();
            if(string.IsNullOrEmpty(nombre)){
                Printer.WriteTitle("El nombre de la evaluacion no puede estar vacio");
                WriteLine("Saliendo del programa");
            }else{
                newEval.Nombre=nombre.ToLower();
                WriteLine("El nombre de la evaluacion ha sido ingresado correctamente");
            }

            WriteLine("Ingrese la nota de la evaluacion");
            Printer.PresioneEnter();
            notaString = Console.ReadLine();
            if(string.IsNullOrEmpty(notaString)){
                Printer.WriteTitle("El valor de la nota no puede estar vacio");
                WriteLine("Saliendo del programa");
            }else{
                try{
                    newEval.Nota=float.Parse(notaString);
                    if(newEval.Nota < 0 || newEval.Nota >100){
                        throw new ArgumentOutOfRangeException ("El rango de las notas debe ser entre 0 y 5");
                    }
                    WriteLine("La nota de la evaluacion ha sido ingresado correctamente");
                }catch(ArgumentOutOfRangeException ex){
                    Printer.WriteTitle(ex.Message);
                    WriteLine("Saliendo del programa");
                }
                catch(Exception ex){
                    Printer.WriteTitle("El valor de la nota no es un numero");
                    WriteLine("Saliendo del programa");
                }
                finally{
                    
                }
            }
            /*Datos con Diccionarios
            ImprimirCursosEscuela(escuela.Escuela); 
            var dictmp = escuela.GetDiccionarioObjetos();

            escuela.ImprimirDiccionario(dictmp,true);*/
            /*Uso de Diccionarios (clave, valor), las llaves de los diccionarios son irrepetibles*/
            

            /*Ejemplo Diccionario
            Dictionary<int,string> diccionario = new Dictionary<int, string>();
            diccionario.Add(10,"Carlos");
            diccionario.Add(11,"Noemi");
 

            /*Sobrecarga de objetos*/
            
            //var listaObjetos = escuela.GetObjetosEscuela(out int conteoEvaluaciones, out int conteoCursos,out int conteoAsignaturas, out int conteoAlumnos);
            
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

        private static void AccionEventoExit(object? sender, EventArgs e)
        {
            Printer.WriteTitle("Saliendo del programa");
            Printer.Beep(1000,cantidad:3);
            Printer.WriteTitle("Salio del programa");
        }
    }
}
