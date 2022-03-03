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
        public Pais Pais { get; set; }
        [JsonProperty("TipoEntidad")]
        public TipoEntidad TipoEntidad { get; set; }
    }
}
