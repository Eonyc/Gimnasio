using Gym.App.Dominio;
//Para manejar la BD
using System.Linq;
//IEnumerable
using System.Collections.Generic;

namespace Gym.App.Persistencia
{
    public class RepositorioCustomer:IRepositorioCustomer
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

        public Customer createCustomer(Customer customer){
            //Realiza la conexion a la BD y adiciona a la tabla
            //[Customers] los datos del obj [customer]
            var customerAdded = conexion.Customers.Add(customer);
            conexion.SaveChanges();
            //retorna la variable encapsulada como un objeto [Entity]
            return customerAdded.Entity; 
        }

        public Customer consultCustomer(int idCustomer){
            //El parametro de FirstOrDefault(p=>p.Id == int idCustomer)
            //se encarga de realiazar la busqueda
            return conexion.Customers.FirstOrDefault(p=>p.Id == idCustomer);
            //var pacienteEncontrado = conexion.Pacientes.FirstOrDefault(p=>p.Id==idPaciente);            
            //if (pacienteEncontrado != null){
            //    return pacienteEncontrado; 
            //}
        }

        public IEnumerable <Customer> consultCustomers(){
            //Retorna todo lo que tiene la consulta
            return conexion.Customers;
        }

        public Customer updateCustomer(Customer customer){

            var customerFound = conexion.Customers.FirstOrDefault(p=>p.Id == customer.Id);
            if (customerFound != null){
                //Actualizamos los atributos de la clase [Customer]
                 customerFound.Id = customer.Id;
                 customerFound.Name = customer.Name;
                 customerFound.Surname = customer.Surname;
                 customerFound.Age = customer.Age;
                 customerFound.Telephone = customer.Telephone;
                 customerFound.Address = customer.Address;
                 //Se debe modificar los datos de las relaciones que tiene la Clase [Customer]   
                 customerFound.Credential = customer.Credential;   
                 customerFound.Tracking   = customer.Tracking;
                 customerFound.Nutrition  = customer.Nutrition;
                 customerFound.Value      = customer.Value;
                 customerFound.Routine    = customer.Routine;

                 conexion.SaveChanges();
            }

            return customerFound;
        }

        public void deleteCustomer(int idCustomer){
          var customerFound = conexion.Customers.FirstOrDefault(p=>p.Id == idCustomer);
          if (customerFound == null) return; 
          
          conexion.Customers.Remove(customerFound);
          conexion.SaveChanges();  
        }

    }
}