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
            if(_diccionario.TryGetValue(LlaveDiccionario.Escuela, out IEnumerable<ObjetoEscuelaBase> lista)){
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
    }
}