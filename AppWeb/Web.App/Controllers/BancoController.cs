using Metrica.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.App.Helpers;
using Web.App.Models.Banco;

namespace Web.App.Controllers
{
    public class BancoController : BaseController
    {
        public async Task<IActionResult> Index()
        {

            var modelo = new BancoIndexModelo();
            modelo.bancos = await _bancoServicio.Listar();

            return View("_Index", modelo);
        }

        public IActionResult Nuevo()
        {
            var modelo = new BancoEditorModelo();
            return View("_Editor", modelo);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var modelo = new BancoEditorModelo();
            modelo.banco = await _bancoServicio.Obtener(id);
            return View("_Editor", modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Grabar(DtoBanco banco)
        {
            if (ModelState.IsValid)
            {
                if (banco.IdBanco == 0)
                    await _bancoServicio.Registrar(banco);
                else
                    await _bancoServicio.Actualizar(banco);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Ver(int id)
        {
            var modelo = new BancoEditorModelo();
            modelo.banco = await _bancoServicio.Obtener(id);
            return View("_Ver", modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(DtoBanco banco)
        {
            await _bancoServicio.Eliminar(banco);

            return RedirectToAction("Index");
        }
    }
}