using Gym.App.Dominio;
//Para manejar la BD
using System.Linq;
//IEnumerable
using System.Collections.Generic;

namespace Gym.App.Persistencia
{
    public class RepositorioCredential:IRepositorioCredential{
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
        public Credential createCredential(Credential credential){
            //Realiza la conexion a la BD y adiciona a la tabla
            //[Credentials] los datos del obj [credential]
            var credentialAdded = conexion.Credentials.Add(credential);
            conexion.SaveChanges();
            //retorna la variable encapsulada como un objeto [Entity]
            return credentialAdded.Entity; 
        }
        public Credential consultCredential(int idCredential){
            //El parametro de FirstOrDefault(p=>p.Id == int idCredential)
            //se encarga de realiazar la busqueda
            return conexion.Credentials.FirstOrDefault(p=>p.Id == idCredential);
        }
        public IEnumerable <Credential> consultCredentials(){
            //Retorna todo lo que tiene la consulta
            return conexion.Credentials;
        }
        public Credential updateCredential(Credential credential){
            var credentialFound = conexion.Credentials.FirstOrDefault(p=>p.Id == credential.Id);
            if (credentialFound != null){
                //Actualizamos los atributos de la clase [Credential]
                 credentialFound.Id = credential.Id;
                 credentialFound.Email = credential.Email;
                 credentialFound.Password = credential.Password;
                 //Se debe modificar los datos de las relaciones que tiene la Clase [Credential]   
                 //customerFound.Credential = customer.Credential;   
                 conexion.SaveChanges();
            }
            return credentialFound;
        }
        public void deleteCredential(int idCredential){
            var credentialFound = conexion.Credentials.FirstOrDefault(p=>p.Id == idCredential);
            if (credentialFound == null) return; 
          
            conexion.Credentials.Remove(credentialFound);
            conexion.SaveChanges();  
        }
    }
}