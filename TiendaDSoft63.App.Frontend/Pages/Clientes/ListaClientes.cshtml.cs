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
    public class ListaClientesModel : PageModel
    {
        private static IRepositorioCliente _repoCliente = new RepositorioCliente(new Persistencia.AppContext());

        public IEnumerable<Cliente> listaClientes {get; set;}

        public ListaClientesModel(IEnumerable<Cliente> listaClientes)
        {
            this.listaClientes = listaClientes;
        }
        public void OnGet()
        {
            listaClientes = _repoCliente.GetAllClientes();           
        }
    }
}
