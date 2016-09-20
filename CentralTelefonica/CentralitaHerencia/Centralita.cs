using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Centralita
    {
        private List<Llamada> _ListaDeLlamadas;
        protected string _razonSocial;
        float ganancia = 0;

        public float GananciaPorLocal
        {
            get { return this.CalcularGanancia(TipoLlamada.Local); }
        }
        
        public float GananciaPorProvincial
        {
            get { return CalcularGanancia(TipoLlamada.Provincial); }
        }

        public float GananciaTotal
        {
            get { return CalcularGanancia(TipoLlamada.Todas); }
        }

        public List<Llamada> Llamadas
        {
            get { return this._ListaDeLlamadas; }
        }

        private float CalcularGanancia(TipoLlamada tipo)
        {       
            switch(tipo)
            {
                case TipoLlamada.Local:
                    {
                        ganancia = this.GananciaPorLocal;
                        break;
                    }
                case TipoLlamada.Provincial:
                    {
                        ganancia = this.GananciaPorProvincial;
                        break;
                    }
                case TipoLlamada.Todas:
                    {
                        ganancia = this.GananciaTotal;
                        break;
                    }
                    
            }

            return ganancia;
        }

        public Centralita()
        {
            this._ListaDeLlamadas = new List<Llamada>();
        }

        public Centralita(string nombreEmpresa) : this()
        {
            this._razonSocial = nombreEmpresa;
        }

        public void Mostrar()
        {
            foreach (Llamada item in _ListaDeLlamadas)
            {
                item.Mostrar();
            }

            StringBuilder sbCentralita = new StringBuilder();

            sbCentralita.AppendLine("Razon social: " + this._razonSocial);
            sbCentralita.AppendLine("Ganancia por local: " + GananciaPorLocal);
            sbCentralita.AppendLine("Ganancia por provincial: " + GananciaPorProvincial);
            sbCentralita.AppendLine("Ganancia total: " + GananciaTotal);

            Console.WriteLine(sbCentralita);
            
        }

        public void OredenarLlamadas()
        {
            throw new System.NotImplementedException();
        }
    }
}
