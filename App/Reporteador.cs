using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        //Pr convencion las variables publicas pueden ir con un underline
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> diccionario){
            if (diccionario == null) throw new ArgumentNullException(nameof(diccionario));
            _diccionario=diccionario;
        }

        public IEnumerable<Evaluacion> GetListaEvaluaciones(){
            IEnumerable<Evaluacion> rta;
            //Si no encuentra el valor trae un valor por defecto del tipo de la variable
            //var lista =_diccionario.GetValueOrDefault(LlaveDiccionario.Escuela);
            if(_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista)){
                return lista.Cast<Evaluacion>();
            }else{
                return new List<Evaluacion>();
            }

        }

        public IEnumerable<Escuela> GetListaEscuela(){
            IEnumerable<Escuela> rta;
            //Si no encuentra el valor trae un valor por defecto del tipo de la variable
            //var lista =_diccionario.GetValueOrDefault(LlaveDiccionario.Escuela);
            if(_diccionario.TryGetValue(LlaveDiccionario.Escuela, out IEnumerable<ObjetoEscuelaBase> lista)){
                return lista.Cast<Escuela>();
            }else{
                return new List<Escuela>();
            }
        }

        public IEnumerable<String> GetListaAsignatura(out IEnumerable<Evaluacion> listaEvaluacion){
            listaEvaluacion = GetListaEvaluaciones();
        
            //LinQ donde hay where select
            //Revisar Comparer y comparison
           return (from Evaluacion ev in listaEvaluacion
                    where ev.Nota >= 40
                    select ev.Asignatura.Nombre).Distinct();
        }

        public IEnumerable<String> GetListaAsignatura(){
            return GetListaAsignatura(out var dummy);
        }

        public Dictionary<string,IEnumerable<Evaluacion>> GetDiccionarioEvaluaxAsignatura(){
            var dictaRta = new Dictionary<string,IEnumerable<Evaluacion>>();

            var listaAsignatura = GetListaAsignatura(out var listaEval);

            foreach (var asignatura in listaAsignatura)
            {
                var evalAsig = from eval in listaEval
                                where eval.Asignatura.Nombre == asignatura 
                                select eval;

                dictaRta.Add(asignatura,evalAsig);
            }


            return dictaRta;
        }

        public Dictionary<string,IEnumerable<AlumnoPromedio>> GetPromedioAlumnoXAsignatura(){
            var rta = new Dictionary<string,IEnumerable<AlumnoPromedio>>();
            var dicEvalXAsig= GetDiccionarioEvaluaxAsignatura();
            foreach (var asigConEval in dicEvalXAsig)
            {
                //LinQ se puede devolver un objeto compuesto
                var promedioAlumnos = from eval in asigConEval.Value
                            group eval by new{eval.Alumno.Id, eval.Alumno.Nombre }
                            into grupoEvalAlumno
                            select new AlumnoPromedio
                            {   
                                AlumnoId = grupoEvalAlumno.Key.Id,
                                AlumnoNombre = grupoEvalAlumno.Key.Nombre,
                                Promedio = grupoEvalAlumno.Average(evaluacion => evaluacion.Nota)
                            };

                rta.Add(asigConEval.Key,promedioAlumnos);
                /*
                var dummy = from eval in asigConEval.Value
                group eval by eval.Alumno.Id 
                            into grupoEvalAlumno
                            select new 
                            {   eval.Alumno.Id,
                                AlumnoNombre = eval.Alumno.Nombre,
                                EvalNombre = eval.Nombre,
                                eval.Nota
                            };
                */
            }
            return rta;
        }

        public Dictionary<string,IEnumerable<AlumnoPromedio>> GetBestAverageStudentXAssesment(int registro){
            var Average = GetPromedioAlumnoXAsignatura();
            var rta= new Dictionary<string,IEnumerable<AlumnoPromedio>>();
            foreach (var best in Average)
            {
                var bestAverage = (from bave in best.Value
                                    orderby bave.Promedio descending
                                    select bave).Take(registro);
                
                rta.Add(best.Key,bestAverage);
            }
            
            return rta;
        }
    }
}