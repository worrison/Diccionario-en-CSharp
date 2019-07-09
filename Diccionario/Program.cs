using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario
{
    class Palabra : IEquatable<Palabra>
    {
        public string palabra { get; set; }
        public string descripcion { get; set; }
        public string tipoPalabra { get; set; }
        public bool Equals(Palabra other)
        {
            return this.palabra == other.palabra && this.descripcion == other.descripcion;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Palabra> diccionario = new SortedDictionary<string, Palabra>();

            Console.WriteLine("Que Desea hacer hoy?");
            int option;
            do
            {
                Console.WriteLine("*************************Menu******************************");
                Console.WriteLine("* Pulse 1 para Introducir una palabra nueva al Dicionario *");
                Console.WriteLine("* Pulse 2 para Buscar una palabra en el diccionario       *");
                Console.WriteLine("* Pulse 0 para Salir                                      *");
                Console.WriteLine("***********************************************************");
                option = Int32.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:nuevaPalabra(ref diccionario);break;
                    case 2:buscarPalabra(ref diccionario); break;
                    case 0:Console.WriteLine("Hasta pronto"); break;
                }
            }while(option!=0);
            
        }

        public static void nuevaPalabra(ref SortedDictionary<string, Palabra> diccionario)
        {
            Console.WriteLine("Introduzca la nueva palabra");
            string palabra = Console.ReadLine();
            Console.WriteLine("Introduzca la descripcion de la nueva palabra");
            string descripcion = Console.ReadLine();
            Console.WriteLine("Introduzca el tipo de palabra que es");
            string tipoPalabra = Console.ReadLine();

            diccionario.Add(palabra, new Palabra() { palabra = palabra, descripcion = descripcion, tipoPalabra = tipoPalabra });

            foreach (KeyValuePair<string, Palabra> item in diccionario)
            {

                Console.WriteLine("Key: {0}, Palabra: {1},Descripción: {2},Tipo de palabra: {3}", item.Key, item.Value.palabra, item.Value.descripcion, item.Value.tipoPalabra);
            }
        }
       
        public static void buscarPalabra(ref SortedDictionary<string, Palabra> diccionario)
        {
            Console.WriteLine("Introduzca la palabra ha buscar");
            Palabra p = new Palabra();
            p.palabra=Console.ReadLine();
 
            if (diccionario.TryGetValue(p.palabra, out p))
            {
                Console.WriteLine("For key = \"palabra\", value = {0}.", p.palabra);
                Console.WriteLine("For key = \"descripcion\", value = {1}.", p.descripcion);
                Console.WriteLine("For key = \"tipoPalabra\", value = {2}.", p.tipoPalabra);
            }
            else
            {
                Console.WriteLine("Key = \"palabra\" is not found.");
            }  
        }
    }
}
