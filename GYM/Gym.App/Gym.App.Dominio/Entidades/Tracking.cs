//Vamos a usar el paquete del sistema
using System;
//Definimos la capa a utilizar
namespace Gym.App.Dominio
{
    public class Tracking{
        //Definimos la funcionalidad de Propiedades, usando la
        //notacion Pascal (1mer caracter del atributo en Mayuscula)
        public int Id {get; set;}
        public DateTime TrackingDate {get; set;}
        public string State {get; set;} 
    } 
}