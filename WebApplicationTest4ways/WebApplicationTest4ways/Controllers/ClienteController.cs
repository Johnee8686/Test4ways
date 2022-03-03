
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using WebAplication.Core;
using WebApplicationTest4ways.Models.Cliente;

namespace WebApplicationTest4ways.Controllers
{
    //..[SessionTimeoutAttribute]
    public class ClienteController : Controller
    {
        private readonly IClienteData clientedata;
        private readonly IPaisData paisdata;
        private readonly ITipoEntidadData tipoEntidaddata;
        public ClienteController(IClienteData clientedata, IPaisData paisdata, ITipoEntidadData tipoEntidaddata)
        {
            this.clientedata = clientedata;
            this.paisdata = paisdata;
            this.tipoEntidaddata = tipoEntidaddata;
        }
        public IActionResult Index()
        {
            ClienteViewModel vm = new ClienteViewModel();

            vm.Paises = paisdata.GetPaises().ToList().ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Nombre,
                    Value = a.IdPais.ToString(),
                    Selected = false
                };
            });

            vm.TipoEntidades = tipoEntidaddata.GetTipoEntidades().ToList().ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Nombre,
                    Value = a.IdTipoEntidad.ToString(),
                    Selected = false
                };
            });

            vm.Clientes = clientedata.GetClientes().ToList().Select((x, index) =>
                      new WebAplication.Entities.Cliente { 
                          idCliente = x.IdCliente.ToString(),
                          Nombre = x.Nombre, 
                          Pais = paisdata.GetPais(x.IdPais).Result,
                          TipoEntidad = tipoEntidaddata.GetTipoEntidad(x.IdTipoEntidad).Result,
                      }).ToList();

            return View(vm);
        }

        public async Task<IActionResult> crearCliente(                   
                     string Nombre
                   , int IdtipoEntidad
                   , int Idpais)
        {
            try
            {
                Cliente cliente = new Cliente { Nombre = Nombre, IdTipoEntidad = IdtipoEntidad, IdPais = Idpais};
                await clientedata.NewCliente(cliente);
                string str = $@"<h1>Sucessfull</h1>";

                return Json(str);
            }
            catch (Exception err)
            {
                return Json(err.ToString());
            }
        }
        public async Task<IActionResult> deleteCliente(int IdCliente)
        {
            try
            {
                await clientedata.Delete(IdCliente);
                string str = $@"<h1>Sucessfull</h1>";

                return Json(str);
            }
            catch (Exception err)
            {
                return Json(err.ToString());
            }
        }
    }
}
