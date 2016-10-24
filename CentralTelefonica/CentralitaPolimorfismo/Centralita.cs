using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    public class Centralita
    {
        private List<Llamada> _listaDeLlamadas;
        protected string _razonSocial;

        #region Constructores

        public Centralita()
        {
            _listaDeLlamadas = new List<Llamada>();
        }

        public Centralita(string nombreEmpresa)
            : this()
        {
            this._razonSocial = nombreEmpresa;
        }

        #endregion

        #region Metodos

        private float calcularGanancia(TipoLlamada tipo)
        {
            float gananciaProvincial = 0;
            float gananciaLocal = 0;
            float gananciaTotal;
            Provincial auxProvincial;
            Local auxLocal;

            switch (tipo)
            {
                case TipoLlamada.Local:
                    foreach (Llamada item in this._listaDeLlamadas)
                    {
                        if (item.GetType() == typeof(Local))
                        {
                            auxLocal = (Local)item;
                            gananciaLocal = auxLocal.CostoLlamada;
                        }
                    }
                    break;
                case TipoLlamada.Provincial:
                    foreach (Llamada item in this._listaDeLlamadas)
                    {
                        if (item.GetType() == typeof(Provincial))
                        {
                            auxProvincial = (Provincial)item;
                            gananciaProvincial = auxProvincial.CostoLlamada;
                        }
                    }
                    break;
                case TipoLlamada.Todas:
                    foreach (Llamada item in this._listaDeLlamadas)
                    {
                        if (item.GetType() == typeof(Local))
                        {
                            auxLocal = (Local)item;
                            gananciaLocal = auxLocal.CostoLlamada;
                        }

                        if (item.GetType() == typeof(Provincial))
                        {
                            auxProvincial = (Provincial)item;
                            gananciaProvincial = auxProvincial.CostoLlamada;
                        }
                    }
                    break;
            }

            gananciaTotal = gananciaProvincial + gananciaLocal;

            return gananciaTotal;
        }

        public override string ToString()
        {
            Provincial auxProvincial;
            Local auxLocal;
            StringBuilder sbGanancias;
            sbGanancias = new StringBuilder();

            foreach (Llamada item in this._listaDeLlamadas)
            {
                if (item.GetType() == typeof(Local))
                {
                    auxLocal = (Local)item;
                    auxLocal.ToString();
                }

                if (item.GetType() == typeof(Provincial))
                {
                    auxProvincial = (Provincial)item;
                    auxProvincial.ToString();
                }
            }

            sbGanancias.AppendLine("-----CENTRALITA-----");
            sbGanancias.AppendLine("Razon social: " + this._razonSocial);
            sbGanancias.AppendLine("Ganancias locales: " + this.GananciaPorLocal);
            sbGanancias.AppendLine("Ganancias provinciales: " + this.GananciaPorProvincial);
            sbGanancias.AppendLine("Ganancias totales: " + this.GananciaTotal);
            sbGanancias.AppendLine();
            sbGanancias.AppendLine("LLAMADAS REALIZADAS:");

            foreach (Llamada item in this._listaDeLlamadas)
            {
                sbGanancias.AppendLine(item.ToString());
                sbGanancias.AppendLine("------------------------");
            }

            return sbGanancias.ToString();
        }

        public void ordenarLlamadas()
        {
            this._listaDeLlamadas.Sort(Llamada.ordenarPorDuracion);
        }

        private void AgregarLlamada(Llamada unaLlamada)
        {
            if (this._listaDeLlamadas.Count == 0)
            {
                this._listaDeLlamadas.Add(unaLlamada);
            }
            else
            {
                for (int i = 0; i < this._listaDeLlamadas.Count; i++)
                {
                    if (this._listaDeLlamadas[i] == unaLlamada)
                    {
                        return;
                    }
                    else
                    {
                        this._listaDeLlamadas.Add(unaLlamada);
                    }
                }
            }

        }

        #endregion

        #region Propiedades

        public float GananciaPorLocal
        {
            get
            {
                return this.calcularGanancia(TipoLlamada.Local);
            }
        }

        public float GananciaPorProvincial
        {
            get
            {
                return this.calcularGanancia(TipoLlamada.Provincial);
            }
        }

        public float GananciaTotal
        {
            get
            {
                return this.calcularGanancia(TipoLlamada.Todas);
            }
        }

        public List<Llamada> Llamadas
        {
            get
            {
                return this._listaDeLlamadas;
            }
        }

        #endregion

        #region Sobrecargas

        public static bool operator ==(Centralita unaCentralita, Llamada unaLlamada)
        {
            foreach (Llamada item in unaCentralita._listaDeLlamadas)
            {
                if (item == unaLlamada)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Centralita unaCentralita, Llamada unaLlamada)
        {
            foreach (Llamada item in unaCentralita._listaDeLlamadas)
            {
                if (item != unaLlamada)
                {
                    return true;
                }
            }

            return false;
        }

        public static Centralita operator +(Centralita unaCentralita, Llamada unaLlamada)
        {
            if (unaCentralita == unaLlamada)
            {
                Console.WriteLine("La llamada ya existe");
            }
            else
            {
                unaCentralita.AgregarLlamada(unaLlamada);
            }

            return unaCentralita;
        }

        #endregion
    }
}
