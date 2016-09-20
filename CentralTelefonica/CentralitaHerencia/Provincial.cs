using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Provincial : Llamada
    {
        protected Franja _franjaHoraria;

        public float CostoLlamada
        {
            get { return CalcularCosto(); }
        }

        public Provincial(string origen, Franja miFranja, float duracion, string destino):base(origen, destino ,duracion)
        {
            _franjaHoraria = miFranja;            
        }

        private float CalcularCosto()
        {
            float costoLlamada = 0;
            //float valorFranja;

            switch (_franjaHoraria)
            {
                case Franja.Franja_1:
                    costoLlamada = 0.99F * base._duracion;
                    break;
                case Franja.Franja_2:
                    costoLlamada = 1.25F * base._duracion;
                    break;
                case Franja.Franja_3:
                    costoLlamada = 0.66F * base._duracion;
                    break;
            }

            return costoLlamada;
        }

        public Provincial(Franja miFranja, Llamada unaLlamada) : this(unaLlamada.NroOrigen, miFranja,unaLlamada.Duracion , unaLlamada.NroDestino) { }

        public void MostrarProvincial()
        {
            StringBuilder sbLlamada = new StringBuilder();

            sbLlamada.AppendLine("Duracion: " + base.Duracion);
            sbLlamada.AppendLine("Origen: " + base.NroOrigen);
            sbLlamada.AppendLine("Destino: " + base.NroDestino);
            sbLlamada.AppendLine("Franja: " + _franjaHoraria);
            sbLlamada.AppendLine("Costo: " + this.CostoLlamada);

            Console.WriteLine(sbLlamada);
        }
    }
}
