//Vamos a usar el paquete del sistema
using System;
//Definimos la capa a utilizar
namespace Gym.App.Dominio
{
    public class Exercise{
        //Definimos la funcionalidad de Propiedades, usando la
        //notacion Pascal (1mer caracter del atributo en Mayuscula).
        public int Id {get; set;}
        public string Name {get; set;}         
        public string Series {get; set;}
        public string Repetitions {get; set;}
        public string CaloriesConsumed {get; set;}
    }
}