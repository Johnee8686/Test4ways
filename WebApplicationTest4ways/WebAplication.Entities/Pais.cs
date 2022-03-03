using Newtonsoft.Json;
using System;

namespace WebAplication.Entities
{
    public class Pais
    {
        [JsonProperty("$id")]
        public string IdPais { get; set; }
        [JsonProperty("Nombre")]
        public string Nombre { get; set; }
    }
}
