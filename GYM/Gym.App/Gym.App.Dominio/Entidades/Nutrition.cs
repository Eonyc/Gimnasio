//Vamos a usar el paquete del sistema
using System;
//Definimos la capa a utilizar
namespace Gym.App.Dominio
{
    public  class Nutrition{
        //Definimos la funcionalidad de Propiedades, usando la
        //notacion Pascal (1mer caracter del atributo en Mayuscula)
        public int Id {get; set;}
        public string Name {get; set;}
        public TypeOfEat Eat {get; set;}
        public int NumberOfDays {get; set;}
        public string Menu {get; set;}
    } 
}