using Newtonsoft.Json;
using System;

namespace WebAplication.Entities
{
    public class TipoEntidad
    {
        [JsonProperty("$id")]
        public string IdTipoEntidad { get; set; }
        [JsonProperty("Nombre")]
        public string Nombre { get; set; }
    }
}
