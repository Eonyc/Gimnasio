using Gym.App.Dominio;
//Para manejar la BD
using System.Linq;
//IEnumerable
using System.Collections.Generic;

namespace Gym.App.Persistencia
{
    public class RepositorioRoutine:IRepositorioRoutine
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
        public Routine createRoutine(Routine routine){
            //Realiza la conexion a la BD y adiciona a la tabla
            //[Routines] los datos del obj [routine]
            var routineAdded = conexion.Routines.Add(routine);
            conexion.SaveChanges();
            //retorna la variable encapsulada como un objeto [Entity]
            return routineAdded.Entity;   
        }    
        public Routine consultRoutine(int idRoutine){
            //El parametro de FirstOrDefault(p=>p.Id == int idRoutine)
            //se encarga de realiazar la busqueda
            return conexion.Routines.FirstOrDefault(p=>p.Id == idRoutine);
        }
        public IEnumerable <Routine> consultRoutines(){
            //Retorna todo lo que tiene la consulta
            return conexion.Routines;    
        }
        public Routine updateRoutine(Routine routine){
            var routineFound = conexion.Routines.FirstOrDefault(p=>p.Id == routine.Id);
            if (routineFound != null){
                //Actualizamos los atributos de la clase [Customer]
                 routineFound.Id = routine.Id;
                 routineFound.BodyPart = routine.BodyPart;
                 routineFound.Intensity = routine.Intensity;
                 routineFound.Category = routine.Category;
                 routineFound.Duration = routine.Duration;
                 routineFound.Level = routine.Level;
                 //Se debe modificar los datos de las relaciones que tiene la Clase [Routine]   
                 routineFound.Exercise = routine.Exercise;   

                 conexion.SaveChanges();
            }
            return routineFound;
        }
        public void deleteRoutine(int idRoutine){
            var routineFound = conexion.Routines.FirstOrDefault(p=>p.Id == idRoutine);
            if (routineFound == null) return; 
          
            conexion.Routines.Remove(routineFound);
            conexion.SaveChanges();  
        }
    }
}