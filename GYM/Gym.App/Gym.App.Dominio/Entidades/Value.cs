//Vamos a usar el paquete del sistema
using System;
//Definimos la capa a utilizar
namespace Gym.App.Dominio
{
    public class Value{
        //Definimos la funcionalidad de Propiedades, usando la
        //notacion Pascal (1mer caracter del atributo en Mayuscula)
        public int Id {get; set;}
        public int Weight {get; set;}
        public int Size {get; set;}
        public Gender Gender {get; set;}
        public string Recommendation {get; set;}  
    }
}