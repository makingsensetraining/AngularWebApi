namespace Hiperion.Models
{
    #region References

    using Newtonsoft.Json;

    #endregion

    public class RoleDto : ModelEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}