using System;

namespace TiendaDSoft63.App.Dominio{

    //Modela el Administrador del sistema
    public class Administrador: Persona{
        //Nombre de usuario en el sistema
        public string Usuario {get; set;}
        //Contraseña en el sistema
        public string contrasenna {get; set;}
        //Fecha de vinculación en la Tienda
        public DateTime FechaVinculación {get;set;}
        //Relación entre el Administrador y la tienda
        public Tienda Tiendas {get;set;}
    }
}