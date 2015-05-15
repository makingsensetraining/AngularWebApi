namespace Hiperion.Models
{
    using Newtonsoft.Json;

    public class RoleDto : ModelEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}