using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    class Program
    {
        static void Main(string[] args)
        {
            Centralita miCentralita = new Centralita("Telefonica");
            Local LlamadaUno = new Local("Gustavo", 0.3F, "Marcela", 2.65F);
            Provincial LlamadaDos = new Provincial("Florencia", Franja.Franja_1, 0.21F, "MJ");
            Local LlamadaTres = new Local("A", 0.45F, "B", 1.99F);
            Provincial LlamadaCuatro = new Provincial(Franja.Franja_3, LlamadaDos);

            miCentralita += LlamadaUno;
            miCentralita += LlamadaDos;
            miCentralita += LlamadaTres;
            miCentralita += LlamadaCuatro;

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
        }
    }
}
