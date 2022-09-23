using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TiendaDSoft63.App.Dominio;
using TiendaDSoft63.App.Persistencia;

namespace TiendaDSoft63.App.Frontend.Pages
{
    public class ListaAdminModel : PageModel
    {
        private readonly IRepositorioAdministrador  repositorioAdministrador;
        public IEnumerable<Administrador> listaAdministradores {get; set;}

        public ListaAdminModel()
        {
            this.repositorioAdministrador = new RepositorioAdministrador(new TiendaDSoft63.App.Persistencia.AppContext);
        }

        
        public void OnGet()
        {
            listaAdministradores = repositorioAdministrador.GetAllAdministradores();
        }
    }
}
