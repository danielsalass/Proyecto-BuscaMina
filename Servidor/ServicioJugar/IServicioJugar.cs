using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioJugar
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioJugar" en el código y en el archivo de configuración a la vez.
    [ServiceContract (CallbackContract = typeof(ICallbackJugar))]
    public interface IServicioJugar
    {
        [OperationContract]
        String Tirar(string Cordenada);
        [OperationContract]
        string UnirseSala(string jugador);
        [OperationContract]
        string SalirSala(string jugador, int idSala);
    }
}
