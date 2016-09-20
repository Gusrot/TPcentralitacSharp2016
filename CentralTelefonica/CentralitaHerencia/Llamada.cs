using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Llamada
    {
        protected float _duracion;
        protected string _nroDestino;
        protected string _nroOrigen;

        public float Duracion
        {
            get { return _duracion; }
        }

        public string NroDestino
        {
            get { return _nroDestino; }
        }

        public string NroOrigen
        {
            get { return _nroOrigen; }
        }
        
        public Llamada(string origen, string destino, float duracion)
        {
            this._nroOrigen = origen;
            this._nroDestino = destino;
            this._duracion = duracion;
        }

        public void Mostrar()
        {
            StringBuilder sbLlamada = new StringBuilder();

            sbLlamada.AppendLine("Duracion: " + this.Duracion);
            sbLlamada.AppendLine("Origen: " + this.NroOrigen);
            sbLlamada.AppendLine("Destino: " + this.NroDestino);        
            
            Console.WriteLine(sbLlamada);
        }

        public int OrdenarPorDuracion(Llamada uno, Llamada dos)
        {
            throw new System.NotImplementedException();
        }
    }
}
