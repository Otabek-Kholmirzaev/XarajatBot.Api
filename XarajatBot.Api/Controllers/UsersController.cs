using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XarajatBot.Api.Models;

namespace XarajatBot.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpGet]
    public string GetUsers() => "All Users..";

    [HttpGet("{id:int}")]
    public UserModel GetUserById(int id) => new UserModel {Id = id, Name = "name1"};

    [HttpGet("sorted")]
    public string SortedUsers()
    {
        return "get sorted users..";
    }

    [HttpPost]
    public string AddUser()
    {
        return "User added..";
    }

    [HttpPut("{id:int}")]
    public string UpdateUser(int id)
    {
        return "User updated..";
    }

    [HttpDelete("{id:int}")]
    public string DeleteUser(int id)
    {
        return "User deleted..";
    }

}