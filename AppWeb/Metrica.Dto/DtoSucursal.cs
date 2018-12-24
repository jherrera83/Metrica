using System.ComponentModel.DataAnnotations;

namespace Metrica.Dto
{
    public class DtoSucursal
    {
        public int IdSucursal { get; set; }
        [Required]
        public int IdBanco { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        public string NombreBanco { get; set; }
    }
}
