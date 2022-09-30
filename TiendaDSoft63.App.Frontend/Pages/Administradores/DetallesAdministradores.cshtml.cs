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
    public class DetallesAdministradoresModel : PageModel
    {
        private static IRepositorioAdministrador _repoAdministrador = new RepositorioAdministrador(new Persistencia.AppContext());
        public IEnumerable<Administrador> listaAdministradores {get; set;}

        public DetallesAdministradoresModel(IEnumerable<Administrador> listaAdministradores)
        {
            this.listaAdministradores = listaAdministradores;
        }

        public void OnGet()
        {
            listaAdministradores = _repoAdministrador.GetAllAdministradores();
        }
        
    }
}
