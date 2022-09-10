//
using Gym.App.Dominio; 
using System.Collections.Generic;

namespace Gym.App.Persistencia
{
    //En esta clase solo incluimos las firmas de los metodos  
    public interface IRepositorioNutrition{
        //Compromisos, Lista de metodos a implementar
        //C = Crear
        Nutrition createNutrition(Nutrition nutrition);
        //R = Consultar
        Nutrition consultNutrition(int idNutrition);
        //Tenemos un objeto Enumerable que es una lst
        //Extraemos todos los datos de la tabla [Nutritions]
        IEnumerable <Nutrition> consultNutritions();
        //U = Actualizar
        Nutrition updateNutrition(Nutrition nutrition);
        //D = Eliminar
        void deleteNutrition(int idNutrition);        
    }  
}