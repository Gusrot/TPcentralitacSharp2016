using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    public class Local : Llamada
    {
        protected float _costo;

        #region Constructores

        public Local(string origen, float duracion, string destino, float costo)
            : base(origen, destino, duracion)
        {
            this._costo = costo;
        }

        public Local(Llamada unaLlamada, float costo)
            : this(unaLlamada.NroOrigen, unaLlamada.Duracion, unaLlamada.NroDestino, costo)
        {

        }

        #endregion

        #region Metodos

        private float calcularCosto()
        {
            float costoLlamada;

            costoLlamada = _costo * base._duracion;

            return costoLlamada;
        }

        protected override string Mostrar()
        {
            StringBuilder sbLlamada;
            sbLlamada = new StringBuilder();

            sbLlamada.AppendLine(base.Mostrar());
            sbLlamada.AppendLine("Costo de llamada: " + this.CostoLlamada);

            return sbLlamada.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

        public override bool Equals(object obj)
        {
            if (obj is Local)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Propiedades

        public override float CostoLlamada
        {
            get
            {
                return this.calcularCosto();
            }
        }

        #endregion
    }
}
