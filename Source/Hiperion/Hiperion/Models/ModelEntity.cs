namespace Hiperion.Models
{
    #region References

    using Newtonsoft.Json;

    #endregion

    public class ModelEntity
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}