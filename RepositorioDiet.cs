using Gym.App.Dominio;
//Para manejar la BD
using System.Linq;
//IEnumerable
using System.Collections.Generic;

namespace Gym.App.Persistencia
{
    public class RepositorioDiet:IRepositorioDiet
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
        public Diet createDiet(Diet diet){
            //Realiza la conexion a la BD y adiciona a la tabla
            //[Diets] los datos del obj [diet]
            var dietAdded = conexion.Diets.Add(diet);
            conexion.SaveChanges();
            //retorna la variable encapsulada como un objeto [Entity]
            return dietAdded.Entity; 
        }
        public Diet consultDiet(int idDiet){
            //El parametro de FirstOrDefault(p=>p.Id == int idDiet)
            //se encarga de realiazar la busqueda
            return conexion.Diets.FirstOrDefault(p=>p.Id == idDiet);
        }
        public IEnumerable <Diet> consultDiets(){
            //Retorna todo lo que tiene la consulta
            return conexion.Diets;    
        }
        public Diet updateDiet(Diet diet){
            var dietFound = conexion.Diets.FirstOrDefault(p=>p.Id == diet.Id);
            if (dietFound != null){
                //Actualizamos los atributos de la clase [Diet]
                 dietFound.Id = diet.Id;
                 //dietFound.Name = nutrition.Name;
                 dietFound.Line = diet.Line;
                 dietFound.Day = diet.Day;
                 dietFound.Menu = diet.Menu;
                 
                 conexion.SaveChanges();
            }
            return dietFound;
        }
        public void deleteDiet(int idDiet){
            var dietFound = conexion.Diets.FirstOrDefault(p=>p.Id == idDiet);
            if (dietFound == null) return; 
          
            conexion.Diets.Remove(dietFound);
            conexion.SaveChanges();     
        }
    
    }
}