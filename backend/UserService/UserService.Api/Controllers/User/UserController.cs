using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Api.Controllers.User.Models;
using UserService.Application.Users.RegisterUser;

//using Asp.Versioning;

namespace UserService.Api.Controllers.User;

[ApiController]
//[ApiVersion(1.0)]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ISender _sender;

    public UserController(ISender sender)
    {
        _sender = sender;
    }

    public async Task<IActionResult> RegisterUser(RequestUserModel model) //TODO: need to clean up controller and add mapper
    {
        if (ModelState.IsValid)
        {
            var command = new RegisterUserCommand(model.FirstName, model.LastName, model.Email, model.Password);
            var result = await _sender.Send(command);
        }

        return Ok(1); 
    }
}