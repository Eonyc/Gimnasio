//Vamos a usar el paquete del sistema
using System;
using System.Collections.Generic;

//Definimos la capa a utilizar
namespace Gym.App.Dominio
{
    public class Routine{
        //Definimos la funcionalidad de Propiedades, usando la
        //notacion Pascal (1mer caracter del atributo en Mayuscula)
        public int Id {get; set;}
        public BodyPart  BodyPart {get; set;}
        public Intensity Intensity {get; set;}
        public Category Category {get; set;}
        public Level Level {get; set;}
        public int Duration {get; set;}
        //Definimos las relaciones de ASOCIACION
        //Clase Routine --> Exercise 
        //Esta es la forma de hacer un <maestro-detalle> del [MER] en el modelo Entidad
        //que estamos implemetando
        public System.Collections.Generic.List<Exercise> Exercise {get; set;}           
    } 
}