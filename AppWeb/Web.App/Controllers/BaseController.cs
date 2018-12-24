using Microsoft.AspNetCore.Mvc;
using Web.App.Helpers;

namespace Web.App.Controllers
{
    public class BaseController : Controller
    {
        public readonly BancoServicio _bancoServicio;
        public readonly EstadoPagoServicio _estadoPagoServicio;
        public readonly MonedaServicio _monedaServicio;
        public readonly OrdenPagoServicio _ordenPagoServicio;
        public readonly RolServicio _rolServicio;
        public readonly SucursalServicio _sucursalServicio;

        public BaseController()
        {
            _bancoServicio = new BancoServicio();
            _estadoPagoServicio = new EstadoPagoServicio();
            _monedaServicio = new MonedaServicio();
            _ordenPagoServicio = new OrdenPagoServicio();
            _rolServicio = new RolServicio();
            _sucursalServicio = new SucursalServicio();
        }

    }
}