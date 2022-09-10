using Gym.App.Dominio;
//Para manejar la BD
using System.Linq;
//IEnumerable
using System.Collections.Generic;

namespace Gym.App.Persistencia
{
    public class RepositorioExercise:IRepositorioExercise
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
        public Exercise createExercise(Exercise exercise){
            //Realiza la conexion a la BD y adiciona a la tabla
            //[Exercises] los datos del obj [exercise]
            var exerciseAdded = conexion.Exercises.Add(exercise);
            conexion.SaveChanges();
            //retorna la variable encapsulada como un objeto [Entity]
            return exerciseAdded.Entity;     
        } 
        public Exercise consultExercise(int idExercise){
            //El parametro de FirstOrDefault(p=>p.Id == int idExercise)
            //se encarga de realiazar la busqueda
            return conexion.Exercises.FirstOrDefault(p=>p.Id == idExercise);
        }
        public IEnumerable <Exercise> consultExercises(){
            //Retorna todo lo que tiene la consulta
            return conexion.Exercises;   
        }
        public Exercise updateExercise(Exercise exercise){
            var exerciseFound = conexion.Exercises.FirstOrDefault(p=>p.Id == exercise.Id);
            if (exerciseFound != null){
                //Actualizamos los atributos de la clase [Exercise]
                 exerciseFound.Id = exercise.Id;
                 exerciseFound.Name = exercise.Name;
                 exerciseFound.Series = exercise.Series;
                 exerciseFound.Repetitions = exercise.Repetitions;
                 exerciseFound.CaloriesConsumed = exercise.CaloriesConsumed;
                 //Se debe modificar los datos de las relaciones que tiene la Clase [Exercise]   
                 //routineFound.Exercise = routine.Exercise;   
                 conexion.SaveChanges();
            }
            return exerciseFound;
        }
        public void deleteExercise(int idExercise){
            var exerciseFound = conexion.Exercises.FirstOrDefault(p=>p.Id == idExercise);
            if (exerciseFound == null) return; 
          
            conexion.Exercises.Remove(exerciseFound);
            conexion.SaveChanges();   
        }
    }    
}