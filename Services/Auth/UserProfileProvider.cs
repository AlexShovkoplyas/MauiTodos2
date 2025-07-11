namespace MauiTodos2.Services.Auth;
public class UserProfileProvider
{
    public ProfileData Profile { get; set; }

}

public class ProfileData
{
    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public string? Image { get; set; }

    public string DisplayName => (FirstName + " " ?? string.Empty) + (LastName + " " ?? string.Empty);
}
