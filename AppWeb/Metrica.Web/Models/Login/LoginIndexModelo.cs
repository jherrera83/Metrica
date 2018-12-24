using Metrica.Dto;
using System.Collections.Generic;

namespace Metrica.Web.Models.Login
{
    public class LoginIndexModelo
    {
        public IEnumerable<DtoRol> roles { get; set; }
        public DtoRol rol { get; set; }
    }
}