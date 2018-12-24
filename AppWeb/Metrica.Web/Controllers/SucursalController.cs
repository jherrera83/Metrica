using Metrica.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Metrica.Web.Models.Sucursal;

namespace Metrica.Web.Controllers
{
    public class SucursalController : BaseController
    {
        public async Task<IActionResult> Index()
        {

            var modelo = new SucursalIndexModelo();
            modelo.sucursales = await _sucursalServicio.Listar();

            return View("_Index", modelo);
        }

        public async Task<IActionResult> Nuevo()
        {
            var modelo = new SucursalEditorModelo();
            modelo.bancos = await _bancoServicio.Listar();
            return View("_Editor", modelo);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var modelo = new SucursalEditorModelo();
            modelo.bancos = await _bancoServicio.Listar();
            modelo.sucursal = await _sucursalServicio.Obtener(id);
            return View("_Editor", modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Grabar(DtoSucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                if (sucursal.IdSucursal == 0)
                    await _sucursalServicio.Registrar(sucursal);
                else
                    await _sucursalServicio.Actualizar(sucursal);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Ver(int id)
        {
            var modelo = new SucursalEditorModelo();
            modelo.bancos = await _bancoServicio.Listar();
            modelo.sucursal = await _sucursalServicio.Obtener(id);
            return View("_Ver", modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(DtoSucursal Sucursal)
        {
            await _sucursalServicio.Eliminar(Sucursal);

            return RedirectToAction("Index");
        }
    }
}