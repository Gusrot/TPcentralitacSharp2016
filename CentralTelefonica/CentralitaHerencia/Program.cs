using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Program
    {
        static void Main(string[] args)
        {
            Centralita miCentralita = new Centralita("Telefonica");
            Local LlamadaUno = new Local("Gustavo", 0.3F, "Marcela", 2.65F);
            Provincial LlamadaDos = new Provincial("Florencia", Franja.Franja_1, 0.21F, "MJ");
            Local LlamadaTres = new Local("A", 0.45F, "B", 1.99F);
            Provincial LlamadaCuatro = new Provincial(Franja.Franja_3, LlamadaDos);

            miCentralita.Llamadas.Add(LlamadaUno);
            miCentralita.Llamadas.Add(LlamadaDos);
            miCentralita.Llamadas.Add(LlamadaTres);
            miCentralita.Llamadas.Add(LlamadaCuatro);

            miCentralita.Mostrar();

            miCentralita.OredenarLlamadas();

            Console.ReadKey();
        }       
    }
}
