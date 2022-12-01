using Application.Commands;
using Application.Interfaces;
using Application.Queries;
using Application.Results;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Contracts;
using UserManagement.Mapping;

namespace UserManagement.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IUserManager _userManager;

    public UserController(IUserManager userManager)
    {
        _userManager = userManager;
    }

    // TODO: See if HttpResponseMessage.ReasonPhrase is sent from server
    
    [HttpPost]
    public async Task<IActionResult> Register(UserRegisterRequest request)
    {
        try
        {
            UserRegisterCommand command = new(request.FirstName, request.LastName, request.UserName, request.Password);
            UserRegisterResult result = await _userManager.RegisterUser(command);
            return Ok(result.ToResponse());
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet]
    public async Task<IActionResult> LogIn(UserLogInRequest request)
    {
        try
        {
            UserLogInQuery query = new(request.UserName, request.Password);
            UserLogInResult result = await _userManager.LogInUser(query);
            return Ok(result.ToResponse());
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}