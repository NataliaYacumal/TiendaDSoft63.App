using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TiendaDSoft63.App.Dominio;

namespace TiendaDSoft63.App.Persistencia
{
    public interface IRepositorioVendedor
    {
        IEnumerable<Vendedor> GetAllVendedores();
        Vendedor AddVendedor(Vendedor vendedor);
        Vendedor UpdateVendedor(Vendedor vendedor);
        void DeleteVendedor(int idVendedor);
        Vendedor GetVendedor(int idVendedor);
        IEnumerable<Vendedor> GetVendedorPorFiltro(string filtro);
    }
}