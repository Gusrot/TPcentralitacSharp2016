using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentralitaSerializacion
{
    interface ISerializable
    {
        bool DeSerializarse();
        bool Serializarse();

        string RutaDeArchivo { get; set; }
    }
}
