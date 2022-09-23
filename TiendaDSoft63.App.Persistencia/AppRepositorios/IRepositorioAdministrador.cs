using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TiendaDSoft63.App.Dominio;

namespace TiendaDSoft63.App.Persistencia
{
    public interface IRepositorioAdministrador
    {
        IEnumerable<Administrador> GetAllAdministradores();
        Administrador AddAdministrador(Administrador administrador);
        Administrador UpdateAdministrador(Administrador administrador);
        void DeleteAdministrador(int idAdministrador);
        Administrador GetAdministrador(int idAdministrador);
        IEnumerable<Administrador> GetAdministradorPorFiltro(string filtro);
    }
}