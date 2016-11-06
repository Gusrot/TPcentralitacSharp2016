using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace CentralitaSerializacion
{
    public class Centralita:ISerializable
    {
        private List<Llamada> _listaDeLlamadas;
        protected string _razonSocial;
        private string _ruta;

        #region Constructores

        public Centralita()
        {
            this._listaDeLlamadas = new List<Llamada>();
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

        public bool Serializarse()
        {
            bool flag = false;

            using (XmlTextWriter escritor = new XmlTextWriter(RutaDeArchivo, Encoding.UTF8))
            {
                try
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(List<Llamada>));
                    serializador.Serialize(escritor, this._listaDeLlamadas);
                    flag = true;
                }
                catch (CentralitaException x)
                {
                    throw new CentralitaException(x.Message, "Centralita", "Serializarse", x.InnerException);
                }
            }          

            return flag;
        }

        public bool DeSerializarse()
        {
            List<Llamada> listaLlamadas = new List<Llamada>();
            bool flag = false;

            using (XmlTextReader lector = new XmlTextReader(this.RutaDeArchivo))
            {
                try
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(Llamada));
                    listaLlamadas = (List<Llamada>)serializador.Deserialize(lector);
                    this._listaDeLlamadas = listaLlamadas;
                    flag = true;
                }
                catch (CentralitaException x)
                {
                    throw new CentralitaException("El archivo no existe", "Centralita", "DeSerializarse", x.InnerException);
                }
            }
            
            return flag;
        }

        private bool GuardarEnArchivo(Llamada unaLlamada, bool agrego)
        {
            StreamWriter sw = null;

            bool flag = false;

            try
            {
                sw = new StreamWriter(this.RutaDeArchivo, agrego);
                sw.Write(unaLlamada.ToString());
                flag = true;
            }
            catch (CentralitaException x)
            {
                throw new CentralitaException(x.Message, "Centralita", "GuardarEnArchivo", x.InnerException);
            }
            finally
            {
                sw.Close();
            }

            return flag;
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

        public string RazonSocial
        {
            get { return this._razonSocial; }
            set { this._razonSocial = value; }
        }

        public string RutaDeArchivo
        {
            get { return this._ruta; }
            set { this._ruta = value; }
        }
        #endregion

        #region Sobrecargas

        public static bool operator ==(Centralita unaCentralita, Llamada unaLlamada)
        {
            foreach (Llamada item in unaCentralita.Llamadas)
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
            return !(unaCentralita == unaLlamada);
        }

        public static Centralita operator +(Centralita unaCentralita, Llamada unaLlamada)
        {
  
            if (unaCentralita == unaLlamada)
            {
                throw new CentralitaException("La llamada ya existe", "Centralita", "Operator +");           
            }
            else
            {
                unaCentralita.AgregarLlamada(unaLlamada);
                return unaCentralita;
            }
        }

        #endregion
    }
}
