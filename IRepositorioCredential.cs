using Gym.App.Dominio; 
using System.Collections.Generic;

namespace Gym.App.Persistencia
{
    //En esta clase solo incluimos las firmas de los metodos
    public interface IRepositorioCredential{
        //Compromisos, Lista de metodos a implementar
        //C = Crear
        Credential createCredential(Credential credential);
        //R = Consultar
        Credential consultCredential(int idCredential);
        //Tenemos un objeto Enumerable que es una lst
        //Extraemos todos los datos de la tabla [Credentials]
        IEnumerable <Credential> consultCredentials();
        //U = Actualizar
        Credential updateCredential(Credential credential);
        //D = Eliminar
        void deleteCredential(int idCredential);        
    }
}