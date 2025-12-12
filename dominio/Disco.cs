using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Disco
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El título es obligatorio.")]
        public string Titulo { get; set; }
        [DisplayName("Fecha de Lanzamiento")]
        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime FechaLanzamiento { get; set; } = DateTime.Now;
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser un número positivo.")]
        public int CantidadCanciones { get; set; } = 1;
        [DisplayName("Imagen")]
        public string UrlTapa { get; set; }
        public Estilo Estilo { get; set; }
        [DisplayName("Tipo de Edición")]
        public TipoEdicion TipoEdicion { get; set; }
    }
}
