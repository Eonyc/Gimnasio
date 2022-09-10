using Gym.App.Dominio;
//Para manejar la BD
using System.Linq;
//IEnumerable
using System.Collections.Generic;

namespace Gym.App.Persistencia
{
     public class RepositorioValue:IRepositorioValue
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

        public  Value createValue(Value value){
            //Realiza la conexion a la BD y adiciona a la tabla
            //[Values] los datos del obj [value]
            var valueAdded = conexion.Values.Add(value);
            conexion.SaveChanges();
            //retorna la variable encapsulada como un objeto [Entity]
            return valueAdded.Entity;     
        }
        public Value consultValue(int idValue){
            //El parametro de FirstOrDefault(p=>p.Id == int idValue)
            //se encarga de realiazar la busqueda
            return conexion.Values.FirstOrDefault(p=>p.Id == idValue);  
        }
        public IEnumerable <Value> consultValues(){
            //Retorna todo lo que tiene la consulta
            return conexion.Values;   
        }
        public Value updateValue(Value value){
            var valueFound = conexion.Values.FirstOrDefault(p=>p.Id == value.Id);
            if (valueFound != null){
                //Actualizamos los atributos de la clase [Exercise]
                 valueFound.Id = value.Id;
                 valueFound.Weight = value.Weight;
                 valueFound.Size = value.Size;
                 valueFound.Gender = value.Gender;
                 valueFound.Recommendation = value.Recommendation;
                 //Se debe modificar los datos de las relaciones que tiene la Clase [value]   
                 //routineFound.Exercise = routine.Exercise;   
                 conexion.SaveChanges();
            }
            return valueFound;  
        }
        public void deleteValue(int idValue){
            var valueFound = conexion.Values.FirstOrDefault(p=>p.Id == idValue);
            if (valueFound == null) return; 
          
            conexion.Values.Remove(valueFound);
            conexion.SaveChanges();     
        }
     }
}