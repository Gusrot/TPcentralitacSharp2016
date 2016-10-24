using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Local : Llamada
    {
        protected float _costo;

        public float CostoLlamada
        {
            get { return CalcularCosto(); }
        }

        private float CalcularCosto()
        {
            float costoLlamada;

            costoLlamada = this._costo * base._duracion;

            return costoLlamada;
        }

        public Local(Llamada unaLlamada, float costo) : this(unaLlamada.NroOrigen,unaLlamada.Duracion,unaLlamada.NroDestino,costo) { }

        public Local(string origen, float duracion, string destino, float costo) : base(origen,destino,duracion)
        {
            this._costo = costo;
        }

        public void MostrarLocal()
        {
            StringBuilder sbLlamda = new StringBuilder();

            sbLlamda.AppendLine("Duracion: " + base.Duracion);
            sbLlamda.AppendLine("Origen: " + base.NroOrigen);
            sbLlamda.AppendLine("Destino: " + base.NroDestino);
            sbLlamda.AppendLine("Costo: " + this.CostoLlamada);

            Console.WriteLine(sbLlamda);
        }
    }
}
