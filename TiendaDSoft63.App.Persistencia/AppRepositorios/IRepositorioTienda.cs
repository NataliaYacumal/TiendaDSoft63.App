using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TiendaDSoft63.App.Dominio;

namespace TiendaDSoft63.App.Persistencia
{
    public interface IRepositorioTienda
    {
        IEnumerable<Tienda> GetAllTiendas();
        Tienda AddTienda(Tienda tienda);
        Tienda UpdateTienda(Tienda tienda);
        void DeleteTienda(int idTienda);
        Tienda GetTienda(int idTienda);
        IEnumerable<Tienda> GetTiendaPorFiltro(string filtro);
    }
}