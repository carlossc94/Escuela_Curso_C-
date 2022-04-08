namespace CoreEscuela.Util{
    //Las clases estaticas no permiten crean nuevas instancias, la clase en si funcionara como un objeto
    public static class Printer{
        public static void DibujarLinea(int tam=10){
            //Pad sirve para el relleno de los datos puedes ser right o left
            var linea = "".PadLeft(tam,'=');
            Console.WriteLine(linea);
        }

        public static void WriteTitle(string titulo){
            var tamanio = titulo.Length +4;
            DibujarLinea(tamanio);
            Console.WriteLine($"| {titulo} |");
            DibujarLinea(tamanio);
        }

        public static void Beep(int hz=3000, int tiempo=5000, int cantidad=1)
        {
            while (cantidad-- > 0){
                Console.Beep(hz,tiempo);
            }
        }

        public static void PresioneEnter(){
            Console.WriteLine("Presione ENTER para continuar");
        }
    }
}