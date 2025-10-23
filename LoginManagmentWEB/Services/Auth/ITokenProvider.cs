namespace LoginManagmentWEB.Services.Auth
{
    public interface ITokenProvider
    {
        string? Token { get; }
        Task LoadTokenAsync();
        Task SetTokenAsync(string token);

        string? GetUsernameFromToken();
        string? GetUserIdFromToken();
        string? GetRoleFromToken();

    }


}