using Gym.App.Dominio;
//Para manejar la BD
using System.Linq;
//IEnumerable
using System.Collections.Generic;

namespace Gym.App.Persistencia
{
    public class RepositorioTracking:IRepositorioTracking
    {
        //Para poder ejecutar el metodo CRUD debemos hacer la
        //conexion a la BD

        //Se deshabilita porque ya estamos usando el servicio [Singlenton]
        //private readonly AppContext conexion;
        //Ahora inicializamos la variable para que pueda consumir el servicio
        private readonly AppContext conexion = new AppContext();

        //El constructor [RepositorioCustomer] es util mientras utilicemos
        //la capa de [Consola]; al momento de implementar la capa de [Presentacion]
        //y consumir el servicio [Singlenton] de la clase [Startup] la
        //Eliminamos o deshabilitamos.        
        //public RepositorioCustomer(AppContext appContext){
        //    this.conexion = appContext;
        //}
        public Tracking createTracking(Tracking tracking){
            //Realiza la conexion a la BD y adiciona a la tabla
            //[Trackings] los datos del obj [tracking]
            var trackingAdded = conexion.Trackings.Add(tracking);
            conexion.SaveChanges();
            //retorna la variable encapsulada como un objeto [Entity]
            return trackingAdded.Entity;     
        }
        public Tracking consultTracking(int idTracking){
            //El parametro de FirstOrDefault(p=>p.Id == int idTracking)
            //se encarga de realiazar la busqueda
            return conexion.Trackings.FirstOrDefault(p=>p.Id == idTracking);
            //var pacienteEncontrado = conexion.Pacientes.FirstOrDefault(p=>p.Id==idPaciente);            
            //if (pacienteEncontrado != null){
            //    return pacienteEncontrado; 
            //}
        }
        public IEnumerable <Tracking> consultTrackings(){
            //Retorna todo lo que tiene la consulta
            return conexion.Trackings;
        }
        public Tracking updateTracking(Tracking tracking){
            var trackingFound = conexion.Trackings.FirstOrDefault(p=>p.Id == tracking.Id);
            if (trackingFound != null){
                //Actualizamos los atributos de la clase [Customer]
                 trackingFound.Id = tracking.Id;
                 trackingFound.TrackingDate = tracking.TrackingDate;
                 trackingFound.State = tracking.State;
                 //Se debe modificar los datos de las relaciones que tiene la Clase [Tracking]   
                 //customerFound.Credential = customer.Credential;   
                 conexion.SaveChanges();
            }
            return trackingFound;    
        }
        public void deleteTracking(int idTracking){
          var trackingFound = conexion.Trackings.FirstOrDefault(p=>p.Id == idTracking);
          if (trackingFound == null) return; 
          
          conexion.Trackings.Remove(trackingFound);
          conexion.SaveChanges();  
        }
    }
}