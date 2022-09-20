//Vamos a usar el paquete del sistema
using System;
//Definimos la capa a utilizar
namespace Gym.App.Dominio
{
    public  class Nutrition{
        //Definimos la funcionalidad de Propiedades, usando la
        //notacion Pascal (1mer caracter del atributo en Mayuscula)
        public int Id {get; set;}
        public TypeOfEat Eat {get; set;}
        public int NumberOfDays {get; set;}
        //Definimos las relaciones de ASOCIACION
        //Clase  Nutrition --> Diet 
        //Esta es la forma de hacer un <maestro-detalle> del [MER] en el modelo Entidad
        //que estamos implemetando
        public System.Collections.Generic.List<Diet> Diets {get; set;} 
    } 
}