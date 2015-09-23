namespace UI.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProductoInputModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "La categoria es obligatoria")]
        public string Categoria { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El tipo es obligatorio")]
        public string Tipo { get; set; }
    }
}