using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    public class Provincial : Llamada
    {
        protected Franja _franjaHoraria;

        #region Constructores

        public Provincial(string origen, Franja miFranja, float duracion, string destino)
            : base(origen, destino, duracion)
        {
            this._franjaHoraria = miFranja;
        }

        public Provincial(Franja miFranja, Llamada unaLlamada)
            : this(unaLlamada.NroOrigen, miFranja, unaLlamada.Duracion, unaLlamada.NroDestino)
        {

        }

        #endregion

        #region Metodos

        private float calcularCosto()
        {
            /*
             (Privado. Retornará el valor de la llamada a partir de la duración y el costo de la misma. 
             * Los valores serán: Franja_1: 0.99, Franja_2: 1.25 y Franja_3: 0.66)   
             */

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

        protected override string Mostrar()
        {
            StringBuilder sbLlamada;
            sbLlamada = new StringBuilder();

            sbLlamada.AppendLine(base.Mostrar());
            sbLlamada.AppendLine("Franja horaria: " + this._franjaHoraria);
            sbLlamada.AppendLine("Costo de llamda: " + this.CostoLlamada);

            return sbLlamada.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
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

        #region Sobrecargas

        public override bool Equals(object obj)
        {
            if (obj is Provincial)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
