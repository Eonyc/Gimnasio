using Gym.App.Dominio; 
using System.Collections.Generic;

namespace Gym.App.Persistencia
{
    //En esta clase solo incluimos las firmas de los metodos
    public interface IRepositorioValue{
        //Compromisos, Lista de metodos a implementar
        //C = Crear
        Value createValue(Value value);
        //R = Consultar
        Value consultValue(int idValue);
        //Tenemos un objeto Enumerable que es una lst
        //Extraemos todos los datos de la tabla [Values]
        IEnumerable <Value> consultValues();
        //U = Actualizar
        Value updateValue(Value value);
        //D = Eliminar
        void deleteValue(int idValue);        
    }
}