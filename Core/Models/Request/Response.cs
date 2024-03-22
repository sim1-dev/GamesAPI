
using Newtonsoft.Json;

namespace GamesAPI.Core.Models;

public class Response {
    [JsonProperty(PropertyName = "success")]
    public bool Success { get; set; }

    [JsonProperty(PropertyName = "message")]
    public string? Message { get; set; } = "";

    [JsonProperty(PropertyName = "data")]
    public object? Data { get; set; }
}