//
using Gym.App.Dominio; 
using System.Collections.Generic;

namespace Gym.App.Persistencia
{
    //En esta clase solo incluimos las firmas de los metodos  
    public interface IRepositorioTracking{
        //Compromisos, Lista de metodos a implementar
        //C = Crear
        Tracking createTracking(Tracking tracking);
        //R = Consultar
        Tracking consultTracking(int idTracking);
        //Tenemos un objeto Enumerable que es una lst
        //Extraemos todos los datos de la tabla [Trackings]
        IEnumerable <Tracking> consultTrackings();
        //U = Actualizar
        Tracking updateTracking(Tracking tracking);
        //D = Eliminar
        void deleteTracking(int idTracking);        
    }  

}