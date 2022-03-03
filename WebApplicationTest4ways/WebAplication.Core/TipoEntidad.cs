using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAplication.Core
{
    public class TipoEntidad
    {
        [Key]
        public int IdTipoEntidad { get; set; }
        public string Nombre { get; set; }   

    }
}
