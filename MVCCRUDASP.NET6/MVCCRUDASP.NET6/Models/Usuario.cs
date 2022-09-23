using System.ComponentModel.DataAnnotations;

namespace MVCCRUDASP.NET6.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public int Telefono { get; set; }
        [Required(ErrorMessage = "El celular es obligatorio")]
        public int Celular { get; set; }
        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; }
    }
}
