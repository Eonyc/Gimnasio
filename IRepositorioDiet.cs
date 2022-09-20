//
using Gym.App.Dominio; 
using System.Collections.Generic;

namespace Gym.App.Persistencia
{
    //En esta clase solo incluimos las firmas de los metodos  
    public interface IRepositorioDiet{
        //Compromisos, Lista de metodos a implementar
        //C = Crear
        Diet createDiet(Diet diet);
        //R = Consultar
        Diet consultDiet(int idDiet);
        //Tenemos un objeto Enumerable que es una lst
        //Extraemos todos los datos de la tabla [Nutritions]
        IEnumerable <Diet> consultDiets();
        //U = Actualizar
        Diet updateDiet(Diet diet);
        //D = Eliminar
        void deleteDiet(int idDiet);        
    }  
}