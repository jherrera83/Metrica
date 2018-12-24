using Metrica.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Metrica.Web.Models.OrdenPago;

namespace Metrica.Web.Controllers
{
    public class OrdenPagoController : BaseController
    {

        public async Task<IActionResult> Index()
        {

            var modelo = new OrdenPagoIndexModelo();
            modelo.ordenesPago = await _ordenPagoServicio.Listar();

            return View("_Index", modelo);
        }

        public async Task<IActionResult> Seleccione()
        {
            var modelo = new OrdenPagoSeleccioneModelo();
            modelo.bancos = await _bancoServicio.Listar();
            return View("_Seleccione", modelo);
        }

        public async Task<IActionResult> Nuevo(int id)
        {
            var modelo = new OrdenPagoEditorModelo();
            modelo.bancos = await _bancoServicio.Listar();
            modelo.sucursales = await _sucursalServicio.ListarPorBanco(id);
            modelo.monedas = await _monedaServicio.Listar();
            modelo.estadosPago = await _estadoPagoServicio.Listar();
            modelo.ordenPago = new DtoOrdenPago();
            modelo.ordenPago.IdBanco = id;
            return View("_Editor", modelo);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var modelo = new OrdenPagoEditorModelo();
            modelo.ordenPago = await _ordenPagoServicio.Obtener(id);
            modelo.bancos = await _bancoServicio.Listar();
            modelo.sucursales = await _sucursalServicio.ListarPorBanco(modelo.ordenPago.IdBanco);
            modelo.monedas = await _monedaServicio.Listar();
            modelo.estadosPago = await _estadoPagoServicio.Listar();
            return View("_Editor", modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Grabar(DtoOrdenPago OrdenPago)
        {
            if (ModelState.IsValid)
            {
                if (OrdenPago.IdOrdenPago == 0)
                    await _ordenPagoServicio.Registrar(OrdenPago);
                else
                    await _ordenPagoServicio.Actualizar(OrdenPago);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Ver(int id)
        {
            var modelo = new OrdenPagoEditorModelo();
            modelo.ordenPago = await _ordenPagoServicio.Obtener(id);

            return View("_Ver", modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(DtoOrdenPago OrdenPago)
        {
            await _ordenPagoServicio.Eliminar(OrdenPago);

            return RedirectToAction("Index");
        }
    }
}