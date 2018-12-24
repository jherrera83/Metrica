using Metrica.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Metrica.Web.Models.Login;

namespace Metrica.Web.Controllers
{
    public class LoginController : BaseController
    {
      
        public async Task<IActionResult> Index()
        {
            var modelo = new LoginIndexModelo();
            modelo.roles = await _rolServicio.Listar();
            modelo.rol = new DtoRol();
            return View("_Index", modelo);
        }

        public IActionResult Login(DtoRol rol)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}