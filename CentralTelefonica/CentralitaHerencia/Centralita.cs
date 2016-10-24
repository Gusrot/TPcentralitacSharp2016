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

        public float GananciaPorLocal
        {
            get { return this.CalcularGanancia(TipoLlamada.Local); }
        }
        
        public float GananciaPorProvincial
        {
            get { return this.CalcularGanancia(TipoLlamada.Provincial); }
        }

        public float GananciaTotal
        {
            get { return this.CalcularGanancia(TipoLlamada.Todas); }
        }

        public List<Llamada> Llamadas
        {
            get { return this._ListaDeLlamadas; }
        }

        private float CalcularGanancia(TipoLlamada tipo)
        {
            float aux1 = 0;
            float aux2 = 0;

            switch(tipo)
            {
                case TipoLlamada.Local:
                    {
                        Local local;

                        foreach (var item in this._ListaDeLlamadas)
                        {
                            if (item is Local)
                            {
                                local = (Local)item;
                                aux1 += local.CostoLlamada;
                            }                               
                        }

                        break;
                    }
                case TipoLlamada.Provincial:
                    {
                        Provincial provincial;

                        foreach (var item in this._ListaDeLlamadas)
                        {
                            if (item is Provincial)
                            {
                                provincial = (Provincial)item;
                                aux1 += provincial.CostoLlamada;
                            }
                        }

                        break;
                    }
                case TipoLlamada.Todas:
                    {
                        Local local;
                        Provincial provincial;

                        foreach (var item in this._ListaDeLlamadas)
                        {
                            if (item is Local)
                            {
                                local = (Local)item;
                                aux1 += local.CostoLlamada;
                            }
                        }
                        foreach (var item in this._ListaDeLlamadas)
                        {
                            if (item is Provincial)
                            {
                                provincial = (Provincial)item;
                                aux2 += provincial.CostoLlamada;
                            }
                        }
                        break;
                    }
                    
            }

            return aux1 + aux2;
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
            this._ListaDeLlamadas.Sort(Llamada.OrdenarPorDuracion);

            this.Mostrar();
        }
    }
}
