//
using Gym.App.Dominio; 
using System.Collections.Generic;

namespace Gym.App.Persistencia
{
    //En esta clase solo incluimos las firmas de los metodos  
    public interface IRepositorioExercise{
        //Compromisos, Lista de metodos a implementar
        //C = Crear
        Exercise createExercise(Exercise exercise);
        //R = Consultar
        Exercise consultExercise(int idExercise);
        //Tenemos un objeto Enumerable que es una lst
        //Extraemos todos los datos de la tabla [Exercises]
        IEnumerable <Exercise> consultExercises();
        //U = Actualizar
        Exercise updateExercise(Exercise exercise);
        //D = Eliminar
        void deleteExercise(int idExercise);        
    }  

}