//
using Gym.App.Dominio; 
using System.Collections.Generic;

namespace Gym.App.Persistencia
{
    //En esta clase solo incluimos las firmas de los metodos  
    public interface IRepositorioRoutine{
        //Compromisos, Lista de metodos a implementar
        //C = Crear
        Routine createRoutine(Routine routine);
        //R = Consultar
        Routine consultRoutine(int idRoutine);
        //Tenemos un objeto Enumerable que es una lst
        //Extraemos todos los datos de la tabla [Routines]
        IEnumerable <Routine> consultRoutines();
        //U = Actualizar
        Routine updateRoutine(Routine routine);
        //D = Eliminar
        void deleteRoutine(int idRoutine);        
    }  

}