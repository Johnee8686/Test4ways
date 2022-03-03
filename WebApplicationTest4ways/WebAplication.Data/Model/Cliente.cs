using Newtonsoft.Json;
using System;

namespace WebAplication.Entities
{
    public class Cliente
    {
        [JsonProperty("$id")]
        public string idCliente { get; set; }
        [JsonProperty("Nombre")]
        public string Nombre { get; set; }
        [JsonProperty("Pais")]
        public WebAplication.Core.Pais Pais { get; set; }
        [JsonProperty("TipoEntidad")]
        public WebAplication.Core.TipoEntidad TipoEntidad { get; set; }
    }
}
