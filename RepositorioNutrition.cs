using Gym.App.Dominio;
//Para manejar la BD
using System.Linq;
//IEnumerable
using System.Collections.Generic;

namespace Gym.App.Persistencia
{
    public class RepositorioNutrition:IRepositorioNutrition
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
        public Nutrition createNutrition(Nutrition nutrition){
            //Realiza la conexion a la BD y adiciona a la tabla
            //[Nutritions] los datos del obj [nutrition]
            var nutritionAdded = conexion.Nutritions.Add(nutrition);
            conexion.SaveChanges();
            //retorna la variable encapsulada como un objeto [Entity]
            return nutritionAdded.Entity; 
        }
        public Nutrition consultNutrition(int idNutrition){
            //El parametro de FirstOrDefault(p=>p.Id == int idNutrition)
            //se encarga de realiazar la busqueda
            return conexion.Nutritions.FirstOrDefault(p=>p.Id == idNutrition);
        }
        public IEnumerable <Nutrition> consultNutritions(){
            //Retorna todo lo que tiene la consulta
            return conexion.Nutritions;    
        }
        public Nutrition updateNutrition(Nutrition nutrition){
            var nutritionFound = conexion.Nutritions.FirstOrDefault(p=>p.Id == nutrition.Id);
            if (nutritionFound != null){
                //Actualizamos los atributos de la clase [Exercise]
                 nutritionFound.Id = nutrition.Id;
                 nutritionFound.Eat = nutrition.Eat;
                 nutritionFound.NumberOfDays = nutrition.NumberOfDays;
                 //nutritionFound.Menu = nutrition.Menu;
                 //Se debe modificar los datos de las relaciones que tiene la Clase [Nutrition]   
                 nutritionFound.Diets = nutrition.Diets;
                 
                 conexion.SaveChanges();
            }
            return nutritionFound;
        }
        public void deleteNutrition(int idNutrition){
            var nutritionFound = conexion.Nutritions.FirstOrDefault(p=>p.Id == idNutrition);
            if (nutritionFound == null) return; 
          
            conexion.Nutritions.Remove(nutritionFound);
            conexion.SaveChanges();     
        }
    }
}