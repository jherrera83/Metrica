using System.ComponentModel.DataAnnotations;

namespace Metrica.Dto
{
    public class DtoBanco
    {
        public int IdBanco { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        
    }
}