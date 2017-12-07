using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioJugar
{
    //Es para soportar otras conexiones
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class ServicioJugar : IServicioJugar
    {
        //Diccionario de jugadores conectados
        public Dictionary<string, ICallbackJugar> UsuariosEnLinea = new Dictionary<string, ICallbackJugar>();

        public string SalirSala(string jugador, int idSala)
        {
            throw new NotImplementedException();
        }

        public string Tirar(string Coordenada)
        {
            throw new NotImplementedException();
        }

        public string UnirseSala(string jugador)
        {
            ICallbackJugar x = OperationContext.Current.GetCallbackChannel<ICallbackJugar>();
            UsuariosEnLinea.Add(jugador, x);
            return "Conexion estableccida";
            
        }

    }
}
