using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console;
namespace CoreEscuela
{
    class Program{
        static void Main(string[] args){
            EscuelaEngine escuela= new EscuelaEngine();
            escuela.Initialize();
            WriteLine("===============================");
            ImprimirCursosEscuela(escuela.Escuela);
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
                    WriteLine("==================================");
                    Console.WriteLine(escuela);
                    WriteLine("==================================");
                    WriteLine("Cursos de la Escuela:");
                    foreach (Curso Curso in escuela.Cursos)
                    {
                        Console.WriteLine($"Id: {Curso.Id},Nombre: {Curso.Nombre}, Jornada: {Curso.Jornada} ");
                    }
                }
            }
        }
    }
}
