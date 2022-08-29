//Vamos a usar el paquete del sistema
using System;
//Definimos la capa a utilizar
namespace Gym.App.Dominio
{
    public class Customer{
        //Definimos la funcionalidad de Propiedades, usando la
        //notacion Pascal (1mer caracter del atributo en Mayuscula).
        public int Id {get; set;}
        public string Name {get; set;} 
        public string Surname {get; set;}
        public int Age {get; set;}
        public string Telephone {get; set;}
        public string Address {get; set;} 
        //Definimos las relaciones de ASOCIACION
        //Clase Customer --> Credential 
        public Credential Credential {get; set;}
        //Clase  Customer --> Tracking
        public Tracking Tracking {get; set;}
        //Clase  Customer --> Nutrition
        public Nutrition Nutrition {get; set;}
        //Clase  Customer --> Value
        public Nutrition Value {get; set;}
        //Clase  Customer --> Routine
        public Nutrition Routine {get; set;}
    } 
}    