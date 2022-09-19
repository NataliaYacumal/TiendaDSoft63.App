using System;

namespace TiendaDSoft63.App.Dominio{
    
    //Modela una persona en el sistema
    public class Persona{

        //Identificador único de cada persona
        public int Id {get; set;}
        //Nombre completo de Persona
        public string Nombre {get; set;}
        //Dirección de residencia de Persona        
        public string Email {get; set;}
        //Tipo de documento
        public Documento Documentos {get; set;}
        //Genero de Persona
        public Genero Generos {get; set;}
        //Teléfono de Persona
        public int Telefono {get; set;}        
    }    
}