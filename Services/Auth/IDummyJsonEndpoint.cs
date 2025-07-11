using System.Text.Json.Serialization;
using Refit;

namespace MauiTodos2.Services.Auth;

[Headers("Content-Type: application/json")]
public interface IDummyJsonEndpoint
{
    [Post("/auth/login")]
    Task<AuthResponse> Login(Credentials credentials, CancellationToken ct);
}

public class Credentials
{
    [JsonPropertyName("username")]
    public string? Username { get; init; }
    [JsonPropertyName("password")]
    public string? Password { get; init; }
}

public class AuthResponse
{
    [JsonPropertyName("accessToken")]
    public string? AccessToken { get; set; }

    [JsonPropertyName("refreshToken")]
    public string? RefreshToken { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    [JsonPropertyName("gender")]
    public string? Gender { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }
}
