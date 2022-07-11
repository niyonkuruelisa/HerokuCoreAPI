using System.Text.Json.Serialization;

namespace HerokuCoreAPI.Models
{
    public class Result
    {
        [JsonPropertyName("resultId")]
        public int ResultId { get; set; }

        [JsonPropertyName("profileId")]
        public int ProfileId { get; set; }

        [JsonPropertyName("profileName")]
        public string ProfileName { get; set; } = string.Empty;

        [JsonPropertyName("resourceId")]
        public int ResourceId { get; set; }

        [JsonPropertyName("resourceName")]
        public string ResourceName { get; set; } = string.Empty;

        [JsonPropertyName("tyoeId")]
        public int TyoeId { get; set; }

        [JsonPropertyName("typeName")]
        public string TypeName { get; set; } = string.Empty;

        [JsonPropertyName("statusId")]
        public int StatusId { get; set; }

        [JsonPropertyName("statusName")]
        public string StatusName { get; set; } = string.Empty;

        [JsonPropertyName("started")]
        public string Started { get; set; } = string.Empty;

        [JsonPropertyName("changed")]
        public string Changed { get; set; } = string.Empty;

        [JsonPropertyName("resultIdduration")]
        public int ResultIdduration { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("points")]
        public int Points { get; set; }

        [JsonPropertyName("streamId")]
        public string StreamId { get; set; } = string.Empty;

        [JsonPropertyName("streamName")]
        public string StreamName { get; set; } = string.Empty;

        [JsonPropertyName("isMarket")]
        public bool IsMarket { get; set; }
    }
}
