namespace UserService.Api.Controllers.User.Models;

public record RequestUserModel(string FirstName, string LastName, string Email, string Password);