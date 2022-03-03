using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAplication.Core;

namespace WebApplicationTest4ways.Models.Cliente
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
        }
        
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Pais es requerido")]
        public int IdPais { get; set; }

        [Required(ErrorMessage = "El Fabricante es requerido")]
        public int IdTipoEntidad { get; set; }

        public List<SelectListItem> Paises { get; set; }
        public List<SelectListItem> TipoEntidades { get; set; }
        public List<WebAplication.Entities.Cliente> Clientes { get; set; }
    }
}
