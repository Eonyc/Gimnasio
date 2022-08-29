//
using Gym.App.Dominio; 
using System.Collections.Generic;

namespace Gym.App.Persistencia
{
    //En esta clase solo incluimos las firmas de los metodos  
    public interface IRepositorioCustomer{
        //Compromisos, Lista de metodos a implementar
        //C = Crear
        Customer createCustomer(Customer customer);
        //R = Consultar
        Customer consultCustomer(int idCustomer);
        //Tenemos un objeto Enumerable que es una lst
        //Extraemos todos los datos de la tabla [Customers]
        IEnumerable <Customer> consultCustomers();
        //U = Actualizar
        Customer updateCustomer(Customer customer);
        //D = Eliminar
        void deleteCustomer(int idCustomer);        
    }  

}