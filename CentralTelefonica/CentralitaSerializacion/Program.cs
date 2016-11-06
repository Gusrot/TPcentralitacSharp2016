using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentralitaSerializacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Centralita miCentralita = new Centralita("Telefonica");
            miCentralita.RutaDeArchivo = "Centralita.XML";

            //miCentralita.DeSerializarse();

            Local LlamadaUno = new Local("Gustavo", 0.3F, "Marcela", 2.65F);
            Provincial LlamadaDos = new Provincial("Florencia", Franja.Franja_1, 0.21F, "MJ");
            Local LlamadaTres = new Local("A", 0.45F, "B", 1.99F);
            Provincial LlamadaCuatro = new Provincial(Franja.Franja_3, LlamadaDos);

            try
            {
                miCentralita += LlamadaUno;
                miCentralita += LlamadaDos;
                miCentralita += LlamadaTres;
                miCentralita += LlamadaCuatro;
            }
            catch (CentralitaException x)
            {
                Console.WriteLine(x.NombreClase);
                Console.WriteLine(x.NombreMetodo);
                Console.WriteLine(x.Message);
                if (x.InnerException != null)
                    Console.WriteLine("Inner exception: " + x.InnerException);
            }
            
            Console.WriteLine(LlamadaUno.ToString());
            Console.WriteLine(LlamadaDos.ToString());
            Console.WriteLine(LlamadaTres.ToString());
            Console.WriteLine(LlamadaCuatro.ToString());

            Console.ReadLine();

            Console.Clear();

            miCentralita.ordenarLlamadas();

            Console.WriteLine("CENTRALITA ORDENADA");

            Console.WriteLine(miCentralita.ToString());

            Console.ReadLine();

            try
            {
                miCentralita.Serializarse();
            }
            catch (CentralitaException x)
            {
                Console.WriteLine(x.Message);
                Console.WriteLine(x.NombreClase);
                Console.WriteLine(x.NombreMetodo);
                if (x.ExcepcionInterna != null)
                    Console.WriteLine(x.ExcepcionInterna);
            }

            try
            {
                miCentralita.DeSerializarse();
            }
            catch (CentralitaException x)
            {
                Console.WriteLine(x.Message);
                Console.WriteLine(x.NombreClase);
                Console.WriteLine(x.NombreMetodo);
                if (x.ExcepcionInterna != null)
                    Console.WriteLine(x.ExcepcionInterna);
            }
        }
    }
}
