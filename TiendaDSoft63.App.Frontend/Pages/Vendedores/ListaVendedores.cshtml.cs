using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TiendaDSoft63.App.Dominio;
using TiendaDSoft63.App.Persistencia;

namespace TiendaDSoft63.App.Frontend.Pages
{
    public class ListaVendedoresModel : PageModel
    {
        private static IRepositorioVendedor _repoVendedor = new RepositorioVendedor(new Persistencia.AppContext());
        public IEnumerable<Vendedor> listaVendedores {get; set;}

        public ListaVendedoresModel(IEnumerable<Vendedor> listaVendedores)
        {
            this.listaVendedores = listaVendedores;
        }
        public void OnGet()
        {
            listaVendedores = _repoVendedor.GetAllVendedores();
        }
    }
}
